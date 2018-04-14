using System;

namespace MLM.UnitTests
{
    public class MicroLearning
    {
        public string Name { get; }
        public DateTime Date { get; set; }
        
        public MicroLearning(Person person, DateTime date)
        {
            Name = person.Name;
            Date = date;
        }
    }
}