using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldsmith
{
    public class Workshop
    {
        public string adress { get; private set; }
        public double income { get; private set; }
        public Goldsmith owner { get; private set; }
        public List<Jewelry> jewelries { get; private set; }

        public Workshop(string a, Goldsmith o)
        {
            adress = a;
            owner = o;
            income = 0;
            jewelries = new List<Jewelry>();
            owner.workshop = this;
        }

        public (bool, Jewelry) SearchForJewelry(int id)
        {
            foreach (Jewelry var in jewelries)
            {
                if (var.id == id)
                {
                    return (true, var);
                }
            }
            return (false, null);
        }

        public void PutIntoSafe(Jewelry j)
        {
            (bool l, j) = SearchForJewelry(j.id);
            if (!l) { jewelries.Add(j); }
        }

        public (double, Jewelry) MostExpensive()
        {
            if (jewelries.Count == 0)
            {
                throw new Exception();
            }
            double max = 0;
            Jewelry ret = null;
            foreach (Jewelry var in jewelries)
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
            (bool l, _) = SearchForJewelry(j.id);
            if (!l)
            {
                throw new Exception();
            }
            if (!owner.exhibited.Contains(j))
            {
                income += j.Price();
                jewelries.Remove(j);
            }

        }
    }
}
