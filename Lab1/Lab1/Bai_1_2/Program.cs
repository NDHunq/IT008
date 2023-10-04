using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1_2
{
    class PhanSo : IComparable  
    {
        public int TuSo;
        public int MauSo;
        public PhanSo(int tuSo, int mauSo)
        {
            TuSo = tuSo;
            MauSo = mauSo;
        }
        public PhanSo() { }
        public int CompareTo(object obj)
        {
           PhanSo p=(PhanSo)obj;
            double gia_tri1 = (double)TuSo / MauSo;
            double gia_tri2 = (double)p.TuSo / p.MauSo;
            if (gia_tri1 < gia_tri2)
            {
                return -1;
            }
            else if (gia_tri1 > gia_tri2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
            return 0;
        }
        public void Xuat()
        {
            Console.Write("{0}/{1} ", TuSo, MauSo);
        }
        public PhanSo RutGon(PhanSo ps)
        {
            int gcd = TimUCLN(ps.TuSo, ps.MauSo);
            ps.TuSo /= gcd;
            ps.MauSo /= gcd;
            return ps;
        }

        public int TimUCLN(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public static PhanSo operator +(PhanSo p1, PhanSo p2)
        {
            PhanSo p = new PhanSo();
            p.TuSo = p2.TuSo * p1.MauSo + p1.TuSo * p2.MauSo;
            p.MauSo = p2.MauSo * p1.MauSo;
            return p;
        }
        public static PhanSo operator -(PhanSo p1, PhanSo p2)
        {
            PhanSo p = new PhanSo();
            p.TuSo = p1.TuSo * p2.MauSo - p2.TuSo * p1.MauSo;
            p.MauSo = p1.MauSo * p2.MauSo;
            return p;
        }
        public static PhanSo operator *(PhanSo p1, PhanSo p2)
        {
            PhanSo p = new PhanSo();
            p.TuSo = p1.TuSo * p2.TuSo;
            p.MauSo = p1.MauSo * p2.MauSo;
            return p;
        }
        public static PhanSo operator /(PhanSo p1, PhanSo p2)
        {
            PhanSo p = new PhanSo();
            p.TuSo = p1.TuSo * p2.MauSo;
            p.MauSo = p1.MauSo * p2.TuSo;
            return p;
        }
        public static bool operator ==(PhanSo p1, PhanSo p2)
        {
            if((float)(p1.TuSo/p1.MauSo)== (float)(p2.TuSo/p2.MauSo))
                return true;
            return false;
        }
        public static bool operator !=(PhanSo p1, PhanSo p2)
        {
            if ((float)(p1.TuSo / p1.MauSo) != (float)(p2.TuSo / p2.MauSo))
                return true;
            return false;
        }
        public static bool operator <(PhanSo p1, PhanSo p2)
        {
            if ((float)(p1.TuSo / p1.MauSo) <(float)(p2.TuSo / p2.MauSo))
                return true;
            return false;
        }
        public static bool operator >(PhanSo p1, PhanSo p2)
        {
            if ((float)(p1.TuSo / p1.MauSo) > (float)(p2.TuSo / p2.MauSo))
                return true;
            return false;
        }
        public static PhanSo CKNgamDinh(int a)
        {
            PhanSo p=new PhanSo();
            p.TuSo=a;
            p.MauSo=1;
            return p;
        }
        public static float CKTuongMinh(PhanSo p)
        {
            return (float)p.TuSo/p.MauSo;
        }
        public void sort()
        {

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap bieu thuc (vd: 1/2 + 1/5): ");
            PhanSo p1 = new PhanSo();
            PhanSo p2 = new PhanSo();
            PhanSo p = new PhanSo();
            string[] s = Console.ReadLine().Split();
            p1.TuSo = (int)s[0][0] - 48;
            p1.MauSo = (int)s[0][2] - 48;
            p2.TuSo = (int)s[2][0] - 48;
            p2.MauSo = (int)s[2][2] - 48;
            if (s[1] == "+")
            {
                p = p1+p2;
            }
            if (s[1] == "-")
            {
                p = p1-p2;
            }
            if (s[1] == "*")
            {
                p = p1*p2;
            }
            if (s[1] == "/")
            {
                p = p1/(p2);
            }
            p = p.RutGon(p);
            p.Xuat();
            Console.WriteLine("\n");
            PhanSo[] danhSachPhanSo = new PhanSo[]
            {
                 new PhanSo(3, 4),
                 new PhanSo(1, 2),
                 new PhanSo(2, 3),
                 new PhanSo(5, 6)
            };
            Console.WriteLine("Danh sach phan so truoc khi sap xep: ");
            for(int i=0; i<3; i++)
            {
                danhSachPhanSo[i].Xuat();
            }
            Console.WriteLine("\n");
            Array.Sort(danhSachPhanSo);
            Console.WriteLine("Danh sach phan so truoc khi sap xep tang: ");
            for (int i = 0; i < 3; i++)
            {
                danhSachPhanSo[i].Xuat();
            }
            Console.ReadKey();


        }
    }
}
