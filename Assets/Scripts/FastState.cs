using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastState : IProjectileState
{
    public void ApplyEffect(Rigidbody2D projectile)
    {
        projectile.velocity *= 1.5f;
    }
}
