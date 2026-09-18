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
        Assert.That.HasProperty<Goldsmith>("Workshops", true, false);
    }

    [TestMethod(2, Description = "Test jewelry creation")]
    public void TestMakeJewelry()
    {
        Assert.That.Catch<Exception>(() =>
        {
            Goldsmith g = new Goldsmith("", 2);
            g.OpenWorkshop("");
            g.MakeJewelry("", 5, [null!, null!, null!], 5, g.Workshops[0]);
        });
        PrettyPrint.Green("Sorry boss, I'm far too stupid to do that");
        Goldsmith g1 = new Goldsmith("Okoska", 3);
        g1.OpenWorkshop("1. gomba");
        Goldsmith g2 = new Goldsmith("Törperős", 2);
        g2.OpenWorkshop("2. gomba");
        g1.MakeJewelry("metal", 6, [null!, null!, null!], 4, g1.Workshops[0]);
        g2.MakeJewelry("metal", 6, [null!, null!], 4, g2.Workshops[0]);
        Assert.AreEqual(1, g1.Workshops[0].Jewelries.Count, "3XP-3ring");
        Assert.AreEqual(1, g2.Workshops[0].Jewelries.Count, "2XP-2ring");
    }

    [TestMethod(3, Description = "Test exhibition")]
    public void TestExhibitJewelry()
    {
        Goldsmith g1 = new Goldsmith("Okoska", 3);
        g1.OpenWorkshop("1. gomba");
        g1.ExhibitJewelry(5, g1.Workshops[0]);
        Assert.AreEqual(0, g1.Exhibited.Count, "Can't exhibit nothing");
        g1.Workshops[0].Jewelries.Add(new Jewelry("", 4, [], 6));
        g1.ExhibitJewelry(6, g1.Workshops[0]);
        Assert.AreEqual(1, g1.Exhibited.Count, "Found, so exhibited");
        g1.ExhibitJewelry(6, g1.Workshops[0]);
        Assert.AreEqual(1, g1.Exhibited.Count, "Prohibition of double exhibition");
        Goldsmith g2 = new Goldsmith("Törperős", 2);
        g2.OpenWorkshop("2. gomba");
        Jewelry j1 = new Jewelry("", 6, [], 5);
        Jewelry j2 = new Jewelry("", 7, [], 5);
        g2.Workshops[0].Jewelries.Add(j1);
        g2.ExhibitJewelry(5, g2.Workshops[0]);
        g2.Workshops[0].Jewelries[0] = j2;
        g2.ExhibitJewelry(5, g2.Workshops[0]);
        Assert.AreEqual(2, g2.Exhibited.Count, "If an ID gets stolen, you can exhibit it twice");
    }

    [TestMethod(4, Description = "Test opening new workshops")]
    public void TestOpenWorkshop()
    {
        Goldsmith g = new Goldsmith("Eötvös", 9999);
        Assert.That.CollectionEquals([], g.Workshops);
        PrettyPrint.Green("No workshops at start");
        g.OpenWorkshop("Déli Tömb");
        Assert.That.CollectionEquals(["Déli Tömb"], g.Workshops.Select(w => w.Address).ToArray());
        PrettyPrint.Green("The workshop exists after creating it");
        g.OpenWorkshop("Kukutyin");
        Assert.That.CollectionEquals(["Déli Tömb", "Kukutyin"], g.Workshops.Select(w => w.Address).ToArray());
        PrettyPrint.Green("Two workshops exist after creating them");
    }

    [TestMethod(5, Description = "Test finding the total income")]
    public void TestTotalIncome()
    {
        Goldsmith g = new Goldsmith("Alexa", 9999);
        Assert.AreEqual(0, g.TotalIncome(), "No work, no income");
        g.OpenWorkshop("Alexafalva");
        g.OpenWorkshop("Pistia");
        g.OpenWorkshop("Miskolc");
        g.Workshops[0].Jewelries.Add(new Jewelry("", 0, [], 5));
        g.Workshops[2].Jewelries.Add(new Jewelry("", 0, [], 5));
        g.Workshops[0].SellJewelry(new Jewelry("", 7, [], 5));
        g.Workshops[2].SellJewelry(new Jewelry("", 5, [], 5));
        Assert.AreEqual(12000, g.TotalIncome(), "But I have sold them!");
    }

    public override string ToString() => "Test Goldsmith class for functionality";
}