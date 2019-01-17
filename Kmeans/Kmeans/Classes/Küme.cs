using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Means
{
    class Küme
    {
        public double x { get; set; }
        public double y { get; set; }
        public List<Düğüm> noktaları = new List<Düğüm>();
        public Color renk;
        public Küme(double x, double y , Color c)
        {
            this.x = x;
            this.y = y;
            this.renk = c;
        }

        public override string ToString()
        {
            return "(" + x + "," + y + ")";
        }
    }
}
