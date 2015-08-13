/****************************************************************
 * Class:         Cutting                                       *
 * Author:        Amor Daniel                                   *
 * Description:   Cut a task from a class compilated on the fly *
 * Date:          23 may 2011                                   *
****************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.CodeDom.Compiler;

namespace DistributedComputing
{
    class Cutting
    {
        object myobj = null;
        MethodInfo calculate;
        Type ObjType;
        CodeDomProvider cp;
        CompilerParameters cpar;
        CompilerResults cr;
        /// <summary>
        /// Compilation from a class file
        /// </summary>
        /// <param name="src">Class file</param>
        public bool LoadSource(string src)
        {
            try
            {
                cp = CodeDomProvider.CreateProvider("C#");
                cpar = new CompilerParameters();
                cpar.GenerateInMemory = true;
                cpar.GenerateExecutable = false;
                cpar.ReferencedAssemblies.Add("system.dll");

                // Compilation and error managment
                cr = cp.CompileAssemblyFromSource(cpar, src);
                ObjType = cr.CompiledAssembly.GetType("CuttingTask");
                myobj = Activator.CreateInstance(ObjType);
                calculate = myobj.GetType().GetMethod("CutTask");
                return true;
            }
            catch { return false; }
        }
        /// <summary>
        /// Cut the task
        /// </summary>
        /// <param name="NbrPackets">Number of packets</param>
        /// <returns>A array of packet who contain an array with data</returns>
        public byte[][] CuttingTask(int NbrPackets)
        {
            byte[][] result = null;
            object[] obj = new object[1] { NbrPackets };
            try
            {
                result = (byte[][])calculate.Invoke(myobj, obj); //Cut the task with the instance of the class on the fly

            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return result;
        }
    }
}
