using FakeAxeAndDummy.Model.Contracts;
using Moq;
using NUnit.Framework;

namespace FakeAxeAndDummy.Test
{
    [TestFixture]
    public class HeroTest
    {
        [Test]
        public void GivenHeroWhenConstructorInitializeThenCreateNewHero()
        {
            IWeapon axe = new Axe(10, 10);
            Hero hero = new Hero("Gogo",axe);

            Assert.AreEqual("Gogo", hero.Name);
            Assert.AreEqual(0, hero.Experience);
            Assert.AreEqual(axe, hero.Weapon);
        }

        [Test]
        public void GivenHeroWhenAttckThenGainsExperience()
        {
            // Arrange
            Mock<IWeapon> weaponMock = new Mock<IWeapon>();
            Mock<ITarget> targetMock = new Mock<ITarget>();
            Hero hero = new Hero("Gogo",weaponMock.Object);

            // Act
            targetMock.Setup(t => t.GiveExperience()).Returns(20);
            targetMock.Setup(t => t.IsDead()).Returns(true);
            hero.Attack(targetMock.Object);
            int expectedExp = 20;
            int actualExp = hero.Experience;

            // Assert
            Assert.AreEqual(expectedExp, actualExp);
            

        }
    }
}
