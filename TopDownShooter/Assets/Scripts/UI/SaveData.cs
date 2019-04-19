using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaveData : MonoBehaviour
{
    public Button savebutton;
    public Slider musicSlider;
    public Slider sfxSlider;
    // Start is called before the first frame update
    void Start()
    {
        savebutton.onClick.AddListener(SaveSettings);
    }

    // Update is called once per frame
    void SaveSettings()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value / 100);
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value / 100);
        
    }
}
