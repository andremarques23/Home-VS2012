﻿//-----------------------------------------------------------------------
// <copyright file="LeftShiftExpression.cs">
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
    /// An expression representing a left-shift operation.
    /// </summary>
    public sealed class LeftShiftExpression : ArithmeticExpression
    {
        /// <summary>
        /// Initializes a new instance of the LeftShiftExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="leftHandSide">The left hand side of the expression.</param>
        /// <param name="rightHandSide">The right hand side of the expression.</param>
        internal LeftShiftExpression(CodeUnitProxy proxy, Expression leftHandSide, Expression rightHandSide)
            : base(proxy, ArithmeticExpressionType.LeftShift, leftHandSide, rightHandSide)
        {
            Param.Ignore(proxy, leftHandSide, rightHandSide);
        }
    }
}
