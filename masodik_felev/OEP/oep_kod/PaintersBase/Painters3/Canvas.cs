namespace Painters3
{
    public abstract class Canvas
    {
        public string Title { get; private set; }

        public List<Character> Paintings { get; private set; }

        public Canvas()
        {
            Title = string.Empty;
            Paintings = new List<Character>();
        }

        public void SetTitle(string t)
        {
            if (Title != string.Empty)
            {
                throw new Exception();
            }
            Title = t;
        }

        public void Paint(Character c)
        {
            if (Paintings.Contains(c))
            {
                throw new Exception();
            }
            Paintings.Add(c);
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
