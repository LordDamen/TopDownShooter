using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Player;
    private SceneManager sm;
    public GameObject pauseMenu;
    private bool paused;
    void awake()
    {
        if(instance == null)
        {
            instance = this; 
        } else
        {
            Destroy(gameObject);
        }
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
        pauseMenu = GameObject.Find("Pause Menu");
        pauseMenu.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.Find("Pause Menu");
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            Pause();

        }
    }
    void OnSceneLoad()
    {
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
        
    }
    public void Pause()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            
        } else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        paused = !paused;
    }
}
