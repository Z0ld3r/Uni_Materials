using Painters5;

namespace Painter3Test
{
    [TestClass]
    public class CanvasTest
    {
        private Canvas canvas;

        [TestInitialize]
        public void InitializeSetup()
        {
            canvas = new Small();
        }

        [TestMethod]
        public void ConstructorTest()
        {
            Assert.AreEqual(string.Empty, canvas.Title);
            Assert.IsNotNull(canvas.Paintings);
        }

        [TestMethod]
        public void LimitTest()
        {
            Canvas c1 = new Portrait();
            Canvas c2 = new Small();
            Canvas c3 = new Large();

            Assert.AreEqual(1, c1.PaintingLimit());
            Assert.AreEqual(3, c2.PaintingLimit());
            Assert.AreEqual(6, c3.PaintingLimit());
        }

        [TestMethod]
        public void SetTitleTest()
        {
            Portrait p = new Portrait();

            p.SetTitle("Goblu");
            Assert.AreEqual("Goblu", p.Title);
            Assert.ThrowsException<Exception>(() => p.SetTitle("Goblu"));
        }

        [TestMethod]
        public void PaintTest()
        {
            Character character = new Character("Gustave", 32, 200);
            canvas.Paint(character);

            Assert.AreEqual(1, canvas.Paintings.Count);
            Assert.IsTrue(canvas.Paintings.Contains(character));

            Assert.ThrowsException<Exception>(() => canvas.Paint(character));

            Character c2 = new Character("Maelle", 16, 600);
            PaintedBuilding building = new PaintedBuilding(200);

            canvas.Paint(building);

            Assert.AreEqual(2, canvas.Paintings.Count);
            Assert.AreEqual(1, building.Residents.Count);

            canvas.Paint(c2);
            Assert.AreEqual(2, building.Residents.Count);
        }
    }
}
