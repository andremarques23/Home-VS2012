//-----------------------------------------------------------------------
// <copyright file="EmptyStatement.cs">
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
    /// A statement consisting only of a single semicolon.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class EmptyStatement : Statement
    {
        /// <summary>
        /// Initializes a new instance of the EmptyStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        internal EmptyStatement(CodeUnitProxy proxy)
            : base(proxy, StatementType.Empty)
        {
            Param.AssertNotNull(proxy, "proxy");
        }
    }
}
