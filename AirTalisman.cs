using UnityEngine;
using System.Collections;
using System;

public class AirTalisman : Talisman {

    bool gliding = false;
    float glidingEnd;
    bool validGliding = true;

    public override void activate()
    {

        if (!transform.parent.GetComponent<Controller>().grounded && validGliding) {
            Rigidbody2D parenrigid = transform.parent.GetComponent<Rigidbody2D>();
            parenrigid.gravityScale = 0;
            parenrigid.velocity = new Vector2(parenrigid.velocity.x, 0);

            if (!gliding) {
                gliding = true;
                glidingEnd = effectDuration + Time.time;
            }
            if (Time.time >= glidingEnd) {
                validGliding = false;
                transform.parent.GetComponent<Rigidbody2D>().gravityScale = 6;

            }
        }
    }

    public override void levelDown()
    {
        level--;
        if (level == 2)
            effectDuration = 2;
    }

    public override void levelUp()
    {
        level++;
        if (level == 3)
            effectDuration *= 1.5f;
    }

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        if (!validGliding)
        {
            gliding = false;
        }

        if (Input.GetButtonUp("Action") && gliding)
        {
            validGliding = false;
            transform.parent.GetComponent<Rigidbody2D>().gravityScale = 6;
        }


        if (transform.parent.GetComponent<Controller>().grounded) {
            validGliding = true;
            gliding = false;
            transform.parent.GetComponent<Rigidbody2D>().gravityScale = 6;
        }
        transform.parent.GetComponent<Animator>().SetBool("Gliding", gliding);
    }
}
