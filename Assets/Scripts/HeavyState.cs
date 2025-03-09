using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyState : IProjectileState
{
    public void ApplyEffect(Rigidbody2D projectile)
    {
        projectile.mass = 3f;
    }
}
