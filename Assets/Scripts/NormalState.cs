using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : IProjectileState
{
    public void ApplyEffect(Rigidbody2D projectile)
    {
        projectile.mass = 1f;
        projectile.velocity *= 1f;
    }
}