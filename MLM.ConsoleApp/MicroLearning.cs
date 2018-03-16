using System;

namespace MLM.ConsoleApp
{
    public class MicroLearning
    {
        public string Name { get; private set; }
        public DateTime Date { get; set; }

        public MicroLearning(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }
    }
}