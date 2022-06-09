using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
   // public GameObject navePosition;
    // Carga la instancia gamedatapersistant al iniciar el juego
    void Awake()
    {
       
        GameObject nave = Instantiate(GameDataPersistent.instance.selectedSpaceship.prefab);
        nave.SetActive(true);
        nave.transform.localScale *= 0.04f;
        nave.transform.parent = transform;
        nave.transform.position = (new Vector3(0, -50, 0));
        Animator animator = nave.GetComponent<Animator>();
         Destroy(animator);
        // nave.transform.rotation = Quaternion.Euler(0, 0,180);
        
    }
}
