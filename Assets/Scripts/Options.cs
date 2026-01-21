using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public AudioMixer mixer;
    public Button save;
    public Button back;
    public Slider slider;
    
    void Start() {
        if (!PlayerPrefs.HasKey("volume")) {
            PlayerPrefs.SetFloat("volume", 0.6f);
        }
        slider.value = PlayerPrefs.GetFloat("volume");
        mixer.SetFloat("Master", Mathf.Log10(PlayerPrefs.GetFloat("volume")) * 20);
    }

    public void ChangeVolume() {
        mixer.SetFloat("Master", Mathf.Log10(slider.value) * 20);
    }
    
    public void Save() {
        PlayerPrefs.SetFloat("volume", slider.value);
        mixer.SetFloat("Master", Mathf.Log10(PlayerPrefs.GetFloat("volume")) * 20);
    }

    public void Back() {
        slider.value = PlayerPrefs.GetFloat("volume");
        mixer.SetFloat("Master", Mathf.Log10(PlayerPrefs.GetFloat("volume")) * 20);
    }
}
