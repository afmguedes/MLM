using System;
using System.Collections.Generic;

namespace MLM.ConsoleApp
{
    public class QueueManager
    {
        private Queue<MicroLearning> Board;

        public QueueManager()
        {
            Board = new Queue<MicroLearning>();
        }

        public void AddPersonToTheBoard(string newPerson)
        {
            var microLearning = new MicroLearning(newPerson, DateTime.Now);

            Board.Enqueue(microLearning);
        }

        public void AddSession(MicroLearning nextSession)
        {
            Board.Enqueue(nextSession);
        }

        public string WhoIsNext()
        {
            var nextMicroLearning = Board.Dequeue();
            return nextMicroLearning.Name;
        }

        public MicroLearning WhatIsNext()
        {
            return Board.Dequeue();
        }

        public void SkipMe()
        {
            var nextSession = Board.Dequeue();
            Board.Enqueue(nextSession);
        }

        public void PushToNextSlot()
        {
            var nextSessionDate = Board.Peek().Date;

            var dayOftheWeek = GetNextValidDayOftheWeek(nextSessionDate);

            var daysToAdd = ((int) dayOftheWeek - (int)nextSessionDate.DayOfWeek + 7) % 7;

            Board.Peek().Date = nextSessionDate.AddDays(daysToAdd);
        }

        private DayOfWeek GetNextValidDayOftheWeek(DateTime nextSessionDate)
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