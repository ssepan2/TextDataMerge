using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Ssepan.Collections;
using Ssepan.Utility;

namespace TextDataMergeLibrary
{
    public interface ITextFunction :
        IDisposable,
        IEquatable<TextFunctionBase>,
        INotifyPropertyChanged
    {
        #region Methods
        /// <summary>
        /// validate settings entered by user
        /// </summary>
        Boolean Valid();

        /// <summary>
        /// validate settings determined at the time of the collate
        /// </summary>
        Boolean Complete();

        /// <summary>
        /// Add a file to input list
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Boolean AddInputFile(String filePath);

        /// <summary>
        /// Remove a file from input list
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Boolean RemoveInputFile(String filePath);

        /// <summary>
        /// Add a file to output list
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Boolean AddOutputFile(String filePath);

        /// <summary>
        /// Remove a file from output list
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Boolean RemoveOutputFile(String filePath);

        /// <summary>
        /// Execute feature.
        /// </summary>
        /// <returns></returns>
        Boolean Run();
        #endregion Methods
    }
}
