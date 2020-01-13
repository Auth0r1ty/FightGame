using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionScript : MonoBehaviour
{
    int health = 3;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
        rb2d.velocity = new Vector2(0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("LeftFighter") || collision.gameObject.tag.Equals("RightFighter"))
        {
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag.Equals("Fireball"))
        { 
            health -= 1;
            if (health == 0)
                Destroy(this.gameObject);
        }
    }
}
