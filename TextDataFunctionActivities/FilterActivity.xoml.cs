using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using TextDataMergeLibrary;
using Ssepan.Application;
using Ssepan.Utility;

namespace TextDataFunctionActivities
{
    public partial class FilterActivity : SequenceActivity
    {
        private Boolean _Result = default(Boolean);
        public Boolean Result
        {
            get { return _Result; }
            set { _Result = value; }
        }

        public static DependencyProperty PathProperty = DependencyProperty.Register("Path", typeof(string), typeof(FilterActivity));

        [DescriptionAttribute("Path")]
        [CategoryAttribute("TextDataFunction")]
        [BrowsableAttribute(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        public string Path
        {
            get
            {
                return ((string)(base.GetValue(FilterActivity.PathProperty)));
            }
            set
            {
                base.SetValue(FilterActivity.PathProperty, value);
            }
        }
        private void runActivity_ExecuteCode(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("FilterActivity runActivity_ExecuteCode");
                Result = false;
                SettingsController<Settings>.FilePath = this.Path;
                SettingsController<Settings>.Open();
                Result = SettingsController<Settings>.Settings.Filter.Run();

            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }
    }

    class FilterActivityValidator : DependencyObjectValidator
    {
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {

            // Invoke the base class method implementation to
            // perform default validation.
            ValidationErrorCollection errors = base.Validate(manager, obj);

            // Make sure there is an activity instance.
            FilterActivity filterActivity = obj as FilterActivity;
            if (filterActivity == null)
            {
                throw new InvalidOperationException();
            }
            if (filterActivity.Parent == null)
            {
                return errors;
            }


            //double checking each field
            if ((string.IsNullOrEmpty(filterActivity.Path)) && (filterActivity.GetBinding(FilterActivity.PathProperty) == null))
            {
                errors.Add(new ValidationError("Path must contain a path.", 100, false, "Path"));
            }
            if (!File.Exists(filterActivity.Path))
            {
                errors.Add(new ValidationError("Path must contain a path that exists.", 100, false, "Path"));
            }

            return errors;
        }
    }
}
