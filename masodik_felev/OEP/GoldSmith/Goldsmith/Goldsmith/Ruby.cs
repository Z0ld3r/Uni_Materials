using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldsmith
{
    public class Ruby : Gemstone
    {
        public Ruby(double weight, int colour, GemCut cut) : base(weight, colour, cut) { }
        public override double Multiplier()
        {
            return 4.5;
        }
    }
}
