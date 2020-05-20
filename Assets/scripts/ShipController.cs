using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private SpriteRenderer spriteRender;

    enum SpritesNames { SampleShip, ShipWIthPlayer };


    [SerializeField]
    private Sprite[] sprites;

    public float angleSpeed = 0.1f;

    public float linearSpeed = 10f;


    private void OnEnable()
    {
        

    }
    private void Start()
    {
        spriteRender = GetComponentInChildren<SpriteRenderer>();
        
        rb2d = GetComponent<Rigidbody2D>();

        spriteRender.sprite = sprites[(int)SpritesNames.ShipWIthPlayer];


    }

    private void FixedUpdate()
    {

        float torgueDirection  = Input.GetAxis("Horizontal");

        if (torgueDirection != 0) AngleMoove(torgueDirection);

        if (Input.GetKey(KeyCode.Space)) EngineBoost();

    }

    private void AngleMoove(float direction)
    {
        
        rb2d.AddTorque(-direction*angleSpeed);
        
    }

    private void EngineBoost()
    {

        rb2d.AddRelativeForce(Vector2.up*linearSpeed);

    }



}
