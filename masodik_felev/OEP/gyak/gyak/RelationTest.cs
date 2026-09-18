using Painters3;

namespace Painter3Test
{
    [TestClass]
    public class RelationTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Person person = new Character("TestCharacter", 10, 10);
            Relation r = new Relation(person, RelationStatus.Like);

            Assert.AreEqual(r.Person, person, "There is an issue with Relation constructor not setting the fields correctly.");
            Assert.AreEqual(r.Status, RelationStatus.Like, "There is an issue with Relation constructor not setting the fields correctly.");
        }
    }
}