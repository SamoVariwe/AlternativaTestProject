using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private SpriteRenderer spriteRender;

    public float horizontalSpeed=0.1f;
    
    
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
        spriteRender = GetComponentInChildren<SpriteRenderer>();
    }
    
    private void FixedUpdate()
    {

        Vector2 direction = Vector2.right *Input.GetAxis("Horizontal");

        if(direction.x!=0)HorizontalMoove(direction);
    }

    private void HorizontalMoove(Vector2 direction)
    {
        if (direction.x > 0) spriteRender.flipX = false;

        if(direction.x<0) spriteRender.flipX = true;

        transform.Translate(direction * horizontalSpeed * Time.fixedDeltaTime,Space.Self);
    }

   

    public void EnteredShipTrigger()
    {

    }
    
}
