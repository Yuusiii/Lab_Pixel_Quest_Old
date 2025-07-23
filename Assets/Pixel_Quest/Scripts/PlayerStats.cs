
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    // string nextlevel = "GeoLevel_2"
    public string nextlevel = "Level2"; 
    public string loadscene;
    // Start is called before the first frame update
    void Start()
    {

    }

    public int health = 3;
    public int coinCount = 0;

    public Transform RespawnPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Finish":
                {
                    string nextlevel = collision.transform.GetComponent<LevelGoal>().nextlevel;
                    SceneManager.LoadScene(nextlevel);
                    break;
                }
            case "Death":
                {
                    health--;
                    if (health <= 0)
                    {
                        string thisScene = SceneManager.GetActiveScene().name;
                        SceneManager.LoadScene(thisScene);
                    }
                    else
                    {
                        transform.position = RespawnPoint.position;
                    }
                    break;
                }
            case "Coin":
                {
                    coinCount++;
                    Destroy(collision.gameObject);
                    break;
                }

            case "Health":
                {
                    if (health < 3)
                    {
                        Destroy(collision.gameObject);
                        health++;
                    }
                    break;

                }
            case "Respawn":{ 
                    RespawnPoint.position = collision.transform.Find("Point").position;
                    break;
                }
        }

    }
}



