using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataPersistent : MonoBehaviour
{
    public Spaceshipdata selectedSpaceship;
    public static GameDataPersistent instance;

    //el game data persistent nos permite cargar la nave, con lo que tenemos que decirle que elimine la última selección guardada.
    void Awake()
    {
        if (GameDataPersistent.instance == null)
        {
            GameDataPersistent.instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

   
}
