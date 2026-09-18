namespace Painters5
{
    public class Character : Person, IPaintable
    {
        private readonly int chromaCost;

        public Character(string name, int age, int chroma) : base(name, age)
        {
            chromaCost = chroma;
        }

        public int GetChromaCost()
        {
            return chromaCost;
        }

        public override void TimePassed(int hour)
        {
            Age += hour * 4;
        }
    }
}
