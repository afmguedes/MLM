using System.Collections.Generic;

namespace MLM.UnitTests
{
    public class QueueOrganizerBuilder
    {
        private readonly Queue<Person> peopleQueue = new Queue<Person>();

        public QueueOrganizerBuilder WithPerson(Person person)
        {
            peopleQueue.Enqueue(person);
            return this;
        }

        internal QueueOrganizer Build()
        {
            return new QueueOrganizer(peopleQueue);
        }
    }
}