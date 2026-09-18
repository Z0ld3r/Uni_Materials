using Painters5;

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

            Assert.AreEqual(r.Person, person);
            Assert.AreEqual(r.Status, RelationStatus.Like);
        }
    }
}