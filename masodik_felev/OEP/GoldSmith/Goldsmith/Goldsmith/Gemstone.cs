using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldsmith
{
    public abstract class Gemstone
    {
        public double weight { get; private set; }
        public int colour { get; private set; }
        public GemCut cut { get; private set; }

        public Gemstone(double weight, int colour, GemCut cut)
        {
            this.weight = weight;
            this.colour = colour;
            this.cut = cut;
        }

        public double Value()
        {
            return Multiplier() * weight * colour;
        }

        public abstract double Multiplier();
    }
}
