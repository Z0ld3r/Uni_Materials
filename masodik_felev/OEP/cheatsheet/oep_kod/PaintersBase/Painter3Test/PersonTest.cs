using Painters3;

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
            Assert.AreEqual("TestPainter", person.Name, "There is an issue with Person constructor not setting the fields correctly.");
            Assert.AreEqual(33, person.Age, "There is an issue with Person constructor not setting the fields correctly.");
            Assert.IsNotNull(person.Relations, "There is an issue with Person constructor not setting the fields correctly.");
        }

        [TestMethod]
        public void RelationShipTest()
        {
            Person p1 = new TestPerson("Renoir", 50);
            Person p2 = new TestPerson("Aline", 50);
            Person p3 = new TestPerson("Clea", 22);

            person.SetRelation(p1, RelationStatus.Like);
            Assert.AreEqual(true, person.IsLikedPerson(), "There is an issue with either IsLikedPerson or SetRelation");

            person.SetRelation(p2, RelationStatus.Dislike);
            Assert.AreEqual(false, person.IsLikedPerson(), "There is an issue with either IsLikedPerson or SetRelation");

            person.SetRelation(p3, RelationStatus.Neutral);
            Assert.AreEqual(false, person.IsLikedPerson(), "There is an issue with either IsLikedPerson or SetRelation");

            Assert.AreEqual(3, person.Relations.Count, "There is an issue with SetRelation. It does not store Relation objects.");

            person.SetRelation(p3, RelationStatus.Like);
            person.SetRelation(p2, RelationStatus.Neutral);
            Assert.AreEqual(3, person.Relations.Count, "There is an issue with SetRelation. It stores multiple Relation objects with the same person.");

            int reputationCalc = (int)RelationStatus.Like + (int)RelationStatus.Neutral + (int)RelationStatus.Like;
            int reputationActual = person.Reputation();
            Assert.AreEqual(reputationCalc, reputationActual, 
                "There is an issue with either Reputation or RelationStatus enum. " +
                "Reputation might not calculate the sum value correctly, or the values in RelationStatus might not be in the correct order.");
        }
    }
}
