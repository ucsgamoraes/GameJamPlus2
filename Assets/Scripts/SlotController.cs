using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    [SerializeField]
    private bool isSelected = false;

    [SerializeField]
    private Sprite defaultSprite;

    [SerializeField]
    private Sprite selectedSprite;

    [SerializeField]
    private Text slotNumberText;

    [SerializeField]
    private GameObject background;

    private int slotNumber;

    public bool IsSelected
    {
        get { return isSelected; }
        set { isSelected = value; }
    }

    public int SlotNumber
    {
        get { return slotNumber; }
        set 
        { 
            slotNumber = value; 
            slotNumberText.text = slotNumber.ToString();
        }

    }

    void Update()
    {
        HandleSlotSelection();
    }

    private void HandleSlotSelection()
    {
        background.GetComponent<Image>().sprite = isSelected ? selectedSprite : defaultSprite;
    }

}
