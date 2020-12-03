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
    public partial class FilterEditor : 
        TextFunctionEditorBase
    {
        public FilterEditor()
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
                if (condition != null)
                {
                    //unbind
                    BindConditionUi(null);

                    //enable
                    chkNot.Enabled = true;
                    lblComparisons.Enabled = true;
                    txtValue.Enabled = true;

                    //bind
                    //use OnValidation so that focus will not jump until user is done changing the control.
                    chkNot.DataBindings.Add("Checked", condition, "Not", false, DataSourceUpdateMode.OnValidation);
                    lblComparisons.DataBindings.Add("Text", condition, "Comparison", false, DataSourceUpdateMode.Never);
                    txtValue.DataBindings.Add("Text", condition, "Value", false, DataSourceUpdateMode.OnValidation);
                }
                else
                {
                    //unbind
                    chkNot.DataBindings.Clear();
                    lblComparisons.DataBindings.Clear();
                    txtValue.DataBindings.Clear();

                    //disable
                    chkNot.Enabled = false;
                    lblComparisons.Enabled = false;
                    txtValue.Enabled = false;
                }
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
            Filter textFunction = default(Filter);

            try
            {
                textFunction = textFunctionBase as Filter;

                //Filter
                ControlBindings.BindListControlToBindingListOfT<DataFile>(lstInputFiles, textFunction.InputFiles, "Path", "Path");
                ControlBindings.BindListControlToBindingListOfT<ConditionedDataFile>(lstOutputFiles, textFunction.OutputFiles, "Path", "Path");

                txtStartingColumn.DataBindings.Clear();
                txtStartingColumn.DataBindings.Add("Text", textFunction, "KeyIndexText", false, DataSourceUpdateMode.OnPropertyChanged);

                txtNumberOfColumns.DataBindings.Clear();
                txtNumberOfColumns.DataBindings.Add("Text", textFunction, "KeyLengthText", false, DataSourceUpdateMode.OnPropertyChanged);

                chkDescending.DataBindings.Clear();
                chkDescending.DataBindings.Add("Checked", textFunction, "Descending", false, DataSourceUpdateMode.OnPropertyChanged);

                chkAllowDuplicates.DataBindings.Clear();
                chkAllowDuplicates.DataBindings.Add("Checked", textFunction, "AllowDuplicates", false, DataSourceUpdateMode.OnPropertyChanged);

                ////trigger Condition binding
                //OnOutputSelectedIndexChanged();
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
