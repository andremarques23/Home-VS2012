﻿//-----------------------------------------------------------------------
// <copyright file="OpenCurlyBracketToken.cs">
//     MS-PL
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
namespace StyleCop.CSharp.CodeModel
{
    using System;

    /// <summary>
    /// Describes an opening curly bracket.
    /// </summary>
    /// <subcategory>token</subcategory>
    public sealed class OpenCurlyBracketToken : OpenBracketToken
    {
        /// <summary>
        /// Initializes a new instance of the OpenCurlyBracketToken class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        internal OpenCurlyBracketToken(CsDocument document)
            : base(document, "{", TokenType.OpenCurlyBracket)
        {
            Param.AssertNotNull(document, "document");
        }

        /// <summary>
        /// Initializes a new instance of the OpenCurlyBracketToken class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="text">The text within the bracket.</param>
        /// <param name="location">The location of the bracket.</param>
        /// <param name="generated">Indicates whether the item lies within a block of generated code.</param>
        internal OpenCurlyBracketToken(CsDocument document, string text, CodeLocation location, bool generated)
            : base(document, text, TokenType.OpenCurlyBracket, location, generated)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertValidString(text, "text");
            Param.AssertNotNull(location, "location");
            Param.Ignore(generated);
        }

        /// <summary>
        /// Gets the matching bracket type for this bracket.
        /// </summary>
        protected override TokenType MatchingBracketType
        {
            get
            {
                return TokenType.CloseCurlyBracket;
            }
        }
    }
}
