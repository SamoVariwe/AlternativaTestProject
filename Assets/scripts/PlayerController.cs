using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour,IRotationConstratable
{
    private Rigidbody2D rb2d;

    private SpriteRenderer spriteRender;

    public float horizontalSpeed=0.1f;
    
    public GameObject AttractingPlanet { get; set; }
    
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
        spriteRender = GetComponentInChildren<SpriteRenderer>();
    }
    
    private void FixedUpdate()
    {
        if (AttractingPlanet != null) FixZRotation();

        Vector2 direction = Vector2.right *Input.GetAxis("Horizontal");

        if(direction.x!=0)HorizontalMoove(direction);
    }

    private void HorizontalMoove(Vector2 direction)
    {
        if (direction.x > 0) spriteRender.flipX = false;

        if(direction.x<0) spriteRender.flipX = true;

        transform.Translate(direction * horizontalSpeed * Time.fixedDeltaTime,Space.Self);
    }

    private void FixZRotation()
    {
        Quaternion rotationRelativeToPlanet = Quaternion.FromToRotation(-transform.up, AttractingPlanet.transform.position - transform.position);

        transform.rotation = transform.rotation* rotationRelativeToPlanet;

        transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
        
    }



}
