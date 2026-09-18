using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldsmith
{

    public class Sapphire : Gemstone
    {
        public Sapphire(double weight, int colour, GemCut cut) : base(weight, colour, cut) { }
        public override double Multiplier()
        {
            return 1.5;
        }
    }
}
