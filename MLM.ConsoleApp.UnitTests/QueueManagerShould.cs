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
            var microLearning = new MicroLearning(nextPerson, new DateTime(2018, 3, 23));
            var sequenceOrganizer = new SequenceOrganizer(new List<MicroLearning>() { microLearning });

            var actual = sequenceOrganizer.WhoIsUpNext();

            actual.Should().Be(nextPerson);
        }

        [TestCase("André")]
        [TestCase("Amanda")]
        [TestCase("Arun")]
        public void PersonIsAddedToTheQueue_WhenAddPersonToTheQueueIsCalled(string person)
        {
            var sequenceOrganizer = new SequenceOrganizer();

            sequenceOrganizer.AddPersonToTheQueue(person);

            sequenceOrganizer.WhoIsUpNext().Should().Be(person);
        }

        [TestCase("André", "2018-03-23")]
        [TestCase("Amanda", "2018-03-26")]
        [TestCase("Arun", "2018-03-28")]
        public void ReturnNextMicroLearning_WhenWhatIsNextIsCalled(string nextPerson, DateTime nextDate)
        {
            var nextMicroLearning = new MicroLearning(nextPerson, nextDate);
            var sequenceOrganizer = new SequenceOrganizer(new List<MicroLearning>() { nextMicroLearning });

            var actual = sequenceOrganizer.WhatIsNext();

            actual.Should().Be(nextMicroLearning);
        }

        [TestCase("André", "2018-03-23", "2018-03-26")]
        [TestCase("Amanda", "2018-03-26", "2018-03-28")]
        [TestCase("Arun", "2018-03-28", "2018-03-30")]
        public void PushMicroLearningToNextValidSlot_WhenPushMeToNextSlotIsCalled(string nextPerson, DateTime nextDate, DateTime nextValidSlot)
        {
            var nextMicroLearning = new MicroLearning(nextPerson, nextDate);
            var sequenceOrganizer = new SequenceOrganizer(new List<MicroLearning>() { nextMicroLearning });

            sequenceOrganizer.PushMeToNextSlot();

            sequenceOrganizer.WhatIsNext().Date.Should().Be(nextValidSlot);
        }

        //[Test]
        //public void PutPersonAtTheBackOfTheQueue_WhenImDoneIsCalled()
        //{
        //    var sequenceOrganizer = new SequenceOrganizer();

        //}

        //[TestCaseSource(nameof(NextAndFollowingSessions))]
        //public void ReturnFollowingSession_WhenSkipMeIsCalled(MicroLearning nextSession, MicroLearning followingSession)
        //{
        //    var sequenceOrganizer = new SequenceOrganizer();
        //    sequenceOrganizer.AddSession(nextSession);
        //    sequenceOrganizer.AddSession(followingSession);

        //    sequenceOrganizer.SkipMe();

        //    sequenceOrganizer.WhatIsNext().Should().Be(followingSession);
        //}

        //private static IEnumerable NextAndFollowingSessions()
        //{
        //    var testcases = new List<Tuple<MicroLearning, MicroLearning>>
        //    {
        //        new Tuple<MicroLearning, MicroLearning>(new MicroLearning("André", new DateTime(2018, 3, 19)),
        //            new MicroLearning("Amanda", new DateTime(2018, 3, 21))),
        //        new Tuple<MicroLearning, MicroLearning>(new MicroLearning("Arun", new DateTime(2018, 3, 23)),
        //            new MicroLearning("Darren", new DateTime(2018, 3, 26)))
        //    };

        //    foreach (var testcase in testcases) yield return new TestCaseData(testcase.Item1, testcase.Item2);
        //}

        //[TestCase("André", "2018-03-19", "2018-03-21")]
        //[TestCase("Amanda", "2018-03-20", "2018-03-21")]
        //[TestCase("Arun", "2018-03-21", "2018-03-23")]
        //[TestCase("Darren", "2018-03-22", "2018-03-23")]
        //[TestCase("David", "2018-03-23", "2018-03-26")]
        //public void PostponeToMondayWednesdayOrFriday_WhenPushToNextSlotIsCalled(string nextPerson, DateTime nextDate,
        //    DateTime postponedDate)
        //{
        //    var nextSession = new MicroLearning(nextPerson, nextDate);
        //    var sequenceOrganizer = new SequenceOrganizer();
        //    sequenceOrganizer.AddSession(nextSession);

        //    sequenceOrganizer.PushToNextSlot();

        //    sequenceOrganizer.WhatIsNext().Date.Should().Be(postponedDate);
        //}
    }
}