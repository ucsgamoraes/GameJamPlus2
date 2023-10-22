using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlantCell : MonoBehaviour
{
    [SerializeField]
    private string plantName;

    [SerializeField]
    private Sprite plantImage;

    [SerializeField]
    private bool locked = false; // remover?

    [SerializeField]
    private Toggle toggle;

    [SerializeField]
    private Text fieldName;

    [SerializeField]
    private Image imageHolder;

    private bool isSelected = false;
    public bool IsSelected
    {
        get => isSelected;
        set => isSelected = value;
    }

    public string PlantName
    {
        get => plantName;
        set
        {
            plantName = value;
            GetComponentInChildren<TextMeshPro>().text = plantName;
        }
    }

    public Sprite PlantImage
    {
        get => plantImage;
        set
        {
            plantImage = value;
            imageHolder.sprite = value;
        }
    }

    void Start()
    {
        fieldName.text = PlantName;
        imageHolder.sprite = PlantImage;
        toggle.isOn = isSelected;
    }

    void Update()
    {
        HandleMouseSelection();
    }

    private void HandleMouseSelection()
    {
        if (!Input.GetMouseButtonDown(0) || locked)
        {
            return;
        }

        GraphicRaycaster raycaster = GetComponentInParent<GraphicRaycaster>();
        PointerEventData clickData = new PointerEventData(EventSystem.current);
        List<RaycastResult> clickResults = new List<RaycastResult>(); ;

        clickData.position = Input.mousePosition;
        clickResults.Clear();
        raycaster.Raycast(clickData, clickResults);

        foreach (RaycastResult result in clickResults)
        {
            if (result.gameObject.GetComponent<PlantCell>() == this)
            {
                IsSelected = !IsSelected;
                toggle.isOn = IsSelected;
                break;
            }
        }

    }
}
