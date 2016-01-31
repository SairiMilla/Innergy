using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    Transform playerPosition;
    public float offset;
    bool following;
    Vector3 follower;
    Vector3 ipostion;

	void Start () {
        playerPosition = GameObject.FindWithTag("player").transform;
        ipostion = transform.position;
    }
	
	void Update () {
        Vector2 playerSpeed;
        playerSpeed = GameObject.FindWithTag("player").GetComponent<Rigidbody2D>().velocity;

        if (!following && (playerPosition.position.x > transform.position.x + offset) && playerSpeed.x > 0)
        {
            following = true;
            follower = transform.position;
        }
        if (following)
        {
            if (transform.position.x < playerPosition.position.x - 1f)
            {
                follower = Vector3.Lerp(follower, playerPosition.position, Time.deltaTime * 9f);
                transform.position = new Vector3(follower.x, transform.position.y, -10);
            }
            else {
                transform.position = new Vector3(playerPosition.position.x, transform.position.y, -10);
            }
        }
        if (playerSpeed.x <= 0)
        {
            following = false;
        }

    }

    public void Reset() {
        transform.position = ipostion;
    }
}
