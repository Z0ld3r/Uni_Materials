using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldsmith
{
    public class Goldsmith
    {
        public string name { get; private set; }
        public int experience { get; private set; }
        public List<Jewelry> exhibited { get; private set; }
        public Workshop workshop { get; set; }

        public Goldsmith(string n, int e)
        {
            name = n;
            experience = e;
            exhibited = new List<Jewelry>();
        }

        public void MakeJewelry(string m, int p, List<Gemstone> g, int id)
        {
            if (g.Count > 2 && experience < 3) { throw new Exception(); }
            workshop.PutIntoSafe(new Jewelry(m, p, g, id));
        }

        public void ExhibitJewelry(int id)
        {
            (bool l, Jewelry jewelry) = workshop.SearchForJewelry(id);
            if (l && !exhibited.Contains(jewelry))
            {
                exhibited.Add(jewelry);
            }
        }
    }
}
