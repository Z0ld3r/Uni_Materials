namespace kodzhpot
{
    internal class Program
    {
        static bool wolde(int i, string[] utszam)
        {
            int j = 0;
            while (j<=i-1 && !(utszam[i]==utszam[j]))
            {
                j++;
            }
            bool van = j <= i - 1;
            return van;
        }
        static void Main(string[] args)
        {
            int ind = 0;
            int n;
            Console.WriteLine("Enter the number of passports:");
            while (int.TryParse(Console.ReadLine(), out n) != true)
            {
                Console.Error.WriteLine("Invalid input. Please enter an integer.");
            }
            string[] utszam = new string[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter passport number " + (i + 1) + ":");
                utszam[i] = Console.ReadLine();
            }
            while (ind < n && !(wolde(ind, utszam)))
            {
                ind++;
            }
            bool van = ind < n;
            if (van)
            {
                string  tlaah = utszam[ind];
            }
            if (van)
            {
                Console.WriteLine("The first passport number to cross the border twice: " + utszam[ind]);
            }
            else
            {
                Console.WriteLine("There has not been a case of someone crossing the border twice.");
            }
        }
    }
}
