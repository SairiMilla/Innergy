using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {
    public Transform playerTransform;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
	}
}
