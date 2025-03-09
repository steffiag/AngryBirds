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
    Rigidbody2D player;
    Collider2D playerCollider;
    public float playerPositionOffset;

    public float force;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);

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
        
    }

    void CreatePlayer(){
        player = Instantiate(playerPrefab).GetComponent<Rigidbody2D>();
        playerCollider = player.GetComponent<Collider2D>();
        playerCollider.enabled = false;

        player.isKinematic = true;
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
        player.isKinematic = false;
        Invoke("CreatePlayer", 0);
        Vector3 playerForce = (currentPosition - center.position) * force * -1;
        player.velocity = playerForce;
        
        player = null;
        playerCollider = null;
        
    }
    Vector3 ClampBoundary(Vector3 bottomBound){
        bottomBound.y = Mathf.Clamp(bottomBound.y, groundBound, 1000);
        return bottomBound;
    }
    
}
