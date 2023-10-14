using System.Security.Cryptography.X509Certificates;

namespace Laboratorium_2.Models
{
    public class Calculator
    {
        public double A { get; set; }
        public double B { get; set; }
        public Operators Operator { get; set; }

        public bool IsValid()
        {
            return A != null && B != null && Operator != null;
        }

        public double Calculate()
        {
            switch (Operator)
            {
                case Operators.add:
                    return (double)(A + B);
                case Operators.sub: 
                    return (double)(A - B);
                case Operators.mul:
                    return (double)(A * B);
                case Operators.div:
                    return (double)(A / B);
                default:
                    return double.NaN;
            }
        }

        public string GetStringOperator()
        {
            switch (Operator)
            {
                case Operators.add:
                    return "+";
                case Operators.sub:
                    return "-";
                case Operators.mul:
                    return "*";
                case Operators.div:
                    return "/";
                default:
                    return "Wrong operator";
            }
        }
    }
}
