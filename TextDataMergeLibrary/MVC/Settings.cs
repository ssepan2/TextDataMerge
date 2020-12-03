using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using Ssepan.Application;
using Ssepan.Utility;

namespace TextDataMergeLibrary
{
	/// <summary>
    /// persisted settings; run-time model depends on this
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class Settings :
        SettingsBase
    {
        #region Declarations
        private const String FILE_TYPE_EXTENSION = "textdatamerge"; //"xml";
        private const String FILE_TYPE_NAME = "textdatamergefile";
        private const String FILE_TYPE_DESCRIPTION = "TextDataMerge Settings File";
        #endregion Declarations

        #region Constructors
        public Settings()
		{
            try
            {
                FileTypeExtension = FILE_TYPE_EXTENSION;
                FileTypeName = FILE_TYPE_NAME;
                FileTypeDescription = FILE_TYPE_DESCRIPTION;
                SerializeAs = SerializationFormat.Xml;//default

                if (Collate != null)
                {
                    Collate.PropertyChanged += new PropertyChangedEventHandler(Collate_PropertyChanged);
                }
                if (Filter != null)
                {
                    Filter.PropertyChanged += new PropertyChangedEventHandler(Filter_PropertyChanged);
                }
                if (Merge != null)
                {
                    Merge.PropertyChanged += new PropertyChangedEventHandler(Merge_PropertyChanged);
                }
                if (Sort != null)
                {
                    Sort.PropertyChanged += new PropertyChangedEventHandler(Sort_PropertyChanged);
                }

            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }
        #endregion Constructors

        #region IDisposable support
        ~Settings()
        {
            Dispose(false);
        }

        //inherited; override if additional cleanup needed
        protected override void Dispose(Boolean disposeManagedResources)
        {//TODO:debug stack overflow on dispose--SJS
            // process only if mananged and unmanaged resources have
            // not been disposed of.
            if (!disposed)
            {
                try
                {
                    //Resources not disposed
                    if (disposeManagedResources)
                    {
                        // dispose managed resources
                        if (Collate != null)
                        {
                            Collate.PropertyChanged -= new PropertyChangedEventHandler(Collate_PropertyChanged);
                        }
                        if (Filter != null)
                        {
                            Filter.PropertyChanged -= new PropertyChangedEventHandler(Filter_PropertyChanged);
                        }
                        if (Merge != null)
                        {
                            Merge.PropertyChanged -= new PropertyChangedEventHandler(Merge_PropertyChanged);
                        }
                        if (Sort != null)
                        {
                            Sort.PropertyChanged -= new PropertyChangedEventHandler(Sort_PropertyChanged);
                        }
                    }

                    disposed = true;
                }
                finally
                {
                    // dispose unmanaged resources
                    base.Dispose(disposeManagedResources);
                }
            }
            else
            {
                //Resources already disposed
            }
        }
        #endregion

        #region IEquatable<ISettings>
        /// <summary>
        /// Compare property values of two specified Settings objects.
        /// </summary>
        /// <param name="anotherSettings"></param>
        /// <returns></returns>
        public override Boolean Equals(ISettingsComponent other)
        {
            Boolean returnValue = default(Boolean);
            Settings otherSettings = default(Settings);

            try
            {
                otherSettings = other as Settings;

                if (this == otherSettings)
                {
                    returnValue = true;
                }
                else
                {
                    if (!base.Equals(other))
                    {
                        returnValue = false;
                    }
                    else if (!this.Collate.Equals(otherSettings.Collate))
                    {
                        returnValue = false;
                    }
                    else if (!this.Filter.Equals(otherSettings.Filter))
                    {
                        returnValue = false;
                    }
                    else if (!this.Merge.Equals(otherSettings.Merge))
                    {
                        returnValue = false;
                    }
                    else if (!this.Sort.Equals(otherSettings.Sort))
                    {
                        returnValue = false;
                    }
                    else
                    {
                        returnValue = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }

            return returnValue;
        }
        #endregion IEquatable<ISettings>

        #region PropertyChanged handlers
        void Collate_PropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            try
            {
                this.OnPropertyChanged(String.Format("Collate.{0}", e.PropertyName));

            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }
        void Filter_PropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            try
            {
                this.OnPropertyChanged(String.Format("Filter.{0}", e.PropertyName));

            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }
        void Merge_PropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            try
            {
                this.OnPropertyChanged(String.Format("Merge.{0}", e.PropertyName));

            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }
        void Sort_PropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            try
            {
                this.OnPropertyChanged(String.Format("Sort.{0}", e.PropertyName));

            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }
        #endregion PropertyChanged handlers

        #region Properties
        [XmlIgnore]
        public override Boolean Dirty
        {
            get
            {
                Boolean returnValue = default(Boolean);

                try
                {
                    if (base.Dirty)
                    {
                        returnValue = true;
                    }
                    else if (_Version != __Version)
                    {
                        returnValue = true;
                    }
                    else if (!_Collate.Equals(__Collate))
                    {
                        returnValue = true;
                    }
                    else if (!_Filter.Equals(__Filter))
                    {
                        returnValue = true;
                    }
                    else if (!_Merge.Equals(__Merge))
                    {
                        returnValue = true;
                    }
                    else if (!_Sort.Equals(__Sort))
                    {
                        returnValue = true;
                    }
                    else
                    {
                        returnValue = false;
                    }
                }
                catch (Exception ex)
                {
                    Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                    throw;
                }

                return returnValue;
            }
        }

        private String __Version = String.Empty;
        private String _Version = String.Empty;
        //[DataObjectFieldAttribute(false, false, false)]
        [ReadOnly(true)]
        [DescriptionAttribute("Application major version"),
        CategoryAttribute("Misc"),
        DefaultValueAttribute(null)]
        public String Version
        {
            get { return _Version; }
            set
            {
                _Version = value;
                this.OnPropertyChanged("Version");
            }
        }

        /// <summary>
        /// Determines the viewer window size.
        /// </summary>
        private System.Drawing.Size __Size = new Size(546, 769);
        private System.Drawing.Size _Size = new Size(546, 769);
        [DescriptionAttribute("Determines the viewer window size."),
        CategoryAttribute("Appearance"),
        DefaultValueAttribute(typeof(Size), "546, 769")]
        public Size Size
        {
            get { return _Size; }
            set
            {
                _Size = value;
                this.OnPropertyChanged("Size");
            }
        }

        /// <summary>
        /// Determines the viewer window position.
        /// </summary>
        private System.Drawing.Point __Location = new Point(100, 100);
        private System.Drawing.Point _Location = new Point(100, 100);
        [DescriptionAttribute("Determines the viewer window position."),
        CategoryAttribute("Appearance"),
        DefaultValueAttribute(typeof(Point), "100, 100")]
        public Point Location
        {
            get { return _Location; }
            set
            {
                _Location = value;
                this.OnPropertyChanged("Location");
            }
        }

        #region Persisted Properties
        private Collate __Collate = new Collate();
        private Collate _Collate = new Collate();
        public Collate Collate
        {
            get { return _Collate; }
            set 
            {
                if (Collate != null)
                {
                    Collate.PropertyChanged -= new PropertyChangedEventHandler(Collate_PropertyChanged);
                }
                _Collate = value;
                if (Collate != null)
                {
                    Collate.PropertyChanged += new PropertyChangedEventHandler(Collate_PropertyChanged);
                }
                this.OnPropertyChanged("Collate");
            }
        }

        private Filter __Filter = new Filter();
        private Filter _Filter = new Filter();
        public Filter Filter
        {
            get { return _Filter; }
            set 
            {
                if (Filter != null)
                {
                    Filter.PropertyChanged -= new PropertyChangedEventHandler(Filter_PropertyChanged);
                }
                _Filter = value;
                if (Filter != null)
                {
                    Filter.PropertyChanged += new PropertyChangedEventHandler(Filter_PropertyChanged);
                }
                this.OnPropertyChanged("Filter");
            }
        }

        private Merge __Merge = new Merge();
        private Merge _Merge = new Merge();
        public Merge Merge
        {
            get { return _Merge; }
            set 
            {
                if (Merge != null)
                {
                    Merge.PropertyChanged -= new PropertyChangedEventHandler(Merge_PropertyChanged);
                }
                _Merge = value;
                if (Merge != null)
                {
                    Merge.PropertyChanged += new PropertyChangedEventHandler(Merge_PropertyChanged);
                }
                this.OnPropertyChanged("Merge");
            }
        }

        private Sort __Sort = new Sort();
        private Sort _Sort = new Sort();
        public Sort Sort
        {
            get { return _Sort; }
            set 
            {
                if (Sort != null)
                {
                    Sort.PropertyChanged -= new PropertyChangedEventHandler(Sort_PropertyChanged);
                }
                _Sort = value;
                if (Sort != null)
                {
                    Sort.PropertyChanged += new PropertyChangedEventHandler(Sort_PropertyChanged);
                }
                this.OnPropertyChanged("Sort");
            }
        }
        #endregion Persisted Properties
        #endregion Properties

        #region Methods
        /// <summary>
        /// Copies property values from source working fields to detination working fields, then optionally syncs destination.
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="sync"></param>
        public override void CopyTo(ISettingsComponent destination, Boolean sync)
        {
            Settings destinationSettings = default(Settings);

            try
            {
                destinationSettings = destination as Settings;

                destinationSettings.Version = this.Version;
                destinationSettings.Collate = this.Collate;
                destinationSettings.Filter = this.Filter;
                destinationSettings.Merge = this.Merge;
                destinationSettings.Sort = this.Sort;

                base.CopyTo(destination, sync);//also checks and optionally performs sync
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }

        /// <summary>
        /// Syncs property values from working fields to reference fields.
        /// </summary>
        public override void Sync()
        {
            try
            {
                __Version = _Version;
                __Collate = ObjectHelper.Clone<Collate>(_Collate);
                __Filter = ObjectHelper.Clone<Filter>(_Filter);
                __Merge = ObjectHelper.Clone<Merge>(_Merge);
                __Sort = ObjectHelper.Clone<Sort>(_Sort);

                base.Sync();

                if (Dirty)
                {
                    throw new ApplicationException("Sync failed.");
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }
        #endregion Methods
    }
}
