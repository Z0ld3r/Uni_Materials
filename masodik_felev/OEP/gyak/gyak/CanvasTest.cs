using Painters3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Assert.AreEqual(string.Empty, canvas.Title, "Canvas contructor does not set the fields correctly.");
            Assert.IsNotNull(canvas.Paintings, "Canvas contructor does not set the fields correctly.");
        }

        [TestMethod]
        public void LimitTest()
        {
            Canvas c1 = new Portrait();
            Canvas c2 = new Small();
            Canvas c3 = new Large();

            Assert.AreEqual(1, c1.PaintingLimit(), "There is an issue with Portrait.PaintingLimit's return value");
            Assert.AreEqual(3, c2.PaintingLimit(), "There is an issue with Small.PaintingLimit's return value");
            Assert.AreEqual(6, c3.PaintingLimit(), "There is an issue with Large.PaintingLimit's return value");
        }

        [TestMethod]
        public void SetTitleTest()
        {
            Portrait p = new Portrait();

            p.SetTitle("Goblu");
            Assert.AreEqual("Goblu", p.Title, "SetTitle does not set the title correctly");
            Assert.ThrowsException<Exception>(() => p.SetTitle("Goblu"), "SetTitle does not throw an excpetion when trying to set Canvas's title a second time");
        }

        [TestMethod]
        public void PaintTest()
        {
            Character character = new Character("Gustave", 32, 200);
            canvas.Paint(character);

            Assert.AreEqual(1, canvas.Paintings.Count, "There is an issue with Canvas.Paint not storing the painted characters.");
            Assert.IsTrue(canvas.Paintings.Contains(character), "There is an issue with Canvas.Paint not storing the painted characters.");

            Assert.ThrowsException<Exception>(() => canvas.Paint(character), 
                "There is an issue with Canvas.Paint not throwing an error if trying to add an already painted character.");
        }
    }
}
