using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource music;
    void Start()
    {
        music=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
