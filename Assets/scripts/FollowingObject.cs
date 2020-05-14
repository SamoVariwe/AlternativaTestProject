using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingObject : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objectsToFollow;

    public Dictionary<string, GameObject> objectsToFollow2;
    
    void Start()
    {
        transform.SetParent(objectsToFollow[0].transform);
    }

    
    void Update()
    {
        
    }
}
