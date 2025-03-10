using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{

    public LineRenderer[] lineRenderers;
    public Transform[] stripPositions;
    public Transform center;
    public Transform idlePosition;

    bool isMouseDown;
    public Vector3 currentPosition;

    public float maxLength;
    public float groundBound;

    public GameObject playerPrefab;
    Projectile player;
    Collider2D playerCollider;
    public float playerPositionOffset;

    public float force;
    private bool powerUpApplied = false;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);

        Debug.Log("the slingshot is started");
        CreatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseDown){
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;

            currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            currentPosition = center.position + Vector3.ClampMagnitude(currentPosition - center.position, maxLength);
            currentPosition = ClampBoundary(currentPosition); 

            SetStrips(currentPosition);

            if (playerCollider){
                playerCollider.enabled = true;
            }
        }
        else{
            ResetStrips();
        }

        if (Input.GetKeyDown(KeyCode.E) && !powerUpApplied)
        {
            IProjectileState storedPowerUp = PowerUpManager.Instance.GetStoredPowerUp();
            if (storedPowerUp != null)
            {
                player.SetState(storedPowerUp);
                powerUpApplied = true;
                PowerUpManager.Instance.ClearPowerUp();
            }
        }
        
    }

    void CreatePlayer(){
        player = Instantiate(playerPrefab).GetComponent<Projectile>();
        playerCollider = player.GetComponent<Collider2D>();
        playerCollider.enabled = false;
        powerUpApplied = false;

        player.GetComponent<Rigidbody2D>().isKinematic = true;

        IProjectileState storedPowerUp = PowerUpManager.Instance.GetStoredPowerUp();
        if (storedPowerUp != null)
        {
            player.SetState(storedPowerUp);
            PowerUpManager.Instance.ClearPowerUp();
        }
    }

    void ResetStrips(){
        currentPosition=idlePosition.position;
        SetStrips(currentPosition);
    }
    void SetStrips(Vector3 newPosition){
        for (int i = 0; i<stripPositions.Length; i++){
            lineRenderers[i].SetPosition(1, newPosition);
        }
        if (player){
            Vector3 playerPosition = newPosition - center.position;
            player.transform.position = newPosition +  playerPosition.normalized * playerPositionOffset;
            player.transform.right = -playerPosition.normalized;
        }
       
    }
    private void OnMouseDown(){
        isMouseDown=true;
    }
    private void OnMouseUp(){
        isMouseDown=false;
        Shoot();
    }

    void Shoot(){
        GameEvents.ShotFired();
        player.GetComponent<Rigidbody2D>().isKinematic = false;

        Vector3 playerForce = (currentPosition - center.position) * force * -1;
        player.GetComponent<Rigidbody2D>().velocity = playerForce;

        player.ApplyPowerUp();
        Debug.Log("Projectile Launched! Initial Velocity: " + player.GetComponent<Rigidbody2D>().velocity);

        player.ResetToNormal();

        Invoke("CreatePlayer", 0);
        
        player = null;
        playerCollider = null;
        
    }
    Vector3 ClampBoundary(Vector3 bottomBound){
        bottomBound.y = Mathf.Clamp(bottomBound.y, groundBound, 1000);
        return bottomBound;
    }
    
}
