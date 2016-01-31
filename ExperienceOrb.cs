using UnityEngine;
using System.Collections;

public class ExperienceOrb : MonoBehaviour {

    public float value;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col) {
        Talisman aux= col.gameObject.GetComponent<Controller>().curTalisman;
        aux.getEnergy(value);
        Destroy(gameObject);
    }

}
