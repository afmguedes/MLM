using System;
using System.Collections.Generic;

namespace MLM.ConsoleApp
{
    public class QueueManager
    {
        private Queue<MicroLearning> MLQueue;

        public QueueManager()
        {
            MLQueue = new Queue<MicroLearning>();
        }
        public QueueManager(IEnumerable<MicroLearning> microLearnings)
        {
            MLQueue = new Queue<MicroLearning>(microLearnings);
        }

        public void AddPersonToTheQueue(string newPerson)
        {
            var microLearning = new MicroLearning(newPerson, DateTime.Now);

            MLQueue.Enqueue(microLearning);
        }

        public string WhoIsUpNext()
        {
            var nextMicroLearning = MLQueue.Dequeue();
            return nextMicroLearning.Name;
        }

        public MicroLearning WhatIsNext()
        {
            return MLQueue.Dequeue();
        }

        //public void SkipMe()
        //{
        //    var nextSession = MLQueue.Dequeue();
        //    MLQueue.Enqueue(nextSession);
        //}

        //public void PushToNextSlot()
        //{
        //    var nextSessionDate = MLQueue.Peek().Date;

        //    var dayOftheWeek = GetNextValidSlot(nextSessionDate);

        //    var daysToAdd = ((int) dayOftheWeek - (int)nextSessionDate.DayOfWeek + 7) % 7;

        //    MLQueue.Peek().Date = nextSessionDate.AddDays(daysToAdd);
        //}

        public void PushMeToNextSlot()
        {
            var nextMicroLearningDate = MLQueue.Peek().Date;

            var dayOftheWeek = GetNextValidSlot(nextMicroLearningDate);

            var daysToAdd = ((int)dayOftheWeek - (int)nextMicroLearningDate.DayOfWeek + 7) % 7;

            MLQueue.Peek().Date = nextMicroLearningDate.AddDays(daysToAdd);
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