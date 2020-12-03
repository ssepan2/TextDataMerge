using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TextDataMergeLibrary;
using Ssepan.Application;
using Ssepan.Collections;
using Ssepan.DataBinding;
using Ssepan.Utility;
using System.Diagnostics;
using System.Reflection;

namespace TextDataFunctionControls
{
    public partial class TextFunctionEditorBase : 
        UserControl
    {
        public TextFunctionEditorBase()
        {
            InitializeComponent();
        }

        [Category("Child")]
        public event EventHandler RunClick
        {
            add { cmdRun.Click += value; }
            remove { cmdRun.Click -= value; }
        }
        
        [Category("Child")]
        public event EventHandler InputAddClick
        {
            add { cmdInputFilesAdd.Click += value; }
            remove { cmdInputFilesAdd.Click -= value; }
        }
        
        [Category("Child")]
        public event EventHandler InputDeleteClick
        {
            add { cmdInputFilesDelete.Click += value; }
            remove { cmdInputFilesDelete.Click -= value; }
        }

        [Category("Child")]
        public event EventHandler OutputAddClick
        {
            add { cmdOutputFilesAdd.Click += value; }
            remove { cmdOutputFilesAdd.Click -= value; }
        }

        [Category("Child")]
        public event EventHandler OutputDeleteClick
        {
            add { cmdOutputFilesDelete.Click += value; }
            remove { cmdOutputFilesDelete.Click -= value; }
        }

        [Category("Child")]
        public event KeyEventHandler InputKeyUp
        {
            add { lstInputFiles.KeyUp += value; }
            remove { lstInputFiles.KeyUp -= value; }
        }

        [Category("Child")]
        public event KeyEventHandler OutputKeyUp
        {
            add { lstOutputFiles.KeyUp += value; }
            remove { lstOutputFiles.KeyUp -= value; }
        }

        [Category("Child")]
        public event EventHandler InputSelectedIndexChanged
        {
            add { lstInputFiles.SelectedIndexChanged += value; }
            remove { lstInputFiles.SelectedIndexChanged -= value; }
        }

        [Category("Child")]
        public event EventHandler OutputSelectedIndexChanged
        {
            add 
            {
                lstOutputFiles.SelectedIndexChanged += value;
            }
            remove 
            {
                lstOutputFiles.SelectedIndexChanged -= value; 
            }
        }
        protected void OnOutputSelectedIndexChanged()
        {
            try
            {
                //attempts to fire event result in CS0079
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }
        
        /// <summary>
        /// Bind Filter Settings controls to Condition
        /// </summary>
        /// <param name="condition"
        public virtual void BindConditionUi(Condition condition)
        {
            try
            {
                //cannot be abstract, or class will must become abstract too, which causes failure to initialize when instances of child contorls are initialized
                throw new ApplicationException(String.Format("BindConditionUi() was called in TextFunctionEditorBase."));
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }

        /// <summary>
        /// Bind Settings controls to SettingsController
        /// </summary>
        public virtual void BindFormUi()
        {
            try
            {
                //cannot be abstract, or class will must become abstract too, which causes failure to initialize when instances of child contorls are initialized
                throw new ApplicationException(String.Format("BindFormUi() was called in TextFunctionEditorBase."));
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        /// <summary>
        /// Bind Settings controls to SettingsController
        /// </summary>
        /// <param name="textFunctionBase"></param>
        public virtual void BindModelUi(TextFunctionBase textFunctionBase)
        {
            try
            {
                //cannot be abstract, or class will must become abstract too, which causes failure to initialize when instances of child contorls are initialized
                throw new ApplicationException(String.Format("BindModelUi() was called in TextFunctionEditorBase."));
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }
    }
}
