namespace Painters3
{
        public enum RelationStatus {
            Hate,
            Dislike,
            Neutral,
            Like,
            Love
        }

        public class Relation{
            public Person person;
            public RelationStatus s;

            public Relation(Person person, RelationStatus s)
            {
                this.person = person;
                this.s = s;
            }
        }

        public abstract class Person {
            private string Name;
            protected int age;
            public List<Relation> relations;

            public string getName()
            {
                return Name;
            }

            public int getAge()
            {
                return age;
            }

            public Person(string n, int a)
            {
                Name = n;
                age = a;
                relations = new List<Relation>();
           }

            public int Reputation()
            {
                int rep = 0;
                foreach (Relation r in relations)
                {
                    rep += (int)r.s;
                }
                return rep;
            }
            
            public bool IsLikedPerson()
            {
                return Reputation() / relations.Count() > (int)RelationStatus.Like;
            }

            public abstract void TimePassed(int hour);

            public void SetRelation(Person p, RelationStatus s)
            {
                int i = 0;
                while (relations[i].person != p && i < relations.Count())
                {
                    i++;
                }
                bool found = i < relations.Count();
                if (found) {
                    relations[i].s = s;                    
                }
                else
                {
                    Relation relation = new Relation(p, s);
                    relations.Add(relation);
                }
            }

            

        }

        public class Painter : Person
        {
            public static int CHROMA_PER_HOUR = 150;
            public int MaxChroma;
            public int CurrentChroma;
            public List<Canvas> Works;
            public List<Character> Creations;

            public int getMaxChroma()
            {
                return MaxChroma;
            }

            public int getCurrentChroma()
            {
                return CurrentChroma;
            }

            public void PaintOn(Painter painter) { }

            public Painter(string n, int a, int c) : base(n, a)
            {
                this.MaxChroma = c;
                this.CurrentChroma = c;
                Works = new List<Canvas>();
                Creations = new List<Character>();
            }

            public override void TimePassed(int hour)
            {
                CurrentChroma = CurrentChroma + hour * CHROMA_PER_HOUR;
                CurrentChroma = Math.Min(CurrentChroma, MaxChroma);

                foreach (Character p in Creations)
                {
                    p.TimePassed(hour);
                }
            }

            public List<Character> GetCreations()
            {
                return Creations;
            }

            public List<Canvas> GetWorks()
            {
                return Works;
            }

            public void BuyCanvas(Canvas canvas, string title)
            {
                if (Works.Contains(canvas))
                {
                    throw new ArgumentException();
                }

                int i = 0;
                while (i < Works.Count && Works[i].GetTitle() != title)
                {
                    i++;
                }
                bool found = i < Works.Count;
                if (found)
                {
                    throw new ArgumentException();
                }
                canvas.SetTitle(title);
                works.Add(canvas);

            }
        }

        public interface IPaintable
        {
            int GetChromaCost();
        }



        public class Character : Person, IPaintable
        {
            private int chromaCost;
            public Character(string n, int a, int c) : base(n, a)
            {
                chromaCost = c;
            }

            public override void TimePassed(int hour)
            {
                age = age * 4;
            }

            public int GetChromaCost()
            {
                return chromaCost;
            }
        }

        public abstract class Canvas
        {
            public string Title;
            public List<IPaintable> Paintings;

            public string GetTitle() { return Title; }

            public Canvas()
            {
                Title = "";
                Paintings = new List<IPaintable>();
            }
            public void SetTitle(string title)
            {
                if (this.Title != "")
                {
                    throw new ArgumentNullException();
                }
                this.Title = title;
            }

            public void Paint(IPaintable painted)
            {
                if (!Paintings.Contains(painted)) { 
                    Paintings.Add(painted);
                }
            }

            public abstract int PaintingLimit();

        }

        public class Portrait : Canvas
        {
            public Portrait() : base() { }
            public override int PaintingLimit()
            {
                return 1;
            }
        }

        public class Small : Canvas
        {
            public Small() : base() { }
            public override int PaintingLimit()
            {
                return 3;
            }
        }

        public class Large : Canvas
        {
            public Large() : base() { }
            public override int PaintingLimit()
            {
                return 6;
            }
        }

    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
