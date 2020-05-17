using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingObject : MonoBehaviour
{


    private bool needToTranslateCamera=false;

    private Vector3 targetVectorToMoveCamera;

    private Quaternion targetRotation;

    void Start()
    {
        targetVectorToMoveCamera= new Vector3(0, 0, transform.position.z);
        targetRotation = new Quaternion(0, 0, 0, 0);
    }

    public void SnapCameraToObject(GameObject gameObject)
    {
        transform.SetParent(gameObject.transform);
        needToTranslateCamera = true;
        // transform.localPosition=new Vector3(0,0, transform.position.z);
        transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    
    void Update()
    {
        if(needToTranslateCamera)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetVectorToMoveCamera, 0.2f);
            
            if (transform.localPosition == targetVectorToMoveCamera & transform.localRotation==targetRotation)
                needToTranslateCamera = false;
        }
    }

    
}
