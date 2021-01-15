//#define USE_CONFIG_FILEPATH

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms; 
using TextDataMergeLibrary;
using TextDataMergeLibrary.Properties;
using Ssepan.Application;
using Ssepan.Collections;
using Ssepan.DataBinding;
using Ssepan.Io;
using Ssepan.Utility;

namespace TextDataMergeForms
{
    /// <summary>
    /// This is the View.
    /// </summary>
    public partial class TextDataMergeViewer  :
        Form,
        INotifyPropertyChanged
    {
        #region Declarations
        protected Boolean disposed;

        private Boolean _ValueChangedProgrammatically;

        //cancellation hook
        Action cancelDelegate = null;
        protected TextDataMergeViewModel ViewModel = default(TextDataMergeViewModel);
        #endregion Declarations

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public TextDataMergeViewer(String[] args)
        {
            try
            {
                InitializeComponent();

                ////(re)define default output delegate
                //ConsoleApplication.defaultOutputDelegate = ConsoleApplication.messageBoxWrapperOutputDelegate;

                //subscribe to notifications
                this.PropertyChanged += PropertyChangedEventHandlerDelegate;

                InitViewModel();

                BindSizeAndLocation();
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }
        #endregion Constructors

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(String propertyName)
        {
            try
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            catch (Exception ex)
            {
                ViewModel.ErrorMessage = ex.Message;
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
        protected void PropertyChangedEventHandlerDelegate
        (
            Object sender,
            PropertyChangedEventArgs e
        )
        {
            try
            {
                if (e.PropertyName == "IsChanged")
                {
                    //ConsoleApplication.defaultOutputDelegate(String.Format("{0}", e.PropertyName));
                    ApplySettings();
                }
                //Status Bar
                else if (e.PropertyName == "ActionIconIsVisible")
                {
                    StatusBarActionIcon.Visible = (ViewModel.ActionIconIsVisible);
                }
                else if (e.PropertyName == "ActionIconImage")
                {
                    StatusBarActionIcon.Image = (ViewModel != null ? ViewModel.ActionIconImage : (Image)null);
                }
                else if (e.PropertyName == "StatusMessage")
                {
                    //replace default action by setting control property
                    StatusBarStatusMessage.Text = (ViewModel != null ? ViewModel.StatusMessage : (String)null);
                    //e = new PropertyChangedEventArgs(e.PropertyName + ".handled");

                    //ConsoleApplication.defaultOutputDelegate(String.Format("{0}", StatusMessage));
                }
                else if (e.PropertyName == "ErrorMessage")
                {
                    //replace default action by setting control property
                    StatusBarErrorMessage.Text = (ViewModel != null ? ViewModel.ErrorMessage : (String)null);
                    //e = new PropertyChangedEventArgs(e.PropertyName + ".handled");

                    //ConsoleApplication.defaultOutputDelegate(String.Format("{0}", ErrorMessage));
                }
                else if (e.PropertyName == "ErrorMessageToolTipText")
                {
                    StatusBarErrorMessage.ToolTipText = ViewModel.ErrorMessageToolTipText;
                }
                else if (e.PropertyName == "ProgressBarValue")
                {
                    StatusBarProgressBar.Value = ViewModel.ProgressBarValue;
                }
                else if (e.PropertyName == "ProgressBarMaximum")
                {
                    StatusBarProgressBar.Maximum = ViewModel.ProgressBarMaximum;
                }
                else if (e.PropertyName == "ProgressBarMinimum")
                {
                    StatusBarProgressBar.Minimum = ViewModel.ProgressBarMinimum;
                }
                else if (e.PropertyName == "ProgressBarStep")
                {
                    StatusBarProgressBar.Step = ViewModel.ProgressBarStep;
                }
                else if (e.PropertyName == "ProgressBarIsMarquee")
                {
                    StatusBarProgressBar.Style = (ViewModel.ProgressBarIsMarquee ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks);
                }
                else if (e.PropertyName == "ProgressBarIsVisible")
                {
                    StatusBarProgressBar.Visible = (ViewModel.ProgressBarIsVisible);
                }
                else if (e.PropertyName == "DirtyIconIsVisible")
                {
                    StatusBarDirtyMessage.Visible = (ViewModel.DirtyIconIsVisible);
                }
                else if (e.PropertyName == "DirtyIconImage")
                {
                    StatusBarDirtyMessage.Image = ViewModel.DirtyIconImage;
                }
                //use if properties cannot be databound
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }
        #endregion PropertyChangedEventHandlerDelegate

        #region Properties
        private String _ViewName = Program.APP_NAME;
        public String ViewName
        {
            get { return _ViewName; }
            set { _ViewName = value; }
        }
        #endregion Properties

        #region Events
        #region Form Events
        /// <summary>
        /// Process Form key presses.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override Boolean ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Boolean returnValue = default(Boolean);
            try
            {
                // Implement the Escape / Cancel keystroke
                if (keyData == Keys.Cancel || keyData == Keys.Escape)
                {
                    //if a long-running cancellable-action has registered 
                    //an escapable-event, trigger it
                    InvokeActionCancel();

                    // This keystroke was handled, 
                    //don't pass to the control with the focus
                    returnValue = true;
                }
                else
                {
                    returnValue = base.ProcessCmdKey(ref msg, keyData);
                }

            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
            return returnValue;
        }

        private void TextDataMerge_Load(Object sender, EventArgs e)
        {
            try
            {
                ViewModel.StatusMessage = String.Format("{0} starting...", ViewName);

                ViewModel.StatusMessage = String.Format("{0} started.", ViewName);

                _Run();
            }
            catch (Exception ex)
            {
                ViewModel.ErrorMessage = ex.Message;
                ViewModel.StatusMessage = String.Empty;

                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        private void TextDataMerge_FormClosing(Object sender, FormClosingEventArgs e)
        {
            try
            {
                ViewModel.StatusMessage = String.Format("{0} completing...", ViewName);

                DisposeSettings();

                ViewModel.StatusMessage = String.Format("{0} completed.", ViewName);
            }
            catch (Exception ex)
            {
                ViewModel.ErrorMessage = ex.Message.ToString();
                ViewModel.StatusMessage = "";

                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
            finally
            {
                ViewModel = null;
            }
        }
        #endregion FormEvents

        #region MenuEvents
        private void menuFileNew_Click(Object sender, EventArgs e)
        {
            ViewModel.FileNew();
        }

        private void menuFileOpen_Click(Object sender, EventArgs e)
        {
            ViewModel.FileOpen();
        }

        private void menuFileSave_Click(Object sender, EventArgs e)
        {
            ViewModel.FileSave();
        }

        private void menuFileSaveAs_Click(Object sender, EventArgs e)
        {
            ViewModel.FileSaveAs();
        }

        private void menuFileExit_Click(Object sender, EventArgs e)
        {
            ViewModel.FileExit();
        }

        private void menuEditProperties_Click(Object sender, EventArgs e)
        {
            ViewModel.EditProperties();
        }

        private void menuEditCopyToClipboard_Click(Object sender, EventArgs e)
        {
            ViewModel.EditCopy();
        }

        private void menuHelpAbout_Click(Object sender, EventArgs e)
        {
            ViewModel.HelpAbout<AssemblyInfo>();
        }
        #endregion MenuEvents
        
        #region Collate Events
        private void collateEditor1_InputAddClick(Object sender, EventArgs e)
        {
            ViewModel.CollateInputAdd();
        }

        private void collateEditor1_InputDeleteClick(Object sender, EventArgs e)
        {
            ViewModel.CollateInputDelete(sender as ListBox);
        }

        private void collateEditor1_InputKeyUp(Object sender, KeyEventArgs e)
        {
            ViewModel.CollateInputKeyUp(sender as ListBox, e.KeyCode);
        }

        private void collateEditor1_OutputAddClick(Object sender, EventArgs e)
        {
            ViewModel.CollateOutputAdd();
        }

        private void collateEditor1_OutputDeleteClick(Object sender, EventArgs e)
        {
            ViewModel.CollateOutputDelete(sender as ListBox);
        }

        private void collateEditor1_OutputKeyUp(Object sender, KeyEventArgs e)
        {
            ViewModel.CollateOutputKeyUp(sender as ListBox, e.KeyCode);
        }

        private void collateEditor1_OutputSelectedIndexChanged(Object sender, EventArgs e)
        {
            ViewModel.CollateOutputIndexSelected(collateEditor1);
        }

        private void collateEditor1_RunClick(Object sender, EventArgs e)
        {
            ViewModel.CollateRun();
        }
        #endregion Collate Events

        #region Filter Events
        private void filterEditor1_InputAddClick(Object sender, EventArgs e)
        {
            ViewModel.FilterInputAdd();
        }

        private void filterEditor1_InputDeleteClick(Object sender, EventArgs e)
        {
            ViewModel.FilterInputDelete(filterEditor1.lstInputFiles);
        }

        private void filterEditor1_InputKeyUp(Object sender, KeyEventArgs e)
        {
            ViewModel.FilterInputKeyUp(sender as ListBox, e.KeyCode);
        }

        private void filterEditor1_OutputAddClick(Object sender, EventArgs e)
        {
            ViewModel.FilterOutputAdd();
        }

        private void filterEditor1_OutputDeleteClick(Object sender, EventArgs e)
        {
            ViewModel.FilterOutputDelete(sender as ListBox);
        }

        private void filterEditor1_OutputKeyUp(Object sender, KeyEventArgs e)
        {
            ViewModel.FilterOutputKeyUp(sender as ListBox, e.KeyCode);
        }

        private void filterEditor1_OutputSelectedIndexChanged(Object sender, EventArgs e)
        {
            ViewModel.FilterOutputIndexSelected(filterEditor1);
        }

        private void filterEditor1_RunClick(Object sender, EventArgs e)
        {
            ViewModel.FilterRun();
        }
        #endregion Filter Events

        #region Merge Events
        private void mergeEditor1_InputAddClick(Object sender, EventArgs e)
        {
            ViewModel.MergeInputAdd();
        }

        private void mergeEditor1_InputDeleteClick(Object sender, EventArgs e)
        {
            ViewModel.MergeInputDelete(sender as ListBox);
        }

        private void mergeEditor1_InputKeyUp(Object sender, KeyEventArgs e)
        {
            ViewModel.MergeInputKeyUp(sender as ListBox, e.KeyCode);
        }

        private void mergeEditor1_OutputAddClick(Object sender, EventArgs e)
        {
            ViewModel.MergeOutputAdd();
        }

        private void mergeEditor1_OutputDeleteClick(Object sender, EventArgs e)
        {
            ViewModel.MergeOutputDelete(sender as ListBox);
        }

        private void mergeEditor1_OutputKeyUp(Object sender, KeyEventArgs e)
        {
            ViewModel.MergeOutputKeyUp(sender as ListBox, e.KeyCode);
        }

        private void mergeEditor1_RunClick(Object sender, EventArgs e)
        {
            ViewModel.MergeRun();
        }
        #endregion Merge Events

        #region Sort Events
        private void sortEditor1_InputAddClick(Object sender, EventArgs e)
        {
            ViewModel.SortInputAdd();
        }

        private void sortEditor1_InputDeleteClick(Object sender, EventArgs e)
        {
            ViewModel.SortInputDelete(sender as ListBox);
        }

        private void sortEditor1_InputKeyUp(Object sender, KeyEventArgs e)
        {
            ViewModel.SortInputKeyUp(sender as ListBox, e.KeyCode);
        }

        private void sortEditor1_OutputAddClick(Object sender, EventArgs e)
        {
            ViewModel.SortOutputAdd();
        }

        private void sortEditor1_OutputDeleteClick(Object sender, EventArgs e)
        {
            ViewModel.SortOutputDelete(sender as ListBox);
        }

        private void sortEditor1_OutputKeyUp(Object sender, KeyEventArgs e)
        {
            ViewModel.SortOutputKeyUp(sender as ListBox, e.KeyCode);
        }

        private void sortEditor1_RunClick(Object sender, EventArgs e)
        {
            ViewModel.SortRun();
        }
        #endregion Sort Events
        #endregion Events

        #region FormAppBase
        protected void InitViewModel()
        {
            try
            {
                //tell controller how model should notify view about non-persisted properties AND including model properties that may be part of settings
                ModelController<TDMModel>.DefaultHandler = PropertyChangedEventHandlerDelegate;

                //tell controller how settings should notify view about persisted properties
                SettingsController<Settings>.DefaultHandler = PropertyChangedEventHandlerDelegate;

                InitModelAndSettings();

                FileDialogInfo settingsFileDialogInfo =
                    new FileDialogInfo
                    (
                        SettingsController<Settings>.FILE_NEW,
                        null,
                        null,
                        /*SettingsController<Settings>.Settings*/Settings.FileTypeExtension,
                        /*SettingsController<Settings>.Settings*/Settings.FileTypeDescription,
                        /*SettingsController<Settings>.Settings*/Settings.FileTypeName,
                        new String[] 
                        { 
                            "XML files (*.xml)|*.xml", 
                            "All files (*.*)|*.*" 
                        },
                        false,
                        default(Environment.SpecialFolder),
                        Environment.GetFolderPath(Environment.SpecialFolder.Personal).WithTrailingSeparator()
                    );
                //set dialog caption
                settingsFileDialogInfo.Title = this.Text;
            
                FileDialogInfo textDataFileDialogInfo = 
                    new FileDialogInfo
                    (
                        "(new)", 
                        null, 
                        null, 
                        "txt", 
                        "Text files", 
                        "txtfile", 
                        new String[] 
                        { 
                            "Data files (*.dat)|*.dat", 
                            "All files (*.*)|*.*" 
                        }, 
                        false, 
                        default(Environment.SpecialFolder)
                    );
                //set dialog caption
                textDataFileDialogInfo.Title = this.Text;


                //class to handle standard behaviors
                ViewModelController<Bitmap, TextDataMergeViewModel>.New
                (
                    ViewName,
                    new TextDataMergeViewModel
                    (
                        this.PropertyChangedEventHandlerDelegate,
                        new Dictionary<String, Bitmap>() 
                        { 
                            { "New", Resources.New }, 
                            { "Save", Resources.Save },
                            { "Open", Resources.Open },
                            { "Print", Resources.Print },
                            { "Copy", Resources.Copy },
                            { "Properties", Resources.Properties }
                        },
                        settingsFileDialogInfo,
                        textDataFileDialogInfo
                    )
                );
                ViewModel = ViewModelController<Bitmap, TextDataMergeViewModel>.ViewModel[ViewName];

                BindFormUi();

                //Init config parameters
                if (!LoadParameters())
                {
                    throw new Exception(String.Format("Unable to load config file parameter(s)."));
                }

                //DEBUG:filename coming in is being converted/passed as DOS 8.3 format equivalent
                //Load
                if ((SettingsController<Settings>.FilePath == null) || (SettingsController<Settings>.Filename == SettingsController<Settings>.FILE_NEW))
                {
                    //NEW
                    ViewModel.FileNew();
                }
                else
                {
                    //OPEN
                    ViewModel.FileOpen(false);
                }

    #if debug
                //debug view
                menuEditProperties_Click(sender, e);
    #endif

                //Display dirty state
                ModelController<TDMModel>.Model.Refresh();
            }
            catch (Exception ex)
            {
                if (ViewModel != null)
                {
                    ViewModel.ErrorMessage = ex.Message;
                }
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        protected void InitModelAndSettings()
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

        protected void DisposeSettings()
        {
            //save user and application settings 
            Properties.Settings.Default.Save();

            if (SettingsController<Settings>.Settings.Dirty)
            {
                //prompt before saving
                DialogResult dialogResult = MessageBox.Show("Save changes?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        {
                            //SAVE
                            ViewModel.FileSave();

                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                    default:
                        {
                            throw new InvalidEnumArgumentException();
                        }
                }
            }

            //unsubscribe from model notifications
            ModelController<TDMModel>.Model.PropertyChanged -= PropertyChangedEventHandlerDelegate;
        }

        protected void _Run()
        {
        }
        #endregion FormAppBase

        #region Utility
        /// <summary>
        /// Bind static list controls to lookup values, etc.
        /// </summary>
        private void BindFormUi()
        {
            try
            {
                //Form
                
                //Controls
                collateEditor1.BindFormUi();
                filterEditor1.BindFormUi();
                mergeEditor1.BindFormUi();
                sortEditor1.BindFormUi();
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
        private void BindModelUi(Settings settings)
        {
            try
            {
                collateEditor1.BindModelUi(settings.Collate);
                filterEditor1.BindModelUi(settings.Filter);
                mergeEditor1.BindModelUi(settings.Merge);
                sortEditor1.BindModelUi(settings.Sort);
                
                //trigger binding of Condition Ui in Collate, Filter
                //TODO:move into controls' BindModelUi and trigger event internally. Attempts to do so result in CS0079.
                collateEditor1_OutputSelectedIndexChanged(collateEditor1.lstOutputFiles, new EventArgs());
                filterEditor1_OutputSelectedIndexChanged(filterEditor1.lstOutputFiles, new EventArgs());
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }

        private void BindField<TControl, TModel>
        (
            TControl fieldControl,
            TModel model,
            String modelPropertyName,
            String controlPropertyName = "Text",
            Boolean formattingEnabled = false,
            DataSourceUpdateMode dataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged,
            Boolean reBind = true
        )
            where TControl : Control
        {
            try
            {
                fieldControl.DataBindings.Clear();
                if (reBind)
                {
                    fieldControl.DataBindings.Add(controlPropertyName, model, modelPropertyName, formattingEnabled, dataSourceUpdateMode);
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        /// <summary>
        /// Apply settings to viewer.
        /// </summary>
        private void ApplySettings()
        {
            try
            {
                _ValueChangedProgrammatically = true;

                //apply settings that have databindings
                BindModelUi(SettingsController<Settings>.Settings);

                //apply settings that shouldn't use databindings
                
                //apply settings that can't use databindings
                Text = Path.GetFileName(SettingsController<Settings>.Filename) + " - " + ViewName;
                
                //apply settings that don't have databindings
                ViewModel.DirtyIconIsVisible = (SettingsController<Settings>.Settings.Dirty);

                _ValueChangedProgrammatically = false;
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }

        /// <summary>
        /// Set function button and menu to enable value, and cancel button to opposite.
        /// For now, do only disabling here and leave enabling based on biz logic 
        ///  to be triggered by refresh?
        /// </summary>
        /// <param name="functionButton"></param>
        /// <param name="functionMenu"></param>
        /// <param name="cancelButton"></param>
        /// <param name="enable"></param>
        private void SetFunctionControlsEnable
        (
            Button functionButton,
            ToolStripButton functionToolbarButton,
            ToolStripMenuItem functionMenu,
            Button cancelButton,
            Boolean enable
        )
        {
            try
            {
                //stand-alone button
                if (functionButton != null)
                {
                    functionButton.Enabled = enable;
                }

                //toolbar button
                if (functionToolbarButton != null)
                {
                    functionToolbarButton.Enabled = enable;
                }

                //menu item
                if (functionMenu != null)
                {
                    functionMenu.Enabled = enable;
                }

                //stand-alone cancel button
                if (cancelButton != null)
                {
                    cancelButton.Enabled = !enable;
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        /// <summary>
        /// Invoke any delegate that has been registered 
        ///  to cancel a long-running background process.
        /// </summary>
        private void InvokeActionCancel()
        {
            try
            {
                //execute cancellation hook
                if (cancelDelegate != null)
                {
                    cancelDelegate();
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        /// <summary>
        /// Load from app config; override with command line if present
        /// </summary>
        /// <returns></returns>
        private Boolean LoadParameters()
        {
            Boolean returnValue = default(Boolean);
#if USE_CONFIG_FILEPATH
            String _settingsFilename = default(String);
#endif

            try
            {
                if ((Program.Filename != null) && (Program.Filename != SettingsController<Settings>.FILE_NEW))
                {
                    //got filename from command line
                    //DEBUG:filename coming in is being converted/passed as DOS 8.3 format equivalent
                    if (!RegistryAccess.ValidateFileAssociation(Application.ExecutablePath, "." + /*SettingsController<Settings>.Settings*/Settings.FileTypeExtension))
                    {
                        throw new ApplicationException(String.Format("Settings filename not associated: '{0}'.\nCheck filename on command line.", Program.Filename));
                    }
                    //it passed; use value from command line
                }
                else
                {
#if USE_CONFIG_FILEPATH
                    //get filename from app.config
                    if (!Configuration.ReadString("SettingsFilename", out _settingsFilename))
                    {
                        throw new ApplicationException(String.Format("Unable to load SettingsFilename: {0}", "SettingsFilename"));
                    }
                    if ((_settingsFilename == null) || (_settingsFilename == SettingsController<Settings>.FILE_NEW))
                    {
                        throw new ApplicationException(String.Format("Settings filename not set: '{0}'.\nCheck SettingsFilename in app config file.", _settingsFilename));
                    }
                    //use with the supplied path
                    SettingsController<Settings>.Filename = _settingsFilename;

                    if (Path.GetDirectoryName(_settingsFilename) == String.Empty)
                    {
                        //supply default path if missing
                        SettingsController<Settings>.Pathname = Environment.GetFolderPath(Environment.SpecialFolder.Personal).WithTrailingSeparator();
                    }
#endif
                }

                returnValue = true;
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                //throw;
            }
            return returnValue;
        }

        private void BindSizeAndLocation()
        {
            //Note:Size must be done after InitializeComponent(); do Location this way as well.--SJS
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::TextDataMergeForms.Properties.Settings.Default, "Location", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("ClientSize", global::TextDataMergeForms.Properties.Settings.Default, "Size", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ClientSize = global::TextDataMergeForms.Properties.Settings.Default.Size;
            this.Location = global::TextDataMergeForms.Properties.Settings.Default.Location;
        }
        #endregion Utility
    }
}