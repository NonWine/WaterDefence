using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform radiusCentreObject;
    [SerializeField] private float speedRot;
    public Vector3 posVector;
    private Camera camera;
    float xRot, yRot;
    float xRotCurrent, yRotCurrent;
    float currentVelosityX, currentVelosityY;
    public GameObject playerGameObject;
    public float sensivity = 5f, smoothTime = 0.1f;

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        transform.RotateAround(radiusCentreObject.position,posVector ,speedRot * Time.deltaTime);
        if (Input.GetMouseButton(0))
        {
            if(GameManager.Instance.InGame)
            Mouse();
        }
    }
    
    void Mouse()
    {
     
    
        xRot += Input.GetAxis("Mouse X") * sensivity ;
        yRot += Input.GetAxis("Mouse Y") * sensivity ;
        yRot = Mathf.Clamp(yRot, -0 , 30);
        xRot = Mathf.Clamp(xRot, -30    , 50);

        xRotCurrent = Mathf.SmoothDamp(xRotCurrent, xRot, ref currentVelosityX, smoothTime);
        yRotCurrent = Mathf.SmoothDamp(yRotCurrent, yRot, ref currentVelosityY, smoothTime);
        playerGameObject.transform.localRotation = Quaternion.Euler(-yRotCurrent , xRotCurrent, 0f);
        //playerGameObject.transform.localRotation = Quaternion.Euler(-yRotCurrent, xRotCurrent, 0f);
    }
}
