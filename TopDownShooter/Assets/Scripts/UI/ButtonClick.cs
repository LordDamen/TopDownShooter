using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public AudioClip clickSound;
    public List<Button> buttonList;

    void Start()
    {
        
     for (var i = 0; i< buttonList.Count;i++)
        {
            buttonList[i].onClick.AddListener(ButtonSound);
        }
    }
    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("sfxVolume");
    }
    void ButtonSound ()
    {
        AudioSource.PlayClipAtPoint(clickSound, gameObject.transform.position);
    }
}
