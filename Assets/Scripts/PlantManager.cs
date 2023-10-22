using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlantManager : MonoBehaviour
{
    public GameObject plant;
    public Dictionary<Vector2, GameObject> instantiatedPlants = new Dictionary<Vector2, GameObject>();

    public AudioClip digSound;
    private AudioSource audioSource;
    public int seedsAmount = 8;
    public TMPro.TextMeshProUGUI textMeshPro;

    public static PlantManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateText();
    }

    private void UpdateText()
    {
        textMeshPro.text = "Seeds: " + seedsAmount.ToString();
    }

    public void InstantiatePlant (Vector2 pos)
    {
        if (seedsAmount <= 0) return;
        if (instantiatedPlants.ContainsKey(pos)) return;

        GameObject newPlant = Instantiate(plant, pos, Quaternion.identity);
        audioSource.PlayOneShot(digSound);

        instantiatedPlants.Add(pos, newPlant);

        seedsAmount--;
        UpdateText();
    }
}
