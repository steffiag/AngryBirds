using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyState : IProjectileState
{
    public void ApplyEffect(Rigidbody2D projectile)
    {
        Debug.Log("Applying HeavyState - Increasing Mass!");
        projectile.mass = 4f;
        projectile.AddForce(projectile.velocity.normalized * 2f, ForceMode2D.Impulse);
        Debug.Log("New Projectile Mass: " + projectile.mass);
    }
}
