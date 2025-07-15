using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeoControl : MonoBehaviour
{
    private Rigidbody2D rb;
    int varTwo = 3;
    public int speed = 3;
   public string loadscene;
    // Start is called before the first frame update
    void Start()
    {
       rb= GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {

        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.tag) 
        {
            case "Finish":
                SceneManager.LoadScene(loadscene);
                break;
            case "Death":
                string thisScene = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(thisScene);
                break;

        }



    }
}


