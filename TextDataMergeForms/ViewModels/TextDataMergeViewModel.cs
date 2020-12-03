using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Ssepan.Utility;
using Ssepan.Application;
using Ssepan.Application.WinForms;
using Ssepan.Collections;
using Ssepan.Io;
using TextDataMergeLibrary;

namespace TextDataMergeForms
{
    /// <summary>
    /// Note: it is not necessary to make this subclass take type parameters.
    /// </summary>
    public class TextDataMergeViewModel :
        FormsViewModel<Bitmap, Settings, TDMModel, TextDataMergeViewer>
    {
        #region Declarations
        private const Int32 INDEX_NOTSELECTED = -1;
        protected static FileDialogInfo _dataFileDialogInfo = default(FileDialogInfo);

        #region Commands
        //public ICommand FileNewCommand { get; private set; }
        //public ICommand FileOpenCommand { get; private set; }
        //public ICommand FileSaveCommand { get; private set; }
        //public ICommand FileSaveAsCommand { get; private set; }
        //public ICommand FilePrintCommand { get; private set; }
        //public ICommand FileExitCommand { get; private set; }
        //public ICommand EditCopyToClipboardCommand { get; private set; }
        //public ICommand EditPropertiesCommand { get; private set; }
        //public ICommand ViewPreviousMonthCommand { get; private set; }
        //public ICommand ViewPreviousWeekCommand { get; private set; }
        //public ICommand ViewNextWeekCommand { get; private set; }
        //public ICommand ViewNextMonthCommand { get; private set; }
        //public ICommand HelpAboutCommand { get; private set; }
        #endregion Commands
        #endregion Declarations

        #region Constructors
        public TextDataMergeViewModel() { }//Note: not called, but need to be present to compile--SJS

        public TextDataMergeViewModel
        (
            PropertyChangedEventHandler propertyChangedEventHandlerDelegate,
            Dictionary<String, Bitmap> actionIconImages,
            FileDialogInfo settingsFileDialogInfo,
            FileDialogInfo dataFileDialogInfo //this param must be assigned in this ctor
        ) :
            base(propertyChangedEventHandlerDelegate, actionIconImages, settingsFileDialogInfo)
        {
            try
            {
                _dataFileDialogInfo = dataFileDialogInfo;
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }
        #endregion Constructors

        #region Properties
        #endregion Properties

        #region Methods
        #region Collate Events
        internal void CollateInputAdd()
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                //OPEN
                _dataFileDialogInfo.Filename = _dataFileDialogInfo.NewFilename;
                _dataFileDialogInfo.Multiselect = false;
                if (FileDialogInfo.GetPathForLoad(_dataFileDialogInfo))
                {
                    StartProgressBar
                    (
                        "Selecting...", 
                        null, 
                        _actionIconImages["Open"],
                        true,
                        33
                    );

                    foreach (String filePath in _dataFileDialogInfo.Filenames)
                    {
                        if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Collate.AddInputFile, filePath))
                        {
                            throw new ApplicationException(String.Format("Unable to add input file: {0}", filePath));
                        }
                    }

                    StopProgressBar("Selected.");
                }
                else
                {
                    StopProgressBar("Selection cancelled.");
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void CollateInputDelete(ListBox listBox)
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                //delete only item
                if (listBox.Items.Count > 0)
                {
                    listBox.SelectedIndex = 0;
                }
                if (listBox.SelectedIndex != INDEX_NOTSELECTED)
                {
                    if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Collate.RemoveInputFile, listBox.Text))
                    {
                        throw new ApplicationException(String.Format("Unable to remove input file: '{0}'", listBox.Text));
                    }

