using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableScreen : MonoBehaviour
{
    //Crea una animación general para todas las pantallas (Un escalado de 0-1), que añadimos a cada una de ellas.
    void OnEnable()
    {
        LeanTween.scale(gameObject, new Vector3(0f, 0f, 0f), 0f);
        LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 1.0f).setEaseOutBounce();
    }

    
}
