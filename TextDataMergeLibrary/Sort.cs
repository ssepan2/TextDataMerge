using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Ssepan.Collections;
using Ssepan.Utility;
using System.Diagnostics;
using System.Reflection;

namespace TextDataMergeLibrary
{
    [Serializable()]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Sort :
        TextFunctionBase
    {
        #region Declarations
        #endregion Declarations

        #region constructors
        public Sort()
        {
            try
            {
                if (InputFiles != null)
                {
                    InputFiles.ListChanged += new ListChangedEventHandler(InputFiles_ListChanged);
                }
                if (OutputFiles != null)
                {
                    OutputFiles.ListChanged += new ListChangedEventHandler(OutputFiles_ListChanged);
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }
        #endregion constructors

        #region IDisposable support
        ~Sort()
        {
            Dispose(false);
        }

        public override void Dispose()
        {
            // dispose of the managed and unmanaged resources
            Dispose(true);

            // tell the GC that the Finalize process no longer needs
            // to be run for this object.
            GC.SuppressFinalize(this);
        }

        protected override void Dispose(Boolean disposeManagedResources)
        {
            // process only if mananged and unmanaged resources have
            // not been disposed of.
            if (!this.disposed)
            {
                //Resources not disposed
                if (disposeManagedResources)
                {
                    // dispose managed resources
                    if (InputFiles != null)
                    {
                        InputFiles.ListChanged -= new ListChangedEventHandler(InputFiles_ListChanged);
                    }
                    if (OutputFiles != null)
                    {
                        OutputFiles.ListChanged -= new ListChangedEventHandler(OutputFiles_ListChanged);
                    }
                }
                // dispose unmanaged resources
                disposed = true;
            }
            else
            {
                //Resources already disposed
            }
        }
        #endregion

        #region IEquatable<T> Members
        /// <summary>
        /// Compare property values of this object to another.
        /// </summary>
        /// <param name="anotherSettings"></param>
        /// <returns></returns>
        public Boolean Equals(Sort other)
        {
            Boolean returnValue = default(Boolean);

            try
            {
                if (!base.Equals((other as TextFunctionBase)))
                {
                    returnValue = false;
                }
                else if (!this.InputFiles.Equals(other.InputFiles))
                {
                    returnValue = false;
                }
                else if (!this.OutputFiles.Equals(other.OutputFiles))
                {
                    returnValue = false;
                }
                else
                {
                    returnValue = true;
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }

            return returnValue;
        }
        #endregion IEquatable<T> Members

        #region ListChanged handlers
        void InputFiles_ListChanged(Object sender, ListChangedEventArgs e)
        {
            try
            {
                this.OnPropertyChanged(String.Format("Sort.InputFiles[{0}].{1}", e.NewIndex, (e.PropertyDescriptor == null ? String.Empty : e.PropertyDescriptor.Name)));
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        void OutputFiles_ListChanged(Object sender, ListChangedEventArgs e)
        {
            try
            {
                this.OnPropertyChanged(String.Format("Sort.OutputFiles[{0}].{1}", e.NewIndex, (e.PropertyDescriptor == null ? String.Empty : e.PropertyDescriptor.Name)));
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }
        #endregion ListChanged handlers

        #region Properties
        #region NonPersisted Properties
        #endregion NonPersisted Properties

        #region Persisted Properties
        private EquatableBindingList<DataFile> _InputFiles = new EquatableBindingList<DataFile>();
        public EquatableBindingList<DataFile> InputFiles
        {
            get { return _InputFiles; }
            set
            {
                if (InputFiles != null)
                {
                    InputFiles.ListChanged -= new ListChangedEventHandler(InputFiles_ListChanged);
                }
                _InputFiles = value;
                if (InputFiles != null)
                {
                    InputFiles.ListChanged += new ListChangedEventHandler(InputFiles_ListChanged);
                }
                this.OnPropertyChanged("InputFiles");
            }
        }

        private EquatableBindingList<DataFile> _OutputFiles = new EquatableBindingList<DataFile>();
        public EquatableBindingList<DataFile> OutputFiles
        {
            get { return _OutputFiles; }
            set
            {
                if (OutputFiles != null)
                {
                    OutputFiles.ListChanged -= new ListChangedEventHandler(OutputFiles_ListChanged);
                }
                _OutputFiles = value;
                if (OutputFiles != null)
                {
                    OutputFiles.ListChanged += new ListChangedEventHandler(OutputFiles_ListChanged);
                }
                this.OnPropertyChanged("OutputFiles");
            }
        }
        #endregion Persisted Properties
        #endregion Properties

        #region Methods
        /// <summary>
        /// validate settings entered by user
        /// </summary>
        public override Boolean Valid()
        {
            Boolean returnValue = default(Boolean);

            try
            {
                ErrorMessage = String.Empty;

                if (!base.Valid())
                {
                    returnValue = false;
                    //ErrorMessage = String.Format("...");
                }
                else if (_InputFiles.Count != 1)
                {
                    returnValue = false;
                    ErrorMessage = String.Format("InputFiles must contain one file.");
                }
                else if (_OutputFiles.Count != 1)
                {
                    returnValue = false;
                    ErrorMessage = String.Format("OutputFiles must contain one file.");
                }
                else
                {
                    returnValue = true;
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }

            return returnValue;
        }

        /// <summary>
        /// Add a file to input list
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public override Boolean AddInputFile(String filePath)
        {
            Boolean returnValue = default(Boolean);
            try
            {
                returnValue = AddFile<DataFile>(filePath, this.InputFiles, new DataFile(filePath), true);
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
            return returnValue;
        }

        /// <summary>
        /// Remove a file from input list
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public override Boolean RemoveInputFile(String filePath)
        {
            Boolean returnValue = default(Boolean);
            try
            {
                returnValue = RemoveFile<DataFile>(filePath, this.InputFiles);
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
            return returnValue;
        }

        /// <summary>
        /// Add a file to output list
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public override Boolean AddOutputFile(String filePath)
        {
            Boolean returnValue = default(Boolean);
            try
            {
                returnValue = AddFile<DataFile>(filePath, this.OutputFiles, new DataFile(filePath), true);
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
            return returnValue;
        }

        /// <summary>
        /// Remove a file from output list
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public override Boolean RemoveOutputFile(String filePath)
        {
            Boolean returnValue = default(Boolean);
            try
            {
                returnValue = RemoveFile<DataFile>(filePath, this.OutputFiles);
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
            return returnValue;
        }

        /// <summary>
        /// Execute feature.
        /// </summary>
        /// <returns></returns>
        public override Boolean Run()
        {
            Boolean returnValue = default(Boolean);
            Int32 maximumLength = Int32.MaxValue;

            try
            {
                //validate settings entered by user
                if (!this.Valid())
                {
                    throw new ApplicationException(String.Format("{0}", this.ErrorMessage));
                }

                // Build list 
                List<String> strings = new List<String>();
                foreach (DataFile item in this.InputFiles)
                {
                    TextDataMergeController<TDMModel>.ReadFileData(item.Path, ref strings, ref maximumLength);
                }

                //validate settings determined at the time of the merge
                this.MaximumKeyLength = maximumLength;
                if (!this.Complete())
                {
                    throw new ApplicationException(String.Format("{0}", this.ErrorMessage));
                }

                //sort by control values
                strings.Sort((IComparer<String>)new KeyedStringComparer(this.KeyIndex, this.KeyLength, this.Descending));

                //write out results
                TextDataMergeController<TDMModel>.WriteFileData(this.OutputFiles[0].Path, strings);

                returnValue = true;
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
            return returnValue;
        }
        #endregion Methods
    }
}
