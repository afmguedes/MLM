using System;
using System.Collections.Generic;

namespace MLM.UnitTests
{
    public class QueueOrganizer
    {
        private readonly Queue<Person> peopleQueue;

        public QueueOrganizer(Queue<Person> queue)
        {
            peopleQueue = queue;
        }

        public MicroLearning WhoIsUpNext()
        {
            var nextPerson = peopleQueue.Dequeue();
            var nextDate = Helper.GetNextValidDate();

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
                var nextValidDay = Helper.GetNextValidDate(currentDay);
                fullQueue.Add(new MicroLearning(person, nextValidDay));
                currentDay = nextValidDay;
            }

            return fullQueue;
        }
    }
}