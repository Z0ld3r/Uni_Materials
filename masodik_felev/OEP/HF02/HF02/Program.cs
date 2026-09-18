using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace HF02
{
    internal class Program
    {
        public enum Content
        {
            EMPTY,
            WALL,
            TREASURE,
            GHOST
        }
        public record Position(int x, int y)
        {
            public bool Inside(int l, int n, int k, int m)
            {
                return (l <= x && x <= n && k <= y && y <= m);
            }
            public bool Direction()
            {
                return (Inside(-1, 1, -1, 1) && ((x == 0 || y != 0) || (x != 0 && y == 0)));
            }
            public static Position operator +(Position a, Position b)
            {
                return new Position(a.x + b.x, a.y + b.y);
            }
        }
        public class Labyrinth
        {
            private readonly int N;
            private readonly int M;
            private readonly Dictionary<Position, Content> map;

            public Labyrinth(int n, int m)
            {
                N = n;
                M = m;
                map = new Dictionary<Position, Content>();
                for (int i = 1; i <= N; i++)
                {
                    for (int j = 1; j <= M; j++)
                    {
                        map[new Position(i, j)] = Content.EMPTY;
                    }
                }
            }

            public void Place(Position pos, Content c)
            {
                if (!map.ContainsKey(pos))
                {
                    throw new Exception();
                }
                map[pos] = c;
            }

            public Content Spy(Position pos, Position dir)
            {
                if (!pos.Inside(1, N, 1, M) || !(pos + dir).Inside(1, N, 1, M) || !dir.Direction())
                {
                    throw new Exception();
                }
                return map[pos + dir];
            }

            public void Gather(Position pos)
            {
                if (!pos.Inside(1, N, 1, M))
                {
                    throw new Exception();
                }
                if (map[pos] != Content.TREASURE)
                {
                    throw new Exception();
                }
                map[pos] = Content.EMPTY;
            }
            static void Main(string[] args)
            {
                int n, m;
                string[] separatedLine = Console.ReadLine().Split();
                n = int.Parse(separatedLine[0]);
                m = int.Parse(separatedLine[1]);
                Labyrinth labyrinth = new Labyrinth(n, m);
                for (int i = 0; i < n; i++)
                {
                    separatedLine = Console.ReadLine().Split();
                    for (int j = 0; j < m; j++)
                    {
                        switch (separatedLine[j])
                        {
                            case "Üres":
                                labyrinth.Place(new Position(i + 1, j + 1), Content.EMPTY);
                                break;
                            case "Fal":
                                labyrinth.Place(new Position(i + 1, j + 1), Content.WALL);
                                break;
                            case "Kincs":
                                labyrinth.Place(new Position(i + 1, j + 1), Content.TREASURE);
                                break;
                            case "Szellem":
                                labyrinth.Place(new Position(i + 1, j + 1), Content.GHOST);
                                break;
                        }
                    }
                }

                try
                {
                    separatedLine = Console.ReadLine().Split();
                    labyrinth.Gather(new Position(int.Parse(separatedLine[0]), int.Parse(separatedLine[1])));
                    Console.WriteLine("Sikerült begyűjteni");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Nem sikerült a begyűjtés");
                }
                try
                {
                    separatedLine = Console.ReadLine().Split();
                    Position pos = new Position(int.Parse(separatedLine[0]), int.Parse(separatedLine[1]));
                    separatedLine = Console.ReadLine().Split();
                    Position dir = new Position(int.Parse(separatedLine[0]), int.Parse(separatedLine[1]));
                    Content result = labyrinth.Spy(pos, dir);
                    if (result == Content.TREASURE)
                        Console.WriteLine("Kincs");
                    else if (result == Content.WALL)
                        Console.WriteLine("Fal");
                    else if (result == Content.EMPTY)
                        Console.WriteLine("Üres");
                    else
                        Console.WriteLine("Szellem");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Nem sikerült megtekinteni a tartalmat");
                }
            }
        }
    }
}
