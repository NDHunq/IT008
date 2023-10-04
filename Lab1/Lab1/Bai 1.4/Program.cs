

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1._4
{
    public class Bai_14
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap vao so lan nhiet ke thay doi nhiet do:");
            int n=int.Parse(Console.ReadLine());
            NhietKe nk =new NhietKe();
            ManHinh mh =new ManHinh();
            nk.set_random_Nhietdo();
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhiet do hien thi tren man hinh lan thu {i + 1} la:");
                nk.update_NhietDo();
                mh.HienThi(nk);

            }   
                
        }
    }
}