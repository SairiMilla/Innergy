using UnityEngine;
using System.Collections;

public class WaterAura : MonoBehaviour {

    public float power; 

    void OnTriggerEnter2D(Collider2D col) {
        col.GetComponent<Enemy>().getHit(power);
    }
}
