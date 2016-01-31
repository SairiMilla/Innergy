using UnityEngine;
using System.Collections;

public class ChasmCheck : MonoBehaviour {
    Enemy parent;
	
	void Start () {
        parent = transform.parent.GetComponent<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit2D(Collider2D col) {
        parent.Flip();
    }
}
