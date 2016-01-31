using UnityEngine;
using System.Collections;
using System;

public class EarthTalisman : Talisman {

    GameObject punch;
    float punchEnd;
    bool punching;
    
    public override void activate()
    {
        if (!punching)
        {
            punch.SetActive(true);
            transform.parent.GetComponent<Animator>().SetBool("pawnching", true);
            punchEnd = Time.time + effectDuration;
            punching = true;
        }
    }

    public override void levelDown()
    {
        level--;
        if (level == 1) {
            punch.GetComponent<Punch>().power *= 0.5f;
        }
    }

    public override void levelUp()
    {
        level++;
        if (level == 2)
            punch.GetComponent<Punch>().power *= 2;
    }

    // Use this for initialization
    void Start () {
        punch = GameObject.FindWithTag("Pawnch");
        punch.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > punchEnd && punching) {
            punch.SetActive(false);
            transform.parent.GetComponent<Animator>().SetBool("pawnching", false);
            punching = false;
        }
    }
}
