namespace Painters5
{
    public abstract class Person
    {
        public readonly string Name;
        public int Age { get; protected set; }
        protected List<Relation> relations;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            relations = new List<Relation>();
        }

        public abstract void TimePassed(int hour);

        public int Reputation()
        {
            return relations.Sum(r => (int)r.Status);
        }

        public bool IsLikedPerson()
        {
            int reputation = Reputation();
            return reputation / relations.Count >= (int)RelationStatus.Like;
        }

        public void SetRelation(Person p, RelationStatus s)
        {
            Relation? r = relations.FirstOrDefault(r => r.Person == p);
            if (r is not null)
            {
                r.Status = s;
            }
            else
            {
                r = new Relation(p, s);
                relations.Add(r);
            }
        }
    }
}
