using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Ssepan.Application;
using Ssepan.Collections;
using Ssepan.Utility;
using TextDataMergeLibrary;

namespace TextDataMergeConsole
{
    //Note: wasn't static originally; changed to match winforms
    static class Program
    {
        #region Declarations
        public const String APP_NAME = "TextDataMergeConsole";

        private const String AllowedFunctionSwitches = "cfms";
        private const String FunctionsHelpText = "Function...\r\n\t\tc\tCollate\r\n\t\tf\tFilter\r\n\t\tm\tMerge\r\n\t\ts\tSort";
        private const String SettingsHelpText = "Settings file...\r\n\t\tFile path of .textdatamerge file with settings for function.";
        #endregion Declarations

        #region INotifyPropertyChanged
        public static event PropertyChangedEventHandler PropertyChanged;
        public static void OnPropertyChanged(String propertyName)
        {
            try
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(null, new PropertyChangedEventArgs(propertyName));
                }

            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                throw;
            }
        }
        #endregion INotifyPropertyChanged

        #region PropertyChangedEventHandlerDelegate
        /// <summary>
        /// Note: property changes update UI manually.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void PropertyChangedEventHandlerDelegate
        (
            Object sender,
            PropertyChangedEventArgs e
        )
        {
            try
            {
                if (e.PropertyName == "Filename")
                {
                    ConsoleApplication.defaultOutputDelegate(String.Format("{0}", Filename));
                }
                else if (e.PropertyName == "FunctionSwitch")
                {
                    ConsoleApplication.defaultOutputDelegate(String.Format("{0}", FunctionSwitch));
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }
        #endregion PropertyChangedEventHandlerDelegate

        #region Properties
        private static String _Filename = default(String);
        public static String Filename
        {
            get { return _Filename; }
            set
            {
                _Filename = value;
                OnPropertyChanged("Filename");
            }
        }

        private static String _FunctionSwitch = default(String);
        public static String FunctionSwitch
        {
            get { return _FunctionSwitch; }
            set
            {
                _FunctionSwitch = value;
                OnPropertyChanged("FunctionSwitch");
            }
        }
        #endregion Properties

        #region Methods
        [STAThread]//Note: wasn't STAThread originally; changed to match winforms--SJS
        static Int32 Main(String[] args)
        {
            //default to fail code
            Int32 returnValue = -1;

            try
            {
                //define default output delegate
                ConsoleApplication.defaultOutputDelegate = ConsoleApplication.writeLineWrapperOutputDelegate;

                //load, parse, run switches
                DoSwitches(args);

                InitModelAndSettings();

                returnValue = new App()._Main();
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                Console.WriteLine(String.Format("{0} did NOT complete: '{1}'", APP_NAME, ex.Message));
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

        #region ConsoleAppBase
        /// <summary>
        /// Note: switches are processed before Model or Settings are accessed.
        /// </summary>
        /// <param name="args"></param>
        static void DoSwitches(String[] args)
        {
            //define supported switches
            // -f;[c|f|m|s] /s;"filepath" -?
            // /f;c /s;"C:\Users\ssepan\Documents\wm_test.textdatamerge" 
            // /f;f /s;"C:\Users\ssepan\Documents\wm_test.textdatamerge" 
            // /f;m /s;"C:\Users\ssepan\Documents\wm_test.textdatamerge" 
            // /f;s /s;"C:\Users\ssepan\Documents\wm_test.textdatamerge" 
            ConsoleApplication.CommandLineSwitchValueSeparator = ";";
            ConsoleApplication.DoCommandLineSwitches
            (
                args,
                new CommandLineSwitch[]  
                { 
                    new CommandLineSwitch("f", FunctionsHelpText, true, f),
                    new CommandLineSwitch("s", SettingsHelpText, true, s),
                    //new CommandLineSwitch("H", "H invokes the Help command.", false, ConsoleApplication.Help)//may already be loaded
                }
            );
            //Note: switches are processed before Model or Settings are accessed.
        }

        static void InitModelAndSettings()
        {
            //create Settings before first use by Model
            if (SettingsController<Settings>.Settings == null)
            {
                SettingsController<Settings>.New();
            }
            //Model properties rely on Settings, so don't call Refresh before this is run.
            if (ModelController<TDMModel>.Model == null)
            {
                ModelController<TDMModel>.New();
            }
        }
        #endregion ConsoleAppBase

        #region CommandLineSwitch Action Delegates

        /// <summary>
        /// Validate and set selected function.
        /// Instance of an action conforming to delegate Action<T>, where T is String.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="outputDelegate"></param>
        static void f(String value, Action<String> outputDelegate)
        {
            String functionSwitch = String.Empty;
            try
            {
#if debug
                outputDelegate(String.Format("f{0}\t{1}", ConsoleApplication.CommandLineSwitchValueSeparator, value));
#endif

                //validate function switch
                if (!AllowedFunctionSwitches.Contains(value[0].ToString().ToLower()))
                {
                    throw new ArgumentException(String.Format("Unexpected function switch: '{0}'", value));
                }

                //set function 
                FunctionSwitch = value[0].ToString().ToLower();
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }

        /// <summary>
        /// Validate and set selected settings.
        /// Instance of an action conforming to delegate Action<T>, where T is String.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="outputDelegate"></param>
        static void s(String value, Action<String> outputDelegate)
        {
            try
            {
#if debug
                outputDelegate(String.Format("s{0}\t{1}", ConsoleApplication.CommandLineSwitchValueSeparator, value));
#endif

                //validate settings file path
                if (!File.Exists(value))
                {
                    throw new ArgumentException(String.Format("Invalid settings file path: '{0}'", value));
                }
                Filename = value;
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }
        #endregion CommandLineSwitch Action Delegates
        #endregion Methods
    }
}
