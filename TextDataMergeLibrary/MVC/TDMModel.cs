using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using Ssepan.Application;
using Ssepan.Application.MVC;
using Ssepan.Utility;

namespace TextDataMergeLibrary
{
    /// <summary>
    /// run-time model; relies on settings
    /// This generic model is replaced by the four specific models Collate, Filter, Merge, and Sort. 
    /// It is a placeholder for the model pieces that are tightly bound to the settings because they need to be persisted.
    /// Settings/SettingsController use INotifyPropertyChanged internally; 
    /// TDMModel/TextDataMergeController use INotifyPropertyChanged.
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class TDMModel :
        ModelBase
    {
        #region Declarations
        #endregion Declarations

        #region Constructors
        public TDMModel() 
        {
            if (SettingsController<Settings>.Settings == null)
            {
                SettingsController<Settings>.New();
            }
            Debug.Assert(SettingsController<Settings>.Settings != null, "SettingsController<MVCSettings>.Settings != null");
        }
        #endregion Constructors

        #region IEquatable<IModel>
        /// <summary>
        /// Compare property values of two specified Model objects.
        /// </summary>
        /// <param name="anotherSettings"></param>
        /// <returns></returns>
        public override Boolean Equals(IModelComponent other)
        {
            Boolean returnValue = default(Boolean);
            TDMModel otherModel = default(TDMModel);

            try
            {
                otherModel = other as TDMModel;

                if (this == otherModel)
                {
                    returnValue = true;
                }
                else
                {
                    if (!base.Equals(other))
                    {
                        returnValue = false;
                    }
                    else if (!this.Collate.Equals(otherModel.Collate))
                    {
                        returnValue = false;
                    }
                    else if (!this.Filter.Equals(otherModel.Filter))
                    {
                        returnValue = false;
                    }
                    else if (!this.Merge.Equals(otherModel.Merge))
                    {
                        returnValue = false;
                    }
                    else if (!this.Sort.Equals(otherModel.Sort))
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
        #endregion IEquatable<IModel>

        #region Properties
        public String Version
        {
            get { return SettingsController<Settings>.Settings.Version; }
            set
            {
                SettingsController<Settings>.Settings.Version = value;
                OnPropertyChanged("Version");
            }
        }

        #region Persisted Properties
        public Collate Collate
        {
            get { return SettingsController<Settings>.Settings.Collate; }
            set
            {
                SettingsController<Settings>.Settings.Collate = value;
                OnPropertyChanged("Collate");
            }
        }

        public Filter Filter
        {
            get { return SettingsController<Settings>.Settings.Filter; }
            set
            {
                SettingsController<Settings>.Settings.Filter = value;
                OnPropertyChanged("Filter");
            }
        }

        public Merge Merge
        {
            get { return SettingsController<Settings>.Settings.Merge; }
            set
            {
                SettingsController<Settings>.Settings.Merge = value;
                OnPropertyChanged("Merge");
            }
        }

        public Sort Sort
        {
            get { return SettingsController<Settings>.Settings.Sort; }
            set
            {
                SettingsController<Settings>.Settings.Sort = value;
                OnPropertyChanged("Sort");
            }
        }
        #endregion Persisted Properties
        #endregion Properties

        #region Methods
        #endregion Methods

    }
}
