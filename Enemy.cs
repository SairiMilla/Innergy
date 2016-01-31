using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float power;
    public float maxSpeed;
    public bool facingRight;
    protected bool attacking = false;
    public float attackRate;
    float nextAttackTime;
    protected Animator anim;
    protected Rigidbody2D enemrigid;
    Random rand;
    public GameObject energyDrop;
    public GameObject healthdrop;
    public float maxEnergyValue;
    public float maxHealthValue;
    public bool pushed;

    public float health;


    void OnCollisionEnter2D(Collision2D col) {
        attacking = true;
        enemrigid.velocity = new Vector2(enemrigid.velocity.x * 0.1f,enemrigid.velocity.y);
        nextAttackTime = Time.time + attackRate;
        Attack(col);
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (Time.time > nextAttackTime)
        {
            Debug.Log(enemrigid.gravityScale);
            nextAttackTime = nextAttackTime + attackRate;
            Attack(col);
        }
    }
    void OnCollisionExit2D(Collision2D col) {
        attacking = false;
        anim.SetBool("Attacking", false);
    }
    void Attack(Collision2D c) {
        anim.SetBool("Attacking",true);
        Controller aux = c.gameObject.GetComponent<Controller>();
        if (aux != null)
        {
            aux.getHit(power);
        }
    }

    public void getHit(float amount) {
        health -= amount;
        if (health <= 0) {
            die();
        }
    }

    void die() {
        int drop = Random.Range(0, 3);
        if (drop == 0) {
            GameObject obj = (GameObject)Instantiate(energyDrop, transform.position, transform.rotation);
            obj.GetComponent<ExperienceOrb>().value = Random.Range(2f, maxEnergyValue);
        }
        else if(drop == 1) {
            GameObject obj = (GameObject)Instantiate(healthdrop, transform.position, transform.rotation);
            obj.GetComponent<HealthOrb>().value = Random.Range(5f, maxHealthValue);
        }
        Destroy(gameObject);

    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
