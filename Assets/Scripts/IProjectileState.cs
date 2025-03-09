using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileState
{
    void ApplyEffect(Rigidbody2D projectile);
}
