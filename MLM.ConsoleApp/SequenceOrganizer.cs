using System;
using System.Collections.Generic;

namespace MLM.ConsoleApp
{
    public class SequenceOrganizer
    {
        private readonly Queue<MicroLearning> microLearningSequence;

        private readonly Dictionary<DayOfWeek, DayOfWeek> validDays =
            new Dictionary<DayOfWeek, DayOfWeek>
            {
                {DayOfWeek.Monday, DayOfWeek.Wednesday},
                {DayOfWeek.Tuesday, DayOfWeek.Wednesday},
                {DayOfWeek.Wednesday, DayOfWeek.Friday},
                {DayOfWeek.Thursday, DayOfWeek.Friday},
                {DayOfWeek.Friday, DayOfWeek.Monday},
                {DayOfWeek.Saturday, DayOfWeek.Monday},
                {DayOfWeek.Sunday, DayOfWeek.Monday}
            };

        public SequenceOrganizer()
        {
            microLearningSequence = new Queue<MicroLearning>();
        }

        public SequenceOrganizer(IEnumerable<MicroLearning> microLearnings)
        {
            microLearningSequence = new Queue<MicroLearning>(microLearnings);
        }

        public void AddPersonToTheQueue(string newPerson)
        {
            var microLearning = new MicroLearning(newPerson, DateTime.Now);

            microLearningSequence.Enqueue(microLearning);
        }

        public string WhoIsUpNext()
        {
            var nextMicroLearning = microLearningSequence.Dequeue();
            return nextMicroLearning.Name;
        }

        public MicroLearning WhatIsUpNext()
        {
            return microLearningSequence.Dequeue();
        }

        public void PushMeToNextSlot()
        {
            var nextMicroLearning = microLearningSequence.Peek();

            nextMicroLearning.Date = GetNextValidSlotAfter(nextMicroLearning.Date);
        }

        private DateTime GetNextValidSlotAfter(DateTime nextMicroLearningDate)
        {
            var dayOftheWeek = validDays[nextMicroLearningDate.DayOfWeek];
            var daysToAdd = ((int)dayOftheWeek - (int)nextMicroLearningDate.DayOfWeek + 7) % 7;

            return nextMicroLearningDate.AddDays(daysToAdd);
        }
    }
}