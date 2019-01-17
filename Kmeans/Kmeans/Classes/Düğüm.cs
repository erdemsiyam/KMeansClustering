using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Means
{
    class Düğüm
    {
        public double x { get; set; }
        public double y { get; set; }

        public Düğüm(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return "("+x+","+y+")";
        }
    }
}
