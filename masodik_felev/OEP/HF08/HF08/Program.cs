using System.Drawing;

namespace HF08
{
    internal class Program
    {
        public class Registration
        {
            protected int size;

            public Registration(int size)
            {
                this.size = size;
            }
            public virtual int GetSize()
            {
                return size;
            }
        }
        public class File : Registration
        {
            public File(int size) : base(size)
            {
            }
            public override int GetSize()
            {
                return size;
            }

        }
        public class Folder : Registration
        {
            List<Registration> registrations = new List<Registration>();
            public Folder() : base(0)
            {
                this.size = 0;
                registrations.Clear();
            }
            public void Add(Registration registration)
            {
                registrations.Add(registration);
            }
            public void Remove(Registration registration)
            {
                registrations.Remove(registration);
            }
            public override int GetSize()
            {
                int totalsize = 0;
                foreach (Registration i in registrations)
                {
                    totalsize += i.GetSize();
                }
                return totalsize;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Unittest to run");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "File":
                    TestFile();
                    break;
                case "Folder":
                    TestFolder();
                    break;
            }
        }
        public static void TestFile()
        {
            Console.WriteLine("Unittesting File class");
            Console.WriteLine("Testing - Constructor");
            File tested;
            int testSize;
            try
            {
                Console.WriteLine("Input - Size of file");
                testSize = int.Parse(Console.ReadLine());
                tested = new File(testSize);
            }
            catch
            {
                Console.WriteLine("Result - Constructor - Unsuccessful");
            }
            Console.WriteLine("Testing - GetSize");
            try
            {
                Console.WriteLine("Input - Size of file");
                testSize = int.Parse(Console.ReadLine());
                tested = new File(testSize);
                Console.WriteLine(tested.GetSize());
            }
            catch
            {
                Console.WriteLine("Result - GetSize - Unsuccessful");
            }
            Console.WriteLine("Testing - Inheritance");
            try
            {
                Registration test = new File(10);
                Console.WriteLine("Inherited registration");
            }
            catch
            {
                Console.WriteLine("Result - Inheritance - Unsuccessful");
            }
        }
        public static void TestFolder()
        {
            Console.WriteLine("Unittesting Folder class");
            Console.WriteLine("Testing - Constructor");
            Folder tested;
            try
            {
                tested = new Folder();
            }
            catch
            {
                Console.WriteLine("Result - Constructor - Unsuccessful");
            }
            Console.WriteLine("Testing - Add and Remove");
            try
            {
                tested = new Folder();
                Console.WriteLine(tested.GetSize());
                File new_file = new File(100);
                tested.Add(new_file);
                Console.WriteLine(tested.GetSize());
                tested.Remove(new_file);
                Console.WriteLine(tested.GetSize());
            }
            catch
            {
                Console.WriteLine("Result - Add and Remove - Unsuccessful");
            }
            Console.WriteLine("Testing - GetSize");
            try
            {
                tested = new Folder();
                ReadRegistrations(tested);
                Console.WriteLine(tested.GetSize());
            }
            catch
            {
                Console.WriteLine("Result - GetSize - Unsuccessful");
            }
            Console.WriteLine("Testing - Inheritance");
            try
            {
                Registration test = new File(10);
                Console.WriteLine("Inherited registration");
            }
            catch
            {
                Console.WriteLine("Result - Inheritance - Unsuccessful");
            }
        }
        public static void ReadRegistrations(Folder root)
        {
            Console.WriteLine("Input - Registrations in the folder");
            int numOfRegistrations = int.Parse(Console.ReadLine());
            string[] input;
            for (int i = 0; i < numOfRegistrations; i++)
            {
                Console.WriteLine("Input - Registration");
                input = Console.ReadLine().Split();
                if (input[0] == "Folder")
                {
                    Folder addedFolder = new Folder();
                    root.Add(addedFolder);
                    ReadRegistrations(addedFolder);
                }
                else
                {
                    File addedFile = new File(int.Parse(input[1]));
                    root.Add(addedFile);
                }
            }
        }
    }
}
