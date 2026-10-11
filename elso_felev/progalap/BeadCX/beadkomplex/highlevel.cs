using System;
using System.Collections.Generic;
using System.Linq;
using magas_szintű_mintamegvalósítások;

namespace beadxmod_high_level
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = Beolvasas();

            if (matrix == null) return;

            int[] eredmeny = Feldolgozas(matrix);

            Kiiras(eredmeny);
        }

        static void Uzenet(string szoveg)
        {
            if (!Console.IsInputRedirected)
            {
                Console.Write(szoveg);
            }
        }

        static int[,] Beolvasas()
        {
            Uzenet("Kérem az N (sorok) és M (oszlopok) számát: ");
            string sor = Console.ReadLine();
            if (string.IsNullOrEmpty(sor)) return null;

            string[] db = sor.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(db[0]);
            int m = int.Parse(db[1]);

            int[,] h = new int[n, m];

            Uzenet($"Kérem a {n} db sort, soronként {m} számmal:\n");
            for (int i = 0; i < n; i++)
            {
                Uzenet($"{i + 1}. sor: ");
                string[] soradatok = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < m; j++)
                {
                    h[i, j] = int.Parse(soradatok[j]);
                }
            }
            return h;
        }

        static int[] Feldolgozas(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[] minik = Mintak.Masol(0, m - 1, j =>
                Mintak.Min(0, n - 1, i => matrix[i, j]).minert
            );

            int[] talalatok = Mintak.Kivalogat(0, n - 1,
                i => Mintak.Van(0, m - 1, j => matrix[i, j] == minik[j]),
                i => i + 1
            );

            return talalatok;
        }

        static void Kiiras(int[] eredmeny)
        {
            Uzenet("Eredmény (darabszám és sorszámok): ");
            Console.Write($"{eredmeny.Length} ");
            Console.WriteLine(string.Join(" ", eredmeny));
        }
    }
}

namespace magas_szintű_mintamegvalósítások
{
    public static class Mintak
    {
        public static G Szumma<H, G>(int e, int u, Func<int, H> f, G kezd, Func<G, H, int, G> add)
        {
            G s = kezd;
            for (int i = e; i <= u; i++)
            {
                s = add(s, f(i), i);
            }
            return s;
        }

        public static H[] Masol<H>(int e, int u, Func<int, H> f)
        {
            return Szumma(e, u, f, new List<H>(), (s, p, i) =>
            {
                s.Add(p);
                return s;
            }).ToArray();
        }

        public static H[] Kivalogat<H>(int e, int u, Func<int, bool> t, Func<int, H> f)
        {
            return Szumma(e, u, f, new List<H>(), (s, p, i) =>
            {
                if (t(i))
                {
                    s.Add(p);
                }
                return s;
            }).ToArray();
        }

        public static (int minind, H minert) Min<H>(int e, int u, Func<int, H> f, Func<H, H, bool> isSmaller = null)
        {
            bool _isSmaller(H a, H b)
            {
                if (a is IComparable<H> aa) return aa.CompareTo(b) < 0;
                else return isSmaller != null ? isSmaller(a, b) : false;
            }
            H minert = f(e);
            int minind = e;
            for (int i = e + 1; i <= u; i++)
            {
                if (_isSmaller(f(i), minert))
                {
                    minert = f(i);
                    minind = i;
                }
            }
            return (minind, minert);
        }

        public static (bool van, int ind) Keres(int e, int u, Func<int, bool> t)
        {
            int ind = e;
            while (ind <= u && !t(ind))
            {
                ind++;
            }
            bool van = ind <= u;
            return (van, ind);
        }

        public static bool Van(int e, int u, Func<int, bool> t)
        {
            return Keres(e, u, t).van;
        }
    }
}