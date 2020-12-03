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
    public abstract class TextFunctionBase :
        ITextFunction
    {
        #region Declarations
        protected Boolean disposed = false;

        public const Int32 MinimumColumnLength = 1;
        public const Int32 MinimumColumnIndex = MinimumColumnLength - 1;
        public const Int32 MaximumColumnLength = Int32.MaxValue;
        public const Int32 MaximumColumnIndex = MaximumColumnLength - 1;
        #endregion Declarations

        #region constructors
        public TextFunctionBase()
        {
            try
            {
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }
        #endregion constructors

        #region IDisposable support
        ~TextFunctionBase()
        {
            Dispose(false);
        }

        public virtual void Dispose()
        {
            // dispose of the managed and unmanaged resources
            Dispose(true);

            // tell the GC that the Finalize process no longer needs
            // to be run for this object.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(Boolean disposeManagedResources)
        {
            // process only if mananged and unmanaged resources have
            // not been disposed of.
            if (!this.disposed)
            {
                //Resources not disposed
                if (disposeManagedResources)
                {
                    // dispose managed resources
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

        #region INotifyPropertyChanged support
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String propertyName)
        {
            try
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
#if debug
                    Log.Write(
                        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Module.Name,
                        Log.FormatEntry(String.Format("PropertyChanged: {0}", propertyName), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name),
                        System.Diagnostics.EventLogEntryType.Information,
                            99);
#endif 
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                //throw;
            }
        }
        #endregion INotifyPropertyChanged support

        #region IEquatable<Settings> Members

        /// <summary>
        /// Compare property values of this object to another.
        /// </summary>
        /// <param name="anotherSettings"></param>
        /// <returns></returns>
        public Boolean Equals(TextFunctionBase other)
        {
            Boolean returnValue = default(Boolean);

            try
            {
                if (this.KeyIndexText != other.KeyIndexText)
                {
                    returnValue = false;
                }
                else if (this.KeyLengthText != other.KeyLengthText)
                {
                    returnValue = false;
                }
                else if (this.Descending != other.Descending)
                {
                    returnValue = false;
                }
                else if (this.AllowDuplicates != other.AllowDuplicates)
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
        #endregion IEquatable<Settings> Members

        #region ListChanged handlers
        //void InputFiles_ListChanged(Object sender, ListChangedEventArgs e)
        //{
        //    try
        //    {
        //        this.OnPropertyChanged(String.Format("Collate.InputFiles[{0}].{1}", e.NewIndex, (e.PropertyDescriptor == null ? String.Empty : e.PropertyDescriptor.Name)));
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Write(
        //            ex,
        //            System.Reflection.MethodBase.GetCurrentMethod(),
        //            System.Diagnostics.EventLogEntryType.Error,
        //            99);
        //        throw;
        //    }
        //}

        //void OutputFiles_ListChanged(Object sender, ListChangedEventArgs e)
        //{
        //    try
        //    {
        //        this.OnPropertyChanged(String.Format("Collate.OutputFiles[{0}].{1}", e.NewIndex, (e.PropertyDescriptor == null ? String.Empty : e.PropertyDescriptor.Name)));
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Write(
        //            ex,
        //            System.Reflection.MethodBase.GetCurrentMethod(),
        //            System.Diagnostics.EventLogEntryType.Error,
        //            99);
        //        throw;
        //    }
        //}
        #endregion ListChanged handlers

        #region Properties
        #region NonPersisted Properties
        private String _ErrorMessage = default(String);
        [XmlIgnore]
        public String ErrorMessage
        {
            get { return _ErrorMessage; }
            set { _ErrorMessage = value; }
        }

        private Int32 _KeyIndex = MinimumColumnIndex;
        [XmlIgnore]
        public Int32 KeyIndex
        {
            get { return _KeyIndex; }
            //set { _KeyIndex = value; }
        }

        private Int32 _KeyLength = MaximumColumnLength;
        [XmlIgnore]
        public Int32 KeyLength
        {
            get { return _KeyLength; }
            //set { _KeyLength = value; }
        }

        private Int32 _MaximumKeyLength = MaximumColumnLength;
        [XmlIgnore]
        public Int32 MaximumKeyLength
        {
            get { return _MaximumKeyLength; }
            set { _MaximumKeyLength = value; }
        }
        #endregion NonPersisted Properties

        #region Persisted Properties
        private String _KeyIndexText = String.Empty;
        public String KeyIndexText
        {
            get { return _KeyIndexText; }
            set 
            { 
                _KeyIndexText = value;
                this.OnPropertyChanged("KeyIndexText");
            }
        }

        private String _KeyLengthText = String.Empty;
        public String KeyLengthText
        {
            get { return _KeyLengthText; }
            set 
            { 
                _KeyLengthText = value;
                this.OnPropertyChanged("KeyLengthText");
            }
        }

        private Boolean _Descending = default(Boolean);
        public Boolean Descending
        {
            get { return _Descending; }
            set 
            { 
                _Descending = value;
                this.OnPropertyChanged("Descending");
            }
        }

        private Boolean _AllowDuplicates = default(Boolean);
        public Boolean AllowDuplicates
        {
            get { return _AllowDuplicates; }
            set 
            { 
                _AllowDuplicates = value;
                this.OnPropertyChanged("AllowDuplicates");
            }
        }
        #endregion Persisted Properties
        #endregion Properties

        #region Methods
        /// <summary>
        /// validate settings entered by user
        /// </summary>
        public virtual Boolean Valid()
        {
            Boolean returnValue = default(Boolean);

            try
            {
                ErrorMessage = String.Empty;

                if (_KeyIndexText == null || _KeyIndexText == String.Empty)
                {
                    returnValue = false;
                    ErrorMessage = String.Format("KeyIndex must not be empty.");
                }
                else if (!Int32.TryParse(_KeyIndexText, out _KeyIndex))
                {
                    returnValue = false;
                    ErrorMessage = String.Format("KeyIndex must be numeric.");
                }
                else if (_KeyIndex < 0)
                {
                    returnValue = false;
                    ErrorMessage = String.Format("KeyIndex must be greater than or equal to zero.");
                }
                else if (_KeyLengthText == null || _KeyLengthText == String.Empty)
                {
                    returnValue = false;
                    ErrorMessage = String.Format("KeyLength must not be empty.");
                }
                else if (!Int32.TryParse(_KeyLengthText, out _KeyLength))
                {
                    returnValue = false;
                    ErrorMessage = String.Format("KeyLength must be numeric.");
                }
                else if (_KeyLength < 1)
                {
                    returnValue = false;
                    ErrorMessage = String.Format("KeyLength must be greater than zero.");
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
        /// validate settings determined at the time of the collate
        /// </summary>
        public Boolean Complete()
        {
            Boolean returnValue = default(Boolean);

            try
            {
                ErrorMessage = String.Empty;

                if (!Valid())
                {
                    returnValue = false;
                    //ErrorMessage = String.Format("");
                }
                else if (_MaximumKeyLength < 1)
                {
                    returnValue = false;
                    ErrorMessage = String.Format("MaximumKeyLength must be greater than zero.");
                }
                else if ((_KeyIndex + _KeyLength - 1) > _MaximumKeyLength)
                {
                    returnValue = false;
                    ErrorMessage = String.Format("Start Index '{0}' and Column Length '{1}' will exceed key maximum '{2}'.", _KeyIndex, _KeyLength, _MaximumKeyLength);
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
        public abstract Boolean AddInputFile(String filePath);

        /// <summary>
        /// Remove a file from input list
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public abstract Boolean RemoveInputFile(String filePath);

        /// <summary>
        /// Add a file to output list
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public abstract Boolean AddOutputFile(String filePath);

        /// <summary>
        /// Remove a file from output list
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public abstract Boolean RemoveOutputFile(String filePath);

        /// <summary>
        /// Execute feature.
        /// </summary>
        /// <returns></returns>
        public abstract Boolean Run();

        /// <summary>
        /// Add a file to list
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list">EquatableBindingList Of DataFile or ConditionedDataFile</param>
        /// <param name="dataFile"></param>
        /// <param name="singleFile"></param>
        /// <returns></returns>
        protected Boolean AddFile<T>(String filePath, EquatableBindingList<T> list, T dataFile, Boolean singleFile) 
            where T : DataFile, IEquatable<T>
        {
            Boolean returnValue = default(Boolean);

            try
            {
                //verify file and add 
                if (File.Exists(filePath))
                {
                    //check for duplicates first
                    if (!list.Contains(list.Find(df => df.Path == filePath)))
                    {
                        if (singleFile)
                        {
                            //is sole entry in list
                            list.Clear();
                        }
                        list.Add(dataFile);
                    }
                    else
                    {
                        throw new ApplicationException(String.Format("File already present: {0}", filePath));
                    }
                }
                else
                {
                    throw new ApplicationException(String.Format("File does not exist: {0}", filePath));
                }

                returnValue = true;
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
            return returnValue;
        }

        /// <summary>
        /// Remove a file from list
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list">EquatableBindingList Of DataFile or ConditionedDataFile</param>
        /// <returns></returns>
        protected Boolean RemoveFile<T>(String filePath, EquatableBindingList<T> list) 
            where T : DataFile, IEquatable<T>
        {
            Boolean returnValue = default(Boolean);
            try
            {
                returnValue = list.Remove(list.Find(df => df.Path == filePath));
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
