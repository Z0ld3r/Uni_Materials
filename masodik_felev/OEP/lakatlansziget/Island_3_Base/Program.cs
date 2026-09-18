using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Island_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShipwreckedTest();
            HouseTest();
            IslandTest();
        }

        static void ShipwreckedTest()
        {
            Shipwrecked sw1 = new Shipwrecked("Karcsi", 10, 20);
            sw1.ReduceStrength(6);
            Check(() => sw1.Strength == 4, "After reducing strenght by 6, strenght should be 4");

            Shipwrecked sw2 = new Shipwrecked("Karcsi", 10, 20);
            sw2.ReduceStrength(20);
            Check(() => sw2.Strength == 0, "After reducing strenght by 20, strenght should be 0");

            Shipwrecked sw3 = new Shipwrecked("Karcsi", 10, 20);
            sw3.ReduceStrength(7);
            sw3.ReduceStrength(7);
            Check(() => sw3.Strength == 0, "After reducing strenght by 7 two times, strenght should be 0");

            Shipwrecked sw4 = new Shipwrecked("Karcsi", 10, 20);
            sw4.Die();
            Check(() => sw4.Strength == 0, "After death, strenght should be 0");
        }

        static void HouseTest()
        {
            Shipwrecked sw1 = new Shipwrecked("Karcsi", 57, 20);
            Shipwrecked sw2 = new Shipwrecked("Hektor", 87, 20);
            Shipwrecked sw3 = new Shipwrecked("Thalia", 40, 20);
            sw3.Die();

            House h1 = null!;
            CheckNoException(() => h1 = new House(new List<Shipwrecked>() { sw1, sw2 }), "House can be constructed without exception.");
            CheckException(() => new House(new List<Shipwrecked>() { sw1 }), "House constructor throws exception when someone already has a home.");
            CheckException(() => new House(new List<Shipwrecked>() { sw3 }), "House constructor throws exception when someone dead tries to build it.");

            Check(() => sw1.Strength == 54, "After working on house, strenght should be reduced by 3.");
            Check(() => sw2.Home == h1, "After working on house, it should be set as home.");
            Check(() => h1.Condition == 10, "House condition should start at 10.");

            sw2.Die();
            Check(() => !h1.Residents.Contains(sw2), "After death, person should be removed from residents.");

            h1.ReduceCondition(3);
            Check(() => h1.Condition == 7, "After reducing condition by 3, condition should be 7");

            h1.ReduceCondition(10);
            Check(() => h1.Condition == 0, "After reducing condition by 3 and 10, condition should be 0");


            Check(() => sw1.Home == null, "After house collapsing, home should be null.");
            Check(() => sw1.Strength == 44, "After house collapsing, strenght should be reduced by 10.");
        }


        static void IslandTest()
        {
            Island i1 = new Tropical();

            Shipwrecked sw1 = new Shipwrecked("Karcsi", 57, 20);
            Shipwrecked sw2 = new Shipwrecked("Hektor", 87, 20);

            CheckNoException(() => i1.Arrive(sw1), "Shipwrecked can arrive on island.");
            CheckException(() => i1.Arrive(sw1), "Shipwrecked can not arrive twice on island.");

            Check(() => sw1.Strength == 52, "Arriving should reduce strenght by 5.");

            CheckNoException(() => i1.Build(new List<Shipwrecked>() { sw1 }), "Shipwrecked can build house on island.");
            CheckException(() => i1.Build(new List<Shipwrecked>() { sw2 }), "Not arrived shipwrecked can not build house on island.");

            Island i2 = new Desert();
            Check(() => i2.WeakestShipwrecked().Item1 == false, "There is no weakest on an empty island.");
            Shipwrecked sw3 = new Shipwrecked("Thalia", 40, 20);
            i2.Arrive(sw3);
            sw3.Die();
            Check(() => i2.WeakestShipwrecked().Item1 == false, "There is no weakest on an island with dead people.");
            i2.Arrive(sw2);
            Check(() => i2.WeakestShipwrecked() == (true, 82, sw2), "Weakest person is correctly choosen when there is only one person.");
            Shipwrecked sw4 = new Shipwrecked("Hugo", 12, 60);
            Shipwrecked sw5 = new Shipwrecked("Zolta", 20, 17);
            i2.Arrive(sw4);
            i2.Arrive(sw5);
            Check(() => i2.WeakestShipwrecked() == (true, 7, sw4), "Weakest person is correctly choosen with multiple people.");

            DisasterTest(new Tropical(), new List<int> { 57, 84, 40 }, new List<int> { 9, 9, 9 }, "On a tropical island, the homeless person's strenght should be reduced by 3.", "On a tropical island, all houses' condition should be reduced by 1.");
            DisasterTest(new Mediterranean(), new List<int> { 57, 87, 40 }, new List<int> { 8, 8, 8 }, "On a mediterranean island, strenghts should be unchanged.", "On a tropical island, all houses' condition should be reduced by 2.");
            DisasterTest(new Desert(), new List<int> { 57, 87, 0 }, new List<int> { 9, 9, 9 }, "On a desert island, the weakest person should die.", "On a desert island, all houses' condition should be reduced by 1.");
        }

        static void DisasterTest(Island i, List<int> strenghts, List<int> conditions, string strenghtText, string conditionText)
        {
            Shipwrecked sw1 = new Shipwrecked("Karcsi", 65, 20);
            Shipwrecked sw2 = new Shipwrecked("Hektor", 92, 20);
            Shipwrecked sw3 = new Shipwrecked("Thalia", 48, 20);

            i.Arrive(sw1);
            i.Arrive(sw2);
            i.Arrive(sw3);

            i.Build(new List<Shipwrecked> { sw1 });
            i.Build(new List<Shipwrecked> { sw3 });
            List<House> houses = new List<House>() { sw1.Home!, sw3.Home! };

            i.Disaster();

            Check(() => i.Shipwreckeds.Zip(strenghts).All(pair => pair.First.Strength == pair.Second), strenghtText);
            Check(() => houses.Zip(conditions).All(pair => pair.First.Condition == pair.Second), conditionText);
        }


        static void Check(Func<bool> func, string text, bool expectException = false)
        {
            bool good = false;
            try
            {
                good = func.Invoke();
                if (expectException)
                {
                    good = false;
                }
            }
            catch (Exception)
            {
                good = expectException;
            }

            if (good)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(text + " - OK");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(text + " - NOT OK");
            }
            Console.ResetColor();
        }

        static void CheckException(Action func, string text)
        {
            Check(() => { func.Invoke(); return false; }, text, true);
        }

        static void CheckNoException(Action func, string text)
        {
            Check(() => { func.Invoke(); return true; }, text, false);
        }

        static void Label(string text)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
