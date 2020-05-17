using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFixRotation : MonoBehaviour, IRotationConstratable
{
    private void FixZRotation()
    {
        Quaternion rotationRelativeToPlanet = Quaternion.FromToRotation(-transform.up, AttractingPlanet.transform.position - transform.position);

        transform.rotation = transform.rotation * rotationRelativeToPlanet;

        //hard fix bug with x and y rotation
        transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
    }

    public GameObject AttractingPlanet { get; set; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (AttractingPlanet != null) FixZRotation();
        
    }
}
