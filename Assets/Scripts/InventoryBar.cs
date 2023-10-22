using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    private SlotController selectedSlot;

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
        SelectSlot(1);
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
    
    private void HandleMouseSelection()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        GraphicRaycaster raycaster = GetComponentInParent<GraphicRaycaster>();
        PointerEventData clickData = new PointerEventData(EventSystem.current);
        List<RaycastResult> clickResults = new List<RaycastResult>(); ;

        clickData.position = Input.mousePosition;
        clickResults.Clear();
        raycaster.Raycast(clickData, clickResults);

        SlotController slot = null;
        foreach (RaycastResult result in clickResults)
        {
            Debug.Log("clicou em: " + result.gameObject.name);
            if (result.gameObject.GetComponentInParent<SlotController>() != null)
            {
                slot = result.gameObject.GetComponentInParent<SlotController>();
                break;
            }
        }

        if (slot == null)
        {
            return;
        }

        SelectSlot(slot.SlotNumber);
    }

    private void SelectSlot(int slotNumber)
    {
        SlotController currentSlot = selectedSlot;
        selectedSlot = null;

        // desativa todos os slots e deixa ativo só clicado
        slots.ForEach(slot => {
            slot.IsSelected = slot.SlotNumber == slotNumber;
            if (slot.IsSelected)
                selectedSlot = slot;
        });

        // caso não exista slot com o número digitado, mantêm o que já tinha
        if (selectedSlot == null)
        {
            selectedSlot = currentSlot;
            selectedSlot.IsSelected = true;
        }

        Debug.Log("Slot selecionado: " + selectedSlot.SlotNumber);
    }
}
