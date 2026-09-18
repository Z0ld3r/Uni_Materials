using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldsmith
{
    public abstract class Gemstone
    {
        protected GemCut cut;
        public GemCut Cut
        {
            get { return cut; }
            set { cut = value; }
        }

        protected double weight;
        protected int colour;

        public Gemstone(double w, int c, GemCut cut)
        {
            this.weight = w;
            this.colour = c;
            this.Cut = cut;
        }

        public double Value()
        {
            return Multiplier() * weight * colour;
        }

        public abstract double Multiplier();


    }
}
