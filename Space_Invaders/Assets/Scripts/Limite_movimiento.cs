using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limite_movimiento : MonoBehaviour
{

    
    public int[] posicionEsteAlien = { 0, 0 };
    public void Start()
    {
        for (int x = 0; x < EnemyController.instance.enemiesLists.Length; x++)
        {
            for (int y = 0; y < EnemyController.instance.enemiesLists[x].enemies.Length; y++)
            {
                if (EnemyController.instance.enemiesLists[x].enemies[y] == gameObject)
                {
                    posicionEsteAlien[0] = x;
                    posicionEsteAlien[1] = y; 
                    //verificar. que el elemento que esta comprobando. sea. el objeto que lleva el script
                }
            }
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Barrera")
        {
            EnemyController.instance.spaceToTheL = !EnemyController.instance.spaceToTheL;
            EnemyController.instance.spaceToTheR = !EnemyController.instance.spaceToTheR;
        }
    }


}
