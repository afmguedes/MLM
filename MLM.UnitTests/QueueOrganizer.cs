using System;
using System.Collections.Generic;
using System.Linq;

namespace MLM.UnitTests
{
    public class QueueOrganizer
    {
        private Queue<Person> peopleQueue;

        public QueueOrganizer()
        {
            peopleQueue = new Queue<Person>();
        }

        public void AddPersonToTheQueue(Person newPerson)
        {
            peopleQueue.Enqueue(newPerson);
        }

        public MicroLearning WhoIsUpNext()
        {
            var nextPerson = peopleQueue.Dequeue();
            var nextDate = Helper.GetNextAvailableDate();

            return new MicroLearning(nextPerson, nextDate);
        }

        public void SkipMe()
        {
            var personSkipped = peopleQueue.Dequeue();

            peopleQueue.Enqueue(personSkipped);
        }

        public List<MicroLearning> LookAtFullQueue()
        {
            var currentDay = DateTime.Now;
            var fullQueue = new List<MicroLearning>();

            foreach (var person in peopleQueue)
            {
                var nextValidDay = Helper.GetNextAvailableDate(currentDay);
                fullQueue.Add(new MicroLearning(person, nextValidDay));
                currentDay = nextValidDay;
            }

            return fullQueue;
        }
    }
}