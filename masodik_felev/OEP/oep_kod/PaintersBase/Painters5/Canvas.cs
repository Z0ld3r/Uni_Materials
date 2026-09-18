namespace Painters5
{
    public abstract class Canvas
    {
        public string Title { get; private set; }

        public List<IPaintable> Paintings { get; private set; }

        public Canvas()
        {
            Title = string.Empty;
            Paintings = new List<IPaintable>();
        }

        public void SetTitle(string t)
        {
            if (Title != string.Empty)
            {
                throw new Exception();
            }
            Title = t;
        }

        public void Paint(IPaintable painted)
        {
            if (Paintings.Contains(painted))
            {
                throw new Exception();
            }
            PaintedBuilding? s = Paintings.FirstOrDefault(p => p is PaintedBuilding) as PaintedBuilding;
            if (painted is PaintedBuilding structure)
            {
                if (s is not null)
                {
                    throw new Exception();
                }
                foreach (IPaintable paintable in Paintings)
                {
                    structure.AddResident((paintable as Character)!);
                }
            } else if (painted is Character character)
            {
                if (s is not null)
                {
                    s.AddResident(character);
                }
            } else
            {
                throw new Exception();
            }
            Paintings.Add(painted);
        }

        public abstract int PaintingLimit();
    }

    public class Portrait : Canvas
    {
        public override int PaintingLimit() { return 1; }
    }

    public class Small : Canvas
    {
        public override int PaintingLimit() { return 3; }
    }

    public class Large : Canvas
    {
        public override int PaintingLimit() { return 6; }
    }
}
