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
    public GameObject settingsMenu;
    public ParticleSystem ps;
    public AudioClip MenuMusic; //= new AudioClip();
    public AudioClip GameMusic; //= new AudioClip();
    public AudioSource musicSource = new AudioSource();
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
        //pauseMenu = GameObject.Find("Pause Menu");
        pauseMenu.SetActive(false);
        //settingsMenu = GameObject.Find("Settings Menu");
        settingsMenu.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (pauseMenu == false) {
            pauseMenu = GameObject.Find("Pause Menu");
            ps = GameObject.FindGameObjectsWithTag("particle")[0].GetComponent< ParticleSystem>();
        }
        pauseMenu.SetActive(false);
        if (settingsMenu == false) { settingsMenu = GameObject.Find("Settings Menu"); }
        settingsMenu.SetActive(false);
        musicSource.volume = PlayerPrefs.GetFloat("musicVolume") / 100.0f;
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
            ps.Play();
            
        } else
        {
            Time.timeScale = 1;
            ps.Pause();
            pauseMenu.SetActive(false);
        }
        paused = !paused;
    }
    public void MusicSwap ()
    {
        if (musicSource.clip == this.MenuMusic)
        {
            if (GameMusic != null) print("Help");
            musicSource.clip = GameMusic;
            musicSource.Play();
        }
    }
}
