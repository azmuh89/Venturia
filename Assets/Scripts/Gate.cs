using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    public string sceneName;
    public bool up, down, right, left;

    private GameObject player;
    private Scene scene;
    private Bounds bounds;
    private static string gateName = null;

    void Start()
    {
        Spawn();
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Player")
        {
            gateName = this.transform.name;
            SceneManager.LoadScene(sceneName);
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
        player = GameObject.Find("Player");

        if (gateName != null)
        {
            bounds = GameObject.Find(gateName).GetComponent<Collider2D>().bounds;
        }
        else
        {
            bounds.size = new Vector3(0, 0, 0);
        }
    }

    void Spawn()
    {
        if (up)
        {
            player.transform.position = new Vector3(bounds.center.x, bounds.center.y + 2, 0);
        }
        else if (down)
        {
            player.transform.position = new Vector3(bounds.center.x, bounds.center.y - 2, 0);
        }
        else if (right)
        {
            player.transform.position = new Vector3(bounds.center.x + 2, bounds.center.y, 0);
        }
        else if (left)
        {
            player.transform.position = new Vector3(bounds.center.x - 2, bounds.center.y, 0);
        }
    }
}
