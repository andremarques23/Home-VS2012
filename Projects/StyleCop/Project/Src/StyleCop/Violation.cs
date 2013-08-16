//-----------------------------------------------------------------------
// <copyright file="Violation.cs">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. If you cannot locate the  
//   Microsoft Public License, please send an email to dlr@microsoft.com. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop
{
    using System;

    /// <summary>
    /// Describes one violation.
    /// </summary>
    public class Violation
    {
        #region Private Fields

        /// <summary>
        /// The line number that the violation appears on.
        /// </summary>
        private readonly int line;

        /// <summary>
        /// The element that the violation appears in.
        /// </summary>
        private readonly ICodeElement element;

        /// <summary>
        /// The source code that the violation appears in.
        /// </summary>
        private readonly SourceCode sourceCode;

        /// <summary>
        /// The context message.
        /// </summary>
        private readonly string message;

        /// <summary>
        /// The rule that triggered the violation.
        /// </summary>
        private readonly Rule rule;

        /// <summary>
        /// The unique key for this violation.
        /// </summary>
        private int key;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the Violation class.
        /// </summary>
        /// <param name="rule">The rule that triggered the violation.</param>
        /// <param name="element">The element that this violation appears in.</param>
        /// <param name="line">The line in the source code where the violation occurs.</param>
        /// <param name="message">The context message for the violation.</param>
        internal Violation(Rule rule, ICodeElement element, int line, string message)
        {
            Param.AssertNotNull(rule, "rule");
            Param.Ignore(element);
            Param.AssertGreaterThanOrEqualToZero(line, "line");
            Param.AssertNotNull(message, "message");

            this.rule = rule;
            this.element = element;
            this.line = line;
            this.message = message;

            if (this.element != null && this.element.Document != null)
            {
                this.sourceCode = this.element.Document.SourceCode;
            }

            this.UpdateKey();
        }
        
        /// <summary>
        /// Initializes a new instance of the Violation class.
        /// </summary>
        /// <param name="rule">The rule that triggered the violation.</param>
        /// <param name="sourceCode">The source code that this violation appears in.</param>
        /// <param name="line">The line in the source code where the violation occurs.</param>
        /// <param name="message">The context message for the violation.</param>
        internal Violation(Rule rule, SourceCode sourceCode, int line, string message)
        {
            Param.AssertNotNull(rule, "rule");
            Param.Ignore(sourceCode);
            Param.AssertGreaterThanOrEqualToZero(line, "line");
            Param.AssertNotNull(message, "message");

            this.rule = rule;
            this.sourceCode = sourceCode;
            this.line = line;
            this.message = message;

            this.UpdateKey();
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the rule that triggered the violation.
        /// </summary>
        public Rule Rule
        {
            get 
            { 
                return this.rule; 
            }
        }

        /// <summary>
        /// Gets the line number in the source code where the violation occurs.
        /// </summary>
        public int Line
        {
            get 
            { 
                return this.line; 
            }
        }
        
        /// <summary>
        /// Gets the element that contains the violation.
        /// </summary>
        public ICodeElement Element
        {
            get 
            { 
                return this.element; 
            }
        }

        /// <summary>
        /// Gets the source code that contains the violation.
        /// </summary>
        public SourceCode SourceCode
        {
            get
            {
                return this.sourceCode;
            }
        }

        /// <summary>
        /// Gets the context message for the violation.
        /// </summary>
        public string Message
        {
            get 
            { 
                return this.message; 
            }
        }

        /// <summary>
        /// Gets the unique key for this violation that can be used when adding
        /// the violation to a dictionary.
        /// </summary>
        public int Key
        {
            get
            {
                return this.key;
            }
        }

        #endregion Public Properties

        /// <summary>
        /// Updates the internal key.
        /// </summary>
        private void UpdateKey()
        {
            this.key = (this.rule.Name + this.line + this.message).GetHashCode();
        }
    }
}