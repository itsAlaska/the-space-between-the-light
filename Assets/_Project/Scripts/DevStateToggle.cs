using UnityEngine;

public class DevStateToggle : MonoBehaviour
{
    [Header("Volumes")]
    public GameObject lightVolume;   // GlobalVolume_Light
    public GameObject darkVolume;    // GlobalVolume_Dark

    [Header("Audio (optional)")]
    public AudioSource darkDrone;    // global dark loop
    public AudioSource[] lightAmbiences; // hum/bugs under lamps

    [Header("Keybinds")]
    public KeyCode toggleKey = KeyCode.Tab;

    bool dark;

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            dark = !dark;

            if (lightVolume) lightVolume.SetActive(!dark);
            if (darkVolume)  darkVolume.SetActive(dark);

            // simple audio swap
            if (darkDrone)
            {
                darkDrone.loop = true;
                darkDrone.mute = !dark;
                if (dark && !darkDrone.isPlaying) darkDrone.Play();
            }
            if (lightAmbiences != null)
            {
                foreach (var a in lightAmbiences)
                {
                    if (!a) continue;
                    a.mute = dark;
                }
            }
        }
    }
}