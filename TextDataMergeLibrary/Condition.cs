using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Reflection;
using Ssepan.Application;
using Ssepan.Application.MVC;
using Ssepan.Utility;

namespace TextDataMergeLibrary
{
    /// <summary>
    /// Condition used by Filter and Collate output files.
    /// Inheritance is not used because it does not play well with XmlSerialize, 
    /// and hard-coded separate static lists used because static constructors do not take params
    /// </summary>
    [Serializable()]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Condition :
        SettingsComponentBase,
        IEquatable<Condition>,
        INotifyPropertyChanged
    {
        #region Declarations
        //operators
        private const String ComparisonOperator_Less = "<";
        private const String ComparisonOperator_Equal = "=";
        private const String ComparisonOperator_Greater = ">";
        private const String ComparisonOperator_Contains = "Contains";
        private const String ComparisonOperator_IsMatch = "IsMatch";

        //lookup lists of operators
        public static List<String> FilterComparisonOperators = new List<String>();
        public static List<String> CollateComparisonOperators = new List<String>();
        #endregion Declarations

        #region Constructors
        static Condition()
        {
            //Load lookup lists of operators
            FilterComparisonOperators.Add(ComparisonOperator_IsMatch);

            CollateComparisonOperators.Add(ComparisonOperator_Less);
            CollateComparisonOperators.Add(ComparisonOperator_Equal);
            CollateComparisonOperators.Add(ComparisonOperator_Greater);
            CollateComparisonOperators.Add(ComparisonOperator_Contains);
            CollateComparisonOperators.Add(ComparisonOperator_IsMatch);
        }

        public Condition()
        {
        }

        public Condition(String filename)
        {
            Filename = filename;
        }

        public Condition(String filename, Boolean not, String comparison, String value)
        {
            Filename = filename;
            Not = not;
            Comparison = comparison;
            Value = value;
        }
        #endregion Constructors

        #region INotifyPropertyChanged support
        //public event PropertyChangedEventHandler PropertyChanged;

//        void OnPropertyChanged(String propertyName)
//        {
//            try
//            {
//                if (this.PropertyChanged != null)
//                {
//                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
//#if debug
//                    Log.Write(
//                        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Module.Name,
//                        Log.FormatEntry(String.Format("PropertyChanged: {0}", propertyName), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name),
//                        System.Diagnostics.EventLogEntryType.Information,
//                            99);
//#endif
//                }
//            }
//            catch (Exception ex)
//            {
//                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
//                //throw;
//            }
//        }
        #endregion INotifyPropertyChanged support

        #region IEquatable<CollateCondition> Members

        /// <summary>
        /// Compare property values of this object to another.
        /// </summary>
        /// <param name="anotherSettings"></param>
        /// <returns></returns>
        public Boolean Equals(Condition condition)
        {
            Boolean returnValue = default(Boolean);

            try
            {
                if (this == condition)
                {
                    returnValue = true;
                }
                else
                {
                    if (this.Filename != condition.Filename)
                    {
                        returnValue = false;
                    }
                    else if (this.Not != condition.Not)
                    {
                        returnValue = false;
                    }
                    else if (this.Comparison != condition.Comparison)
                    {
                        returnValue = false;
                    }
                    else if (this.Value != condition.Value)
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

        #endregion

        #region Properties
        #region NonPersisted Properties
        private List<String> _Results = new List<String>();
        [XmlIgnore]
        public List<String> Results
        {
            get { return _Results; }
            set { _Results = value; }
        }
        #endregion NonPersisted Properties

        #region Persisted Properties
        private String _Filename = default(String);
        public String Filename
        {
            get { return _Filename; }
            set
            {
                _Filename = value;
                this.OnPropertyChanged("Filename");
            }
        }

        private Boolean _Not = default(Boolean);
        public Boolean Not
        {
            get { return _Not; }
            set
            {
                _Not = value;
                this.OnPropertyChanged("Not");
            }
        }

        private String _Comparison = String.Empty; 
        public String Comparison
        {
            get { return _Comparison; }
            set
            {
                _Comparison = value;
                this.OnPropertyChanged("Comparison");
            }
        }

        private String _Value = default(String);
        public String Value
        {
            get { return _Value; }
            set
            {
                _Value = value;
                this.OnPropertyChanged("Value");
            }
        }
        #endregion Persisted Properties
        #endregion Properties

        #region Methods
        /// <summary>
        /// Compare passed line key to Value, using Not and Comparison, and return Boolean result.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Boolean Evaluate(String key)
        {
            Boolean returnValue = default(Boolean);
            Int32 result;
            try
            {
                switch (Comparison)
                {
                    case ComparisonOperator_Less:
                    {
                        //returnValue = (key < Value);
                        result = key.CompareTo(Value);
                        returnValue = (result < 0);
                        break;
                    }
                    case ComparisonOperator_Equal:
                    {
                        //returnValue = (key == Value);
                        result = key.CompareTo(Value);
                        returnValue = (result == 0);
                        break;
                    }
                    case ComparisonOperator_Greater:
                    {
                        //returnValue = (key > Value);
                        result = key.CompareTo(Value);
                        returnValue = (result > 0);
                        break;
                    }
                    case ComparisonOperator_Contains:
                    {
                        //returnValue = (key like Value);
                        returnValue = key.Contains(Value);
                        break;
                    }
                    case ComparisonOperator_IsMatch:
                    {
                        //returnValue = (key IsMatch Value);
                        returnValue = Regex.IsMatch(key, Value, RegexOptions.None);
                        break;
                    }
                    default:
                    {
                        throw new ArgumentOutOfRangeException(String.Format("Invalid operator: {0}", Comparison));
                    }
                }

                if (Not)
                {
                    returnValue = !returnValue;
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                //throw;
            }
            return returnValue;
        }
        #endregion Methods
    }
}
