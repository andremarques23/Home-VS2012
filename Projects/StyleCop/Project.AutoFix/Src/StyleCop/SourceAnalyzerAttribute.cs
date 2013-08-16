//-----------------------------------------------------------------------
// <copyright file="SourceAnalyzerAttribute.cs">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Attribute class for marking StyleCop analyzer classes.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1019:DefineAccessorsForAttributeArguments", Justification = "The attribute has no other arguments.")]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class SourceAnalyzerAttribute : StyleCopAddInAttribute
    {
        #region Private Fields

        /// <summary>
        /// The type of the parser that this analyzer is associated with.
        /// </summary>
        private Type parserType;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the SourceAnalyzerAttribute class.
        /// </summary>
        /// <param name="parserType">The type of the parser that this analyzer is associated with.</param>
        public SourceAnalyzerAttribute(Type parserType)
        {
            Param.RequireNotNull(parserType, "parserType");
            this.parserType = parserType;
        }

        /// <summary>
        /// Initializes a new instance of the SourceAnalyzerAttribute class.
        /// </summary>
        /// <param name="parserType">The type of the parser that this analyzer is associated with.</param>
        /// <param name="analyzerXmlId">The ID of the analyzer xml file within the analyzer resource.</param>
        public SourceAnalyzerAttribute(Type parserType, string analyzerXmlId) : base(analyzerXmlId)
        {
            Param.RequireNotNull(parserType, "parserType");
            Param.RequireValidString(analyzerXmlId, "analyzerXmlId");

            this.parserType = parserType;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the type of the parser that this analyzer is associated with.
        /// </summary>
        public Type ParserType
        {
            get
            {
                return this.parserType;
            }
        }

        #endregion Public Properties
    }
}
