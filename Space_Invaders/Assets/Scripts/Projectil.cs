using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    Rigidbody rigidbody;
    public bool isFuerte = false;
    // private class SetObjective ;
  
   
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    //elimina el proyectil cuando pasa de una distancia
    private void Update()
    {
        if (transform.position.magnitude > 200.0f)
        {
            Destroy(gameObject);
        }
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
