using TextFile;
namespace bead5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //StreamReader sr = new StreamReader("input.txt");
            TextFileReader reader = new TextFileReader("input.txt");
            bool lmax = false, lmin = false;
            int max = 0, min = 0;
            int e;
            bool van = reader.ReadInt(out e);
            max = e;
            min = e;
            
            while (van)
            {
                if (e >= 0)
                {
                    
                }
                else if (lmax && e<0) 
                {
                    if (e > max)
                    {
                        max = e;
                    }
                }
                else if (!lmax && e < 0)
                {
                    lmax = true;
                    max = e;
                }
                if (e <= 0)
                {
                    
                }
                else if (lmin && e > 0)
                {
                    if (e < min)
                    {
                        min = e;
                    }
                }
                else if (!lmin && e > 0)
                {
                    lmin = true;
                    min = e;
                }
                van = reader.ReadInt(out e);
            }
            if (lmax)
            {
                Console.WriteLine(max);
            }
            else
            {
                Console.WriteLine("nincs");
            }
            if (lmin)
            {
                Console.WriteLine(min);
            }
            else
            {
                Console.WriteLine("nincs");
            }

        }
    }
}
