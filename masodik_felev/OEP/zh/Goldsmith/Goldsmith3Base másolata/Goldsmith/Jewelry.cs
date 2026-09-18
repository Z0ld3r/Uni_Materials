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
        private List<Gemstone> gems = new List<Gemstone>();
        public List<Gemstone> Gems
        {
            get { return gems; }
        }

        private string metal;

        private int purity;

        private int id;
        public int Id
        {
            get { return id; }
        }

        public Jewelry(string m, int p, List<Gemstone> g, int id)
        {
            metal = m;
            purity = p;
            gems = g;           //kivulrol kapja a listat: aggregacio
            this.id = id;
        }

        public double Price()
        {
            return GemPriceSum() + purity * 1000 + BrilliantCount() * 5000;
        }

        private int BrilliantCount()        //return SUM 1 \n e in gems \n e is Diamond... feltetel (szamlalas)
        {
            int db = 0;

            foreach(Gemstone e in gems)
            {
                if (e is Diamond && e.Cut == GemCut.Round)
                {
                    db++;
                }
            }

            return db;
        }


        private double GemPriceSum()            //return SUM e.Value() \n e in gems (osszegzes)
        {
            double sum = 0;

            foreach (Gemstone e in gems)
            {
                sum = sum + e.Value();
            }

            return sum;
        }


        public bool IsEveryGem(GemCut c)        //return ∀SEARCH e.Cut=c \n e in gems (optimista linearis kereses/mind eldontes)
        {
            bool l = true;
            Gemstone elem;

            foreach(Gemstone e in gems)
            {
                if (l == (e.Cut == c)) ; else { l = false;  elem = e; break; }
            }

            return l;
        }


    }
}
