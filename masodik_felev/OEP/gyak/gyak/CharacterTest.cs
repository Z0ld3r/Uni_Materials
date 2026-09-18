using Microsoft.VisualStudio.TestTools.UnitTesting;
using Painters3;

namespace Painter3Test
{
    [TestClass]
    public class CharacterTest
    {
        private Character character;

        [TestInitialize]
        public void InitialSetup()
        {
            character = new Character("Gustave", 32, 200);
        }

        [TestMethod]
        public void ConstructorTest()
        {
            Assert.AreEqual("Gustave", character.Name, "There is an issue with Character constructor not setting the fields correctly.");
            Assert.AreEqual(32, character.Age, "There is an issue with Character or Person constructor not setting the fields correctly.");
            Assert.AreEqual(200, character.ChromaCost, "There is an issue with Character or Person constructor not setting the fields correctly.");
        }

        [TestMethod]
        public void TimePassedTest()
        {
            character.TimePassed(1);
            Assert.AreEqual(36, character.Age, "There is an issue with Character.TimePassed not setting the Age correctly.");
            character.TimePassed(3);
            Assert.AreEqual(48, character.Age, "There is an issue with Character.TimePassed not setting the Age correctly.");
        }
    }
}
