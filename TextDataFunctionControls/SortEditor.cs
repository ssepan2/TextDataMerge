using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TextDataMergeLibrary;
using Ssepan.DataBinding;
using Ssepan.Utility;
using System.Diagnostics;
using System.Reflection;

namespace TextDataFunctionControls
{
    public partial class SortEditor : 
        TextFunctionEditorBase
    {
        public SortEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Bind Settings controls to Condition
        /// </summary>
        /// <param name="condition"
        public override void BindConditionUi(Condition condition)
        {
            try
            {
                //not applicable
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }

        /// <summary>
        /// Bind static list controls to lookup values, etc.
        /// </summary>
        public override void BindFormUi()
        {
            try
            {
                //Form
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
        public override void BindModelUi(TextFunctionBase textFunctionBase)
        {
            Sort textFunction = default(Sort);

            try
            {
                textFunction = textFunctionBase as Sort;

                //Sort
                ControlBindings.BindListControlToBindingListOfT<DataFile>(lstInputFiles, textFunction.InputFiles, "Path", "Path");
                ControlBindings.BindListControlToBindingListOfT<DataFile>(lstOutputFiles, textFunction.OutputFiles, "Path", "Path");

                txtStartingColumn.DataBindings.Clear();
                txtStartingColumn.DataBindings.Add("Text", textFunction, "KeyIndexText", false, DataSourceUpdateMode.OnPropertyChanged);

                txtNumberOfColumns.DataBindings.Clear();
                txtNumberOfColumns.DataBindings.Add("Text", textFunction, "KeyLengthText", false, DataSourceUpdateMode.OnPropertyChanged);

                chkDescending.DataBindings.Clear();
                chkDescending.DataBindings.Add("Checked", textFunction, "Descending", false, DataSourceUpdateMode.OnPropertyChanged);

                chkAllowDuplicates.DataBindings.Clear();
                chkAllowDuplicates.DataBindings.Add("Checked", textFunction, "AllowDuplicates", false, DataSourceUpdateMode.OnPropertyChanged);
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
            finally
            {
                textFunction = null;
            }
        }
    }
}
