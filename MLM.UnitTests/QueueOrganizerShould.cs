using System.Linq;
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
            var nextDate = Helper.GetNextValidDate();
            var expectedMicroLearning = new MicroLearning(nextPerson, nextDate);
            var queueOrganizer = new QueueOrganizerBuilder().WithPerson(nextPerson).Build();

            var actual = queueOrganizer.WhoIsUpNext();

            actual.Should().BeEquivalentTo(expectedMicroLearning);
        }

        [Test]
        public void SkipPerson_WhenSkipMeIsCalled()
        {
            var person1 = new Person("Andre");
            var person2 = new Person("Amanda");
            var expectedDate = Helper.GetNextValidDate();
            var expectedMicroLearning = new MicroLearning(person2, expectedDate);
            var queueOrganizer = new QueueOrganizerBuilder().WithPerson(person1).WithPerson(person2).Build();

            queueOrganizer.SkipMe();

            var actual = queueOrganizer.WhoIsUpNext();
            actual.Should().BeEquivalentTo(expectedMicroLearning);
        }

        [Test]
        public void PutPersonSkippedAtTheBackOfTheQueue_WhenSkipMeIsCalled()
        {
            var person1 = new Person("Andre");
            var person2 = new Person("Amanda");
            var queueOrganizer = new QueueOrganizerBuilder().WithPerson(person1).WithPerson(person2).Build();

            queueOrganizer.SkipMe();

            var actual = queueOrganizer.LookAtFullQueue().Last().Name;
            actual.Should().Be(person1.Name);
        }

        [Test]
        public void PostponeToNextWorkingDay_WhenPostponeMeIsCalled()
        {
            var person1 = new Person("Andre");
            var queueOrganizer = new QueueOrganizerBuilder().WithPerson(person1).Build();
        }
    }
}