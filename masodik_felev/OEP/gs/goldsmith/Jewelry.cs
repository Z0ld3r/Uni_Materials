using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldsmith
{
    public class Jewelry
    {
        public string metal { get; private set; }
        public int purity { get; private set; }
        public int id { get; private set; }
        public List<Gemstone> gems { get; private set; }

        public Jewelry(string m, int p, List<Gemstone> g, int id)
        {
            metal = m;
            purity = p;
            gems = new List<Gemstone>();
            this.id = id;
        }

        public double Price() { return GemPriceSum() + purity * 1000 + BrilliantCount() * 5000; }

        private int BrilliantCount()
        {
            int c = 0;
            foreach (Gemstone gem in gems)
            {
                if (gem.GetType() == typeof(Diamond) && gem.cut == GemCut.ROUND) { c++; }

            }
            return c;
        }

        private double GemPriceSum()
        {
            double s = 0;
            foreach (Gemstone gem in gems)
            {
                s += gem.Value();
            }
            return s;
        }

        public bool IsEveryGem(GemCut c)
        {
            foreach (Gemstone gem in gems)
            {
                if(gem.cut != c)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
