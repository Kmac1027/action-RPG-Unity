using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D theRB;

    private Animator anim;

    public SpriteRenderer theSR;
    public Sprite[] playerDirectionSprites;
    
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = new Vector3(transform.position.x + (Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime), transform.position.y +(Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime), transform.position.z);

        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"),  Input.GetAxisRaw("Vertical")).normalized * moveSpeed;

        anim.SetFloat("Speed", theRB.velocity.magnitude);

        if(theRB.velocity != Vector2.zero)
        {
            if(Input.GetAxisRaw("Horizontal") != 0)
            {
                theSR.sprite = playerDirectionSprites[1];
                if(Input.GetAxisRaw("Horizontal") < 0)
                {
                    theSR.flipX = true;
                } else 
                {
                    theSR.flipX = false;
                }
            } else 
            {
                if(Input.GetAxisRaw("Vertical") < 0)
                {
                    theSR.sprite = playerDirectionSprites[0];
                } else
                {
                    theSR.sprite = playerDirectionSprites[2];
                }
                
            }
        }
    }
}
