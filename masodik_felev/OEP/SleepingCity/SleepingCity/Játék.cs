using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepingCity
{
    public class Game
    {
        public List<Kor> Korok;
        public Killer Killer;
        public Doctor orvos;
        public List<Player> jatekosok;
        public Game(Doctor d, Killer k, List<Player> jatekosok) { 
            Korok = new List<Kor>();
            gyilkos = k;
            orvos = d;
            this.jatekosok = jatekosok;
        }
        public void Run()
        {

        }

        public bool JatekVege()
        {
            return VarosNyert() || GyilkosNyert();
        }

        public bool VarosNyert() { return !gyilkos.Jatekban; }
        public bool GyilkosNyert() {
            int c = 0;
            foreach (Player p in jatekosok) { 
                if (!p.IsGyilkos() && p.Jatekban)
                {
                    c++;
                }
            }
            return c <= 1;
        }
    }
}
