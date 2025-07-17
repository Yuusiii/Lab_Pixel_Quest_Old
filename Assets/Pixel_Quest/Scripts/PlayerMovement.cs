using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed = 4;
    private SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = transform.Find("Sprite").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xMovement * speed, rb.velocity.y);
        if (xMovement > 0) { sp.flipX = true; }
        else if (xMovement < 0) {sp.flipX = false; }
    }
}
