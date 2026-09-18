namespace Painters3
{
    public class Character : Person
    {
        public int ChromaCost { get; }

        public Character(string name, int age, int chroma) : base(name, age)
        {
            ChromaCost = chroma;
        }

        public override void TimePassed(int hour)
        {
            Age += hour * 4;
        }
    }
}
