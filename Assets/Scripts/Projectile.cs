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
        ApplyPowerUp();
        

    }

    public void ApplyPowerUp()
    {
        if (currentState != null)
        {
            Debug.Log(currentState);
            currentState.ApplyEffect(rb);
            Debug.Log("New Velocity: " + rb.velocity);
            Debug.Log("New Mass: " + rb.mass);

        }
    }

    public void ResetToNormal()
    {
        SetState(new NormalState());
    }
}
