using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    public float velY = 0f, velX;
    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;

        if(gameObject.name.Equals("FireballToLeft(Clone)"))
        {
            velX = -5;
        }else
        {
            velX = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(velX, velY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
