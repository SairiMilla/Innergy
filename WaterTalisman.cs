using UnityEngine;
using System.Collections;
using System;

public class WaterTalisman : Talisman {

    public float cooldown;
    public float dashDuration;
    float coolDownEnd;
    float dashEnd;
    public float dashSpeed;
    public GameObject waterAura;
    public GameObject splash;
    bool dashActive;

    void Start() {
        waterAura = GameObject.FindWithTag("waterAura");
        waterAura.SetActive(false);
    }

    public override void activate()
    {
        if (!dashActive && Time.time > coolDownEnd)
        {
            dashEnd = Time.time + dashDuration;
            if (level >= 2)
            {
                Physics2D.IgnoreLayerCollision(8, 11, true); ;
                waterAura.SetActive(true);
            }
            Rigidbody2D parRigid = transform.parent.GetComponent<Rigidbody2D>();
            transform.parent.GetComponent<Controller>().dashing = true;
            dashActive = true;
            parRigid.gravityScale = 0;
            if (parRigid.velocity.x >= 0)
                parRigid.velocity = new Vector2(dashSpeed, 0);
            else
                parRigid.velocity = new Vector2(-dashSpeed, 0);
        }

    }

    public override void levelDown()
    {
        level--;
    }

    public override void levelUp()
    {
        level++;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > dashEnd && dashActive)
        {
            Physics2D.IgnoreLayerCollision(8, 11, false); ;
            transform.parent.GetComponent<Controller>().dashing = false;
            waterAura.SetActive(false);
            if (level == 3) {
                Instantiate(splash, new Vector2(transform.parent.position.x, transform.parent.position.y - 1), transform.rotation);
            }
            transform.parent.GetComponent<Rigidbody2D>().gravityScale = 6;
            coolDownEnd = Time.time + cooldown;
            dashActive = false;
        }
    }
}
