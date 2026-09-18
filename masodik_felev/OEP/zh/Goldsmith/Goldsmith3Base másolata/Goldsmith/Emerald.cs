using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldsmith
{
    public class Emerald : Gemstone
    {
        public Emerald(double w, int c, GemCut cut) : base(w, c, cut) { }

        public override double Multiplier()
        {
            return 3.5;
        }
    }
}
