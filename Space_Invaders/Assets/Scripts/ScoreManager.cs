using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI scoretextgame;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI highscoreTextgame;
    public int score = 0;
    public int highscore = 0;
    public int extrahit = 0;

    private void Awake()
    {
        instance = this;
    }
    //carga las puntuaciones maximas al iniciar en la pantalla de juego y la final
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoretext.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
        scoretextgame.text = score.ToString() + " POINTS";
        highscoreTextgame.text = "HIGHSCORE: " + highscore.ToString();
    }
    //añadir puntos al dar un tiro, actualiza la puntuación maxima
    public void AddPoint()
    {
        score += 20;
        scoretext.text = score.ToString() + extrahit + " POINTS";
        scoretextgame.text = score.ToString() + " POINTS";
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
        highscoreTextgame.text = "HIGHSCORE: " + highscore.ToString();

    }
    //resetea la puntuacion en la pantalla de juego
    public void ResetGame()
    {
        scoretextgame.text = score.ToString() + "POINTS" + -50f;

        Debug.Log("no resta");
    }
    /*
    public void Racha()
    {
        ScoreManager.instance.AddPoint()

    }
    */
}
