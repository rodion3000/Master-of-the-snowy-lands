using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ScrollingCamera : MonoBehaviour
{
    public float paralaxSpeed;
    private Transform cameraTransform;
    private float lastCameraX;
    private float length;


    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

  

    }
    private void Update()
    {
        float temp = (lastCameraX * (1 - paralaxSpeed));
        float deltaX = cameraTransform.position.x - lastCameraX;
        transform.position += Vector3.right * (deltaX * paralaxSpeed);
        lastCameraX = cameraTransform.position.x;

      
        
            
        


    }
}
