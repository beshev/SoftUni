using NUnit.Framework;

namespace Tests
{
    using System;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        // Test Arena Count
        [Test]
        public void ArenaCountShouldWorkCorrectly()
        {
            // Arrange
            Warrior warrior = new Warrior("Gosho", 20, 100);

            // Act
            int expextedResult = 1;
            this.arena.Enroll(warrior);

            // Assert
            Assert.AreEqual(expextedResult, this.arena.Count);
        }

        // Test Arena Constructor
        [Test]
        public void ArenaConstructorShouldWorkCorrectly()
        {
            Assert.IsNotNull(this.arena);
        }

        // Test Arena Enroll Method
        [Test]
        public void AlreadyEnrolledWarriorsShouldNotBeAbleToEnrollAgain()
        {
            // Arrange
            Warrior warrior = new Warrior("Gosho", 50, 100);

            // Act
            this.arena.Enroll(warrior);

            // Assert
            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(warrior));
        }

        [Test]
        public void ArenaEnrollShouldWorkCorrectly()
        {
            // Arrange
            Warrior warrior = new Warrior("Gosho", 20, 100);

            // Act
            this.arena.Enroll(warrior);

            // Assert
            Assert.That(this.arena.Warriors, Has.Member(warrior));
        }

        // Test Arena Fight Method
        [Test]
        public void ArenaFightMethodShouldThrowExceptionIfWarriorsAreNotFound()
        {
            // Assert
            Warrior attacker = new Warrior("Gosho", 20, 100);
            Warrior defender = new Warrior("Pesho", 30, 100);

            // Act
            this.arena.Enroll(attacker);
            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            this.arena.Fight(attacker.Name, defender.Name));
        }

        [Test]
        public void ArenaFightShouldWorkCorrectly()
        {
            // Arrange
            Warrior attacker = new Warrior("Gosho", 20, 100);
            Warrior defender = new Warrior("Pesho", 30, 100);

            // Act
            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            this.arena.Fight(attacker.Name, defender.Name);

            int expecdetAttackerHp = 70;
            int expecdetDefenderHp = 80;

            // Assert
            Assert.AreEqual(expecdetAttackerHp, attacker.HP);
            Assert.AreEqual(expecdetDefenderHp, defender.HP);
        }
    }
}
