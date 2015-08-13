/****************************************************************
 * Class:         Calculation                                   *
 * Author:        Amor Daniel                                   *
 * Description:   Calculate a task from a class compilated      *
 *                on the fly                                    *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.CodeDom.Compiler;
using System.Reflection;
using System.CodeDom;
using System.ComponentModel;
using System.Threading;

namespace DistributedComputing
{
    class Calculation
    {
        object myobj = null;
        int nbrThread;
        MethodInfo calculate;
        Type ObjType;
        CodeDomProvider cp;
        CompilerParameters cpar;
        CompilerResults cr;
        List<Thread> listThread;
        Dictionary<int, List<ThreadData>> listTaskEachCore;
        private object lockThis = new object();
        List<bool> listBool;
        /*Event when work is done*/
        public delegate void finished(SortedList<int, byte[]> listResult);
        public event finished OnFinished;
        /// <summary>
        /// Compilation of a string
        /// </summary>
        /// <param name="src">A string with a class to compile</param>
        /// <returns>Compilable?</returns>
        public bool LoadSource(string src)
        {
            try
            {
                cp = CodeDomProvider.CreateProvider("C#");
                cpar = new CompilerParameters();

                cpar.TempFiles = new TempFileCollection(".", false);
                cpar.GenerateInMemory = true;
                cpar.GenerateExecutable = false;
                cpar.ReferencedAssemblies.Add("system.dll");

                // Compilation and error managment
                cr = cp.CompileAssemblyFromSource(cpar, src);
                ObjType = cr.CompiledAssembly.GetType("ClassCalculator");
                myobj = Activator.CreateInstance(ObjType);
                calculate = myobj.GetType().GetMethod("Calculate");
                return true;
            }
            catch { return false; }
        }
        /// <summary>
        /// Calculate a byte[] with the instance of compiled string class
        /// </summary>
        /// <param name="listTasks">List of task to calculate</param>
        public void Calculate(SortedList<int, byte[]> listTasks)
        {
            listBool = new List<bool>();
            listThread = new List<Thread>();
            listTaskEachCore = new Dictionary<int, List<ThreadData>>();
            nbrThread = Environment.ProcessorCount;
            int core = 0;
            if (!(listTasks.Count > Environment.ProcessorCount)) //Number task lower than nbcore?
                nbrThread = listTasks.Count;
            for (int i = 0; i < nbrThread; i++) //Load listTaskEachCore
            {
                listTaskEachCore.Add(i, new List<ThreadData>());
            }

            foreach (int item in listTasks.Keys) //Load task to each core
            {
                listTaskEachCore[core++].Add(new ThreadData(item, listTasks[item], null));
                core = core == nbrThread ? 0 : core;
            }

            for (int i = 0; i < nbrThread; i++) //Start threads
            {
                Thread thread = new Thread(new ParameterizedThreadStart(doWork));
                thread.IsBackground = true;
                thread.Priority = ThreadPriority.Lowest;
                listThread.Add(thread);
                thread.Start((object)listTaskEachCore[i]);
            }
        }

        void threadWorkCompleted()
        {
            lock (lockThis) //Thread safe code
            {
                listBool.Add(true); 
                if (listBool.Count == nbrThread) //All thread finished?
                {
                    SortedList<int, byte[]> listResults = new SortedList<int, byte[]>();
                    foreach (int key in listTaskEachCore.Keys) //Get each core
                    {
                        foreach (ThreadData data in listTaskEachCore[key]) //Get each packet of this core
                        {
                            listResults.Add(data.noPacket, data.result); //Add all result of all threads in same list
                        }
                    }
                    if (OnFinished != null)
                    {
                        OnFinished(listResults); //Return results
                        foreach (Thread item in listThread) //Stop all threads
                        {
                            item.Abort();
                            item.Join();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Method for thread calculation
        /// </summary>
        /// <param name="sender">Packets to calculate</param>
        void doWork(object sender)
        {
            List<ThreadData> listTask = (List<ThreadData>)sender;
            foreach (ThreadData item in listTask) //Each packet to calculate
            {
                object[] obj = new object[1] { item.data };
                try
                {
                    item.result = (byte[])calculate.Invoke(myobj, obj); //Calculate with the instance of the class on the fly
                }
                catch { }
            }
            threadWorkCompleted(); //Finish all works
        }   
    }
}
