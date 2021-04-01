using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    [TestCase(100, 100, 10)]
    public void DummyShouldLosesHealthIfAttacked(int health, int experience, int attackPoint)
    {
        // Arrange
        Dummy dummy = new Dummy(health, experience);

        // Act
        int expectedHealth = dummy.Health - attackPoint;

        dummy.TakeAttack(attackPoint);
        int actualHealth = dummy.Health;

        // Assert
        Assert.AreEqual(expectedHealth, actualHealth);
    }

    [Test]
    [TestCase(0, 100)]
    public void DeadDummyShouldThrowsExceptionIfAttacked(int health, int experience)
    {
        // Arrange
        Dummy dummy = new Dummy(health, experience);

        // Act - Assert
        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(10));
    }

    [Test]
    [TestCase(0, 100)]
    public void DeadDummyShouldCanGiveXP(int health, int experience)
    {
        // Arrange
        Dummy dummy = new Dummy(health, experience);

        // Act 
        int expectedValue = experience;
        int actualValue = dummy.GiveExperience();

        // Assert
        Assert.AreEqual(expectedValue, actualValue);
    }

    [Test]
    [TestCase(100, 100)]
    public void AliveDummyCantGiveXP(int health, int experience)
    {
        // Arrange
        Dummy dummy = new Dummy(health, experience);

        // Act - Assert
        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
    }
}
