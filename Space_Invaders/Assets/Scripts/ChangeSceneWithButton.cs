using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeSceneWithButton : MonoBehaviour
{
    public GameObject pantalla1;
    public GameObject pantalla2;
    public GameObject pantalla3;
    public GameObject pantalla4;
    public GameObject pantalla5;
    public GameObject pantalla6;
    public GameObject pantalla7;
    public GameObject pantalla8;
    public GameObject currentScreen;
    public GameObject nextScreen;
    public float contador;
    public float cuentaAtras = 34f;
    public static ChangeSceneWithButton instance;

    //En el awake le decimos que si hay alguna activa, lo destruya.

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy (this);
        }
    }
    void Start() 
    {
        //Bucle entre pantallas, reinicia el contador.

        contador = 0f;
        pantalla1.SetActive(true);
        pantalla2.SetActive(false);
        pantalla3.SetActive(false);
        pantalla4.SetActive(false);
        pantalla5.SetActive(false);
        pantalla6.SetActive(false);
        pantalla7.SetActive(false);
        pantalla8.SetActive(false);
    }

    void Update()

    {   
        //Contador de tiempo mientras el juego esté en funcionamiento

        contador += Time.deltaTime;
       

        //Presionar tecla espacio para saltar pantallas.

        if (Input.GetKeyUp(KeyCode.Space) && pantalla3.gameObject.activeSelf == false)
        {
            pantalla1.SetActive(false);
            pantalla2.SetActive(true);
        }

        //Cuenta atrás para el salto de pantalla, si llega a cuentaAtras, salta a pantalla2.

        if (cuentaAtras >= 34f && cuentaAtras < 36f)
        { 
            pantalla1.SetActive(false);
            pantalla2.SetActive(true);
        }
        
      
       
        //Saltar a la tercera pantalla presionando espacio


        if (pantalla2.gameObject.activeSelf == true && Input.GetKeyDown(KeyCode.Space))
        {
            pantalla2.SetActive(false);
            pantalla3.SetActive(true);
        } 
       
    }

    // crear multiples pantallas
       
    public void NextScreen()
    {
    currentScreen.SetActive(false);
    nextScreen.SetActive(true);
    }

     
}

