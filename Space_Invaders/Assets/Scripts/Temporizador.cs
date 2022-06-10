using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Temporizador : MonoBehaviour
{
    public float tiempoPartida;
    public TextMeshProUGUI tiempo;


    public void Update()
    {
        tiempoPartida += Time.deltaTime;

       
        

        tiempo.text = ("Tiempo de juego :") + tiempoPartida.ToString();
        
    }
}
