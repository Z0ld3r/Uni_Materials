namespace Goldsmith
{
    public enum GemCut
    {
        ROUND,
        PRINCESS,
        OVAL,
        CUSHION
    }

    public abstract class Gemstone
    {
        public double weight { get; private set; }
        public int colour { get; private set; }
        public GemCut cut { get; private set; }

        public Gemstone(double weight, int colour, GemCut cut)
        {
            this.weight = weight;
            this.colour = colour;
            this.cut = cut; 
        }

        public double Value()
        {
            return Multiplier() * weight * colour;
        }

        public abstract double Multiplier();
    }


    public class Sapphire : Gemstone
    {
        public Sapphire(double weight, int colour, GemCut cut) : base(weight, colour, cut) { }
        public override double Multiplier()
        {
            return 1.5;
        }
    }

    public class Diamond : Gemstone
    {
        public Diamond(double weight, int colour, GemCut cut) : base(weight, colour, cut) { }
        public override double Multiplier()
        {
            return 2.5;
        }
    }

    public class Emerald : Gemstone
    {
        public Emerald(double weight, int colour, GemCut cut) : base(weight, colour, cut) { }
        public override double Multiplier()
        {
            return 3.5;
        }
    }

    public class Ruby : Gemstone
    {
        public Ruby(double weight, int colour, GemCut cut) : base(weight, colour, cut) { }
        public override double Multiplier()
        {
            return 4.5;
        }
    }
}
