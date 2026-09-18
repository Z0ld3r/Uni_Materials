using TextFile;

namespace bead6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextFileReader reader = new TextFileReader("input.txt");
            int ossz = 0;
            string sor;
            bool vane = reader.ReadLine(out sor);
            while (vane)
            {
                string[] f = sor.Split(' ');
                if (f.Length >=3)
                {
                    int i = 2;
                    while (i < f.Length)
                    {
                        ossz += int.Parse(f[i]);
                        i += 2;
                    }
                }
                vane = reader.ReadLine(out sor);
            }
            if (vane) { Console.WriteLine("nincs"); }
            else { Console.WriteLine(ossz); }

        }

    }
}
