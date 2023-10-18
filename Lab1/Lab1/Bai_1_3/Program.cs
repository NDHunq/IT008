using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Collections;
using Microsoft.SqlServer.Server;
using System.Runtime.CompilerServices;

namespace BT_LTTQ
{
    public class Program
    {
        static void Main(string[] args)
        {

            string s = Console.ReadLine();
            Ham h = new Ham();
            h.lonnhat(s);
            h.nhonhat(s);


        }


    }
    public class Ham
    {
        public void lonnhat(string ch)
        {
            string[] chuoi = ch.Split(' ');
            int[] s = new int[chuoi.Length];
            for (int i = 0; i < chuoi.Length; i++)
                if (int.TryParse(chuoi[i], out s[i]) == false)
                    goto nextcase;

            int max = s[0];
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] > max) max = s[i];
            }
            Console.WriteLine(max);
            return;

        nextcase:
            double[] d = new double[chuoi.Length];
            for (int i = 0; i < chuoi.Length; i++)
                if (double.TryParse(chuoi[i], out d[i]) == false)
                    goto nextcase2;
            double max2 = d[0];
            for (int i = 1; i < s.Length; i++)
            {
                if (d[i] > max2) max2 = d[i];
            }
            Console.WriteLine(max2);
            return;

        nextcase2:
            int max3 = chuoi[0].Length;
            for (int i = 1; i < s.Length; i++)
            {
                if (chuoi[i].Length > max3) max3 = chuoi[i].Length;
            }
            for (int i = 0; i < chuoi.Length; i++)
                if (chuoi[i].Length == max3)
                    Console.WriteLine(chuoi[i]);
            return;
        }
        public void nhonhat(string ch)
        {
            string[] chuoi = ch.Split(' ');
            int[] s = new int[chuoi.Length];
            for (int i = 0; i < chuoi.Length; i++)
                if (int.TryParse(chuoi[i], out s[i]) == false)
                    goto nextc;

            int min = s[0];
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] <min) min  = s[i];
            }
            Console.WriteLine(min);
            return;

        nextc:
            double[] d = new double[chuoi.Length];
            for (int i = 0; i < chuoi.Length; i++)
                if (double.TryParse(chuoi[i], out d[i]) == false)
                    goto nextc2;
            double min2 = d[0];
            for (int i = 1; i < s.Length; i++)
            {
                if (d[i] <min2) min2 = d[i];
            }
            Console.WriteLine(min2);
            return;

        nextc2:
            int min3 = chuoi[0].Length;
            for (int i = 1; i < s.Length; i++)
            {
                if (chuoi[i].Length <min3) min3 = chuoi[i].Length;
            }
            for (int i = 0; i < chuoi.Length; i++)
                if (chuoi[i].Length == min3)
                    Console.WriteLine(chuoi[i]);
            return;
        }
    }

}