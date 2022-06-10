using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{
    public float speed;
    public float heat;
    float nextShoot;
    public int disparo;

    public Spaceshipdata data;
    public GameObject projectilPrefab;
    Vector3 lookDirection = new Vector3(0, 1, 0);
    [SerializeField]
    Quaternion rotation;
    public static ShipController instance;

    private void Start()
    {
       
    }
    //carga la escena y la nave, junto con sus caracteristicas
    void Awake()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("EscenaJuego"))
        {
            gameObject.SetActive(true);
            data = GameDataPersistent.instance.selectedSpaceship;
            speed = data.speed;
        }
    }

    // actualiza la posicion de la nave en base a la escena y su movimiento
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("EscenaJuego"))
        {
            float horizontal = Input.GetAxis("Horizontal");
            Vector2 position = transform.position;
            position.x = position.x + 0.1f * horizontal * speed;
            transform.position = position;
        }
        //asignamos la tecla para el disparo

        if (nextShoot <= Time.time)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                nextShoot = Time.time + heat;
                Launch();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                nextShoot = Time.time + heat;
                Launch2();
            }
        }
       
    }
    //disparo de la nave
    void Launch()
    {
        GameObject projectilObject = Instantiate(projectilPrefab, GetComponent<Rigidbody>().position + Vector3.up * 12.0f, rotation);

        Projectil projectil = projectilObject.GetComponent<Projectil>();
        projectil.Launch(lookDirection, 5000);
        disparo++;
    }

    void Launch2()
    {
        GameObject projectilObject = Instantiate(projectilPrefab, GetComponent<Rigidbody>().position + Vector3.up * 12.0f, rotation);

        Projectil projectil = projectilObject.GetComponent<Projectil>();
        projectil.isFuerte = true;
        Projectil_fuerte projectil_Fuerte = projectilObject.GetComponent<Projectil_fuerte>();
        projectil_Fuerte.isFuerte = true;
        projectil_Fuerte.Launch2(lookDirection, 5000);
    }
}
