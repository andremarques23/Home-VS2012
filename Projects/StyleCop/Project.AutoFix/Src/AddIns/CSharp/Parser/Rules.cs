﻿//-----------------------------------------------------------------------
// <copyright file="Rules.cs">
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
namespace StyleCop.CSharp
{
    using System;

    /// <summary>
    /// The list of rules that can be triggered by this parser module.
    /// </summary>
    internal enum Rules
    {
        /// <summary>
        /// The file could not be read.
        /// </summary>
        FileMustBeReadable,

        /// <summary>
        /// An exception occurred while parsing the file.
        /// </summary>
        ExceptionOccurred,

        /// <summary>
        /// A syntax error was found in the code.
        /// </summary>
        SyntaxException
    }
}