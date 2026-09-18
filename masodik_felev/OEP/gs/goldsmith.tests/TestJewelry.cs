using Goldsmith.TestUtils;

namespace Goldsmith.Test;

[TestCase(2)]
public class TestJewelry
{
    [TestMethod(1,
        Description = "Tests Jewelry for structural soundness (you don't want your necklace to break, right?)")]
    public void TestStructure()
    {
        Assert.That.HasNoPublicFields<Jewelry>();
        Assert.That.HasProperty<Jewelry>("Gems", true, false);
        Assert.That.HasProperty<Jewelry>("Id", true, false);
        List<Gemstone> test = [new Ruby(2, 2, GemCut.Cushion)];
        Jewelry j = new Jewelry("iron", 2, test, 42);
        Assert.AreEqual(42, j.Id, "Constructor should set jewelry ID", "Constructor sets jewelry ID");
        Assert.That.CollectionEquals(test, j.Gems);
        PrettyPrint.Green("Constructor sets gems");
    }
    
    [TestMethod(2, Description = "Test IsEveryGem")]
    public void TestIsEveryGem()
    {
        Assert.IsTrue(new Jewelry("iron", 2, [], 2).IsEveryGem(GemCut.Cushion), "Should return true for empty list");
        Assert.IsTrue(new Jewelry("mercury", 8, [new Ruby(2, 2, GemCut.Oval), new Sapphire(2, 2, GemCut.Oval)], 45)
            .IsEveryGem(GemCut.Oval), "Should return true for correct list");
        Assert.IsFalse(new Jewelry("mercury", 8, [new Ruby(2, 2, GemCut.Cushion), new Sapphire(2, 2, GemCut.Cushion)], 45)
            .IsEveryGem(GemCut.Princess), "Should return false for completely different list");
        Assert.IsFalse(new Jewelry("mercury", 8, [new Ruby(2, 2, GemCut.Oval), new Sapphire(2, 2, GemCut.Cushion)], 45)
            .IsEveryGem(GemCut.Cushion), "Should return false for mixed list");
    }

    [TestMethod(3, Description = "Test counting brilliant diamonds")]
    public void TestBrilliantCount()
    {
        Assert.AreEqual(0, new Jewelry("mud", 0, [], 1).Price(), "No gems are not brilliant at all");
        Assert.AreEqual(0,
            new Jewelry("mud", 0,
                    [new Sapphire(0, 0, GemCut.Round), new Emerald(0, 0, GemCut.Round), new Ruby(0, 0, GemCut.Round)],
                    1)
                .Price(), "No diamonds are not brilliant at all");
        Assert.AreEqual(10000,
            new Jewelry("mud", 0,
                    [new Diamond(0, 0, GemCut.Round), new Emerald(0, 0, GemCut.Round), new Diamond(0, 0, GemCut.Round)],
                    1)
                .Price(), "Diamonds are brilliant");
        Assert.AreEqual(5000,
            new Jewelry("mud", 0,
                    [
                        new Diamond(0, 0, GemCut.Round), new Diamond(0, 0, GemCut.Princess),
                        new Diamond(0, 0, GemCut.Oval), new Diamond(0, 0, GemCut.Cushion)
                    ],
                    1)
                .Price(), "Unless they are not");
    }

    [TestMethod(4, Description = "Test finding the total price of gems")]
    public void TestGemPriceSum()
    {
        Assert.AreEqual(0, new Jewelry("mud", 0, [], 1).Price(), "No gems are cheap");
        Assert.AreEqual(-9, new Jewelry("mud", 0, [new Sapphire(2, -3, GemCut.Cushion)], 1).Price(),
            "But negative colored gems are cheaper");
        Assert.AreEqual(37, new Jewelry("mud", 0, [new Sapphire(2, 3, GemCut.Cushion), new Emerald(2, 4, GemCut.Cushion)], 1).Price(),
            "The code can handle multiple gems");
        Assert.AreEqual(39.5,
            new Jewelry("mud", 0,
            [
                new Sapphire(2, 3, GemCut.Cushion), new Emerald(2, 4, GemCut.Cushion), new Diamond(1, 1, GemCut.Cushion)
            ], 1).Price(),
            "Even three");
    }

    [TestMethod(5, Description = "Test finding the price of jewelry")]
    public void TestPrice()
    {
        Assert.AreEqual(0, new Jewelry("mud", 0, [], 1).Price(), "No gems are cheap");
        Assert.AreEqual(2000, new Jewelry("mud", 2, [], 1).Price(), "Except for when they are pure");
        Assert.AreEqual(50000, new Jewelry("mud", 50, [], 1).Price(), "Or purer (that's not a word, right?)");
        Assert.AreEqual(55039.5,
            new Jewelry("mud", 50,
            [
                new Sapphire(2, 3, GemCut.Cushion), new Emerald(2, 4, GemCut.Cushion), new Diamond(1, 1, GemCut.Round)
            ], 1).Price(), "Let's just add everything, what could go wrong?");
    }

    public override string ToString() => "Test Jewelry";
}