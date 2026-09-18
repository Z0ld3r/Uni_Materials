using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldsmith
{
    public class Sapphire : Gemstone
    {
        public Sapphire(double w, int c, GemCut cut) : base(w, c, cut) { }

        public override double Multiplier()
        {
            return 1.5;
        }
    }
}
