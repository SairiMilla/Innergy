using UnityEngine;
using System.Collections;

public class FireAura : MonoBehaviour {

    public float power;
    public float damageStep;
    float waitTime;

    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D col) {
        waitTime = Time.time + damageStep;
        col.GetComponent<Enemy>().getHit(power);
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (waitTime < Time.time)
        {
            waitTime = Time.time + damageStep;
            col.GetComponent<Enemy>().getHit(power);
        }
    }
}
