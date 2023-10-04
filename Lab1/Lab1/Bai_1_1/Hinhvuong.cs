using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1._1
{
    public class Hinhvuong : HCN

    {
        public override void Nhap_diem()
        {
            Console.WriteLine("Nhap diem thu 1 cua HV:");
            Console.WriteLine("Nhap hoanh do:");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap tung do:");
            double y = double.Parse(Console.ReadLine());
            p1 = (x, y);
            Console.WriteLine("Nhap diem thu 2 cua HV:");
            Console.WriteLine("Nhap hoanh do:");
            x = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap tung do:");
            y = double.Parse(Console.ReadLine());
            p2 = (x, y);
            Console.WriteLine("Nhap diem thu 3 cua HV:");
            Console.WriteLine("Nhap hoanh do:");
            x = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap tung do:");
            y = double.Parse(Console.ReadLine());
            p3 = (x, y);
            Console.WriteLine("Nhap diem thu 4 cua HV:");
            Console.WriteLine("Nhap hoanh do:");
            x = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap tung do:");
            y = double.Parse(Console.ReadLine());
            p4 = (x, y);
            Console.WriteLine("Nhap chieu dai canh:");
            d = double.Parse(Console.ReadLine());
            r = d;
        }
        public override void Draw()
        {
            Console.WriteLine("La hinh:" + this.Name);
            Console.WriteLine("Cac diem cua hinh vuong la luot la:(" + p1.x + "," + p1.y + "),(" + p2.x + "," + p2.y + "),(" + p3.x + "," + p3.y + "),(" + p4.x + "," + p4.y + ")");
            Console.WriteLine("Chieu dai cua canh hinh vuong  la:" + d);

            Console.WriteLine("Dien tich cua hinh vuong la:" + this.Area());
        }
    }
}
