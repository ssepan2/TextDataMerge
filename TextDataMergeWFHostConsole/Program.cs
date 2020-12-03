using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Workflow.Runtime;
using Ssepan.Utility;
using System.Threading;
using System.Diagnostics;
using System.Reflection;

namespace TextDataMergeWFHostConsole
{
    class Program
    {
        #region Declarations

        private static AutoResetEvent waitHandle;
        private static String paramWorkflow = String.Empty;
        #endregion Declarations

        static Int32 Main(String[] args)
        {
            Int32 returnValue = -1;
            try
            {
                //Run library
                Console.WriteLine("starting library workflow");
                using (WorkflowRuntime runtime = new WorkflowRuntime())
                {
                    waitHandle = new AutoResetEvent(false);

                    runtime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(runtime_WorkflowCompleted);
                    runtime.WorkflowTerminated += new EventHandler<WorkflowTerminatedEventArgs>(runtime_WorkflowTerminated);

                    //create workflow instance
                    WorkflowInstance instance = runtime.CreateWorkflow(typeof(TextDataMergeWFLibrary.TextDataMergeWorkflow));

                    //start the workflow instance
                    instance.Start();

                    waitHandle.WaitOne();
                }
                Console.WriteLine("completing library workflow");

                //Run activities
                Console.WriteLine("starting activity workflow");
                using (WorkflowRuntime runtime = new WorkflowRuntime())
                {
                    waitHandle = new AutoResetEvent(false);

                    runtime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(runtime_WorkflowCompleted);
                    runtime.WorkflowTerminated += new EventHandler<WorkflowTerminatedEventArgs>(runtime_WorkflowTerminated);

                    //create workflow instance
                    WorkflowInstance instance = runtime.CreateWorkflow(typeof(TextDataMergeWFLibrary.TextDataFunctionActivityWorkflow));

                    //start the workflow instance
                    instance.Start();

                    waitHandle.WaitOne();
                }
                Console.WriteLine("completing activity workflow");

                returnValue = 0;
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                Console.WriteLine(String.Format("Workflow failed or did not start. Workflow selected was: {0}", paramWorkflow));

                //throw;
            }
            finally
            {
#if debug
                Console.Write("Press ENTER to continue> ");
                Console.ReadLine();
#endif
            }
            return returnValue;
        }

        static void runtime_WorkflowTerminated(Object sender, WorkflowTerminatedEventArgs e)
        {
            Console.WriteLine("workflow {0} terminated because {1}.", e.WorkflowInstance.InstanceId.ToString(), e.Exception.Message);
            waitHandle.Set();
        }

        static void runtime_WorkflowCompleted(Object sender, WorkflowCompletedEventArgs e)
        {
            Console.WriteLine("workflow {0} completed.", e.WorkflowInstance.InstanceId.ToString());
            waitHandle.Set();
        }
    }
}
