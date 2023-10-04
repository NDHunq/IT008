using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1._1
{
    public class Tamgiac : Shape
    {
        public double r { get; set; }
        public double h { get; set; }
        public (double x, double y) p1 { get; set; }
        public (double x, double y) p2 { get; set; }
        public (double x, double y) p3 { get; set; }

        public override void Nhap_diem()
        {
            Console.WriteLine("Nhap diem thu 1 cua Tamgiac:");
            Console.WriteLine("Nhap hoanh do:");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap tung do:");
            double y = double.Parse(Console.ReadLine());
            p1 = (x, y);
            Console.WriteLine("Nhap diem thu 2 cua Tamgiac:");
            x = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap tung do:");
            y = double.Parse(Console.ReadLine());
            p2 = (x, y);
            Console.WriteLine("Nhap diem thu 3 cua Tamgiac:");
            x = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap tung do:");
            y = double.Parse(Console.ReadLine());
            p3 = (x, y);

            Console.WriteLine("Nhap chieu dai day:");
            r = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap chieu cao:");
            h = double.Parse(Console.ReadLine());
        }
        public override double Area()
        {
            return r * h / 2;
        }
        public override void Draw()
        {
            Console.WriteLine("La hinh:" + this.Name);
            Console.WriteLine("Cac diem cua hinh chu nhat la luot la:(" + p1.x + "," + p1.y + "),(" + p2.x + "," + p2.y + "),(" + p3.x + "," + p3.y + ")");
            Console.WriteLine("Chieu cao cua hinh Tamgiac la:" + h);
            Console.WriteLine("Chieu dai day cua Tamgiac la:" + r);
            Console.WriteLine("Dien tich cua Tamgiac la:" + this.Area());
        }
    }
}
