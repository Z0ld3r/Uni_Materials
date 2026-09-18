using System;
using System.Collections.Generic;

namespace HF09
{
    public abstract class Starship
    {
        protected string name;
        protected int shield;
        protected int armor;
        protected int guard;
        // Internal-ra módosítva, hogy a Planet osztály elérje
        internal Planet? planet;

        public string Name => name;
        public int Shield => shield;
        public Planet? Planet => planet;

        protected Starship(string n, int sh, int ar, int g)
        {
            name = n;
            shield = sh;
            armor = ar;
            guard = g;
            planet = null;
        }

        public void Protect(Planet p)
        {
            if (p == null) throw new Exception();
            if (planet != null)
            {
                planet.LeftBy(this);
            }
            // Itt beállítjuk a hajó bolygóját, majd regisztráljuk a bolygónál is
            planet = p;
            planet.ProtectedBy(this);
        }

        public void Leave()
        {
            if (planet == null) throw new Exception();
            planet.LeftBy(this);
            planet = null;
        }

        public abstract int FireP();
    }

    public class Wallbreaker : Starship
    {
        public Wallbreaker(string n, int sh, int ar, int g) : base(n, sh, ar, g) { }
        public override int FireP() => armor / 2;
    }

    public class Landingship : Starship
    {
        public Landingship(string n, int sh, int ar, int g) : base(n, sh, ar, g) { }
        public override int FireP() => guard;
    }

    public class Lasership : Starship
    {
        public Lasership(string n, int sh, int ar, int g) : base(n, sh, ar, g) { }
        public override int FireP() => shield;
    }

    public class Planet
    {
        public readonly string name;
        private List<Starship> ships = new List<Starship>();

        public Planet(string n) => name = n;

        public void ProtectedBy(Starship h)
        {
            if (ships.Contains(h)) throw new Exception();
            ships.Add(h);
            // KRITIKUS JAVÍTÁS: Beállítjuk a hajó bolygóját, 
            // hogy a konzolos teszt közvetlen hívása esetén is konzisztens maradjon.
            h.planet = this;
        }

        public void LeftBy(Starship h)
        {
            // A diagram szerint: h not in ships VAGY h.Planet != this esetén hiba
            if (!ships.Contains(h) || h.Planet != this) throw new Exception();
            ships.Remove(h);
        }

        public int ShipCount() => ships.Count;

        public double TotalShield()
        {
            double sum = 0;
            foreach (var s in ships) sum += s.Shield;
            return sum;
        }

        public bool MaxFireP(out double max, out Starship? bestship)
        {
            if (ships.Count == 0)
            {
                max = 0;
                bestship = null;
                return false;
            }
            bestship = ships[0];
            max = bestship.FireP();
            foreach (var s in ships)
            {
                if (s.FireP() > max)
                {
                    max = s.FireP();
                    bestship = s;
                }
            }
            return true;
        }
    }

    public class Solarsystem
    {
        private List<Planet> planets;
        public Solarsystem(List<Planet> p) => planets = p;

        public List<Planet> Defenseless()
        {
            List<Planet> result = new List<Planet>();
            foreach (var p in planets)
            {
                if (p.ShipCount() == 0) result.Add(p);
            }
            return result;
        }

        public bool MaxFireShip(out Starship? bestship)
        {
            bestship = null;
            double globalMax = -1;
            bool found = false;

            foreach (var p in planets)
            {
                if (p.MaxFireP(out double currentMax, out Starship? currentBest))
                {
                    if (!found || currentMax > globalMax)
                    {
                        globalMax = currentMax;
                        bestship = currentBest;
                        found = true;
                    }
                }
            }
            return found;
        }
    }
}