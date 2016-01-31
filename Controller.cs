using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controller : MonoBehaviour
{

    public float maxSpeed;
    bool facingRight = false;
    float move;
    float ijumpForce;
    public float jumpforce;
    public bool grounded = true;
    float extraspeed = 1f;
    public Transform groundCheck;
    float groundRadius = 0.05f;
    public LayerMask whatIsGround;
    bool muerto;
    public Vector3 spawnPoint;
    Talisman[] habilities;
    public GameObject[] talismans;
    public Slider healthSlider;
    public Slider experienceSlider;
    public Image talismanSimbol;
    public bool dashing = false;
    Animator anim;
    public Talisman curTalisman;
    int selectedTalisman = 0;

    public Text levelTag;

    public float health;
    public float maxhealth;

    public Image gameOverScreen;

    void Awake() {
        habilities = new Talisman[talismans.Length];
    }
    void Start()
    {
        gameOverScreen.CrossFadeAlpha(0f, 0f, false);
        spawnPoint = transform.position;
        anim = GetComponent<Animator>();
        ijumpForce = jumpforce;
        for (int i = 0; i < talismans.Length; i++)
        {
            GameObject go = Instantiate(talismans[i]) as GameObject;
            go.transform.parent = transform;
            habilities[i] = go.GetComponent<Talisman>();
        }
    }

    void Update()
    {
        healthSlider.value = health;
        move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        curTalisman = habilities[selectedTalisman];
        levelTag.text = "level " + curTalisman.level;
        talismanSimbol.sprite = curTalisman.simbol;
        experienceSlider.value = curTalisman.energy;
        if (curTalisman.level != 1)
            experienceSlider.minValue = curTalisman.energytresholds[curTalisman.level - 2];
        else
            experienceSlider.minValue = 0;

        experienceSlider.maxValue = curTalisman.energytresholds[curTalisman.level - 1];
        if (!dashing)
        {
            if (Input.GetButton("Run"))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed * 1.7f, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }

            if (move > 0 && !facingRight)
                Flip();
            else if (move < 0 && facingRight)
                Flip();
        }
        if (Input.GetButtonDown("Jump") && (grounded))
        {
            grounded = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y + jumpforce);

        }
        if (Input.GetButton("Jump") && GetComponent<Rigidbody2D>().velocity.y > 0 && !(grounded))
        {
            grounded = false;
            extraspeed -= Time.deltaTime * 50;
            jumpforce += Time.deltaTime * extraspeed;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpforce);

        }

        if (!grounded && !Input.GetButton("Jump"))
            jumpforce = 0f;

        if (Input.GetButtonDown("SwitchUp")) {
            if (selectedTalisman != 3)
                selectedTalisman++;
            else
                selectedTalisman = 0;
        }

        if (Input.GetButtonDown("SwitchDown"))
        {
            if (selectedTalisman != 0)
                selectedTalisman--;
            else
                selectedTalisman = 3;
        }

        if (Input.GetButtonDown("Action")) {
            if (selectedTalisman != 0)
                curTalisman.activate();
        }

        if (Input.GetButton("Action")) {
            if (selectedTalisman == 2)
            {
                curTalisman.activate();
            }
        }
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (grounded)
        {
            jumpforce = ijumpForce;
            extraspeed = 1f;
        }
        if (transform.position.y < -2f && !muerto)
        {
            die();
        }
    }

    void die() {
        gameOverScreen.CrossFadeAlpha(1f, 0.7f, false);
        muerto = true;
        Invoke("respawn", 2f);
    }

    public void getHit(float amount) {
        health -= amount;
        curTalisman.looseEnergy(amount * 0.5f);
        if (health <= 0) {
            die();
        }
    }
 
    void respawn()
    {
        gameOverScreen.CrossFadeAlpha(0, 0.5f, false);
        Application.LoadLevel(Application.loadedLevel);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void heal(float healz) {
        health += healz;
        if (health > maxhealth)
            health = maxhealth;
    }

}
