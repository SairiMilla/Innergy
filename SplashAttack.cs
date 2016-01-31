using UnityEngine;
using System.Collections;

public class SplashAttack : MonoBehaviour {
    public float power;
	void Start () {
        Invoke("die", 1f);
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerStay2D (Collider2D col){
        Enemy en = col.GetComponent<Enemy>();
        col.GetComponent<Enemy>().getHit(power);
        float direction = col.transform.position.x - transform.position.x ;
        if (direction < 0)
            col.GetComponent<Rigidbody2D>().velocity= new Vector2(-power * 5, 0);
        else
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(power * 5, 0);

        en.pushed = true;
        Debug.Log("Yas");
    }

    void die() {
        Destroy(gameObject);
    }
}
