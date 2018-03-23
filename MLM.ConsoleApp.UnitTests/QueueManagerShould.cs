using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace MLM.ConsoleApp.UnitTests
{
    [TestFixture]
    public class QueueManagerShould
    {
        [TestCase("André")]
        [TestCase("Amanda")]
        [TestCase("Arun")]
        public void ReturnNextPerson_WhenWhoIsUpNextIsCalled(string nextPerson)
        {
            var queueManager = new QueueManager();
            queueManager.AddPersonToTheBoard(nextPerson);

            var actual = queueManager.WhoIsUpNext();

            actual.Should().Be(nextPerson);
        }

        [TestCase("André", "2018-03-19")]
        [TestCase("Amanda", "2018-03-21")]
        [TestCase("Arun", "2018-03-23")]
        public void ReturnNextSession_WhenWhatIsNextIsCalled(string nextPerson, DateTime nextDate)
        {
            var nextSession = new MicroLearning(nextPerson, nextDate);
            var queueManager = new QueueManager();
            queueManager.AddSession(nextSession);

            var actual = queueManager.WhatIsNext();

            actual.Should().Be(nextSession);
        }

        [TestCaseSource(nameof(NextAndFollowingSessions))]
        public void ReturnFollowingSession_WhenSkipMeIsCalled(MicroLearning nextSession, MicroLearning followingSession)
        {
            var queueManager = new QueueManager();
            queueManager.AddSession(nextSession);
            queueManager.AddSession(followingSession);

            queueManager.SkipMe();

            queueManager.WhatIsNext().Should().Be(followingSession);
        }

        private static IEnumerable NextAndFollowingSessions()
        {
            var testcases = new List<Tuple<MicroLearning, MicroLearning>>
            {
                new Tuple<MicroLearning, MicroLearning>(new MicroLearning("André", new DateTime(2018, 3, 19)),
                    new MicroLearning("Amanda", new DateTime(2018, 3, 21))),
                new Tuple<MicroLearning, MicroLearning>(new MicroLearning("Arun", new DateTime(2018, 3, 23)),
                    new MicroLearning("Darren", new DateTime(2018, 3, 26)))
            };

            foreach (var testcase in testcases) yield return new TestCaseData(testcase.Item1, testcase.Item2);
        }

        [TestCase("André", "2018-03-19", "2018-03-21")]
        [TestCase("Amanda", "2018-03-20", "2018-03-21")]
        [TestCase("Arun", "2018-03-21", "2018-03-23")]
        [TestCase("Darren", "2018-03-22", "2018-03-23")]
        [TestCase("David", "2018-03-23", "2018-03-26")]
        public void PostponeToMondayWednesdayOrFriday_WhenPushToNextSlotIsCalled(string nextPerson, DateTime nextDate,
            DateTime postponedDate)
        {
            var nextSession = new MicroLearning(nextPerson, nextDate);
            var queueManager = new QueueManager();
            queueManager.AddSession(nextSession);

            queueManager.PushToNextSlot();

            queueManager.WhatIsNext().Date.Should().Be(postponedDate);
        }
    }
}