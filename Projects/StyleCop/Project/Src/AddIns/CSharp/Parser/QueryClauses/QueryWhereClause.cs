//-----------------------------------------------------------------------
// <copyright file="QueryWhereClause.cs">
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

    /// <summary>
    /// Describes a where clause in a query expression.
    /// </summary>
    public sealed class QueryWhereClause : QueryClauseWithExpression
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the QueryWhereClause class.
        /// </summary>
        /// <param name="tokens">The list of tokens that form the clause.</param>
        /// <param name="expression">The expression.</param>
        internal QueryWhereClause(CsTokenList tokens, Expression expression)
            : base(QueryClauseType.Where, tokens, expression)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(expression, "expression");
        }

        #endregion Internal Constructors
    }
}