//Cristina Luongo
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;


[TestFixture]
public class PowerUpTests
{
   [Test]
   public void HeavyState_ApplyEffect_IncreasesMassAndForce()
   {
       // Arrange
       var heavyState = new HeavyState();
       var rigidbody = new GameObject().AddComponent<Rigidbody2D>();
       rigidbody.mass = 1f;
       rigidbody.velocity = new Vector2(5, 0);

       // Act
       heavyState.ApplyEffect(rigidbody);


       // Assert
       Assert.AreEqual(4f, rigidbody.mass);
       Assert.AreNotEqual(new Vector2(5, 0), rigidbody.velocity);
   }

   [Test]
    public void FastState_ApplyEffect_IncreasesSpeed()
    {
        // Arrange
        var fastState = new FastState();
        var rigidbody = new GameObject().AddComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(2, 0);
    
        // Act
        fastState.ApplyEffect(rigidbody);

        // Assert
        Assert.Greater(rigidbody.velocity.magnitude, 2.0f);
    }


   [Test]
   public void NormalState_ApplyEffect_NormalMassAndVelocity()
   {
       // Arrange
       var normalState = new NormalState();
       var rigidbody = new GameObject().AddComponent<Rigidbody2D>();
       rigidbody.mass = 4f;
       rigidbody.velocity = new Vector2(10, 0);


       // Act
       normalState.ApplyEffect(rigidbody);


       // Assert
       Assert.AreEqual(1f, rigidbody.mass);
       Assert.AreEqual(new Vector2(10, 0), rigidbody.velocity);
   }


   [Test]
   public void PowerUpManager_StoresAndGetsPowerUp()
   {
       // Arrange
       var gameObject = new GameObject();
       var powerUpManager = gameObject.AddComponent<PowerUpManager>();
       PowerUpManager.Instance = powerUpManager;
       powerUpManager.powerUpIcon = new GameObject().AddComponent<UnityEngine.UI.Image>();
       var powerUp = new HeavyState();
       var sprite = Sprite.Create(Texture2D.blackTexture, new Rect(0, 0, 1, 1), Vector2.zero);
       var statsManagerObject = new GameObject();
       var statsManager = statsManagerObject.AddComponent<StatsManager>();
       StatsManager.Instance = statsManager;

       // Act
       powerUpManager.StorePowerUp(powerUp, sprite);

       // Assert
       Assert.AreEqual(powerUp, powerUpManager.GetStoredPowerUp());
   }


   [Test]
   public void PowerUpManager_UsesAndRemovesPowerUp()
   {
       // Arrange
       var gameObject = new GameObject();
       var powerUpManager = new GameObject().AddComponent<PowerUpManager>();
       PowerUpManager.Instance = powerUpManager;
       var powerUp = new HeavyState();
       bool called = false;
       
       if (StatsManager.Instance == null)
       {
        var statsManagerObject = new GameObject();
        var statsManager = statsManagerObject.AddComponent<StatsManager>();
        StatsManager.Instance = statsManager;
       }   

       powerUpManager.powerUpIcon = new GameObject().AddComponent<UnityEngine.UI.Image>();
       var sprite = Sprite.Create(Texture2D.blackTexture, new Rect(0, 0, 1, 1), Vector2.zero);


       void Used()
       {
        called = true;
       }
      
       powerUpManager.OnPowerUpUsed += Used;

       // Act
       powerUpManager.StorePowerUp(powerUp, sprite);
       powerUpManager.UsePowerUp();


       // Assert
       Assert.IsTrue(called);
       Assert.IsNull(powerUpManager.GetStoredPowerUp());
   }


   [Test]
   public void Projectile_SetState_SetsTheState()
   {
       // Arrange
       var projectileObject = new GameObject();
       var projectile = projectileObject.AddComponent<Projectile>();
       var rigidbody = projectileObject.AddComponent<Rigidbody2D>();
       projectile.GetType().GetField("rb", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(projectile, rigidbody); //access to rb in projectile
       rigidbody.mass = 1f;
       var heavyState = new HeavyState();

       // Act
       projectile.SetState(heavyState);


       // Assert
       Assert.AreEqual(4f, rigidbody.mass);
   }
}


