using UnityEngine;
using System.Collections;

public class Border : MonoBehaviour {
    float initialDist;
	// Use this for initialization
	void Start () {
        initialDist = Camera.main.transform.position.x - transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(Camera.main.transform.position.x - initialDist, Camera.main.transform.position.y);
	}
}
