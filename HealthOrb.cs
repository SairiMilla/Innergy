using UnityEngine;
using System.Collections;

public class HealthOrb : MonoBehaviour {

    public float value;

    void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.GetComponent<Controller>().heal(value);
        Destroy(gameObject);
    }
}
