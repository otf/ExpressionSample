using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionSample
{
    class Program
    {
        public static string ToPolish(Expression<Func<int, int, int>> expr)
        {
            var op = (BinaryExpression)expr.Body;
            if (op.NodeType == ExpressionType.Add)
            {
                return string.Format("{0} {1} +", op.Left.ToString(), op.Right.ToString());
            }

            if (op.NodeType == ExpressionType.Subtract)
            {
                return string.Format("{0} {1} -", op.Left.ToString(), op.Right.ToString());
            }

            if (op.NodeType == ExpressionType.Multiply)
            {
                return string.Format("{0} {1} *", op.Left.ToString(), op.Right.ToString());
            }

            if (op.NodeType == ExpressionType.Divide)
            {
                return string.Format("{0} {1} /", op.Left.ToString(), op.Right.ToString());
            }

            throw new InvalidOperationException();
        }

        static void Main(string[] args)
        {
            Expression<Func<int, int, int>> expr = (x, y) => x * y;

            Console.WriteLine(ToPolish(expr));
        }
    }
}
