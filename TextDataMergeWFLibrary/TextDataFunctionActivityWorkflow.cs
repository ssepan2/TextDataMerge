using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Linq;
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

namespace TextDataMergeWFLibrary
{
    public sealed partial class TextDataFunctionActivityWorkflow : SequentialWorkflowActivity
    {
        Boolean result = default(Boolean);
        String settingsFilePath = default(String);

        public TextDataFunctionActivityWorkflow()
        {
            InitializeComponent();
        }

        private void workflowStartCode_ExecuteCode(object sender, EventArgs e)
        {
            //load path(s) from config file here
            if (!Ssepan.Utility.Configuration.ReadString("SettingsFilePath", out settingsFilePath))
            {
                throw new ApplicationException(String.Format("Configuration setting was not read: {0}", "SettingsFilePath"));
            }
            Console.WriteLine("workflow started");
        }

        private void mergeCode_ExecuteCode(object sender, EventArgs e)
        {
            result = false;
            SettingsController<Settings>.FilePath = settingsFilePath;
            SettingsController<Settings>.Open();
            result = SettingsController<Settings>.Settings.Merge.Run();
        }

        private void mergeSucceededCode_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("merge succeeded");
        }

        private void mergeFailedCode_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("merge failed");
        }

        private void collateCode_ExecuteCode(object sender, EventArgs e)
        {
            result = false;
            SettingsController<Settings>.FilePath = settingsFilePath;
            SettingsController<Settings>.Open();
            result = SettingsController<Settings>.Settings.Collate.Run();
        }

        private void collateSucceededCode_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("collate succeeded");
        }

        private void collateFailedCode_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("collate failed");
        }

        private void sortCode_ExecuteCode(object sender, EventArgs e)
        {
            result = false;
            SettingsController<Settings>.FilePath = settingsFilePath;
            SettingsController<Settings>.Open();
            result = SettingsController<Settings>.Settings.Sort.Run();
        }

        private void sortSucceededCode_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("sort succeeded");
        }

        private void sortFailedCode_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("sort failed");
        }

        private void filterCode_ExecuteCode(object sender, EventArgs e)
        {
            result = false;
            SettingsController<Settings>.FilePath = settingsFilePath;
            SettingsController<Settings>.Open();
            result = SettingsController<Settings>.Settings.Filter.Run();
        }

        private void filterSucceededCode_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("filter succeeded");
        }

        private void filterFailedCode_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("filter failed");
        }

        private void workflowCompleteCode_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("workflow completed");
        }

        public static DependencyProperty collateActivity1_TextDataFunction1Property = DependencyProperty.Register("collateActivity1_TextDataFunction1", typeof(TextDataMergeLibrary.Collate), typeof(TextDataMergeWFLibrary.TextDataFunctionActivityWorkflow));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("TextDataFunction Category")]
        public Collate collateActivity1_TextDataFunction1
        {
            get
            {
                return ((TextDataMergeLibrary.Collate)(base.GetValue(TextDataMergeWFLibrary.TextDataFunctionActivityWorkflow.collateActivity1_TextDataFunction1Property)));
            }
            set
            {
                base.SetValue(TextDataMergeWFLibrary.TextDataFunctionActivityWorkflow.collateActivity1_TextDataFunction1Property, value);
            }
        }
    }

}
