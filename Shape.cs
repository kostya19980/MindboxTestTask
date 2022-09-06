using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindboxTestTask
{
    public abstract class Shape
    {
        public abstract double CalculateArea();
    }
    public class Circle: Shape
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
    public class Triangle: Shape
    {
        public double AB { get; set; }
        public double BC { get; set; }
        public double AC { get; set; }
        public Triangle(double ab, double bc, double ac)
        {
            if (IsExist(ab, bc, ac))
            {
                AB = ab;
                BC = bc;
                AC = ac;
            }
        }
        private bool IsExist(double ab, double bc, double ac)
        {
            if (ab < 0 || bc < 0 || ac < 0)
            {
                throw new ArgumentException("Стороны не могут быть меньше 0!");
            }

            if (ab > (bc + ac) || bc > (ab + ac) || ac > (ab + bc))
            {
                throw new ArgumentException("Каждая сторона должна быть меньше суммы двух других!");
            }
            return true;
        }
        public bool IsRightTriangle()
        {
            return (AB == Math.Sqrt(Math.Pow(BC, 2) + Math.Pow(AC, 2))
                || BC == Math.Sqrt(Math.Pow(AB, 2) + Math.Pow(AC, 2))
                || AC == Math.Sqrt(Math.Pow(AB, 2) + Math.Pow(BC, 2)));
        }
        public override double CalculateArea()
        {
            double p = (AB + BC + AC) / 2;
            return Math.Sqrt(p * (p - AB) * (p - BC) * (p - AC));
        }
    }
}
