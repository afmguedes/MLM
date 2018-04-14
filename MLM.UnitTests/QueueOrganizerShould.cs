using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace MLM.UnitTests
{
    [TestFixture]
    public class QueueOrganizerShould
    {
        [Test]
        public void ReturnExpectedMicroLearning_WhenWhoIsUpNextIsCalled()
        {
            var nextPerson = new Person("Andre");
            var nextDate = new DateTime(2018, 4, 16);
            var expectedMicroLearning = new MicroLearning(nextPerson, nextDate);
            var queueOrganizer = new QueueOrganizer();
            queueOrganizer.AddPersonToTheQueue(nextPerson);

            var actual = queueOrganizer.WhoIsUpNext();

            actual.Should().BeEquivalentTo(expectedMicroLearning);
        }

        //[TestCase("André")]
        //[TestCase("Amanda")]
        //[TestCase("Arun")]
        //public void PersonIsAddedToTheQueue_WhenAddPersonToTheQueueIsCalled(string person)
        //{
        //    var queueOrganizer = new QueueOrganizer();

        //    queueOrganizer.AddPersonToTheQueue(person);

        //    queueOrganizer.WhoIsUpNext().Should().Be(person);
        //}

        //[TestCase("André", "2018-03-23")]
        //[TestCase("Amanda", "2018-03-26")]
        //[TestCase("Arun", "2018-03-28")]
        //public void ReturnNextMicroLearning_WhenWhatIsUpNextIsCalled(string nextPerson, DateTime nextDate)
        //{
        //    var nextMicroLearning = new MicroLearning(nextPerson, nextDate);
        //    var queueOrganizer = new QueueOrganizer(new List<MicroLearning> {nextMicroLearning});

        //    var actual = queueOrganizer.WhatIsUpNext();

        //    actual.Should().Be(nextMicroLearning);
        //}

        //[TestCase("André", "2018-03-23", "2018-03-26")]
        //[TestCase("Amanda", "2018-03-26", "2018-03-28")]
        //[TestCase("Arun", "2018-03-28", "2018-03-30")]
        //public void PushNextMicroLearningToNextValidSlot_WhenPushMeToNextSlotIsCalled(string nextPerson, DateTime nextDate,
        //    DateTime nextValidSlot)
        //{
        //    var nextMicroLearning = new MicroLearning(nextPerson, nextDate);
        //    var queueOrganizer = new QueueOrganizer(new List<MicroLearning> {nextMicroLearning});

        //    queueOrganizer.PushMeToNextSlot();

        //    queueOrganizer.WhatIsUpNext().Date.Should().Be(nextValidSlot);
        //}

        //[TestCaseSource(nameof(SequencesForPushMeToNextSlot))]
        //public void PushAllMicroLearningsBackOneSlot_WhenPushMeToNextSlotIsCalled(Queue<MicroLearning> actualSequence,
        //    Queue<MicroLearning> expectedSequence)
        //{
        //    var queueOrganizer = new QueueOrganizer(actualSequence);

        //    queueOrganizer.PushMeToNextSlot();

        //    queueOrganizer.Should().BeEquivalentTo(new QueueOrganizer(expectedSequence));
        //}

        //[TestCaseSource(nameof(SequencesForSkipMe))]
        //public void PushAllMicroLearningsForwardOneSLot_WhenSkipMeIsCalled(Queue<MicroLearning> actualSequence,
        //    Queue<MicroLearning> expectedSequence)
        //{
        //    var queueOrganizer = new QueueOrganizer(actualSequence);

        //    queueOrganizer.SkipMe();

        //    queueOrganizer.Should().BeEquivalentTo(new QueueOrganizer(expectedSequence));
        //}

        //private static IEnumerable SequencesForPushMeToNextSlot()
        //{
        //    var testcases = new List<TestCase>
        //                    {
        //                        new TestCase
        //                        {
        //                            ActualSequence =
        //                                new Queue<MicroLearning>(
        //                                    new[]
        //                                    {
        //                                        new MicroLearning(
        //                                            "André", new DateTime(2018, 4, 6)),
        //                                        new MicroLearning(
        //                                            "Amanda", new DateTime(2018, 4, 9))
        //                                    }),
        //                            ExpectedSequence =
        //                                new Queue<MicroLearning>(
        //                                    new[]
        //                                    {
        //                                        new MicroLearning(
        //                                            "André", new DateTime(2018, 4, 9)),
        //                                        new MicroLearning(
        //                                            "Amanda", new DateTime(2018, 4, 11))
        //                                    })
        //                        },
        //                        new TestCase
        //                        {
        //                            ActualSequence =
        //                                new Queue<MicroLearning>(
        //                                    new[]
        //                                    {
        //                                        new MicroLearning(
        //                                            "André", new DateTime(2018, 4, 6)),
        //                                        new MicroLearning(
        //                                            "Amanda", new DateTime(2018, 4, 9)),
        //                                        new MicroLearning(
        //                                            "Arun", new DateTime(2018, 4, 11))
        //                                    }),
        //                            ExpectedSequence =
        //                                new Queue<MicroLearning>(
        //                                    new[]
        //                                    {
        //                                        new MicroLearning(
        //                                            "André", new DateTime(2018, 4, 9)),
        //                                        new MicroLearning(
        //                                            "Amanda", new DateTime(2018, 4, 11)),
        //                                        new MicroLearning(
        //                                            "Arun", new DateTime(2018, 4, 13))
        //                                    })
        //                        },
        //                        new TestCase
        //                        {
        //                            ActualSequence =
        //                                new Queue<MicroLearning>(
        //                                    new[]
        //                                    {
        //                                        new MicroLearning(
        //                                            "André", new DateTime(2018, 4, 6)),
        //                                        new MicroLearning(
        //                                            "Amanda", new DateTime(2018, 4, 9)),
        //                                        new MicroLearning(
        //                                            "Arun", new DateTime(2018, 4, 11)),
        //                                        new MicroLearning(
        //                                            "Darren", new DateTime(2018, 4, 13))
        //                                    }),
        //                            ExpectedSequence =
        //                                new Queue<MicroLearning>(
        //                                    new[]
        //                                    {
        //                                        new MicroLearning(
        //                                            "André", new DateTime(2018, 4, 9)),
        //                                        new MicroLearning(
        //                                            "Amanda", new DateTime(2018, 4, 11)),
        //                                        new MicroLearning(
        //                                            "Arun", new DateTime(2018, 4, 13)),
        //                                        new MicroLearning(
        //                                            "Darren", new DateTime(2018, 4, 16))
        //                                    })
        //                        }
        //                    };

        //    foreach (var testcase in testcases)
        //    {
        //        yield return new TestCaseData(testcase.ActualSequence, testcase.ExpectedSequence);
        //    }
        //}

        private class TestCase
        {
            public Queue<MicroLearning> ActualSequence;
            public Queue<MicroLearning> ExpectedSequence;
        }
    }
}