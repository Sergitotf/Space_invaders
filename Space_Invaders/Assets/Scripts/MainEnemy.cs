using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnemy : MonoBehaviour
{
    public GameObject Enemigo1;
    public float cuentaAtras;
    
    //Asignamos un rango al empezar su movimiento
    void Awake()
    {
        
        cuentaAtras = Random.Range (10f, 30f);

        
    }

    //activamos que tras la cuenta atras, la nave principal se mueva hacia la derecha
    void Update()
    {
         cuentaAtras -= Time.deltaTime;
        
         if (cuentaAtras <= 0.0f)
         {

            Enemigo1.transform.Translate(Vector3.right * 0.05f);
         } 
        
    }
}
