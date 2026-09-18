namespace Painters3
{
    public class Relation
    {
        public RelationStatus Status;
        public readonly Person Person;

        public Relation(Person person, RelationStatus relationStatus)
        {
            Person = person;
            Status = relationStatus;
        }
    }
}
