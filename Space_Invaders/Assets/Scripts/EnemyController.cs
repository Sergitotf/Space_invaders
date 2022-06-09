using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    [Serializable]

    public class EnemiesList
    {
        public GameObject[] enemies;
    }
    public EnemiesList[] enemiesLists;
    public int columNumber; // Numero de columnas
    public int[] rowNumber; //Array que almacena el numero de enemigos por cada columna
    public int columsActivated;
    public GameObject projectilePrefab;
    public float shootTimer = 1;
    public GameObject enemigos;
    public GameObject pantalla8;


    public bool spaceToTheR = true;
    public bool spaceToTheL;
    public float movingTimer;
    public float movingTime = 2;
    float speed = 4;

    public static EnemyController instance;

   
    void Awake()
    {
        movingTimer = movingTime * speed;
        if (EnemyController.instance == null)
        {
            EnemyController.instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        columNumber = enemiesLists.Length;

        //rowsDeactivated = enemiesLists.Length; rellena el array, con la cantidad de enemigos que hay en cada columna

        for (int x = 0; x < enemiesLists.Length; x++)
        {
            rowNumber.SetValue(enemiesLists[x].enemies.Length, x);
        }
    }

    public void Disparo()
    {
        for (int x = 0; x < enemiesLists.Length; x++)
        {
            rowNumber.SetValue(enemiesLists[x].enemies.Length, x);
        }
        if (enemiesLists[0].enemies[0])
        {
            Debug.Log("Ultimo en pie");
        }
    }
    
    void Update()
    {
        //Region donde se encuentra el disparo de los aliens.

        #region
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {

            shootTimer = 1;
            bool seHaDisparado = false;

            while (!seHaDisparado)
            {
                columsActivated = 0; //columnas desactivadas
                for (int r = 0; r < rowNumber.Length; r++)
                {
                    columsActivated += rowNumber[r];
                }
                if (columsActivated > 0)
                {
                    seHaDisparado = AlienShoot();
                    //Debug.Log("Se ha disparado " + seHaDisparado);
                }
                else
                {
                    seHaDisparado = true;
                    // mueren todos los alien, añadir la pantalla final aqui.
                   pantalla8.SetActive(true);
                }
            }
        }
        #endregion
        movingTimer -= Time.deltaTime; //Temporizador para el movimiento
        //Comprueba si hay espacio hacia la derecha y se mueve en esa dirección -9.7 a 3.7 = 12 en x
        if (spaceToTheR == true)
        {
            if (movingTimer <= 0)
            {
                enemigos.transform.Translate(Vector3.right * 2);
           
                movingTimer = movingTime;
            }

        }
        if (spaceToTheL == true)
        {
            if (movingTimer <= 0)
            {
                enemigos.transform.Translate(Vector3.left * 2);
                movingTimer = movingTime;
            }
        }
    }
    /// <summary>
    /// Funcion para hacer que el conjunto de aliens dispare. Además devuelve un booleano que indica si hay aliens o no.
    /// </summary>
    /// <returns></returns>
    public bool AlienShoot()
    {
        //Selecciono al azar una de las columnas.

        int colum = UnityEngine.Random.Range(0, enemiesLists.Length);

        //Debug.Log("Se ha escogido la columna " + colum);

        int lastActiveAlien = 0;
        bool hayAliens = true;
        if (rowNumber[colum] > 0)
        {
            //Ahora debo comprobar si en esa columna hay algún enemigo activo y de haberlo cuál es:

            for (int y = 0; y < enemiesLists[colum].enemies.Length; y++)
            {
                if (enemiesLists[colum].enemies[y].activeSelf == false && y == 0)
                {
                    hayAliens = false;
                    rowNumber.SetValue(0, colum);  //rownumber = {alienscolumn0, alienscolumna1, alienscolumna2....}
                    break;
                }
                else if (enemiesLists[colum].enemies[y].activeSelf == true)
                {
                    lastActiveAlien = y;
                    rowNumber.SetValue(lastActiveAlien + 1, colum);
                }
            }
            
            if (hayAliens)
            {
                //Ahora el último activo debe disparar:

                GameObject shooter = enemiesLists[colum].enemies[lastActiveAlien];
                GameObject projectileObject = Instantiate(projectilePrefab, shooter.transform.position + Vector3.down, Quaternion.Euler(0, 0, 0));
                Projectil projectile = projectileObject.GetComponent<Projectil>();
               
            }
                      
        }

        if (rowNumber[colum] == 0)
        {
            hayAliens = false;
        }
        return hayAliens;
    }

    

} 