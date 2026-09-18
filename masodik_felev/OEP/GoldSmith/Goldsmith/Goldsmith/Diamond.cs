using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldsmith
{
    public class Diamond : Gemstone
    {
        public Diamond(double weight, int colour, GemCut cut) : base(weight, colour, cut) { }
        public override double Multiplier()
        {
            return 2.5;
        }
    }
}
