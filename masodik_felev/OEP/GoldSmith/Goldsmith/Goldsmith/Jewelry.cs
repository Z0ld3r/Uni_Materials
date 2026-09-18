using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Goldsmith
{
    public class Jewelry
    {
        public string metal { get; private set; }
        public int purity { get; private set; }
        public int Id { get; private set; }
        public List<Gemstone> Gems { get; private set; }

        public Jewelry(string m, int p, List<Gemstone> g, int id)
        {
            metal = m;
            purity = p;
            this.Gems = g;
            this.Id = id;
        }

        public double Price() { return GemPriceSum() + purity * 1000 + BrilliantCount() * 5000; }

        private int BrilliantCount()
        {
            int c = 0;
            foreach (Gemstone gem in Gems)
            {
                if (gem.GetType() == typeof(Diamond) && gem.cut == GemCut.Round) { c++; }

            }
            return c;
        }

        private double GemPriceSum()
        {
            double s = 0;
            foreach (Gemstone gem in Gems)
            {
                s += gem.Value();
            }
            return s;
        }

        public bool IsEveryGem(GemCut c)
        {
            foreach (Gemstone gem in Gems)
            {
                if (gem.cut != c)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
