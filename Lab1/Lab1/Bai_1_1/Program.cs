
using Bai_1._1;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1._1
{
    public class Bai_11
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Nhap vao so hinh:");
            n = int.Parse(Console.ReadLine());
            Random random = new Random();
            Shape[] shape = new Shape[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Hinh {i + 1}:");
                int shapetype = random.Next(1, 4);

                switch (shapetype)
                {
                    case 1:
                        shape[i] = new HCN();
                        shape[i].Name = "Hinh chu nhat";

                        break;
                    case 2:
                        shape[i] = new Hinhvuong();
                        shape[i].Name = "Hinh vuong";
                        break;
                    case 3:
                        shape[i] = new Tron();
                        shape[i].Name = "Hinh tron";
                        break;
                    case 4:
                        shape[i] = new Tamgiac();
                        shape[i].Name = "Hinh tam giac";
                        break;
                }
                shape[i].Nhap_diem();

            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Ve hinh thu {i + 1}:");
                shape[i].Draw();
            }
        }
    }
}