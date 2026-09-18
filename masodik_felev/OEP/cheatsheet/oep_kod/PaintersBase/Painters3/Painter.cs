namespace Painters3
{
    public class Painter : Person
    {
        public const int CHROMA_PER_HOUR = 150;

        public int MaxChroma { get; private set; }
        public int CurrentChroma { get; private set; }

        public List<Character> Creations { get; private set; }
        public List<Canvas> Works { get; private set; }

        public Painter(string name, int age, int chroma) : base(name, age)
        {
            MaxChroma = chroma;
            CurrentChroma = chroma;
            Creations = new List<Character>();
            Works = new List<Canvas>();
        }

        public override void TimePassed(int hour)
        {
            CurrentChroma = Math.Min(CurrentChroma + hour * CHROMA_PER_HOUR, MaxChroma);
            foreach (Character character in Creations)
            {
                character.TimePassed(hour);
            }
        }

        public void BuyCanvas(Canvas canvas, string title)
        {
            if (Works.Contains(canvas))
            {
                throw new Exception();
            }
            Canvas? c = Works.FirstOrDefault(c => c.Title == title);
            if (c is not null)
            {
                throw new Exception();
            }
            canvas.SetTitle(title);
            Works.Add(canvas);
        }

        public void PaintOn(Canvas canvas, string name, int age, int chromaCost)
        {
            if (CurrentChroma < chromaCost)
            {
                throw new Exception();
            }
            if (canvas.Paintings.Count >= canvas.PaintingLimit())
            {
                throw new Exception();
            }
            CurrentChroma -= chromaCost;
            Character newCharacter = new Character(name, age, chromaCost);
            canvas.Paint(newCharacter);
            Creations.Add(newCharacter);
        }

        public Character MostLikedCreation()
        {
            if (Creations.Count == 0)
            {
                throw new Exception();
            }
            return Creations.Aggregate((c1, c2) => c1.Reputation() >= c2.Reputation() ? c1 : c2);
        }

        public bool SearchForNotFullCanvas(out Canvas? c)
        {
            c = Works.FirstOrDefault(cnvs => cnvs.Paintings.Count < cnvs.PaintingLimit());
            return c is not null;
        }
    }
}
