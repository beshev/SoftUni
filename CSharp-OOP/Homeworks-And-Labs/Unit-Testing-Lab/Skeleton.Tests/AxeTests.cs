using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    [TestCase(10, 10)]
    public void WeaponShouldLosesDurabilityAfterEachAttack(int attack, int durability)
    {
        // Arrange
        Dummy dummy = new Dummy(100, 100);
        Axe axe = new Axe(attack, durability);

        // Act
        int expectedValue = 9;

        axe.Attack(dummy);
        int actualValue = axe.DurabilityPoints;

        // Assert
        Assert.AreEqual(expectedValue, actualValue);
    }

    [Test]
    [TestCase(10, 0)]
    public void AttackingWithABrokenWeaponShouldThrowException(int attack, int durability)
    {
        // Arrange
        Dummy dummy = new Dummy(100, 100);
        Axe axe = new Axe(attack, durability);

        // Act - Assert
        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
    }
}