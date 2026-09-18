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
        private List<Jewelry> jewelries = new List<Jewelry>();
        public List<Jewelry> Jewelries
        {
            get { return jewelries; }
        }

        private Goldsmith owner;

        private string address;
        private double income;
        public double Income
        {
            get { return income; }
        }

        public Workshop(string a, Goldsmith o)
        {
            address = a;
            owner = o;
            income = 0;
            jewelries = new List<Jewelry>();
            owner.Workshop = this;                  //kompozicio
        }

        public void PutIntoSafe(Jewelry? j)
        {
            bool l;
            Jewelry? jewelry;
            
            (l, jewelry) = SearchForJewelry(j.Id);

            if(!l)
            {
                jewelries.Add(j);
            }
        }

        public void SellJewelry(Jewelry? j)
        {
            bool l;
            Jewelry? jewelry;

            (l, jewelry) = SearchForJewelry(j.Id);

            if(!l)
            {
                throw new Exception("Can't find the wrong jewelry either");
            }
            

            if(!(owner.Exhibited.Contains(j)))
            {
                income = income + j.Price();
                jewelries.Remove(j);
            }
        }

        public List<Jewelry> OnlyOneTypeOfCut(GemCut c)         //return ⊕ <e> \n e in jewelries \n e.IsEveryGem(c) (kivalogatas)
        {
            List<Jewelry> OneCut = new List<Jewelry>();
            
            foreach(Jewelry e in jewelries)
            {
                if(e.IsEveryGem(c))
                {
                    OneCut.Add(e);
                }
            }

            return OneCut;
        }


        public (bool, Jewelry?) SearchForJewelry(int id)            //return SEARCH e.id=id \n e in jewelries
        {
            bool l = false;
            Jewelry? elem = null;

            foreach(Jewelry e in jewelries)
            {
                if ((l = (e.Id == id)))
                {
                    l = true;
                    elem = e;
                    break;
                }
            }

            return (l, elem);
        }


        public (double, Jewelry) MostExpensive()        //return MAX e.Price() \n e in jewelries
        {
            if(jewelries.Count == 0)
            {
                throw new Exception();
            }

            double exVal = jewelries[0].Price();
            Jewelry exJewel = jewelries[0];

            foreach(Jewelry e in jewelries)
            {
                if(e.Price() > exVal)
                {
                    exVal = e.Price();
                    exJewel = e;
                }
            }

            return (exVal, exJewel);
        }






    }
}
