using Painters5;

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
            Assert.AreEqual(32, character.Age);
            Assert.AreEqual(200, character.GetChromaCost());
        }

        [TestMethod]
        public void TimePassedTest()
        {
            character.TimePassed(1);
            Assert.AreEqual(36, character.Age);

            character.TimePassed(3);
            Assert.AreEqual(48, character.Age);
        }
    }
}
