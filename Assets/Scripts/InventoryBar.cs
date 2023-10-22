using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InventoryBar : MonoBehaviour
{
    [SerializeField]
    private int slotsAmmount = 5;

    [SerializeField]
    private GameObject slotPrefab;

    [SerializeField]
    private HorizontalLayoutGroup slotHolder;

    [SerializeField]
    private List<SlotController> slots = new List<SlotController>();

    void Start()
    {
        LoadSlots();
    }

    private void Update()
    {
        HandleKeyboardSelection();
        HandleMouseSelection();
    }

    private void LoadSlots()
    {
        for (int i = 0; i < slotsAmmount; i++)
        {
            CreateSlot(i + 1);
        }
        slotHolder.CalculateLayoutInputHorizontal();
        slotHolder.SetLayoutHorizontal();
        slotHolder.SetLayoutVertical();
    }

    private void CreateSlot(int number)
    {
        GameObject slot = Instantiate(slotPrefab);

        // definindo HorizontalLayoutGroup como pai do slot
        slot.transform.SetParent(slotHolder.transform);

        // slot deve ter um RectTransform para que o HorizontalLayoutGroup do slotHolder possa controlar
        RectTransform rectTransform = slot.GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            rectTransform = slot.AddComponent<RectTransform>();
        }

        // ajuste do tamanho e posição do slot
        rectTransform.sizeDelta = new Vector2(60, 60);
        rectTransform.anchoredPosition = Vector2.zero;
        rectTransform.localScale = Vector2.one;

        // atualiza o número do slot
        slot.GetComponent<SlotController>().SlotNumber = number;
        slots.Add(slot.GetComponent<SlotController>());
    }

    private void HandleKeyboardSelection()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectSlot(4);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectSlot(5);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SelectSlot(6);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SelectSlot(7);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SelectSlot(8);
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SelectSlot(9);

        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SelectSlot(0);
        }

    }
    
    private void SelectSlot(int slotNumber)
    {
        slots.ForEach(slot => slot.IsSelected = slot.SlotNumber == slotNumber);
    }

    private void HandleMouseSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast a partir do mouse para determinar o objeto clicado.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Verifique se o objeto clicado é um slot do inventário.
                SlotController slot = hit.collider.GetComponent<SlotController>();

                if (slot != null)
                {
                    // Slot do inventário clicado. Atualize o slot selecionado.

                    Debug.Log("Slot " + (slot.SlotNumber) + " selecionado.");
                }


            }
        }

    }
}
