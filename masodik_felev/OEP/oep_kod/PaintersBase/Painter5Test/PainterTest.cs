using Painters5;

namespace Painter3Test
{
    [TestClass]
    public class PainterTest
    {
        private Painter painter;

        [TestInitialize]
        public void InitialSetup()
        {
            painter = new Painter("Renoir", 50, 1500);
        }

        [TestMethod]
        public void ConstructorTest()
        {
            Assert.AreEqual(150, Painter.CHROMA_PER_HOUR);
            Assert.AreEqual(1500, painter.MaxChroma);
            Assert.AreEqual(1500, painter.CurrentChroma);
            Assert.IsNotNull(painter.Works);
        }

        [TestMethod]
        public void BuyCanvasTest()
        {
            Small small = new Small();
            painter.BuyCanvas(small, "Visages");

            Assert.AreEqual(1, painter.Works.Count);
            Assert.ThrowsException<Exception>(() => painter.BuyCanvas(small, "Eveque"));

            Small small2 = new Small();
            Assert.ThrowsException<Exception>(() => painter.BuyCanvas(small2, "Visages"));

            Small small3 = new Small();
            painter.BuyCanvas(small3, "Duellist");
            Assert.AreEqual(2, painter.Works.Count);
        }

        [TestMethod]
        public void PaintTest()
        {
            Small canvas = new Small();
            painter.BuyCanvas(canvas, "Infinity Tower");
            painter.PaintOn<Character>(canvas, ["Verso", 110, 1000]);

            Assert.AreEqual(500, painter.CurrentChroma);
            Assert.AreEqual(1500, painter.MaxChroma);
            Assert.AreEqual(1, canvas.Paintings.Count);

            Assert.ThrowsException<Exception>(() => painter.PaintOn<Character>(canvas, ["Alicia", 16, 600]));
            Assert.AreEqual(500, painter.CurrentChroma);

            painter.PaintOn<Character>(canvas, ["Monoco", 560, 150]);
            painter.PaintOn<Character>(canvas, ["Esquie", 560, 300]);

            Assert.AreEqual(3, canvas.Paintings.Count);
            Assert.AreEqual(3, painter.Creations.Count);

            Assert.ThrowsException<Exception>(() => painter.PaintOn<Character>(canvas, ["Noco", 560, 50]));

            Large large = new Large();
            painter.BuyCanvas(large, "Old Lumiére");

            painter.TimePassed(3);

            painter.PaintOn<PaintedBuilding>(large, [1]);

            Assert.AreEqual(3, painter.Creations.Count);
            Assert.AreEqual(1, large.Paintings.Count);
        }

        [TestMethod]
        public void SearchNotFullTest()
        {
            Small small = new Small();
            Portrait portrait = new Portrait();
            Large large = new Large();

            bool found = painter.SearchForNotFullCanvas(out Canvas? c);
            Assert.IsFalse(found);

            painter.BuyCanvas(small, "Visages");

            found = painter.SearchForNotFullCanvas(out c);
            Assert.IsTrue(found);
            Assert.IsNotNull(c);

            painter.BuyCanvas(large, "Lumiére");
            painter.BuyCanvas(portrait, "Duellist");

            painter.PaintOn<Character>(portrait, ["Duellist", 1500, 1]);
            painter.PaintOn<Character>(small, ["Verso", 110, 1]);
            painter.PaintOn<Character>(small, ["Monoco", 560, 1]);
            painter.PaintOn<Character>(small, ["Esquie", 560, 1]);

            found = painter.SearchForNotFullCanvas(out c);
            Assert.IsTrue(found);
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void MostLikedTest()
        {
            Large large = new Large();
            painter.BuyCanvas(large, "Lumiére");

            Character? output;
            Assert.ThrowsException<Exception>(() => painter.MostLikedCreation(out output));

            painter.PaintOn<Character>(large, ["Gustave", 32, 1]);
            painter.PaintOn<Character>(large, ["Sophie", 33, 1]);
            painter.PaintOn<Character>(large, ["Sol", 36, 1]);
            painter.PaintOn<Character>(large, ["Emma", 31, 1]);

            Character gustave = painter.Creations[0];
            Character sophie = painter.Creations[1];
            Character sol = painter.Creations[2];
            Character emma = painter.Creations[3];

            gustave.SetRelation(sophie, RelationStatus.Love); // 4
            gustave.SetRelation(emma, RelationStatus.Like); // 7
            gustave.SetRelation(sol, RelationStatus.Like); // 10

            sophie.SetRelation(gustave, RelationStatus.Love); // 4
            sophie.SetRelation(emma, RelationStatus.Like); // 7

            emma.SetRelation(sophie, RelationStatus.Neutral); // 2
            emma.SetRelation(sol, RelationStatus.Love); // 6

            sol.SetRelation(emma, RelationStatus.Love); // 4

            Assert.IsTrue(painter.MostLikedCreation(out output));
            Assert.AreEqual(gustave,output);
        }
    }
}
