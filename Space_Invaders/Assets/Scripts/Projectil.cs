using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Projectil : MonoBehaviour
{
    Rigidbody rigidbody;
    public bool isFuerte = false;
    public int acierto;
    
    public int porcentaje;
    public TextMeshProUGUI porcentajeAcierto;
    

    

    // private class SetObjective ;

    private void Start()
    {
        
    }
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    //elimina el proyectil cuando pasa de una distancia
   public void Update()
    {
        if (transform.position.magnitude > 200.0f)
        {
            Destroy(gameObject);
            
        }

        porcentajeAcierto.text = "el % de acierto es :" + (acierto / ShipController.instance.disparo);
    }
    //fuerza el movimiento de la bala en la dirección que tiene.
    public void Launch(Vector2 direction, float force)
    {
        rigidbody.AddForce(direction * force);
        
        
    }
    // destruye los objetivos con los que choca.
    private void OnTriggerEnter(Collider other)
    {
      
        
        if (!isFuerte)
        {
            other.gameObject.SetActive(false);

            Destroy(gameObject);
            acierto++;
            
        }

        if(isFuerte)
        {
            Limite_movimiento elScriptLlevaAlien = other.GetComponent<Limite_movimiento>();
            if(elScriptLlevaAlien.posicionEsteAlien[1] == 0)
            {
                Destroy(gameObject);
            }
            other.gameObject.SetActive(false);
        }
    }
   
    

}
