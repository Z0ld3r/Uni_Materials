using Painters3;

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
            Assert.AreEqual(150, Painter.CHROMA_PER_HOUR, "The constant's value in Painter class is not correct");
            Assert.AreEqual(1500, painter.MaxChroma);
            Assert.AreEqual(1500, painter.CurrentChroma);
            Assert.IsNotNull(painter.Works);
        }

        [TestMethod]
        public void BuyCanvasTest()
        {
            Small small = new Small();
            painter.BuyCanvas(small, "Visages");

            Assert.AreEqual(1, painter.Works.Count, "BuyCanvas does not store the given Canvas");
            Assert.ThrowsException<Exception>(() => painter.BuyCanvas(small, "Eveque"), 
                "BuyCanvas doesnt throw an exception when an already bought Canvas is given as parameter");

            Small small2 = new Small();
            Assert.ThrowsException<Exception>(() => painter.BuyCanvas(small2, "Visages"),
                "BuyCanvas doesnt throw an exception when a Canvas is given with an already existing name");

            Small small3 = new Small();
            painter.BuyCanvas(small3, "Duellist");
            Assert.AreEqual(2, painter.Works.Count, "BuyCanvas does not store the given Canvas");
        }

        [TestMethod]
        public void PaintTest()
        {
            Small canvas = new Small();
            painter.BuyCanvas(canvas, "Infinity Tower");
            painter.PaintOn(canvas, "Verso", 110, 1000);

            Assert.AreEqual(500, painter.CurrentChroma, "The price for painting a character does not get subtracted from CurrentChroma");
            Assert.AreEqual(1500, painter.MaxChroma, "The MaxChroma field is modified after painting on a Canvas");
            Assert.AreEqual(1, canvas.Paintings.Count, "PaintOn does not save the newly painted Character in the Canvas");

            Assert.ThrowsException<Exception>(() => painter.PaintOn(canvas, "Alicia", 16, 600),
                "PaintOn does not throw an exception if CurrentChroma is less than the required");
            Assert.AreEqual(500, painter.CurrentChroma, "The CurrentChroma is modified even upon an unsuccessful paint");

            painter.PaintOn(canvas, "Monoco", 560, 150);
            painter.PaintOn(canvas, "Esquie", 560, 300);

            Assert.AreEqual(3, canvas.Paintings.Count, "PaintOn does not save the newly painted Character in the Canvas");
            Assert.AreEqual(3, painter.Creations.Count, "PaintOn does not save the newly painted Character in Creations");

            Assert.ThrowsException<Exception>(() => painter.PaintOn(canvas, "Noco", 560, 50),
                "PaintOn does not throw an exception when trying to paint on an already full Canvas");
        }

        [TestMethod]
        public void SearchNotFullTest()
        {
            Small small = new Small();
            Portrait portrait = new Portrait();
            Large large = new Large();

            bool found = painter.SearchForNotFullCanvas(out Canvas? c);
            Assert.IsFalse(found, "SearchForNotFullCanvas does not return with false when searching in an empty list");

            painter.BuyCanvas(small, "Visages");

            found = painter.SearchForNotFullCanvas(out c);
            Assert.IsTrue(found, "SearchForNotFullCanvas does not return with true when the only element in the list is empty");
            Assert.IsNotNull(c, "SearchForNotFullCanvas returns null Canvas when finding an empty one");

            painter.BuyCanvas(large, "Lumiére");
            painter.BuyCanvas(portrait, "Duellist");

            painter.PaintOn(portrait, "Duellist", 1500, 1);
            painter.PaintOn(small, "Verso", 110, 1);
            painter.PaintOn(small, "Monoco", 560, 1);
            painter.PaintOn(small, "Esquie", 560, 1);

            found = painter.SearchForNotFullCanvas(out c);
            Assert.IsTrue(found, "SearchForNotFullCanvas does not return with true when finding an empty element");
            Assert.IsNotNull(c, "SearchForNotFullCanvas returns null Canvas when finding an empty one");
        }

        [TestMethod]
        public void MostLikedTest()
        {
            Large large = new Large();
            painter.BuyCanvas(large, "Lumiére");

            Assert.ThrowsException<Exception>(() => painter.MostLikedCreation(), 
                "MostLikedCreation doesnt throw an excpetion when trying to search in an empty list");

            painter.PaintOn(large, "Gustave", 32, 1);
            painter.PaintOn(large, "Sophie", 33, 1);
            painter.PaintOn(large, "Sol", 36, 1);
            painter.PaintOn(large, "Emma", 31, 1);

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

            Assert.AreEqual(gustave, painter.MostLikedCreation(), "MostLikedCreation returns wrong Character");
        }
    }
}
