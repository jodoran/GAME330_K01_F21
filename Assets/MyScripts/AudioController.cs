using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume", 1);
    }

    public void SetVolume(float val)
    {
        PlayerPrefs.SetFloat("Volume", val);
        GetComponent<AudioSource>().volume = val;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
