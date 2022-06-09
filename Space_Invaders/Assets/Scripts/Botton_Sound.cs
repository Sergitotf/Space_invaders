using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Botton_Sound : MonoBehaviour,ISelectHandler
{
    public Button myButton;
    public TextMeshProUGUI mytext;
    public Botton_Sound defaultSound;
    public Botton_Sound selectedSound;
    public AudioSource effect;
    

    public void OnSelect(BaseEventData eventData)
    {
        effect.Play();
        
    }
}
// Sonido al seleccionar boton