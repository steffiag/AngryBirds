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
    // Start is called before the first frame update
    void Start()
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);
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
        }
        else{
            ResetStrips();
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
    }
    private void OnMouseDown(){
        isMouseDown=true;
    }
    private void OnMouseUp(){
        isMouseDown=false;
    }

    Vector3 ClampBoundary(Vector3 bottomBound){
        bottomBound.y = Mathf.Clamp(bottomBound.y, groundBound, 1000);
        return bottomBound;
    }
    
}
