using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        RaceEntry _raceEntry;
        UnitDriver _pesho;
        UnitCar _bmw;

        [SetUp]
        public void Setup()
        {
            _raceEntry = new RaceEntry();
            _bmw = new UnitCar("BMW", 250, 2000);
            _pesho = new UnitDriver("Pesho", _bmw);
        }

        [Test]
        public void RaceAddThrowExpNull()
        {
            Assert.Throws<InvalidOperationException>(() => _raceEntry.AddDriver(null));
        }

        [Test]
        public void RaceAddThrowExpExist()
        {
            _raceEntry.AddDriver(_pesho);

            Assert.Throws<InvalidOperationException>(() => _raceEntry.AddDriver(_pesho));
        }

        [Test]
        public void RaceAddWork()
        {
            string expectedResult = "Driver Pesho added in race.";

            Assert.AreEqual(expectedResult, _raceEntry.AddDriver(_pesho));
            Assert.AreEqual(1, _raceEntry.Counter);
        }

        [Test]
        public void RaceCalcExpCount()
        {
            _raceEntry.AddDriver(_pesho);

            Assert.Throws<InvalidOperationException>(() => _raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void RaceCalcWork()
        {
            _raceEntry.AddDriver(_pesho);
            UnitDriver unitDriver1 = new UnitDriver("Gosho", _bmw);
            UnitDriver unitDriver2 = new UnitDriver("Tosho", _bmw);

            _raceEntry.AddDriver(unitDriver1);
            _raceEntry.AddDriver(unitDriver2);

            Assert.AreEqual(250, _raceEntry.CalculateAverageHorsePower());
        }
    }
}