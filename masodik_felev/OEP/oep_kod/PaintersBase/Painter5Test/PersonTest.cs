using Painters5;

namespace Painter3Test
{
    [TestClass]
    public class PersonTest
    {
        internal class TestPerson : Person
        {
            internal List<Relation> Relations => this.relations;
            public TestPerson(string name, int age) : base(name, age) { }
            public override void TimePassed(int hour)
            {
                throw new NotImplementedException();
            }
        }

        private TestPerson person;

        [TestInitialize]
        public void InitialSetup()
        {
            person = new TestPerson("TestPainter", 33);
        }

        [TestMethod]
        public void ConstructorTest()
        {
            Assert.AreEqual("TestPainter", person.Name);
            Assert.AreEqual(33, person.Age);
            Assert.IsNotNull(person.Relations);
        }

        [TestMethod]
        public void RelationShipTest()
        {
            Person p1 = new TestPerson("Renoir", 50);
            Person p2 = new TestPerson("Aline", 50);
            Person p3 = new TestPerson("Clea", 22);

            person.SetRelation(p1, RelationStatus.Like);
            Assert.AreEqual(true, person.IsLikedPerson());

            person.SetRelation(p2, RelationStatus.Dislike);
            Assert.AreEqual(false, person.IsLikedPerson());

            person.SetRelation(p3, RelationStatus.Neutral);
            Assert.AreEqual(false, person.IsLikedPerson());

            Assert.AreEqual(3, person.Relations.Count);

            person.SetRelation(p3, RelationStatus.Like);
            person.SetRelation(p2, RelationStatus.Neutral);
            Assert.AreEqual(3, person.Relations.Count);

            int reputationCalc = (int)RelationStatus.Like + (int)RelationStatus.Neutral + (int)RelationStatus.Like;
            int reputationActual = person.Reputation();
            Assert.AreEqual(reputationCalc, reputationActual);
        }
    }
}
