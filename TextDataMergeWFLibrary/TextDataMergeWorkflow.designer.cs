using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace TextDataMergeWFLibrary
{
    partial class TextDataMergeWorkflow
    {
        #region Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference2 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference3 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference4 = new System.Workflow.Activities.Rules.RuleConditionReference();
            this.filterFailedCode = new System.Workflow.Activities.CodeActivity();
            this.filterSucceededCode = new System.Workflow.Activities.CodeActivity();
            this.faultHandlersActivity1 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            this.cancellationHandlerActivity1 = new System.Workflow.ComponentModel.CancellationHandlerActivity();
            this.filterElseBranch = new System.Workflow.Activities.IfElseBranchActivity();
            this.filterIfBranch = new System.Workflow.Activities.IfElseBranchActivity();
            this.sortFailedCode = new System.Workflow.Activities.CodeActivity();
            this.filterIfElse = new System.Workflow.Activities.IfElseActivity();
            this.filterCode = new System.Workflow.Activities.CodeActivity();
            this.sortSucceededCode = new System.Workflow.Activities.CodeActivity();
            this.sortElseBranch = new System.Workflow.Activities.IfElseBranchActivity();
            this.sortIfBranch = new System.Workflow.Activities.IfElseBranchActivity();
            this.collateFailedCode = new System.Workflow.Activities.CodeActivity();
            this.sortIfElse = new System.Workflow.Activities.IfElseActivity();
            this.sortCode = new System.Workflow.Activities.CodeActivity();
            this.collateSucceededCode = new System.Workflow.Activities.CodeActivity();
            this.collateElseBranch = new System.Workflow.Activities.IfElseBranchActivity();
            this.collateIfBranch = new System.Workflow.Activities.IfElseBranchActivity();
            this.mergeFailedCode = new System.Workflow.Activities.CodeActivity();
            this.collateIfElse = new System.Workflow.Activities.IfElseActivity();
            this.collateCode = new System.Workflow.Activities.CodeActivity();
            this.mergeSucceededCode = new System.Workflow.Activities.CodeActivity();
            this.mergeElseBranch = new System.Workflow.Activities.IfElseBranchActivity();
            this.mergeIfBranch = new System.Workflow.Activities.IfElseBranchActivity();
            this.workflowCompleteCode = new System.Workflow.Activities.CodeActivity();
            this.mergeIfElse = new System.Workflow.Activities.IfElseActivity();
            this.mergeCode = new System.Workflow.Activities.CodeActivity();
            this.workflowStartCode = new System.Workflow.Activities.CodeActivity();
            // 
            // filterFailedCode
            // 
            this.filterFailedCode.Name = "filterFailedCode";
            this.filterFailedCode.ExecuteCode += new System.EventHandler(this.filterFailedCode_ExecuteCode);
            // 
            // filterSucceededCode
            // 
            this.filterSucceededCode.Name = "filterSucceededCode";
            this.filterSucceededCode.ExecuteCode += new System.EventHandler(this.filterSucceededCode_ExecuteCode);
            // 
            // faultHandlersActivity1
            // 
            this.faultHandlersActivity1.Name = "faultHandlersActivity1";
            // 
            // cancellationHandlerActivity1
            // 
            this.cancellationHandlerActivity1.Name = "cancellationHandlerActivity1";
            // 
            // filterElseBranch
            // 
            this.filterElseBranch.Activities.Add(this.filterFailedCode);
            this.filterElseBranch.Name = "filterElseBranch";
            // 
            // filterIfBranch
            // 
            this.filterIfBranch.Activities.Add(this.filterSucceededCode);
            ruleconditionreference1.ConditionName = "filterIfCondition";
            this.filterIfBranch.Condition = ruleconditionreference1;
            this.filterIfBranch.Description = "test result for true";
            this.filterIfBranch.Name = "filterIfBranch";
            // 
            // sortFailedCode
            // 
            this.sortFailedCode.Name = "sortFailedCode";
            this.sortFailedCode.ExecuteCode += new System.EventHandler(this.sortFailedCode_ExecuteCode);
            // 
            // filterIfElse
            // 
            this.filterIfElse.Activities.Add(this.filterIfBranch);
            this.filterIfElse.Activities.Add(this.filterElseBranch);
            this.filterIfElse.Activities.Add(this.cancellationHandlerActivity1);
            this.filterIfElse.Activities.Add(this.faultHandlersActivity1);
            this.filterIfElse.Name = "filterIfElse";
            // 
            // filterCode
            // 
            this.filterCode.Name = "filterCode";
            this.filterCode.ExecuteCode += new System.EventHandler(this.filterCode_ExecuteCode);
            // 
            // sortSucceededCode
            // 
            this.sortSucceededCode.Name = "sortSucceededCode";
            this.sortSucceededCode.ExecuteCode += new System.EventHandler(this.sortSucceededCode_ExecuteCode);
            // 
            // sortElseBranch
            // 
            this.sortElseBranch.Activities.Add(this.sortFailedCode);
            this.sortElseBranch.Name = "sortElseBranch";
            // 
            // sortIfBranch
            // 
            this.sortIfBranch.Activities.Add(this.sortSucceededCode);
            this.sortIfBranch.Activities.Add(this.filterCode);
            this.sortIfBranch.Activities.Add(this.filterIfElse);
            ruleconditionreference2.ConditionName = "sortIfCondition";
            this.sortIfBranch.Condition = ruleconditionreference2;
            this.sortIfBranch.Description = "test result for true";
            this.sortIfBranch.Name = "sortIfBranch";
            // 
            // collateFailedCode
            // 
            this.collateFailedCode.Name = "collateFailedCode";
            this.collateFailedCode.ExecuteCode += new System.EventHandler(this.collateFailedCode_ExecuteCode);
            // 
            // sortIfElse
            // 
            this.sortIfElse.Activities.Add(this.sortIfBranch);
            this.sortIfElse.Activities.Add(this.sortElseBranch);
            this.sortIfElse.Name = "sortIfElse";
            // 
            // sortCode
            // 
            this.sortCode.Name = "sortCode";
            this.sortCode.ExecuteCode += new System.EventHandler(this.sortCode_ExecuteCode);
            // 
            // collateSucceededCode
            // 
            this.collateSucceededCode.Name = "collateSucceededCode";
            this.collateSucceededCode.ExecuteCode += new System.EventHandler(this.collateSucceededCode_ExecuteCode);
            // 
            // collateElseBranch
            // 
            this.collateElseBranch.Activities.Add(this.collateFailedCode);
            this.collateElseBranch.Name = "collateElseBranch";
            // 
            // collateIfBranch
            // 
            this.collateIfBranch.Activities.Add(this.collateSucceededCode);
            this.collateIfBranch.Activities.Add(this.sortCode);
            this.collateIfBranch.Activities.Add(this.sortIfElse);
            ruleconditionreference3.ConditionName = "collateIfCondition";
            this.collateIfBranch.Condition = ruleconditionreference3;
            this.collateIfBranch.Description = "test result for true";
            this.collateIfBranch.Name = "collateIfBranch";
            // 
            // mergeFailedCode
            // 
            this.mergeFailedCode.Name = "mergeFailedCode";
            this.mergeFailedCode.ExecuteCode += new System.EventHandler(this.mergeFailedCode_ExecuteCode);
            // 
            // collateIfElse
            // 
            this.collateIfElse.Activities.Add(this.collateIfBranch);
            this.collateIfElse.Activities.Add(this.collateElseBranch);
            this.collateIfElse.Name = "collateIfElse";
            // 
            // collateCode
            // 
            this.collateCode.Name = "collateCode";
            this.collateCode.ExecuteCode += new System.EventHandler(this.collateCode_ExecuteCode);
            // 
            // mergeSucceededCode
            // 
            this.mergeSucceededCode.Name = "mergeSucceededCode";
            this.mergeSucceededCode.ExecuteCode += new System.EventHandler(this.mergeSucceededCode_ExecuteCode);
            // 
            // mergeElseBranch
            // 
            this.mergeElseBranch.Activities.Add(this.mergeFailedCode);
            this.mergeElseBranch.Name = "mergeElseBranch";
            // 
            // mergeIfBranch
            // 
            this.mergeIfBranch.Activities.Add(this.mergeSucceededCode);
            this.mergeIfBranch.Activities.Add(this.collateCode);
            this.mergeIfBranch.Activities.Add(this.collateIfElse);
            ruleconditionreference4.ConditionName = "mergeIfCondition";
            this.mergeIfBranch.Condition = ruleconditionreference4;
            this.mergeIfBranch.Description = "test result for true";
            this.mergeIfBranch.Name = "mergeIfBranch";
            // 
            // workflowCompleteCode
            // 
            this.workflowCompleteCode.Name = "workflowCompleteCode";
            this.workflowCompleteCode.ExecuteCode += new System.EventHandler(this.workflowCompleteCode_ExecuteCode);
            // 
            // mergeIfElse
            // 
            this.mergeIfElse.Activities.Add(this.mergeIfBranch);
            this.mergeIfElse.Activities.Add(this.mergeElseBranch);
            this.mergeIfElse.Name = "mergeIfElse";
            // 
            // mergeCode
            // 
            this.mergeCode.Name = "mergeCode";
            this.mergeCode.ExecuteCode += new System.EventHandler(this.mergeCode_ExecuteCode);
            // 
            // workflowStartCode
            // 
            this.workflowStartCode.Name = "workflowStartCode";
            this.workflowStartCode.ExecuteCode += new System.EventHandler(this.workflowStartCode_ExecuteCode);
            // 
            // TextDataMergeWorkflow
            // 
            this.Activities.Add(this.workflowStartCode);
            this.Activities.Add(this.mergeCode);
            this.Activities.Add(this.mergeIfElse);
            this.Activities.Add(this.workflowCompleteCode);
            this.Name = "TextDataMergeWorkflow";
            this.CanModifyActivities = false;

        }

        #endregion

        private FaultHandlersActivity faultHandlersActivity1;

        private CancellationHandlerActivity cancellationHandlerActivity1;

        private IfElseBranchActivity filterElseBranch;

        private IfElseBranchActivity filterIfBranch;

        private IfElseActivity filterIfElse;

        private CodeActivity filterCode;

        private IfElseBranchActivity sortElseBranch;

        private IfElseBranchActivity sortIfBranch;

        private IfElseActivity sortIfElse;

        private CodeActivity sortCode;

        private IfElseBranchActivity collateElseBranch;

        private IfElseBranchActivity collateIfBranch;

        private IfElseActivity collateIfElse;

        private CodeActivity collateCode;

        private IfElseBranchActivity mergeElseBranch;

        private IfElseBranchActivity mergeIfBranch;

        private IfElseActivity mergeIfElse;

        private CodeActivity filterFailedCode;

        private CodeActivity filterSucceededCode;

        private CodeActivity sortFailedCode;

        private CodeActivity sortSucceededCode;

        private CodeActivity collateFailedCode;

        private CodeActivity collateSucceededCode;

        private CodeActivity mergeFailedCode;

        private CodeActivity mergeSucceededCode;

        private CodeActivity workflowCompleteCode;

        private CodeActivity workflowStartCode;

        private CodeActivity mergeCode;





































    }
}
