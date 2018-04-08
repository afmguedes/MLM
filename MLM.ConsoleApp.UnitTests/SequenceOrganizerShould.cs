using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace MLM.ConsoleApp.UnitTests
{
    [TestFixture]
    public class SequenceOrganizerShould
    {
        [TestCase("André")]
        [TestCase("Amanda")]
        [TestCase("Arun")]
        public void ReturnNextPerson_WhenWhoIsUpNextIsCalled(string nextPerson)
        {
            var microLearning = new MicroLearning(nextPerson, new DateTime(2018, 3, 23));
            var sequenceOrganizer = new SequenceOrganizer(new List<MicroLearning> {microLearning});

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
        public void ReturnNextMicroLearning_WhenWhatIsUpNextIsCalled(string nextPerson, DateTime nextDate)
        {
            var nextMicroLearning = new MicroLearning(nextPerson, nextDate);
            var sequenceOrganizer = new SequenceOrganizer(new List<MicroLearning> {nextMicroLearning});

            var actual = sequenceOrganizer.WhatIsUpNext();

            actual.Should().Be(nextMicroLearning);
        }

        [TestCase("André", "2018-03-23", "2018-03-26")]
        [TestCase("Amanda", "2018-03-26", "2018-03-28")]
        [TestCase("Arun", "2018-03-28", "2018-03-30")]
        public void PushNextMicroLearningToNextValidSlot_WhenPushMeToNextSlotIsCalled(string nextPerson, DateTime nextDate,
            DateTime nextValidSlot)
        {
            var nextMicroLearning = new MicroLearning(nextPerson, nextDate);
            var sequenceOrganizer = new SequenceOrganizer(new List<MicroLearning> {nextMicroLearning});

            sequenceOrganizer.PushMeToNextSlot();

            sequenceOrganizer.WhatIsUpNext().Date.Should().Be(nextValidSlot);
        }

        [TestCaseSource(nameof(SequenceBeforePush))]
        public void PushAllMicroLearningsBackOneSlot_WhenPushMeToNextSlotIsCalled(Queue<MicroLearning> actualSequence,
            Queue<MicroLearning> expectedSequence)
        {
            var sequenceOrganizer = new SequenceOrganizer(actualSequence);

            sequenceOrganizer.PushMeToNextSlot();

            sequenceOrganizer.Should().BeEquivalentTo(new SequenceOrganizer(expectedSequence));
        }

        private static IEnumerable SequenceBeforePush()
        {
            var testcases = new List<TestCase>
                            {
                                new TestCase
                                {
                                    ActualSequence =
                                        new Queue<MicroLearning>(
                                            new[]
                                            {
                                                new MicroLearning(
                                                    "André", new DateTime(2018, 4, 6)),
                                                new MicroLearning(
                                                    "Amanda", new DateTime(2018, 4, 9))
                                            }),
                                    ExpectedSequence =
                                        new Queue<MicroLearning>(
                                            new[]
                                            {
                                                new MicroLearning(
                                                    "André", new DateTime(2018, 4, 9)),
                                                new MicroLearning(
                                                    "Amanda", new DateTime(2018, 4, 11))
                                            })
                                },
                                new TestCase
                                {
                                    ActualSequence =
                                        new Queue<MicroLearning>(
                                            new[]
                                            {
                                                new MicroLearning(
                                                    "André", new DateTime(2018, 4, 6)),
                                                new MicroLearning(
                                                    "Amanda", new DateTime(2018, 4, 9)),
                                                new MicroLearning(
                                                    "Arun", new DateTime(2018, 4, 11))
                                            }),
                                    ExpectedSequence =
                                        new Queue<MicroLearning>(
                                            new[]
                                            {
                                                new MicroLearning(
                                                    "André", new DateTime(2018, 4, 9)),
                                                new MicroLearning(
                                                    "Amanda", new DateTime(2018, 4, 11)),
                                                new MicroLearning(
                                                    "Arun", new DateTime(2018, 4, 13))
                                            })
                                },
                                new TestCase
                                {
                                    ActualSequence =
                                        new Queue<MicroLearning>(
                                            new[]
                                            {
                                                new MicroLearning(
                                                    "André", new DateTime(2018, 4, 6)),
                                                new MicroLearning(
                                                    "Amanda", new DateTime(2018, 4, 9)),
                                                new MicroLearning(
                                                    "Arun", new DateTime(2018, 4, 11)),
                                                new MicroLearning(
                                                    "Darren", new DateTime(2018, 4, 13))
                                            }),
                                    ExpectedSequence =
                                        new Queue<MicroLearning>(
                                            new[]
                                            {
                                                new MicroLearning(
                                                    "André", new DateTime(2018, 4, 9)),
                                                new MicroLearning(
                                                    "Amanda", new DateTime(2018, 4, 11)),
                                                new MicroLearning(
                                                    "Arun", new DateTime(2018, 4, 13)),
                                                new MicroLearning(
                                                    "Darren", new DateTime(2018, 4, 16))
                                            })
                                }
                            };

            foreach (var testcase in testcases)
            {
                yield return new TestCaseData(testcase.ActualSequence, testcase.ExpectedSequence);
            }
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

        //    sequenceOrganizer.WhatIsUpNext().Should().Be(followingSession);
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

        //    sequenceOrganizer.WhatIsUpNext().Date.Should().Be(postponedDate);
        //}

        private class TestCase
        {
            public Queue<MicroLearning> ActualSequence;
            public Queue<MicroLearning> ExpectedSequence;
        }
    }
}