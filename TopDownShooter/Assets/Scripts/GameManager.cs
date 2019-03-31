using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Player;
    private SceneManager sm;
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
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnSceneLoad()
    {
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
    }
}
