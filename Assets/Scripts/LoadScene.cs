using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Animator animator;
    public string sceneName;
    public bool spawn;
    public bool up, down, left, right;

    private GameObject player;
    private Bounds bounds;

    void Start()
    {
        Spawn();
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Time.timeScale = 0;
            FadeToLevel();
        }
    }

    void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += SpawnLocation;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= SpawnLocation;
    }

    void SpawnLocation(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bounds = GameObject.Find(this.transform.name).GetComponent<Collider2D>().bounds;
    }

    void Spawn()
    {
        if (spawn)
        {
            if (up)
            {
                player.transform.position = new Vector3(bounds.center.x, bounds.center.y + 2, 0);
            }
            if (down)
            {
                player.transform.position = new Vector3(bounds.center.x, bounds.center.y - 2, 0);
            }
            if (right)
            {
                player.transform.position = new Vector3(bounds.center.x + 2, bounds.center.y, 0);
            }
            if (left)
            {
                player.transform.position = new Vector3(bounds.center.x - 2, bounds.center.y, 0);
            }
        }
    }
}
