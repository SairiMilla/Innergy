using UnityEngine;
using System.Collections;

public class ConejoEvil : Enemy {

	void Start () {
        enemrigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	void Update () {
        if (!attacking && !pushed)
        {
            if (facingRight)
                enemrigid.velocity = new Vector2(maxSpeed, enemrigid.velocity.y);
            else
                enemrigid.velocity = new Vector2(-maxSpeed, enemrigid.velocity.y);
            if (enemrigid.velocity.x != 0)
                anim.SetBool("Running", true);
            else
                anim.SetBool("Running", false);
        }
    }

}
