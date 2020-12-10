using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Ssepan.Application;
using Ssepan.Utility;

namespace TextDataMergeLibrary
{
    public class TextDataMergeController<TModel> :
        ModelController<TModel>
        where TModel :
            class,
            IModel,
            new()
    {
        #region Constructors
        #endregion Constructors

        #region Properties
        #endregion Properties

        #region Methods
        /// <summary>
        /// Add or Remove item with specified path from input- or output-list, using delegate provided.
        /// </summary>
        /// <param name="imageFile"></param>
        /// <param name="shiftType"></param>
        public static Boolean AddRemoveFile(Func<String, Boolean> textFunctionAddRemove, String filePath) 
        {
            Boolean returnValue = default(Boolean);

            try
            {
                _ValueChanging = true;

                textFunctionAddRemove(filePath);

                _ValueChanging = false;

                //Refresh();

                returnValue = true;
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                _ValueChanging = false;
                throw;
            }
            return returnValue;
        }

        /// <summary>
        /// Read data from text file into List.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="tokenList"></param>
        /// <param name="maximumLength"></param>
        internal static void ReadFileData(String fileName, ref List<String> tokenList, ref Int32 maximumLength)
        {
            String line = String.Empty;
            try
            {
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    while (streamReader.Peek() >= 0)
                    {
                        line = streamReader.ReadLine();
                        tokenList.Add(line);

                        //update max columns
                        maximumLength = Math.Min(maximumLength, line.Length);
                    }
                    streamReader.Close();
                }
            }

            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }

        /// <summary>
        /// Write data to text file from List.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="tokenList"></param>
        internal static void WriteFileData(String fileName, List<String> tokenList)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(fileName))
                {
                    foreach (String item in tokenList)
                    {
                        streamWriter.WriteLine(item);
                    }
                    streamWriter.Close();
                }

            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }
        #endregion Methods

        //public static void Refresh()
        //{
        //    TextDataMergeController<TDMModel>.Model.IsChanged = true;//Value doesn't matter; a changed fire event;
        //}
    }
}
