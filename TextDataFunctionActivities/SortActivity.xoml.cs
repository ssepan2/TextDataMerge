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
using Ssepan.Application.MVC;
using Ssepan.Utility;

namespace TextDataFunctionActivities
{
    public partial class SortActivity : SequenceActivity
    {
        private Boolean _Result = default(Boolean);
        public Boolean Result
        {
            get { return _Result; }
            set { _Result = value; }
        }

        public static DependencyProperty PathProperty = DependencyProperty.Register("Path", typeof(string), typeof(SortActivity));

        [DescriptionAttribute("Path")]
        [CategoryAttribute("TextDataFunction")]
        [BrowsableAttribute(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        public string Path
        {
            get
            {
                return ((string)(base.GetValue(SortActivity.PathProperty)));
            }
            set
            {
                base.SetValue(SortActivity.PathProperty, value);
            }
        }
        private void runActivity_ExecuteCode(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("SortActivity runActivity_ExecuteCode");
                Result = false;
                SettingsController<Settings>.FilePath = this.Path;
                SettingsController<Settings>.Open();
                Result = SettingsController<Settings>.Settings.Sort.Run();

            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }
    }

    class SortActivityValidator : DependencyObjectValidator
    {
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {

            // Invoke the base class method implementation to
            // perform default validation.
            ValidationErrorCollection errors = base.Validate(manager, obj);

            // Make sure there is an activity instance.
            SortActivity sortActivity = obj as SortActivity;
            if (sortActivity == null)
            {
                throw new InvalidOperationException();
            }
            if (sortActivity.Parent == null)
            {
                return errors;
            }


            //double checking each field
            if ((string.IsNullOrEmpty(sortActivity.Path)) && (sortActivity.GetBinding(SortActivity.PathProperty) == null))
            {
                errors.Add(new ValidationError("Path must contain a path.", 100, false, "Path"));
            }
            if (!File.Exists(sortActivity.Path))
            {
                errors.Add(new ValidationError("Path must contain a path that exists.", 100, false, "Path"));
            }

            return errors;
        }
    }
}
