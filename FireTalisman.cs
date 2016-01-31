using UnityEngine;
using System.Collections;
using System;

public class FireTalisman : Talisman {
    Light vision;
    public GameObject fireAura;

    void Start() {
        vision = GameObject.FindWithTag("playerSpotlight").GetComponent<Light>();
        fireAura = GameObject.FindWithTag("fireAura");
        fireAura.SetActive(false);
    }

    public override void levelUp()
    {
        Debug.Log("LevelUp");
        level++;
        if (level == 2)
        {
            vision.spotAngle = 70;
        }
        else if(level==3){
            fireAura.SetActive(true);
        }
    }



    public override void levelDown()
    {
        Debug.Log("LevelDown");
        level--;
        if (level == 1)
        {
            vision.spotAngle = 45;
        }
        else if (level == 2)
        {
            fireAura.SetActive(false);
        }
    }

    public override void activate()
    {
        throw new NotImplementedException();
    }

	
	void Update () {
	}
}
