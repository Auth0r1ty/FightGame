using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Control : MonoBehaviour
{
    Rigidbody2D rb2d;
    float dirX, dirY, moveSpeed = 7f;
    int health = 100;
    float fireRate = 0.5f, nextFire = 0;
    GameObject fireballToRight, fireballToLeft;
    Animator anim;
    Vector2 bulletPos;
    bool collided = false;
    Text healthText;
    GameObject fightControl;
    int numberOfJumps = 0;
    bool dead = false;

    public int Health { get => health; set => health = value; }

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        rb2d.freezeRotation = true;

        fireballToRight = (GameObject)Resources.Load("Prefabs/FireballToRight", typeof(GameObject));
        fireballToLeft = (GameObject)Resources.Load("Prefabs/FireballToLeft", typeof(GameObject));

        fightControl = GameObject.Find("FightControl");
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
            return;

        dirX = Input.GetAxisRaw("Horizontal2") * moveSpeed;
        dirY = Input.GetAxis("Vertical2") * moveSpeed;

        if (Input.GetButtonDown("Fire2")) //range attack
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
        if (Input.GetKey(KeyCode.L))
        {
            anim.SetTrigger("swordAttack");
            if (collided)
            {
                HitEnemy();
            }
        }

        if (health == 0)
        {
            anim.SetTrigger("die");
            dead = true;
        }


        if (Input.GetButtonDown("Jump2") && numberOfJumps < 2)
        {
            rb2d.AddForce(new Vector2(0f, 200f));
            numberOfJumps++;
        }
    }

    private void FixedUpdate()
    {
        if (dead)
            return;

        Vector3 movement = new Vector3(dirX, 0, dirY) * 1f;
        movement.y = rb2d.velocity.y;
        rb2d.velocity = movement;

        if (Input.GetButtonDown("Jump2") && numberOfJumps < 2)
            rb2d.AddForce(new Vector2(0f, 200f));
    }

    private void Fire()
    {
        anim.SetTrigger("fireAttack");
        bulletPos = transform.position;
        bulletPos += new Vector2(-1.5f, -0.3f);
        Instantiate(fireballToLeft, bulletPos, Quaternion.identity);
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("LeftFighter"))
        {
            collided = true;
        }
        if (collision.gameObject.tag.Equals("Fireball"))
        {
            Health -= 10;
            Debug.Log(Health);
        }

        if (collision.gameObject.name.Equals("healthPotion(Clone)"))
        {
            Health += 20;
        }

        if (collision.gameObject.name.Equals("Background") || collision.gameObject.name.Equals("Platform"))
            numberOfJumps = 0;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collided = false;
    }

    void HitEnemy()
    {
        fightControl.GetComponent<FightControlScript>().Notify("1");
    }
}
