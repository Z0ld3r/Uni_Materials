using Goldsmith.TestUtils;

namespace Goldsmith.Test;

[TestCase(4)]
public class TestGoldsmith
{
    [TestMethod(1, Description = "Strukturális tesztek Aranykovács számára")]
    public void TestStructure()
    {
        Assert.That.HasNoPublicFields<Goldsmith>();
        Assert.That.HasProperty<Goldsmith>("Exhibited", true, false);
        Assert.That.HasProperty<Goldsmith>("Workshop", true, true);
    }

    [TestMethod(2, Description = "Test jewelry creation")]
    public void TestMakeJewelry()
    {
        Assert.That.Catch<Exception>(() => new Goldsmith("Géza", 50).MakeJewelry("asd", 6, [], 1));
        PrettyPrint.Green("Can't do it nowhere, boss");
        Assert.That.Catch<Exception>(() =>
        {
            Goldsmith g = new Goldsmith("", 2);
            _ = new Workshop("", g);
            g.MakeJewelry("", 5, [null!, null!, null!], 5);
        });
        PrettyPrint.Green("Sorry boss, I'm far too stupid to do that");
        Goldsmith g1 = new Goldsmith("Okoska", 3);
        Goldsmith g2 = new Goldsmith("Törperős", 2);
        Workshop w1 = new Workshop("1. gomba", g1);
        Workshop w2 = new Workshop("2. gomba", g2);
        g1.MakeJewelry("metal", 6, [null!, null!, null!], 4);
        g2.MakeJewelry("metal", 6, [null!, null!], 4);
        Assert.AreEqual(1, w1.Jewelries.Count, "3XP-3ring");
        Assert.AreEqual(1, w2.Jewelries.Count, "2XP-2ring");
    }

    [TestMethod(3, Description = "Test exhibition")]
    public void TestExhibitJewelry()
    {
        Goldsmith g1 = new Goldsmith("Okoska", 3);
        Workshop w1 = new Workshop("1. gomba", g1);
        g1.ExhibitJewelry(5);
        Assert.AreEqual(0, g1.Exhibited.Count, "Can't exhibit nothing");
        w1.Jewelries.Add(new Jewelry("", 4, [], 6));
        g1.ExhibitJewelry(6);
        Assert.AreEqual(1, g1.Exhibited.Count, "Found, so exhibited");
        g1.ExhibitJewelry(6);
        Assert.AreEqual(1, g1.Exhibited.Count, "Prohibition of double exhibition");
        Goldsmith g2 = new Goldsmith("Törperős", 2);
        Workshop w2 = new Workshop("2. gomba", g2);
        Jewelry j1 = new Jewelry("", 6, [], 5);
        Jewelry j2 = new Jewelry("", 7, [], 5);
        w2.Jewelries.Add(j1);
        g2.ExhibitJewelry(5);
        w2.Jewelries[0] = j2;
        g2.ExhibitJewelry(5);
        Assert.AreEqual(2, g2.Exhibited.Count, "If an ID gets stolen, you can exhibit it twice");
    }

    public override string ToString() => "Test Goldsmith class for functionality";
}