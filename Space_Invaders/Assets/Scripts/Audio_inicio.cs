using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Audio_inicio : MonoBehaviour
{
    public AudioSource audioSource;
    
    //comienza la m�sica desde el inicio del juego.
    void Start()
    {
        audioSource.Play();
    }

    
    void Update()
    {
        
    }
}
