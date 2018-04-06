using System;
using System.Collections.Generic;

namespace MLM.ConsoleApp
{
    public class SequenceOrganizer
    {
        private Queue<MicroLearning> MicroLearningSequence;

        public SequenceOrganizer()
        {
            MicroLearningSequence = new Queue<MicroLearning>();
        }
        public SequenceOrganizer(IEnumerable<MicroLearning> microLearnings)
        {
            MicroLearningSequence = new Queue<MicroLearning>(microLearnings);
        }

        public void AddPersonToTheQueue(string newPerson)
        {
            var microLearning = new MicroLearning(newPerson, DateTime.Now);

            MicroLearningSequence.Enqueue(microLearning);
        }

        public string WhoIsUpNext()
        {
            var nextMicroLearning = MicroLearningSequence.Dequeue();
            return nextMicroLearning.Name;
        }

        public MicroLearning WhatIsNext()
        {
            return MicroLearningSequence.Dequeue();
        }

        //public void SkipMe()
        //{
        //    var nextSession = MicroLearningSequence.Dequeue();
        //    MicroLearningSequence.Enqueue(nextSession);
        //}

        //public void PushToNextSlot()
        //{
        //    var nextSessionDate = MicroLearningSequence.Peek().Date;

        //    var dayOftheWeek = GetNextValidSlot(nextSessionDate);

        //    var daysToAdd = ((int) dayOftheWeek - (int)nextSessionDate.DayOfWeek + 7) % 7;

        //    MicroLearningSequence.Peek().Date = nextSessionDate.AddDays(daysToAdd);
        //}

        public void PushMeToNextSlot()
        {
            var nextMicroLearningDate = MicroLearningSequence.Peek().Date;
            var dayOftheWeek = GetNextValidSlot(nextMicroLearningDate);
            var daysToAdd = ((int)dayOftheWeek - (int)nextMicroLearningDate.DayOfWeek + 7) % 7;

            MicroLearningSequence.Peek().Date = nextMicroLearningDate.AddDays(daysToAdd);
        }

        private static DayOfWeek GetNextValidSlot(DateTime nextSessionDate)
        {
            switch (nextSessionDate.DayOfWeek)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                    return DayOfWeek.Wednesday;
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                    return DayOfWeek.Friday;
                default:
                    return DayOfWeek.Monday;
            }
        }
    }
}