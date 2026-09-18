using Goldsmith.TestUtils;

namespace Goldsmith.Test;

[TestCase(3)]
public class TestWorkshop
{
    [TestMethod(1, Description = "Structural tests for Workshop")]
    public void TestStructure()
    {
        Assert.That.HasNoPublicFields<Workshop>();
        Assert.That.HasProperty<Workshop>("Jewelries", true, false);
        Assert.That.HasProperty<Workshop>("Income", true, false);
        Goldsmith g = new Goldsmith("Sanyi", 5);
        Workshop w = new Workshop("addr", g);
        Assert.AreEqual(0, g.Workshops.Count, "Workshop constructor should set up Goldsmith.Workshop property", "Workshop constructor sets up Goldsmith.Workshop property");
    }

    [TestMethod(2, Description = "Test jewelry search")]
    public void TestSearchForJewelry()
    {
        Workshop w = new Workshop("Aprajafalva", new Goldsmith("Robinson", 2));
        Assert.IsFalse(w.SearchForJewelryNice(4).Found, "Can't find no jewelry");
        Jewelry good = new Jewelry("good", 2, [], 42);
        w.Jewelries.Add(good);
        w.Jewelries.Add(new Jewelry("", 2, [], 43));
        Assert.IsFalse(w.SearchForJewelryNice(4).Found, "Can't find the wrong jewelry either");
        Assert.IsTrue(w.SearchForJewelryNice(42).Found, "Can find the right jewelry");
        Assert.AreSame(good, w.SearchForJewelryNice(42).Jewelry, "And the right jewelry is found");
        w.Jewelries.Add(new Jewelry("good", 2, [], 42));
        Assert.AreSame(good, w.SearchForJewelryNice(42).Jewelry, "Even if in trouble");
    }

    [TestMethod(3, Description = "Test most expensive jewelry")]
    public void TestMostExpensive()
    {
        Workshop w = new Workshop("Lakatlan Sziget", new Goldsmith("Szerda", 2));
        Assert.That.Catch<Exception>(() => w.MostExpensive(), "No jewelry? No answer!");
        Jewelry winner = new Jewelry("ok", 1, [], 2);
        w.Jewelries.Add(winner);
        Assert.AreEqual((1000, winner), w.MostExpensive(), "Finds the single element");
        w.Jewelries.Add(new Jewelry("", 0, [], 4));
        Assert.AreEqual((1000, winner), w.MostExpensive(), "Even if there are two");
        w.Jewelries.Add(new Jewelry("", 1, [], 3));
        Assert.AreEqual((1000, winner), w.MostExpensive(), "Even if there are three");
        Jewelry w2 = new Jewelry("", 2, [], 4);
        w.Jewelries.Add(w2);
        Assert.AreEqual((2000, w2), w.MostExpensive(), "But we still keep an open mind");

        w = new Workshop("Érdekes Sziget", new Goldsmith("Csütörtök", 50));
        winner = new Jewelry("strange", 0, [new Diamond(Double.NegativeInfinity, 1, GemCut.Cushion)], 4);
        w.Jewelries.Add(winner);
        Assert.AreEqual((double.NegativeInfinity, winner), w.MostExpensive());
        w.Jewelries.Add(new Jewelry("strange", 0, [new Diamond(Double.NegativeInfinity, 1, GemCut.Cushion)], 4));
        Assert.AreEqual((double.NegativeInfinity, winner), w.MostExpensive());
    }

    [TestMethod(4, Description = "Test OnlyOneTypeOfCut")]
    public void TestOnlyOneTypeOfCut()
    {
        Workshop w = new Workshop("NFK", new Goldsmith("Norbi", -1));
        Assert.AreEqual(0, w.OnlyOneTypeOfCut(GemCut.Round).Count, "No gems, no cuts");
        w.Jewelries.Add(new Jewelry("", 4, [new Diamond(2, 2, GemCut.Cushion), new Ruby(2, 2, GemCut.Round)], 4));
        Assert.AreEqual(0, w.OnlyOneTypeOfCut(GemCut.Round).Count, "Only different");
        Jewelry[] exp = new[]
        {
            new Jewelry("", 4, [], 4),
            new Jewelry(",", 5, [new Ruby(5, 1, GemCut.Cushion), new Ruby(5, 6, GemCut.Cushion)], 5)
        };
        w.Jewelries.AddRange(exp);
        w.Jewelries.Add(new Jewelry("", 4, [new Diamond(4, 4, GemCut.Princess)], 4));
        Assert.That.CollectionEquals(exp, w.OnlyOneTypeOfCut(GemCut.Cushion));
        PrettyPrint.Green("Found cut correctly");
        Assert.That.CollectionEquals(exp[..1], w.OnlyOneTypeOfCut(GemCut.Round));
    }

    [TestMethod(5, Description = "Test jewelry selling")]
    public void TestSellJewelry()
    {
        Goldsmith o = new Goldsmith("Béla", 5);
        o.OpenWorkshop("Sarok");
        Workshop w = o.Workshops[0];
        Jewelry j = new Jewelry("", 5, [], 5);
        w.Jewelries.Add(j);
        Assert.That.Catch<Exception>(() => w.SellJewelry(new Jewelry(",", 5, [], 6)));
        Assert.AreEqual(0, w.Income, "Unfair business practices", "Unscrupulous business practices");
        w.SellJewelry(new Jewelry("", 7, [], 5));
        Assert.AreEqual(7000, w.Income, "Sold it, right?");
        Assert.That.CollectionEquals([j], w.Jewelries);
        PrettyPrint.Green("Infinite money glitch working");
        Jewelry j2 = new Jewelry("", 6, [], 5);
        o.Exhibited.Add(j2);
        w.SellJewelry(j2);
        Assert.AreEqual(7000, w.Income, "Could not sell it, unfortunately");
        Assert.That.CollectionEquals([j], w.Jewelries);
        w.SellJewelry(j);
        Assert.AreEqual(12000, w.Income, "Sold (twice)");
        Assert.That.CollectionEquals([], w.Jewelries);
    }

    [TestMethod(6, Description = "Test stashing jewelry")]
    public void TestPutIntoSafe()
    {
        Workshop w = new Workshop("NFK", new Goldsmith("Norbi", -1));
        Jewelry j1 = new Jewelry("", 6, [], 1);
        Jewelry j2 = new Jewelry("", 7, [], 2);
        Assert.That.CollectionEquals([], w.Jewelries);
        PrettyPrint.Green("No jewelries yet");
        w.PutIntoSafe(j1);
        Assert.That.CollectionEquals([j1], w.Jewelries);
        w.PutIntoSafe(j1);
        w.PutIntoSafe(new Jewelry("asd", 12, [], 1));
        Assert.That.CollectionEquals([j1], w.Jewelries);
        PrettyPrint.Green("Just look at the IDs, it will be fine");
        w.PutIntoSafe(j2);
        Assert.That.CollectionEquals([j1, j2], w.Jewelries);
        PrettyPrint.Green("... it was fine");
    }
    
    public override string ToString() => "Workshop tests";
}