using Painters5;

namespace Painter5Test
{
    [TestClass]
    public class StructureTest
    {
        [TestMethod]
        public void MansionTest()
        {
            Mansion m1 = Mansion.Instance();
            Mansion m2 = Mansion.Instance();
            Assert.AreEqual(m1, m2);

            Assert.IsNotNull(m1.Residents);

            Character c = new Character("TestCharacter", 50, 1);

            Assert.ThrowsException<Exception>(() => m1.AddResident(c));

            Painter p = new Painter("TestPainter", 50, 1);

            Assert.AreEqual(1, m1.Residents.Count);
        }

        [TestMethod]
        public void PaintedBuildingTest()
        {
            PaintedBuilding building = new PaintedBuilding(1);

            Painter p = new Painter("TestPainter", 50, 1);
            Assert.ThrowsException<Exception>(() => building.AddResident(p));

            Character c = new Character("TestCharacter", 50, 1);
            building.AddResident(c);
            Assert.AreEqual(1, building.Residents.Count);
        }
    }
}
