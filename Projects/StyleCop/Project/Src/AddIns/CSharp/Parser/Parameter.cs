//-----------------------------------------------------------------------
// <copyright file="Parameter.cs">
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
namespace StyleCop.CSharp
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes a single method parameter.
    /// </summary>
    /// <subcategory>other</subcategory>
    public class Parameter : ICodePart
    {
        #region Internal Readonly Static Fields

        /// <summary>
        /// An empty array of parameters.
        /// </summary>
        internal static readonly Parameter[] EmptyParameterArray = new Parameter[0];

        #endregion Internal Readonly Static Fields

        #region Private Fields

        /// <summary>
        /// The location of the parameter.
        /// </summary>
        private CodeLocation location;

        /// <summary>
        /// The parameter type.
        /// </summary>
        private TypeToken type;

        /// <summary>
        /// The parameter name.
        /// </summary>
        private string name;

        /// <summary>
        /// The parameter modifiers, if any.
        /// </summary>
        private ParameterModifiers modifiers;

        /// <summary>
        /// The tokens that make up the parameter.
        /// </summary>
        private CsTokenList tokens;

        /// <summary>
        /// Indicates whether the parameter is located within a block of generated code.
        /// </summary>
        private bool generated;

        /// <summary>
        /// The optional default argument for the parameter.
        /// </summary>
        private Expression defaultArgument;

        /// <summary>
        /// The parent of the parameter.
        /// </summary>
        private Reference<ICodePart> parent;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Parameter class.
        /// </summary>
        /// <param name="type">The type of the parameter.</param>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="parent">The parent of the parameter.</param>
        /// <param name="modifiers">Modifers applied to this parameter.</param>
        /// <param name="defaultArgument">The optional default argument for the parameter.</param>
        /// <param name="location">The location of the parameter in the code.</param>
        /// <param name="tokens">The tokens that form the parameter.</param>
        /// <param name="generated">Indicates whether the parameter is located within a block of generated code.</param>
        internal Parameter(
            TypeToken type, 
            string name, 
            Reference<ICodePart> parent,
            ParameterModifiers modifiers, 
            Expression defaultArgument, 
            CodeLocation location, 
            CsTokenList tokens, 
            bool generated)
        {
            Param.Ignore(type);
            Param.AssertValidString(name, "name");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(modifiers);
            Param.Ignore(defaultArgument);
            Param.AssertNotNull(location, "location");
            Param.Ignore(tokens);
            Param.Ignore(generated);

            this.type = type;
            this.name = CodeLexer.DecodeEscapedText(name, true);
            this.parent = parent;
            this.modifiers = modifiers;
            this.defaultArgument = defaultArgument;
            this.location = location;
            this.tokens = tokens;
            this.generated = generated;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the parameter name.
        /// </summary>
        public string Name
        {
            get 
            { 
                return this.name; 
            }
        }

        /// <summary>
        /// Gets the parent of the parameter.
        /// </summary>
        public ICodePart Parent
        {
            get
            {
                return this.parent.Target;
            }
        }

        /// <summary>
        /// Gets the type of this code part.
        /// </summary>
        public CodePartType CodePartType
        {
            get
            {
                return CodePartType.Parameter;
            }
        }

        /// <summary>
        /// Gets the parameter type.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Naming", 
            "CA1721:PropertyNamesShouldNotMatchGetMethods",
            Justification = "API has already been published and should not be changed.")]
        public TypeToken Type
        {
            get 
            { 
                return this.type; 
            }
        }

        /// <summary>
        /// Gets the modifiers applied to this parameter.
        /// </summary>
        public ParameterModifiers Modifiers
        {
            get 
            {
                return this.modifiers; 
            }
        }

        /// <summary>
        /// Gets the optional default argument for the parameter.
        /// </summary>
        public Expression DefaultArgument
        {
            get
            {
                return this.defaultArgument;
            }
        }

        /// <summary>
        /// Gets the location of the parameter in the code.
        /// </summary>
        public CodeLocation Location
        {
            get
            {
                return this.location;
            }
        }

        /// <summary>
        /// Gets the line number that the parameter appears on in the code.
        /// </summary>
        public int LineNumber
        {
            get
            {
                return this.location.LineNumber;
            }
        }

        /// <summary>
        /// Gets the tokens that form the parameter.
        /// </summary>
        public CsTokenList Tokens
        {
            get
            {
                return this.tokens;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the parameter is located within a block of generated code.
        /// </summary>
        public bool Generated
        {
            get
            {
                return this.generated;
            }
        }

        #endregion Public Properties
    }
}