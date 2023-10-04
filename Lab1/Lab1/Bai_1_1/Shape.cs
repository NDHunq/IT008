using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1._1
{
    public abstract class Shape
    {
        public string Name { get; set; }

        public abstract void Nhap_diem();
        public abstract double Area();
        public abstract void Draw();

    }
}
