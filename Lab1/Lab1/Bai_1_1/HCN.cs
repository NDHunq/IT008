using Bai_1._1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1._1
{
    public class HCN : Shape
    {
        public double r { get; set; }
        public double d { get; set; }
        public (double x, double y) p1 { get; set; }
        public (double x, double y) p2 { get; set; }
        public (double x, double y) p3 { get; set; }
        public (double x, double y) p4 { get; set; }
        public override void Nhap_diem()
        {
            Console.WriteLine("Nhap diem thu 1 cua HCN:");
            Console.WriteLine("Nhap hoanh do:");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap tung do:");
            double y = double.Parse(Console.ReadLine());
            p1 = (x, y);
            Console.WriteLine("Nhap diem thu 2 cua HCN:");
            Console.WriteLine("Nhap hoanh do:");
            x = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap tung do:");
            y = double.Parse(Console.ReadLine());
            p2 = (x, y);
            Console.WriteLine("Nhap diem thu 3 cua HCN:");
            Console.WriteLine("Nhap hoanh do:");
            x = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap tung do:");
            y = double.Parse(Console.ReadLine());
            p3 = (x, y);
            Console.WriteLine("Nhap diem thu 4 cua HCN:");
            Console.WriteLine("Nhap hoanh do:");
            x = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap tung do:");
            y = double.Parse(Console.ReadLine());
            p4 = (x, y);
            Console.WriteLine("Nhap chieu dai:");
            d = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap chieu rong:");
            r = double.Parse(Console.ReadLine());
        }
        public override double Area()
        {
            return r * d;
        }
        public override void Draw()
        {
            Console.WriteLine("La hinh:" + this.Name);
            Console.WriteLine("Cac diem cua hinh chu nhat la luot la:(" + p1.x + "," + p1.y + "),(" + p2.x + "," + p2.y + "),(" + p3.x + "," + p3.y + "),(" + p4.x + "," + p4.y + ")");
            Console.WriteLine("Chieu dai cua hinh chu nhat la:" + d);
            Console.WriteLine("Chieu rong cua hinh chu nhat la:" + r);
            Console.WriteLine("Dien tich cua hinh chu nhat la:" + this.Area());
        }
    }
}
