using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creamos una clase para definir los valores minimo y max de las naves, de cada una de sus caracteristicas.
[CreateAssetMenu(fileName = "Data", menuName = "Spaceship", order = 1)]
public class Spaceshipdata : ScriptableObject
{
    public string spaceshipname;
    [Range(0,3.0f)]
    public float shield = 0;
    [Range(0, 3.0f)]
    public float speed = 0;
    [Range(0, 3.0f)]
    public float heat = 0;

    public GameObject prefab;
    
}