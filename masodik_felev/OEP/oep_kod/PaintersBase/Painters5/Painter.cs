namespace Painters5
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
            Mansion.Instance().AddResident(this);
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

        public void PaintOn<T>(Canvas canvas, object[] param) where T : IPaintable
        {
            IPaintable painting;
            int chromaCost;
            if (canvas.Paintings.Count >= canvas.PaintingLimit())
            {
                throw new Exception();
            }
            if (typeof(T) == typeof(Character))
            {
                string name = (string)param[0];
                int age = (int)param[1];
                chromaCost = (int)param[2];
                painting = new Character(name, age, chromaCost);
            } else if (typeof(T) == typeof(PaintedBuilding))
            {
                chromaCost = (int)param[0];
                painting = new PaintedBuilding(chromaCost);
            } else
            {
                throw new Exception();
            }
            if (CurrentChroma < chromaCost)
            {
                throw new Exception();
            }
            CurrentChroma -= chromaCost;
            canvas.Paint(painting);
            if (typeof(T) == typeof(Character))
            {
                Creations.Add((painting as Character)!);
            }
        }

        public bool MostLikedCreation(out Character? mostLiked)
        {
            if (Creations.Count == 0)
            {
                throw new Exception();
            }
            bool found = false;
            mostLiked = null;
            for (int i = 0; i < Creations.Count; i++)
            {
                if (Creations[i].IsLikedPerson())
                {
                    if (found)
                    {
                        if (Creations[i].Reputation() > mostLiked!.Reputation())
                        {
                            mostLiked = Creations[i];
                        }
                    } else
                    {
                        mostLiked = Creations[i];
                        found = true;
                    }
                }
            }
            return found;
        }

        public bool SearchForNotFullCanvas(out Canvas? c)
        {
            c = Works.FirstOrDefault(cnvs => cnvs.Paintings.Count < cnvs.PaintingLimit());
            return c is not null;
        }
    }
}
