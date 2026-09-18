namespace Painters5
{
    public abstract class Structure
    {
        public List<Person> Residents { get; protected set; }

        public Structure()
        {
            Residents = new List<Person>();
        }

        public virtual void AddResident(Painter p)
        {
            throw new Exception();
        }

        public virtual void AddResident(Character c)
        {
            throw new Exception();
        }
    }

    public class PaintedBuilding : Structure, IPaintable
    {
        private readonly int chromaCost;

        public PaintedBuilding(int c)
        {
            chromaCost = c;
        }

        public int GetChromaCost()
        {
            return chromaCost;
        }

        public override void AddResident(Character c)
        {
            Residents.Add(c);
        }
    }

    public class Mansion : Structure
    {
        private static Mansion? instance;
        public static Mansion Instance()
        {
            if (instance == null)
            {
                instance = new Mansion();
            }
            return instance;
        }

        private Mansion() : base() { }

        public override void AddResident(Painter p)
        {
            Residents.Add(p);
        }
    }
}
