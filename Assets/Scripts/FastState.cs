using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastState : IProjectileState
{
    public void ApplyEffect(Rigidbody2D projectile)
    {
        Debug.Log("Applying FastState - Increasing Speed!");
        Vector2 direction = projectile.transform.right;
        if (projectile.velocity.magnitude < 0.1f) 
        {
            projectile.velocity += direction * 5f;
        }
        else
        {
            projectile.velocity *= 1.75f;
        }
        Debug.Log("New Projectile Velocity: " + projectile.velocity);
    }
}
