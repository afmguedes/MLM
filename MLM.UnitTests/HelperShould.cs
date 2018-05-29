using System;
using FluentAssertions;
using NUnit.Framework;

namespace MLM.UnitTests
{
    [TestFixture]
    public class HelperShould
    {
        private static TestData[] testDataForNextValidDate =
        {
            new TestData { CurrentDate = new DateTime(2018, 5, 14), ExpectedDate = new DateTime(2018, 5, 16)},
            new TestData { CurrentDate = new DateTime(2018, 5, 15), ExpectedDate = new DateTime(2018, 5, 16)},
            new TestData { CurrentDate = new DateTime(2018, 5, 16), ExpectedDate = new DateTime(2018, 5, 18)},
            new TestData { CurrentDate = new DateTime(2018, 5, 17), ExpectedDate = new DateTime(2018, 5, 18)},
            new TestData { CurrentDate = new DateTime(2018, 5, 18), ExpectedDate = new DateTime(2018, 5, 21)},
            new TestData { CurrentDate = new DateTime(2018, 5, 19), ExpectedDate = new DateTime(2018, 5, 21)},
            new TestData { CurrentDate = new DateTime(2018, 5, 20), ExpectedDate = new DateTime(2018, 5, 21)}
        };

        private static TestData[] testDataForNextWorkingDay =
        {
            new TestData { CurrentDate = new DateTime(2018, 5, 14), ExpectedDate = new DateTime(2018, 5, 15)},
            new TestData { CurrentDate = new DateTime(2018, 5, 15), ExpectedDate = new DateTime(2018, 5, 16)},
            new TestData { CurrentDate = new DateTime(2018, 5, 16), ExpectedDate = new DateTime(2018, 5, 17)},
            new TestData { CurrentDate = new DateTime(2018, 5, 17), ExpectedDate = new DateTime(2018, 5, 18)},
            new TestData { CurrentDate = new DateTime(2018, 5, 18), ExpectedDate = new DateTime(2018, 5, 21)},
            new TestData { CurrentDate = new DateTime(2018, 5, 19), ExpectedDate = new DateTime(2018, 5, 21)},
            new TestData { CurrentDate = new DateTime(2018, 5, 20), ExpectedDate = new DateTime(2018, 5, 21)}
        };

        [Test]
        public void ReturnNextValidDate_WhenGetNextValidDateIsCalled([ValueSource(nameof(testDataForNextValidDate))]
            TestData testData)
        {
            var actual = Helper.GetNextValidDate(testData.CurrentDate);

            actual.Should().Be(testData.ExpectedDate);
        }

        [Test]
        public void ReturnNextWorkingDay_WhenGetNextWorkingDayIsCalled([ValueSource(nameof(testDataForNextValidDate))]
            TestData testData)
        {
            var actual = Helper.GetNextWorkingDay(testData.CurrentDate);

            actual.Should().Be(testData.ExpectedDate);
        }

        public class TestData
        {
            public DateTime CurrentDate { get; set; }
            public DateTime ExpectedDate { get; set; }
        }
    }
}