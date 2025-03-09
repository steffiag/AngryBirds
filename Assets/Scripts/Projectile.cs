using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private IProjectileState currentState;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentState = new NormalState();
    }

    public void SetState(IProjectileState newState)
    {
        currentState = newState;
    }

    public void ApplyPowerUp()
    {
        currentState.ApplyEffect(rb);
    }

    public void ResetToNormal()
    {
        SetState(new NormalState());
    }
}
