using System;
using System.Collections.Generic;

namespace MLM.UnitTests
{
    public class QueueOrganizer
    {
        public Queue<Person> PeopleQueue;
        
        public QueueOrganizer()
        {
            PeopleQueue = new Queue<Person>();
        }

        public void AddPersonToTheQueue(Person newPerson)
        {
            PeopleQueue.Enqueue(newPerson);
        }

        public MicroLearning WhoIsUpNext()
        {
            var nextPerson = PeopleQueue.Dequeue();

            return new MicroLearning(nextPerson, new DateTime(2018, 4, 16));
        }

        //public void AddPersonToTheQueue(string newPerson)
        //{
        //    var microLearning = new MicroLearning(newPerson, DateTime.Now);
        //    PeopleQueue.Enqueue(microLearning);
        //}

        //public MicroLearning WhatIsUpNext()
        //{
        //    return PeopleQueue.Dequeue();
        //}

        //public void PushMeToNextSlot()
        //{
        //    foreach (var microLearning in PeopleQueue)
        //    {
        //        microLearning.Date = GetNextValidSlotAfter(microLearning.Date);
        //    }
        //}

        //private DateTime GetNextValidSlotAfter(DateTime nextMicroLearningDate)
        //{
        //    var dayOftheWeek = validDays[nextMicroLearningDate.DayOfWeek];
        //    var daysToAdd = ((int)dayOftheWeek - (int)nextMicroLearningDate.DayOfWeek + 7) % 7;

        //    return nextMicroLearningDate.AddDays(daysToAdd);
        //}

        //private readonly Dictionary<DayOfWeek, DayOfWeek> validDays =
        //    new Dictionary<DayOfWeek, DayOfWeek>
        //    {
        //        {DayOfWeek.Monday, DayOfWeek.Wednesday},
        //        {DayOfWeek.Tuesday, DayOfWeek.Wednesday},
        //        {DayOfWeek.Wednesday, DayOfWeek.Friday},
        //        {DayOfWeek.Thursday, DayOfWeek.Friday},
        //        {DayOfWeek.Friday, DayOfWeek.Monday},
        //        {DayOfWeek.Saturday, DayOfWeek.Monday},
        //        {DayOfWeek.Sunday, DayOfWeek.Monday}
        //    };
        
    }
}