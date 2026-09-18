using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace beadando
{
    public interface IRagadozoVisitor
    {
        void Visit(Lemming l);
        void Visit(Nyul n);
        void Visit(Javorszarvas j);
    }

    public abstract class Kolonia
    {
        public string Nev { get; protected set; }
        public char Faj { get; protected set; }
        public int Egyedszam { get; set; }

        public Kolonia(string nev, char faj, int szam)
        {
            Nev = nev;
            Faj = faj;
            Egyedszam = szam;
        }

        public void KovetkezoKor(int kor)
        {
            if (Egyedszam <= 0) return;

            Szaporodik(kor);
            EllenorizTulnepesedes();
        }

        protected abstract void Szaporodik(int kor);
        protected virtual void EllenorizTulnepesedes() { }
    }

    public abstract class Zsakmany : Kolonia
    {
        protected Zsakmany(string nev, char faj, int szam) : base(nev, faj, szam) { }
        public abstract void Accept(IRagadozoVisitor r);
    }

    public class Lemming : Zsakmany
    {
        public Lemming(string n, int sz) : base(n, 'l', sz) { }
        public override void Accept(IRagadozoVisitor r) => r.Visit(this);

        protected override void Szaporodik(int kor)
        {
            if (kor % 2 == 0) Egyedszam *= 2;
        }

        protected override void EllenorizTulnepesedes()
        {
            if (Egyedszam >= 200) Egyedszam = 30;
        }
    }

    public class Nyul : Zsakmany
    {
        public Nyul(string n, int sz) : base(n, 'n', sz) { }
        public override void Accept(IRagadozoVisitor r) => r.Visit(this);

        protected override void Szaporodik(int kor)
        {
            if (kor % 2 == 0) Egyedszam = (int)(Egyedszam * 1.5);
        }

        protected override void EllenorizTulnepesedes()
        {
            if (Egyedszam >= 100) Egyedszam = 20;
        }
    }

    public class Javorszarvas : Zsakmany
    {
        public Javorszarvas(string n, int sz) : base(n, 'j', sz) { }
        public override void Accept(IRagadozoVisitor r) => r.Visit(this);

        protected override void Szaporodik(int kor)
        {
            if (kor % 4 == 0) Egyedszam = (int)(Egyedszam * 1.2);
        }

        protected override void EllenorizTulnepesedes()
        {
            if (Egyedszam >= 200) Egyedszam = 40;
        }
    }

    public abstract class Ragadozo : Kolonia, IRagadozoVisitor
    {
        protected Ragadozo(string nev, char faj, int szam) : base(nev, faj, szam) { }

        public void Tamad(Zsakmany celpont)
        {
            if (Egyedszam > 0 && celpont.Egyedszam > 0)
                celpont.Accept(this);
        }

        protected void VadaszatLogika(Zsakmany zs, double tamadasiArany, double eltartokepesseg)
        {
            int elejtett = (int)(zs.Egyedszam * tamadasiArany);
            zs.Egyedszam -= elejtett;

            if (eltartokepesseg > 0)
            {
                int eltarthato = (int)(elejtett / eltartokepesseg);
                if (eltarthato < Egyedszam) Egyedszam = eltarthato;
            }
        }

        public abstract void Visit(Lemming l);
        public abstract void Visit(Nyul n);
        public abstract void Visit(Javorszarvas j);
    }

    public class Hobagoly : Ragadozo
    {
        public Hobagoly(string n, int sz) : base(n, 'h', sz) { }
        public override void Visit(Lemming l) => VadaszatLogika(l, 0.3, 2);
        public override void Visit(Nyul n) => VadaszatLogika(n, 0.2, 1);
        public override void Visit(Javorszarvas j) => VadaszatLogika(j, 0, 0);

        protected override void Szaporodik(int kor)
        {
            if (kor % 3 == 0) Egyedszam += (Egyedszam / 4) * 2;
        }
    }

    public class Roka : Ragadozo
    {
        public Roka(string n, int sz) : base(n, 's', sz) { }
        public override void Visit(Lemming l) => VadaszatLogika(l, 0.05, 4);
        public override void Visit(Nyul n) => VadaszatLogika(n, 0.35, 2);
        public override void Visit(Javorszarvas j) => VadaszatLogika(j, 0, 0);

        protected override void Szaporodik(int kor)
        {
            if (kor % 3 == 0) Egyedszam += (Egyedszam / 4) * 3;
        }
    }

    public class Jegesmedve : Ragadozo
    {
        public Jegesmedve(string n, int sz) : base(n, 'm', sz) { }
        public override void Visit(Lemming l) => VadaszatLogika(l, 0.02, 20);
        public override void Visit(Nyul n) => VadaszatLogika(n, 0.01, 10);
        public override void Visit(Javorszarvas j) => VadaszatLogika(j, 0.25, 0.5);

        protected override void Szaporodik(int kor)
        {
            if (kor % 8 == 0) Egyedszam += (Egyedszam / 4) * 1;
        }
    }

    public class Tundra
    {
        private List<Zsakmany> zsakmanyok = new List<Zsakmany>();
        private List<Ragadozo> ragadozok = new List<Ragadozo>();
        private int kezdetiRagadozoOsszeg;
        private Random rnd = new Random();

        public void Beolvas(string fajlnev)
        {
            string[] sorok = File.ReadAllLines(fajlnev);
            string[] elsoSor = sorok[0].Split(' ');
            int zsakmanyDb = int.Parse(elsoSor[0]);

            for (int i = 1; i < sorok.Length; i++)
            {
                string[] adatok = sorok[i].Split(' ');
                string nev = adatok[0];
                char faj = adatok[1][0];
                int szam = int.Parse(adatok[2]);

                switch (faj)
                {
                    case 'l': zsakmanyok.Add(new Lemming(nev, szam)); break;
                    case 'n': zsakmanyok.Add(new Nyul(nev, szam)); break;
                    case 'j': zsakmanyok.Add(new Javorszarvas(nev, szam)); break;
                    case 'h': ragadozok.Add(new Hobagoly(nev, szam)); break;
                    case 's': ragadozok.Add(new Roka(nev, szam)); break;
                    case 'm': ragadozok.Add(new Jegesmedve(nev, szam)); break;
                }
            }
            kezdetiRagadozoOsszeg = ragadozok.Sum(r => r.Egyedszam);
        }

        public void Futtat()
        {
            int kor = 1;
            while (!VegeE())
            {
                Console.WriteLine($"\n--- {kor}. KÖR ---");

                foreach (var zs in zsakmanyok) zs.KovetkezoKor(kor);

                foreach (var r in ragadozok.Where(r => r.Egyedszam > 0))
                {
                    var eloZsakmanyok = zsakmanyok.Where(z => z.Egyedszam > 0).ToList();
                    if (eloZsakmanyok.Count > 0)
                    {
                        var celpont = eloZsakmanyok[rnd.Next(eloZsakmanyok.Count)];
                        r.Tamad(celpont);
                    }
                    r.KovetkezoKor(kor);
                }

                AllapotKiiras();
                kor++;
            }
            KihaltEllenorzes();
        }

        private bool VegeE()
        {
            bool mindenKritikus = ragadozok.All(r => r.Egyedszam < 4);
            bool osszesMegduplazodott = ragadozok.Sum(r => r.Egyedszam) >= kezdetiRagadozoOsszeg * 2;
            return mindenKritikus || osszesMegduplazodott;
        }

        private void AllapotKiiras()
        {
            foreach (var k in zsakmanyok.Cast<Kolonia>().Concat(ragadozok))
                Console.WriteLine($"{k.Nev} ({k.Faj}): {k.Egyedszam}");
        }

        private void KihaltEllenorzes()
        {
            Console.WriteLine("\nSzimuláció vége.");
            var fajok = new char[] { 'l', 'n', 'j', 'h', 's', 'm' };
            foreach (var f in fajok)
            {
                int ossz = zsakmanyok.Where(z => z.Faj == f).Sum(z => z.Egyedszam) +
                           ragadozok.Where(r => r.Faj == f).Sum(r => r.Egyedszam);
                if (ossz <= 0) Console.WriteLine($"A(z) {f} faj teljesen kihalt!");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Tundra tundra = new Tundra();
            try
            {
                tundra.Beolvas("bemenet.txt");
                tundra.Futtat();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hiba: " + e.Message);
            }
        }
    }
}
