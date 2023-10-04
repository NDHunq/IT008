using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1._4
{
    internal class NhietKe
    {
        public double nhietDo { get; set; }
        public void update_NhietDo()
        {
            Random random  =new Random();
            double change = random.NextDouble()*6-3;
            nhietDo+= change;
        }
        public void set_random_Nhietdo()
        {
            Random random = new Random();
            double start = random.NextDouble() * 50 -10;
            nhietDo = (int)start;
        }

    }
}
