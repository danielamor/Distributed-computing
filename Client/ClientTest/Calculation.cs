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
using System.Security.AccessControl;
using System.ComponentModel;
using System.Threading;

namespace ClientTest
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
        public delegate void finished(List<Task> listResult);
        public event finished OnFinished;
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
        public void Calculate(List<Task> listTasks)
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

            foreach (Task item in listTasks) //Load task to each core
            {
                listTaskEachCore[core++].Add(new ThreadData(item.noPacket, item.data, null,item.secondSince1970,item.issueNumber));
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
            lock (lockThis)
            {
                listBool.Add(true);
                if (listBool.Count == nbrThread)
                {
                    List<Task> listResults = new List<Task>();
                    foreach (int key in listTaskEachCore.Keys)
                    {
                        foreach (ThreadData data in listTaskEachCore[key])
                        {
                            listResults.Add(new Task(data.noPacket, data.result,data.secondSince1970,data.issueNumber));
                        }
                    }
                    if (OnFinished != null)
                    {
                        OnFinished(listResults);
                        foreach (Thread item in listThread) //Stop all threads
                        {
                            item.Abort();
                            item.Join();
                        }
                    }
                }
            }
        }

        void doWork(object sender)
        {
            List<ThreadData> listTask = (List<ThreadData>)sender;
            foreach (ThreadData item in listTask)
            {
                object[] obj = new object[1] { item.data };
                try
                {                    
                    item.result = (byte[])calculate.Invoke(myobj, obj);
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                }
            }
            threadWorkCompleted();
        }     
    }
}
