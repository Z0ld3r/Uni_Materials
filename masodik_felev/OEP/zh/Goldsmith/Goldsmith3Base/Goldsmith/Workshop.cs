using Goldsmith.TestUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Goldsmith
{
    public class Workshop
    {
        public string adress { get; private set; }
        public double Income { get; private set; }
        public Goldsmith owner { get; private set; }
        public List<Jewelry> Jewelries { get; private set; }

        public Workshop(string a, Goldsmith o)
        {
            adress = a;
            owner = o;
            Income = 0;
            Jewelries = new List<Jewelry>();
            owner.Workshop = this;
        }

        public (bool, Jewelry) SearchForJewelry(int id)
        {
            foreach (Jewelry var in Jewelries)
            {
                if (var.Id == id)
                {
                    return (true, var);
                }
            }
            return (false, null);
        }

        public void PutIntoSafe(Jewelry j)
        {
            (bool l, _) = SearchForJewelry(j.Id);
            if (!l) { Jewelries.Add(j); }
        }

        public (double, Jewelry) MostExpensive()
        {
            if (Jewelries.Count() == 0)
            {
                throw new Exception();
            }
            double max = Jewelries[0].Price();
            Jewelry ret = Jewelries[0];
            foreach (Jewelry var in Jewelries)
            {
                if (var.Price() > max)
                {
                    max = var.Price();
                    ret = var;
                }
            }
            return (max, ret);
        }

        public void SellJewelry(Jewelry j)
        {
            (bool l, _) = SearchForJewelry(j.Id);
            if (!l)
            {
                throw new Exception();
            }
            if (!owner.Exhibited.Contains(j))
            {
                Income += j.Price();
                Jewelries.Remove(j);
            }

        }

        public List<Jewelry> OnlyOneTypeOfCut(GemCut c)
        {
            List<Jewelry> pips = new List<Jewelry>();
            foreach (Jewelry e in Jewelries)
            {
                if (e.IsEveryGem(c))
                {
                    pips.Add(e);
                }
            }
            return pips;
        }
    }
}
