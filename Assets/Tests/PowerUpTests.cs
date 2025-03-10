//Cristina Luongo
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class PowerUpTests
{
    private Rigidbody2D mockProjectile;

    [SetUp]
    public void SetUp()
    {
        mockProjectile = Substitute.For<Rigidbody2D>();
    }

    [Test]
    public void HeavyState_ApplyEffect_IncreasesMassAndForce()
    {
        // Arrange
        var heavyState = new HeavyState();
        mockProjectile.velocity = new Vector2(5, 0);

        // Act
        heavyState.ApplyEffect(mockProjectile);

        // Assert
        mockProjectile.Received().mass = 4f;
        mockProjectile.Received().AddForce(Arg.Any<Vector2>(), ForceMode2D.Impulse);
    }

    [Test]
    public void NormalState_ApplyEffect_NormalMassAndVelocity()
    {
        // Arrange
        var normalState = new NormalState();
        mockProjectile.mass = 4f;
        mockProjectile.velocity = new Vector2(10, 0);

        // Act
        normalState.ApplyEffect(mockProjectile);

        // Assert
        mockProjectile.Received().mass = 1f;
        Assert.AreEqual(new Vector2(10, 0), mockProjectile.velocity); 
    }

    [Test]
    public void PowerUpManager_StoresAndGetsPowerUp()
    {
        // Arrange
        var powerUpManager = new GameObject().AddComponent<PowerUpManager>();
        var powerUp = new HeavyState();

        // Act
        powerUpManager.StorePowerUp(powerUp, null);

        // Assert
        Assert.AreEqual(powerUp, powerUpManager.GetStoredPowerUp());
    }

    [Test]
    public void PowerUpManager_UsesAndRemovesPowerUp()
    {
        // Arrange
        var powerUpManager = new GameObject().AddComponent<PowerUpManager>();
        var powerUp = new HeavyState();
        bool called = false;
        
        powerUpManager.OnPowerUpUsed += delegate {called = true;};

        powerUpManager.StorePowerUp(powerUp, null);

        // Act
        powerUpManager.UsePowerUp();

        // Assert
        Assert.IsTrue(called);
        Assert.IsNull(powerUpManager.GetStoredPowerUp());
    }

    [Test]
    public void Projectile_SetState_AppliesState()
    {
        // Arrange
        var projectileObject = new GameObject();
        var projectile = projectileObject.AddComponent<Projectile>();
        projectileObject.AddComponent<Rigidbody2D>();
        var heavyState = new HeavyState();

        // Act
        projectile.SetState(heavyState);

        // Assert
        Assert.AreEqual(4f, mockProjectile.mass);
    }
}
