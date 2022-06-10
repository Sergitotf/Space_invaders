using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SpaceShipScreen : MonoBehaviour
{
    public Spaceshipdata[] infoSpaceShip;
    public Slider speedSlider;
    public Slider shieldSlider;
    public Slider heatSlider;
    public TextMeshProUGUI spaceName;
    public int shipActive = 0;
    public GameObject[] ModeloNave;
    public float velocidadSlider = 0.01f;
    
    //valor por defecto de los sliders
    void Start()
    {
        speedSlider.value = 0;
        shieldSlider.value = 0;
        heatSlider.value = 0;
        
    }
    //permite que al iniciar, siempre exista la nave 0 activa.
    public void OnEnable()
    {

        ModeloNave[0].SetActive(true);
        GameDataPersistent.instance.selectedSpaceship = infoSpaceShip[shipActive];
        
    }

    // Permite que cargue la información de la nave y la refleje en los sliders.
    void Update()
    {
        if (shieldSlider.value < infoSpaceShip[shipActive].shield - 0.1)
        {
            shieldSlider.value += Mathf.Lerp(0,infoSpaceShip[shipActive].shield, velocidadSlider);

        }
        if (speedSlider.value < infoSpaceShip[shipActive].speed - 0.1)
        {
            speedSlider.value += Mathf.Lerp(0, infoSpaceShip[shipActive].speed, velocidadSlider);

        }
        if (heatSlider.value < infoSpaceShip[shipActive].heat - 0.1)
        {
            heatSlider.value += Mathf.Lerp(0, infoSpaceShip[shipActive].heat, velocidadSlider);

        }

        if (shieldSlider.value > infoSpaceShip[shipActive].shield + 0.1)
        {
            shieldSlider.value -= Mathf.Lerp(0, infoSpaceShip[shipActive].shield, velocidadSlider);

        }
        if (speedSlider.value > infoSpaceShip[shipActive].speed + 0.1)
        {
            speedSlider.value -= Mathf.Lerp(0, infoSpaceShip[shipActive].speed, velocidadSlider);

        }
        if (heatSlider.value > infoSpaceShip[shipActive].heat + 0.1)
        {
            heatSlider.value -= Mathf.Lerp(0, infoSpaceShip[shipActive].heat, velocidadSlider);

        }
        spaceName.text = infoSpaceShip[shipActive].spaceshipname;

    }
   //selección con botones de las naves siguiente y anterior
    public void SelectNextShip()
    {
        ModeloNave[shipActive].SetActive(false);
        shipActive++;
        if (shipActive > 2)
        {
            shipActive = 0;
        }
        ModeloNave[shipActive].SetActive(true);
          GameDataPersistent.instance.selectedSpaceship = infoSpaceShip[shipActive];
       
    }

    public void SelectfirstShip()
    {
        ModeloNave[shipActive].SetActive(false);
        shipActive--;
        if (shipActive < 0)
        {
            shipActive = 2;
        }
        ModeloNave[shipActive].SetActive(true);
       GameDataPersistent.instance.selectedSpaceship = infoSpaceShip[shipActive];
    }

    public void Jugar()
    {

    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("EscenaJuego");
    }
}
