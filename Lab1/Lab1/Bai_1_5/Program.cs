using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap duong dan den thu muc: ");
        string path = Console.ReadLine();

        if (Directory.Exists(path))
        {
            string[] files = Directory.GetFiles(path);
            string[] folders = Directory.GetDirectories(path);

            Console.WriteLine("Files:");
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }

            Console.WriteLine();

            Console.WriteLine("Folders:");
            foreach (string folder in folders)
            {
                Console.WriteLine(folder);
            }
        }
        else
        {
            Console.WriteLine("Duong dan khong ton tai");
        }
    }
}