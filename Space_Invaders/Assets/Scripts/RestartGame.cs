using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    
    //asignamos el reseteo de la partida al boton
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    //reseteamos el juego por completo
    public void ResetAll()
    {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex);

    }
}
