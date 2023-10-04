using Bai_1._1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1._1
{
    public class Tron : Shape
    {
        public double r { get; set; }

        public (double x, double y) o { get; set; }

        public override void Nhap_diem()
        {
            Console.WriteLine("Nhap tam cua hinh tron:");
            Console.WriteLine("Nhap hoanh do:");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap tung do:");
            double y = double.Parse(Console.ReadLine());
            o = (x, y);
            Console.WriteLine("Nhap chieu dai ban kinh cua hinh tron:");
            r = double.Parse(Console.ReadLine());
        }
        public override double Area()
        {
            return Math.PI * r * r;
        }
        public override void Draw()
        {
            Console.WriteLine("La hinh:" + this.Name);
            Console.WriteLine("Tam cua hinh tron la:(" + o.x + "," + o.y + ")");
            Console.WriteLine("Chieu dai cua ban kinh hinh tron la:" + r);
            Console.WriteLine("Dien tich cua hinh tron la:" + this.Area());
        }
    }
}