                    StopProgressBar("Input file removed.");
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void CollateInputKeyUp(ListBox listBox, Keys keyCode)
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                if (keyCode == Keys.Delete)
                {
                    //delete only item
                    if (listBox.Items.Count > 0)
                    {
                        listBox.SelectedIndex = 0;
                    }
                    if (listBox.SelectedIndex != INDEX_NOTSELECTED)
                    {
                        if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Collate.RemoveInputFile, listBox.Text))
                        {
                            throw new ApplicationException(String.Format("Unable to remove input file: '{0}'", listBox.Text));
                        }
                    
                        StopProgressBar("Input file removed");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void CollateOutputAdd()
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                //SAVE
                _dataFileDialogInfo.Filename = _dataFileDialogInfo.NewFilename;
                if (FileDialogInfo.GetPathForSave(_dataFileDialogInfo, false))
                {
                    StartProgressBar("Selecting...", "", _actionIconImages["Open"], true, 33);

                    foreach (String filePath in _dataFileDialogInfo.Filenames)
                    {
                        if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Collate.AddOutputFile, filePath))
                        {
                            throw new ApplicationException(String.Format("Unable to add output file: {0}", filePath));
                        }
                    }

                    StopProgressBar("Selected.");
                }
                else
                {
                    StopProgressBar("Selection cancelled.");
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void CollateOutputDelete(ListBox listBox)
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                if (listBox.SelectedIndex != INDEX_NOTSELECTED)
                {
                    if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Collate.RemoveOutputFile, listBox.Text))
                    {
                        throw new ApplicationException(String.Format("Unable to remove output file: '{0}'", listBox.Text));
                    }

                    StopProgressBar("Output file removed.");
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void CollateOutputKeyUp(ListBox listBox, Keys keyCode)
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                if (keyCode == Keys.Delete)
                {
                    if (listBox.SelectedIndex != INDEX_NOTSELECTED)
                    {
                        String filename = listBox.Text;

                        if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Collate.RemoveOutputFile, listBox.Text))
                        {
                            throw new ApplicationException(String.Format("Unable to remove output file: '{0}'", filename));
                        }
                    
                        StopProgressBar("Output file removed");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void CollateOutputIndexSelected(TextDataFunctionControls.CollateEditor collateEditor)
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                ListBox listBox = collateEditor.lstOutputFiles;
                if (listBox.SelectedIndex != INDEX_NOTSELECTED)
                {
                    //bind condition
                    Condition condition = (Condition)SettingsController<Settings>.Settings.Collate.OutputFiles.Find(cf => cf.Path == listBox.Text).Criterion;
                    collateEditor.BindConditionUi(condition);
                }
                else
                {
                    //unbind condition
                    collateEditor.BindConditionUi(null);
                }
                
                StopProgressBar("Selection updated.");
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void CollateRun()
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                StartProgressBar("Collating...", "", _actionIconImages["Save"], true, 33);

                if (!SettingsController<Settings>.Settings.Collate.Run())
                {
                    throw new ApplicationException(String.Format("Unable to Collate: {0}", SettingsController<Settings>.Settings.Collate.ErrorMessage));
                }

                StopProgressBar("Collated.");
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }
        #endregion Collate Events

        #region Filter Events
        internal void FilterInputAdd()
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                //OPEN
                _dataFileDialogInfo.Filename = _dataFileDialogInfo.NewFilename;
                _dataFileDialogInfo.Multiselect = false;
                if (FileDialogInfo.GetPathForLoad(_dataFileDialogInfo))
                {
                    StartProgressBar("Selecting...", "", _actionIconImages["Open"], true, 33);

                    foreach (String filePath in _dataFileDialogInfo.Filenames)
                    {
                        if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Filter.AddInputFile, filePath))
                        {
                            throw new ApplicationException(String.Format("Unable to add input file: {0}", filePath));
                        }
                    }

                    StopProgressBar("Selected.");
                }
                else
                {
                    StopProgressBar("Selection cancelled.");
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void FilterInputDelete(ListBox listBox)
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                //delete only item
                if (listBox.Items.Count > 0)
                {
                    listBox.SelectedIndex = 0;
                }
                if (listBox.SelectedIndex != INDEX_NOTSELECTED)
                {
                    if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Filter.RemoveInputFile, listBox.Text))
                    {
                        throw new ApplicationException(String.Format("Unable to remove input file: '{0}'", listBox.Text));
                    }

                    StopProgressBar("Input file removed.");
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void FilterInputKeyUp(ListBox listBox, Keys keyCode)
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                if (keyCode == Keys.Delete)
                {
                    //delete only item
                    if (listBox.Items.Count > 0)
                    {
                        listBox.SelectedIndex = 0;
                    }
                    if (listBox.SelectedIndex != INDEX_NOTSELECTED)
                    {
                        if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Filter.RemoveInputFile, listBox.Text))
                        {
                            throw new ApplicationException(String.Format("Unable to remove input file: '{0}'", listBox.Text));
                        }

                        StopProgressBar("Input file removed");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void FilterOutputAdd()
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                //SAVE
                _dataFileDialogInfo.Filename = _dataFileDialogInfo.NewFilename;
                if (FileDialogInfo.GetPathForSave(_dataFileDialogInfo))
                {
                    StartProgressBar("Selecting...", "", _actionIconImages["Open"], true, 33);

                    foreach (String filePath in _dataFileDialogInfo.Filenames)
                    {
                        if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Filter.AddOutputFile, filePath))
                        {
                            throw new ApplicationException(String.Format("Unable to add output file: {0}", filePath));
                        }
                    }

                    StopProgressBar("Selected.");
                }
                else
                {
                    StopProgressBar("Selection cancelled.");
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void FilterOutputDelete(ListBox listBox)
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                //delete only item
                if (listBox.Items.Count > 0)
                {
                    listBox.SelectedIndex = 0;
                }
                if (listBox.SelectedIndex != INDEX_NOTSELECTED)
                {
                    if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Filter.RemoveOutputFile, listBox.Text))
                    {
                        throw new ApplicationException(String.Format("Unable to remove output file: '{0}'", listBox.Text));
                    }

                    StopProgressBar("Output file removed.");
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void FilterOutputKeyUp(ListBox listBox, Keys keyCode)
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                if (keyCode == Keys.Delete)
                {
                    //delete only item
                    if (listBox.Items.Count > 0)
                    {
                        listBox.SelectedIndex = 0;
                    }
                    if (listBox.SelectedIndex != INDEX_NOTSELECTED)
                    {
                        if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Filter.RemoveOutputFile, listBox.Text))
                        {
                            throw new ApplicationException(String.Format("Unable to remove output file: '{0}'", listBox.Text));
                        }

                        StopProgressBar("Output file removed");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void FilterOutputIndexSelected(TextDataFunctionControls.FilterEditor filterEditor)
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                ListBox listBox = filterEditor.lstOutputFiles;
                if (listBox.SelectedIndex != INDEX_NOTSELECTED)
                {
                    //bind condition
                    Condition condition = (Condition)SettingsController<Settings>.Settings.Filter.OutputFiles.Find(cf => cf.Path == listBox.Text).Criterion;
                    filterEditor.BindConditionUi(condition);
                }
                else
                {
                    //unbind condition
                    filterEditor.BindConditionUi(null);
                }

                StopProgressBar("Selection updated.");
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void FilterRun()
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                StartProgressBar("Filtering...", "", _actionIconImages["Save"], true, 33);

                if (!SettingsController<Settings>.Settings.Filter.Run())
                {
                    throw new ApplicationException(String.Format("Unable to Filter: {0}", SettingsController<Settings>.Settings.Filter.ErrorMessage));
                }

                StopProgressBar("Filtered.");
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
            finally
            {
            }
        }
        #endregion Filter Events

        #region Merge Events
        internal void MergeInputAdd()
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                //OPEN
                _dataFileDialogInfo.Filename = _dataFileDialogInfo.NewFilename;
                _dataFileDialogInfo.Multiselect = true;
                if (FileDialogInfo.GetPathForLoad(_dataFileDialogInfo))
                {
                    StartProgressBar("Selecting...", "", _actionIconImages["Open"], true, 33);

                    foreach (String filePath in _dataFileDialogInfo.Filenames)
                    {
                        if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Merge.AddInputFile, filePath))
                        {
                            throw new ApplicationException(String.Format("Unable to add input file: {0}", filePath));
                        }
                    }

                    StopProgressBar("Selected.");
                }
                else
                {
                    StopProgressBar("Selection cancelled.");
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void MergeInputDelete(ListBox listBox)
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                if (listBox.SelectedIndex != INDEX_NOTSELECTED)
                {
                    if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Merge.RemoveInputFile, listBox.Text))
                    {
                        throw new ApplicationException(String.Format("Unable to remove input file: '{0}'", listBox.Text));
                    }

                    StopProgressBar("Input file removed.");
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void MergeInputKeyUp(ListBox listBox, Keys keyCode)
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                if (keyCode == Keys.Delete)
                {
                    if (listBox.SelectedIndex != INDEX_NOTSELECTED)
                    {
                        if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Merge.RemoveInputFile, listBox.Text))
                        {
                            throw new ApplicationException(String.Format("Unable to remove input file: '{0}'", listBox.Text));
                        }

                        StopProgressBar("Input file removed");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void MergeOutputAdd()
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                //SAVE
                _dataFileDialogInfo.Filename = _dataFileDialogInfo.NewFilename;
                if (FileDialogInfo.GetPathForSave(_dataFileDialogInfo, false))
                {
                    StartProgressBar("Selecting...", "", _actionIconImages["Save"], true, 33);

                    foreach (String filePath in _dataFileDialogInfo.Filenames)
                    {
                        if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Merge.AddOutputFile, filePath))
                        {
                            throw new ApplicationException(String.Format("Unable to add output file: {0}", filePath));
                        }
                    }

                    StopProgressBar("Selected.");
                }
                else
                {
                    StopProgressBar("Selection cancelled.");
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void MergeOutputDelete(ListBox listBox)
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                //delete only item
                if (listBox.Items.Count > 0)
                {
                    listBox.SelectedIndex = 0;
                }
                if (listBox.SelectedIndex != INDEX_NOTSELECTED)
                {
                    if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Merge.RemoveOutputFile, listBox.Text))
                    {
                        throw new ApplicationException(String.Format("Unable to remove output file: '{0}'", listBox.Text));
                    }

                    StopProgressBar("Output file removed.");
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void MergeOutputKeyUp(ListBox listBox, Keys keyCode)
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                if (keyCode == Keys.Delete)
                {
                    //delete only item
                    if (listBox.Items.Count > 0)
                    {
                        listBox.SelectedIndex = 0;
                    }
                    if (listBox.SelectedIndex != INDEX_NOTSELECTED)
                    {
                        if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Merge.RemoveOutputFile, listBox.Text))
                        {
                            throw new ApplicationException(String.Format("Unable to remove output file: '{0}'", listBox.Text));
                        }

                        StopProgressBar("Output file removed");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void MergeRun()
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                StartProgressBar("Merging...", "", _actionIconImages["Save"], true, 33);

                if (!SettingsController<Settings>.Settings.Merge.Run())
                {
                    throw new ApplicationException(String.Format("Unable to Merge: {0}", SettingsController<Settings>.Settings.Merge.ErrorMessage));
                }

                StopProgressBar("Merged.");
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }
        #endregion Merge Events

        #region Sort Events
        internal void SortInputAdd()
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                //OPEN
                _dataFileDialogInfo.Filename = _dataFileDialogInfo.NewFilename;
                _dataFileDialogInfo.Multiselect = false;
                if (FileDialogInfo.GetPathForLoad(_dataFileDialogInfo))
                {
                    StartProgressBar("Selecting...", "", _actionIconImages["Open"], true, 33);

                    foreach (String filePath in _dataFileDialogInfo.Filenames)
                    {
                        if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Sort.AddInputFile, filePath))
                        {
                            throw new ApplicationException(String.Format("Unable to add input file: {0}", filePath));
                        }
                    }

                    StopProgressBar("Selected.");
                }
                else
                {
                    StopProgressBar("Selection cancelled.");
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void SortInputDelete(ListBox listBox)
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                //delete only item
                if (listBox.Items.Count > 0)
                {
                    listBox.SelectedIndex = 0;
                }
                if (listBox.SelectedIndex != INDEX_NOTSELECTED)
                {
                    if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Sort.RemoveInputFile, listBox.Text))
                    {
                        throw new ApplicationException(String.Format("Unable to remove input file: '{0}'", listBox.Text));
                    }

                    StopProgressBar("Input file removed.");
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void SortInputKeyUp(ListBox listBox, Keys keyCode)
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                if (keyCode == Keys.Delete)
                {
                    //delete only item
                    if (listBox.Items.Count > 0)
                    {
                        listBox.SelectedIndex = 0;
                    }
                    if (listBox.SelectedIndex != INDEX_NOTSELECTED)
                    {
                        if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Sort.RemoveInputFile, listBox.Text))
                        {
                            throw new ApplicationException(String.Format("Unable to remove input file: '{0}'", listBox.Text));
                        }

                        StopProgressBar("Input file removed");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void SortOutputAdd()
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                //SAVE
                _dataFileDialogInfo.Filename = _dataFileDialogInfo.NewFilename;
                if (FileDialogInfo.GetPathForSave(_dataFileDialogInfo, false))
                {
                    StartProgressBar("Selecting...", "", _actionIconImages["Save"], true, 33);

                    foreach (String filePath in _dataFileDialogInfo.Filenames)
                    {
                        if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Sort.AddOutputFile, filePath))
                        {
                            throw new ApplicationException(String.Format("Unable to add output file: {0}", filePath));
                        }
                    }

                    StopProgressBar("Selected.");
                }
                else
                {
                    StopProgressBar("Selection cancelled.");
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void SortOutputDelete(ListBox listBox)
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                //delete only item
                if (listBox.Items.Count > 0)
                {
                    listBox.SelectedIndex = 0;
                }
                if (listBox.SelectedIndex != INDEX_NOTSELECTED)
                {
                    if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Sort.RemoveOutputFile, listBox.Text))
                    {
                        throw new ApplicationException(String.Format("Unable to remove output file: '{0}'", listBox.Text));
                    }

                    StopProgressBar("Output file removed.");
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void SortOutputKeyUp(ListBox listBox, Keys keyCode)
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                if (keyCode == Keys.Delete)
                {
                    //delete only item
                    if (listBox.Items.Count > 0)
                    {
                        listBox.SelectedIndex = 0;
                    }
                    if (listBox.SelectedIndex != INDEX_NOTSELECTED)
                    {
                        if (!TextDataMergeController<TDMModel>.AddRemoveFile(SettingsController<Settings>.Settings.Sort.RemoveOutputFile, listBox.Text))
                        {
                            throw new ApplicationException(String.Format("Unable to remove output file: '{0}'", listBox.Text));
                        }

                        StopProgressBar("Output file removed");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        internal void SortRun()
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                StartProgressBar("Sorting...", "", _actionIconImages["Save"], true, 33);

                if (!SettingsController<Settings>.Settings.Sort.Run())
                {
                    throw new ApplicationException(String.Format("Unable to Sort: {0}", SettingsController<Settings>.Settings.Sort.ErrorMessage));
                }

                StopProgressBar("Sorted.");
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }
        #endregion Sort Events
        #endregion Methods
    }
}
