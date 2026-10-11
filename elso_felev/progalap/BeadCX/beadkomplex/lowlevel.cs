using System;
using System.Collections.Generic; // Listához kell

namespace beadxmod
{
    internal class Program
    {
        static int minsor(int colIndex, int[,] h, int n)
        {
            int mini = h[0, colIndex];
            for (int i = 1; i < n; i++)
            {
                if (mini > h[i, colIndex])
                {
                    mini = h[i, colIndex];
                }
            }
            return mini;
        }

        static int[] minik(int[,] h, int n, int m)
        {
            int[] minik = new int[m];
            for (int j = 0; j < m; j++)
            {
                minik[j] = minsor(j, h, n);
            }
            return minik;
        }

        static bool eleme(int[] minik, int[,] h, int rowIndex, int m)
        {
            int k = 0;
            while (k < m && minik[k] != h[rowIndex, k])
            {
                k++;
            }
            return (k < m);
        }

        static void Main(string[] args)
        {
            string sor = Console.ReadLine();
            if (sor == null) return;

            string[] db = sor.Split(' ');
            int n = int.Parse(db[0]);
            int m = int.Parse(db[1]);

            int[,] h = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                string[] soradatok = Console.ReadLine().Split(' ');
                for (int j = 0; j < m; j++)
                {
                    h[i, j] = int.Parse(soradatok[j]);
                }
            }

            int[] mini = minik(h, n, m);

            List<int> talalatok = new List<int>();

            for (int i = 0; i < n; i++)
            {
                if (eleme(mini, h, i, m))
                {
                    talalatok.Add(i + 1);
                }
            }

            Console.Write($"{talalatok.Count} ");

            Console.WriteLine(string.Join(" ", talalatok));
        }
    }
}