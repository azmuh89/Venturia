using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    public string sceneName;
    
    private GameObject player;
    private Vector3 playerBounds;
    private Scene scene;
    private Bounds bounds;
    private static string gateName = null;
    private static bool up, down, right, left;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Player")
        {
            gateName = this.transform.name;
            SceneManager.LoadScene(sceneName);
            SceneFade.instance.Fade();
        }

        Vector3 gateBounds = this.GetComponent<Collider2D>().bounds.center;

        if (playerBounds.y < gateBounds.y)
        {
            up = true;
        }
        else if (playerBounds.y > gateBounds.y)
        {
            down = true;
        }
        else if (playerBounds.x < gateBounds.x)
        {
            right = true;
        }
        else if (playerBounds.x > gateBounds.x)
        {
            left = true;
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerBounds = player.GetComponent<Collider2D>().bounds.center;

        if (gateName != null)
        {
            bounds = GameObject.Find(gateName).GetComponent<Collider2D>().bounds;
        }
        else
        {
            bounds.size = new Vector3(0, 0, 0);
        }

        Spawn();
    }

    void Spawn()
    {
        if (up)
        {
            player.transform.position = new Vector3(bounds.center.x, bounds.center.y + 3, 0);
            up = false;
        }
        else if (down)
        {
            player.transform.position = new Vector3(bounds.center.x, bounds.center.y - 3, 0);
            down = false;
        }
        else if (right)
        {
            player.transform.position = new Vector3(bounds.center.x + 2, bounds.center.y, 0);
            right = false;
        }
        else if (left)
        {
            player.transform.position = new Vector3(bounds.center.x - 2, bounds.center.y, 0);
            left = false;
        }
    }
}
