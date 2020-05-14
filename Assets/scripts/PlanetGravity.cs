using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof( Collider2D))]
public class PlanetGravity : MonoBehaviour
{
    private  HashSet<Rigidbody2D> AffectedRigidBodys= new HashSet<Rigidbody2D>();

    [SerializeField]
    private float PlanetMass=10f;

    [SerializeField]
    private float GravityConst = 10f;

    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        foreach(Rigidbody2D rb2d in AffectedRigidBodys)
        {
            Vector2 bodyToPlanetVector = ((Vector2)transform.position - rb2d.position);

            float distance = bodyToPlanetVector.magnitude;

            Vector2 direction = bodyToPlanetVector.normalized;

            float strength = PlanetMass * rb2d.mass * GravityConst / Mathf.Pow(distance, 2);

            rb2d.AddForce(direction * strength);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody != null)
        {
            SetAPlanetToABody(collision,true);

            AffectedRigidBodys.Add(collision.attachedRigidbody);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody != null)
        {
            SetAPlanetToABody(collision,false);

            AffectedRigidBodys.Remove(collision.attachedRigidbody);
        }
    }

    private void SetAPlanetToABody(Collider2D collision,bool SetOrRemove)
    {
        IRotationConstratable BodyToFixRotation = collision.GetComponent<IRotationConstratable>();
        if (BodyToFixRotation != null)
        {
            if(SetOrRemove==true)

            BodyToFixRotation.AttractingPlanet = gameObject;

            else BodyToFixRotation.AttractingPlanet = null;
        }
        
    }
}
