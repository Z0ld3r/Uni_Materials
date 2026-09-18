using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepingCity
{
    public class Player
    {
        public string Nev { get; protected set; }
        public bool Jatekban { get; protected set; }
        public int Rep { get; protected set; }

        public Player(string n, int r) { 
            Nev = n;
            Rep = r;
            Jatekban = true;
        }

        public virtual bool IsOrvos()
        {
            return false;
        }

        public virtual bool IsPolgar()
        {
            return false;
        }
        public virtual bool IsGyilkos()
        {
            return false;
        }

        public virtual void Vedobeszed() { }
    }



    public class Doctor : Player
    {

        public Doctor(string Nev, int r) : base(Nev, r) { }
        public override bool IsOrvos()
        {
            return true;
        }

        public override void Vedobeszed()
        {
            Rep += 2;
        }
    }

    public class Citizen : Player
    {
        public Citizen(string Nev, int r) : base(Nev, r) { }
        public override bool IsPolgar()
        {
            return true;
        }

        public override void Vedobeszed()
        {
            Rep += 4;
        }
    }

    public class Killer : Player
    {
        public List<Player> deathlist;
        public Killer(string Nev, int r, List<Player> dl) : base(Nev, r) {
            deathlist = dl;
        }
        public override bool IsGyilkos()
        {
            return true;
        }

        public override void Vedobeszed()
        {
            Rep += 6;
        }

        private Player Jatekos()
        {
            
        }
    }
}
