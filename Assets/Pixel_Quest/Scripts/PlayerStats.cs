using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour

{
    public string nextlevel = "Level2"; 
    public string loadscene;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Finish":
                {
                    SceneManager.LoadScene(loadscene);
                    break;
                }
            case "Death":
                {
                    string thisScene = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thisScene);
                    break;
                }

        }
    }
}



