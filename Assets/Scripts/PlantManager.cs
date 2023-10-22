using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public GameObject plant;
    public Dictionary<Vector2, GameObject> instantiatedPlants = new Dictionary<Vector2, GameObject>();
    public int seedsAmount = 8;

    public static PlantManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {

    }
    public void InstantiatePlant (Vector2 pos)
    {
        if (seedsAmount <= 0) return;
        if (instantiatedPlants.ContainsKey(pos)) return;

        GameObject newPlant = Instantiate(plant, pos, Quaternion.identity);
        instantiatedPlants.Add(pos, newPlant);
        seedsAmount--;
    }
}
