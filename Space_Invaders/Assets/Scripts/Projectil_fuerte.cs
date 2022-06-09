using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil_fuerte : MonoBehaviour
{
    public bool isFuerte = false;
   
    // private class SetObjective ;
    void Awake()
    {
       
    }
    //elimina el proyectil cuando pasa de una distancia
    private void Update()
    {
        if (transform.position.magnitude > 200.0f)
        {
            Destroy(gameObject);
        }
    }

    public void Launch2(Vector2 direction, float force)
    {
        Rigidbody nuevorigidbody = GetComponent<Rigidbody>();
        nuevorigidbody.AddForce(direction * force);
    }

    private void OnCollisionEnter(Collision other)
    {

        if (isFuerte)
        {
            other.gameObject.SetActive(false);
           
        }

    }
}
