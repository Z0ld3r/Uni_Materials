using Goldsmith.TestUtils;

namespace Goldsmith.Test;

[TestCase(1)]
public class TestGemstone
{
    [TestMethod(1, Description = "Test correct structure of gemstone classes")]
    public void TestStructure()
    {
        Assert.IsTrue(typeof(Gemstone).IsAbstract, "Gemstone should be abstract", "Gemstone is abstract");
        Assert.That.HasNoPublicFields<Gemstone>();
        Assert.That.HasNoPublicFields<Sapphire>();
        Assert.That.HasNoPublicFields<Diamond>();
        Assert.That.HasNoPublicFields<Emerald>();
        Assert.That.HasNoPublicFields<Ruby>();
        Assert.That.IsSubtypeOf<Gemstone>(typeof(Sapphire));
        Assert.That.IsSubtypeOf<Gemstone>(typeof(Diamond));
        Assert.That.IsSubtypeOf<Gemstone>(typeof(Emerald));
        Assert.That.IsSubtypeOf<Gemstone>(typeof(Ruby));
        Assert.IsTrue(typeof(Gemstone).GetMethod(nameof(Gemstone.Multiplier))!.IsAbstract, "Multiplier should be abstract", "Multiplier is abstract");
        Assert.IsFalse(
            typeof(Gemstone).GetMethod(nameof(Gemstone.Value))!.IsVirtual ||
            typeof(Gemstone).GetMethod(nameof(Gemstone.Value))!.IsAbstract, "Value should not be virtual",
            "Multiplier is not virtual");
        Assert.IsTrue(typeof(GemCut).IsEnum, "GemCut should be an enum", "GemCut is an enum");
        Assert.That.CollectionEquals([GemCut.Round, GemCut.Princess, GemCut.Cushion, GemCut.Oval], Enum.GetValues<GemCut>(), true);
        PrettyPrint.Green("GemCut values are correct");
    }

    [TestMethod(2, Description = "Test multipliers")]
    public void TestMultipliers()
    {
        Assert.AreEqual(1.5, new Sapphire(0, 0, GemCut.Cushion).Multiplier(), "Sapphire should be 1.5", "Sapphire is 1.5");
        Assert.AreEqual(2.5, new Diamond(0, 0, GemCut.Cushion).Multiplier(), "Diamond should be 2.5", "Diamond is 2.5");
        Assert.AreEqual(3.5, new Emerald(0, 0, GemCut.Cushion).Multiplier(), "Emerald should be 3.5", "Emerald is 3.5");
        Assert.AreEqual(4.5, new Ruby(0, 0, GemCut.Cushion).Multiplier(), "Ruby should be 4.5", "Ruby is 4.5");
    }

    [TestMethod(3, Description = "Test gem values")]
    public void TestValues()
    {
        Assert.AreEqual(0, new Diamond(0, 1, GemCut.Cushion).Value(), "Diamond with weight 0 should be worth nothing");
        Assert.AreEqual(0, new Diamond(21.1, 0, GemCut.Oval).Value(), "Diamond with colour 0 should be worth nothing");
        Assert.AreEqual(0, new Emerald(0, 1, GemCut.Princess).Value(), "Emerald with weight 0 should be worth nothing");
        Assert.AreEqual(0, new Emerald(21.1, 0, GemCut.Round).Value(), "Emerald with colour 0 should be worth nothing");
        Assert.AreEqual(0, new Sapphire(0, 1, GemCut.Cushion).Value(), "Sapphire with weight 0 should be worth nothing");
        Assert.AreEqual(0, new Sapphire(21.1, 0, GemCut.Oval).Value(), "Sapphire with colour 0 should be worth nothing");
        Assert.AreEqual(0, new Ruby(0, 1, GemCut.Princess).Value(), "Ruby with weight 0 should be worth nothing");
        Assert.AreEqual(0, new Ruby(21.1, 0, GemCut.Round).Value(), "Ruby with colour 0 should be worth nothing");
        Assert.AreEqual(9, new Sapphire(2, 3, GemCut.Cushion).Value(), "1.5 * 2 * 3 = 9");
        Assert.AreEqual(9, new Sapphire(3, 2, GemCut.Oval).Value(), "1.5 * 3 * 2 = 9");
        Assert.AreEqual(4.5, new Sapphire(3, 1, GemCut.Princess).Value(), "1.5 * 3 * 1 = 9");
        Assert.AreEqual(18, new Ruby(2, 2, GemCut.Round).Value(), "4.5 * 2 * 2 = 18");
        Assert.AreEqual(7.5, new Diamond(1.5, 2, GemCut.Round).Value(), "2.5 * 1.5 * 2 = 7.5");
    }
    
    public override string ToString() => "Test Gemstone and its children";
}