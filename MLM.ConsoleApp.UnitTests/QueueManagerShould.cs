using System;
using FluentAssertions;
using NUnit.Framework;

namespace MLM.ConsoleApp.UnitTests
{
    [TestFixture]
    public class QueueManagerShould
    {
        [TestCase("Andre")]
        [TestCase("Amanda")]
        [TestCase("Arun")]
        public void ReturnNextPerson_WhenWhoIsNextIsCalled(string nextPerson)
        {
            var queueManager = new QueueManager();
            queueManager.AddPersonToTheBoard(nextPerson);

            var actual = queueManager.WhoIsNext();

            actual.Should().Be(nextPerson);
        }

        [TestCase("Andre", "2018-03-19")]
        [TestCase("Amanda", "2018-03-21")]
        [TestCase("Arun", "2018-03-23")]
        public void ReturnNextSession_WhenWhatIsNextIsCalled(string nextPerson, DateTime nextDate)
        {
            var nextSession = new MicroLearning(nextPerson, nextDate);
            var queueManager = new QueueManager();
            queueManager.AddSession(nextSession);

            var actual = queueManager.WhatIsnext();

            actual.Should().Be(nextSession);
        }

        [Test]
        public void ReturnFollowingSession_WhenSkipMeIsCalled()
        {
            var nextSession = new MicroLearning("Andre", new DateTime(2018, 3, 19));
            var followingSession = new MicroLearning("Amanda", new DateTime(2018, 3, 21));
            var queueManager = new QueueManager();
            queueManager.AddSession(nextSession);
            queueManager.AddSession(followingSession);

            queueManager.SkipMe();

            queueManager.WhatIsnext().Should().Be(followingSession);
        }

        [TestCase("Andre", "2018-03-19", "2018-03-21")]
        [TestCase("Amanda", "2018-03-20", "2018-03-21")]
        [TestCase("Arun", "2018-03-21", "2018-03-23")]
        [TestCase("Darren", "2018-03-22", "2018-03-23")]
        [TestCase("David", "2018-03-23", "2018-03-26")]
        public void PostponeToMondayWednesdayOrFriday_WhenPushToNextSlotIsCalled(string nextPerson, DateTime nextDate, DateTime postponedDate)
        {
            var nextSession = new MicroLearning(nextPerson, nextDate);
            var queueManager = new QueueManager();
            queueManager.AddSession(nextSession);

            queueManager.PushToNextSlot();

            queueManager.WhatIsnext().Date.Should().Be(postponedDate);
        }
    }
}
