﻿//-----------------------------------------------------------------------
// <copyright file="ModExpression.cs">
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
    /// <summary>
    /// An expression representing a mod operation.
    /// </summary>
    public sealed class ModExpression : ArithmeticExpression
    {
        /// <summary>
        /// Initializes a new instance of the ModExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="leftHandSide">The left hand side of the expression.</param>
        /// <param name="rightHandSide">The right hand side of the expression.</param>
        internal ModExpression(CodeUnitProxy proxy, Expression leftHandSide, Expression rightHandSide)
            : base(proxy, ArithmeticExpressionType.Mod, leftHandSide, rightHandSide)
        {
            Param.Ignore(proxy, leftHandSide, rightHandSide);
        }
    }
}
