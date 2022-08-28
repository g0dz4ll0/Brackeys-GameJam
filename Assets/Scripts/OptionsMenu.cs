using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    

    public GameObject previousMenu;

    public Slider volumeSlider;
    //public TextMeshProUGUI volumeSliderText;

    public TMP_Dropdown resolutionDropdown;

    public Toggle fullscreenToggle;


    bool isFullscreen;

    Resolution[] resolutions;

    public AudioMixer mainMixer;

    // Start is called before the first frame update
    void Start()
    {
        isFullscreen = true;
        volumeSlider.value = PlayerPrefs.GetFloat("VolumeValue");
        //volumeSliderText.text = volumeSlider.value.ToString();

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();


        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {

            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {

        gameObject.SetActive(false);
        previousMenu.SetActive(true);

    }

    public void ScreenMode()
    {

        Screen.fullScreen = fullscreenToggle.isOn;

    }

    public void Resolution()
    {

        Resolution resolution = resolutions[resolutionDropdown.value];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }

    public void SetVolume(float _volume)
    {
        float volume = volumeSlider.value;
        //volumeSliderText.text = (volume * 100)

        mainMixer.SetFloat("GeneralVolume", volume);
    }

    public void Done()
    {
        ScreenMode();
        Resolution();
        Back();
    }
}
