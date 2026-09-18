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
        public List<Jewelry> Exhibited { get; private set; }
        public Workshop Workshop { get; set; }

        public Goldsmith(string n, int e)
        {
            name = n;
            experience = e;
            Exhibited = new List<Jewelry>();
        }

        public void MakeJewelry(string m, int p, List<Gemstone> g, int id)
        {
            if (Workshop == null)
            {
                throw new Exception("Nincs hol dolgoznom!");
            }
            if (g.Count > 2 && experience < 3) { throw new Exception(); }
            Workshop.PutIntoSafe(new Jewelry(m, p, g, id));
        }

        public void ExhibitJewelry(int id)
        {
            (bool l, Jewelry jewelry) = Workshop.SearchForJewelry(id);
            if (l && !Exhibited.Contains(jewelry))
            {
                Exhibited.Add(jewelry);
            }
        }
    }
}
