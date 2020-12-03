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
    [Serializable()]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class DataFile :
        IDisposable,
        IEquatable<DataFile>,
        INotifyPropertyChanged
    {
        #region declarations
        protected Boolean disposed = false;
        #endregion declarations

        #region constructors
        public DataFile()
        { 
        }

        public DataFile(String path)
        {
            Path = path;
        }
        #endregion constructors

        #region IDisposable support
        ~DataFile()
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

        #region IEquatable<DataFile> Members
        public virtual bool Equals(DataFile other)
        {
            Boolean returnValue = default(Boolean);

            try
            {
                if (!this.Path.Equals(other.Path))
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

        #region Persisted Properties
        private String _Path = default(String);
        public String Path
        {
            get { return _Path; }
            set 
            { 
                _Path = value;
                this.OnPropertyChanged("Path");
            }
        }
        #endregion Persisted Properties
    }
}
