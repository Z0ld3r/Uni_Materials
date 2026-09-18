using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldsmith
{
    public class Goldsmith
    {
        private List<Jewelry> exhibited = new List<Jewelry>();
        public List<Jewelry> Exhibited
        {
            get { return exhibited; }
        }

        private Workshop? workshop;
        public Workshop? Workshop
        {
            get { return workshop; }
            set { workshop = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
        }

        private int experience;
        public int Experience
        {
            get { return experience; }
        }

        public Goldsmith(string n, int e)
        {
            name = n;
            experience = e;
            workshop = null;
            exhibited = new List<Jewelry>();
        }

        public void MakeJewelry(string m, int p, List<Gemstone> g, int id)
        {
            if(g.Count > 2 && experience < 3)
            {
                throw new Exception();
            }

            if (workshop == null)            //ezek nelkul a workshop zolddel ala lenne huzva, az exception: "object reference not set to an instance of an object"
            {
                throw new Exception();
            }

            workshop.PutIntoSafe(new Jewelry(m, p, g, id));     // ^^ itt volt a workshopnal egy possible null reference, ilyeneket nem szabad hagyni (kompozicio, kell legye egy workshop)
            //^^ itt hozza letre a muhely a jewelryket: kompozicio (de akkor itt a workshop hamarabb letezik, mint legalabb egy jewelry, nem? ha nem letezhet az egesz a resz nelkul, akkor a kialakulasi sorrend nem jewelry -> workshop -> goldsmith? ---- NEM, mert tervben ez igy szep es jo de a kodban es a valo eletben is inkabb forditott a sorrend. ez jo igy)        
        }

        public void ExhibitJewelry(int id)
        {
            bool l;
            Jewelry? jewelry;

            if (workshop == null)
            {
                throw new Exception();
            }

            (l, jewelry) = workshop.SearchForJewelry(id);

            /*if (jewelry == null)            //exception type of system exception was thrown: itt NEM kellett volna exceptiont dobni
            {
                throw new Exception();
            }*/

            if (l && !(exhibited.Contains(jewelry)) )
            {
                exhibited.Add(jewelry);
            }
        }


    }
}
