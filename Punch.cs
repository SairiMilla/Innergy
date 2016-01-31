using UnityEngine;
using System.Collections;

public class Punch : MonoBehaviour {

    public float power;

    void OnTriggerEnter2D(Collider2D col) {
        col.GetComponent<Enemy>().getHit(power);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        col.GetComponent<Enemy>().getHit(power);
    }
}
