using Goldsmith.TestUtils;

namespace Goldsmith.Test;

[TestCase]
public class TestGoldsmithRegistry
{
    private GoldsmithRegistry Instance => GrossHack.GetSingletonInstance<GoldsmithRegistry>();

    [TestMethod(1, Description = "Structural tests for registry")]
    public void TestStructure()
    {
        Assert.That.IsSingleton<GoldsmithRegistry>();
        Assert.That.HasNoPublicFields<GoldsmithRegistry>();
    }

    [TestMethod(2, Description = "Test registration")]
    public void TestRegister()
    {
        Instance.Goldsmiths.Clear();
        Goldsmith b = new Goldsmith("Batman", 50000);
        b.OpenWorkshop("cave");
        b.OpenWorkshop("otherCave");
        Goldsmith r = new Goldsmith("Batman", 1);
        r.OpenWorkshop("cave");
        r.OpenWorkshop("otherCave");
        r.OpenWorkshop("anotherCave");
        r.OpenWorkshop("anotherCaveToBeSure");
        Assert.That.Catch<Exception>(() => Instance.Register(b), "Less than 3 workshops");
        Assert.That.Catch<Exception>(() => Instance.Register(r), "Less than 2 XP");
        Goldsmith j = new Goldsmith("Józsiiii", 2);
        Goldsmith j2 = new Goldsmith("Józsiiii", 2);
        for (int i = 0; i < 3; ++i)
        {
            j.OpenWorkshop("ws");
            j2.OpenWorkshop("ws2");
        }

        Instance.Register(j);
        Assert.That.CollectionEquals([j], Instance.Goldsmiths);
        PrettyPrint.Green("One goldsmith registers");
        Instance.Register(j2);
        Assert.That.CollectionEquals([j], Instance.Goldsmiths);
        PrettyPrint.Green("One goldsmith tries to register twice");
        b.OpenWorkshop("now better?");
        Instance.Register(b);
        Assert.That.CollectionEquals([j, b], Instance.Goldsmiths);
        PrettyPrint.Green("Even Batman registers");
    }

    [TestMethod(3, Description = "Test goldsmith with most income")]
    public void TestMostIncome()
    {
        Instance.Goldsmiths.Clear();
        Assert.That.Catch<Exception>(() => Instance.GoldsmithWithMostIncome());
        Instance.Goldsmiths.Add(new Goldsmith("Józsi", 9999));
        Assert.AreEqual("Józsi", Instance.GoldsmithWithMostIncome().Name, "single element");
        Instance.Goldsmiths.Add(new Goldsmith("Peti", 9999));
        Assert.AreEqual("Józsi", Instance.GoldsmithWithMostIncome().Name, "two equal elements");
        Instance.Goldsmiths.Add(new Goldsmith("Peti", 9999));
        Assert.AreEqual("Józsi", Instance.GoldsmithWithMostIncome().Name, "three equal elements");
        foreach (Goldsmith g in Instance.Goldsmiths)
        {
            g.OpenWorkshop("");
            g.Workshops[0].Jewelries.Add(new Jewelry("", -5, [], 6));
            g.Workshops[0].SellJewelry(new Jewelry("", 1, [new Ruby(Double.NegativeInfinity, 5, GemCut.Cushion)], 6));
        }

        Assert.AreEqual("Józsi", Instance.GoldsmithWithMostIncome().Name, "pretty worthless test, if you ask me");
        Instance.Goldsmiths.Add(new Goldsmith("Sanyi", 5));
        Instance.Goldsmiths.Add(new Goldsmith("Tomi", 5));
        Instance.Goldsmiths[3].OpenWorkshop("");
        Instance.Goldsmiths[3].Workshops[0].Jewelries.Add(new Jewelry("", -1, [], 6));
        Instance.Goldsmiths[3].Workshops[0].SellJewelry(new Jewelry("", -1, [], 6));
        Instance.Goldsmiths[4].OpenWorkshop("");
        Instance.Goldsmiths[4].Workshops[0].Jewelries.Add(new Jewelry("", -1, [], 6));
        Instance.Goldsmiths[4].Workshops[0].SellJewelry(new Jewelry("", -1, [], 6));
        Assert.AreEqual("Sanyi", Instance.GoldsmithWithMostIncome().Name, "find a real maximum");
    }

    [TestMethod(4, Description = "Help those poor bad goldsmiths")]
    public void TestLeastProfitable()
    {
        Instance.Goldsmiths.Clear();
        Assert.IsFalse(Instance.HelpLeastProfitableNice(9999).Found, "no goldsmiths");
        Instance.Goldsmiths.Add(new Goldsmith("Józsi", 9999));
        Assert.IsTrue(Instance.HelpLeastProfitableNice(9999).Found, "single element");
        Assert.AreEqual("Józsi", Instance.HelpLeastProfitableNice(9999).Goldsmith.Name, "single element", "");
        Instance.Goldsmiths.Add(new Goldsmith("Peti", 9999));
        Assert.IsTrue(Instance.HelpLeastProfitableNice(9999).Found, "two equal elements");
        Assert.AreEqual("Józsi", Instance.HelpLeastProfitableNice(9999).Goldsmith.Name, "two equal elements", "");
        Instance.Goldsmiths.Add(new Goldsmith("Peti", 9999));
        Assert.IsTrue(Instance.HelpLeastProfitableNice(9999).Found, "three equal elements", "");
        Assert.AreEqual("Józsi", Instance.HelpLeastProfitableNice(9999).Goldsmith.Name, "three equal elements", "");
        Assert.IsFalse(Instance.HelpLeastProfitableNice(9998).Found, "not found if no such experience");
        foreach (Goldsmith g in Instance.Goldsmiths)
        {
            g.OpenWorkshop("");
            g.Workshops[0].Jewelries.Add(new Jewelry("", -5, [], 6));
            g.Workshops[0].SellJewelry(new Jewelry("", 1, [new Ruby(Double.PositiveInfinity, 5, GemCut.Cushion)], 6));
        }

        Assert.IsTrue(Instance.HelpLeastProfitableNice(9999).Found, "pretty worthless test, if you ask me");
        Assert.AreEqual("Józsi", Instance.HelpLeastProfitableNice(9999).Goldsmith.Name,
            "pretty worthless test, if you ask me", "");
        Instance.Goldsmiths.Add(new Goldsmith("Sanyi", 5));
        Instance.Goldsmiths.Add(new Goldsmith("Tomi", 9999));
        Instance.Goldsmiths.Add(new Goldsmith("Gergő", 9999));
        Instance.Goldsmiths[3].OpenWorkshop("");
        Instance.Goldsmiths[3].Workshops[0].Jewelries.Add(new Jewelry("", -1, [], 6));
        Instance.Goldsmiths[3].Workshops[0]
            .SellJewelry(new Jewelry("", 1, [new Ruby(Double.NegativeInfinity, 1, GemCut.Princess)], 6));
        Assert.IsTrue(Instance.HelpLeastProfitableNice(9999).Found, "find a real minimum");
        Assert.AreEqual("Tomi", Instance.HelpLeastProfitableNice(9999).Goldsmith.Name, "find a real minimum", "");
    }
}