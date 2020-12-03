using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Ssepan.Utility;
using System.Diagnostics;
using System.Reflection;

namespace TextDataMergeLibrary
{
    /// <summary>
    /// Like DataFile, but with a Condition attached.
    /// Does not use inheritance, due to serialization problems.
    /// </summary>
    [Serializable()]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ConditionedDataFile :
        DataFile,
        IEquatable<ConditionedDataFile>
    {
        #region declarations
        #endregion declarations

        #region constructors
        public ConditionedDataFile()
        {
            try
            {
                if (Criterion != null)
                {
                    Criterion.PropertyChanged += new PropertyChangedEventHandler(Criterion_PropertyChanged);
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }

        public ConditionedDataFile(String path, Condition criterion)
        {
            try
            {
                Path = path;
                Criterion = criterion;

                if (Criterion != null)
                {
                    Criterion.PropertyChanged += new PropertyChangedEventHandler(Criterion_PropertyChanged);
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }
        #endregion constructors

        #region IDisposable support
        ~ConditionedDataFile()
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
                    if (Criterion != null)
                    {
                        Criterion.PropertyChanged -= new PropertyChangedEventHandler(Criterion_PropertyChanged);
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

        #region IEquatable<ConditionedDataFile> Members
        public bool Equals(ConditionedDataFile other)
        {
            Boolean returnValue = default(Boolean);

            try
            {
                if (!base.Equals(other))
                {
                    returnValue = false;
                }
                else if (!this.Criterion.Equals(other.Criterion))
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
        #endregion IEquatable<DataFile> Members

        #region PropertyChanged handlers
        void Criterion_PropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            try
            {
                ////MessageBox.Show(String.Format("Collate.{0} was changed: ", e.PropertyName /*, (sender as Collate).SomeProperty*/));
                this.OnPropertyChanged(String.Format("Criterion.{0}", e.PropertyName));

            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }
        #endregion PropertyChanged handlers

        #region Persisted Properties
        private Condition _Criterion = default(Condition);
        public Condition Criterion
        {
            get { return _Criterion; }
            set 
            {
                if (Criterion != null)
                {
                    Criterion.PropertyChanged -= new PropertyChangedEventHandler(Criterion_PropertyChanged);
                }
                _Criterion = value;
                if (Criterion != null)
                {
                    Criterion.PropertyChanged += new PropertyChangedEventHandler(Criterion_PropertyChanged);
                }
                this.OnPropertyChanged("Criterion");
            }
        }
        #endregion Persisted Properties
    }
}
