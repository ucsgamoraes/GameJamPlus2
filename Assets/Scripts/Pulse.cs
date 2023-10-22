using System.Collections;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    public int numberOfToggles = 3;
    public float toggleInterval = 1.0f;

    public GameObject spriteRenderer;
    private Coroutine toggleCoroutine;

    private IEnumerator ToggleSprite()
    {
        for (int i = 0; i < numberOfToggles; i++)
        {
            spriteRenderer.SetActive(!spriteRenderer.activeSelf);
            yield return new WaitForSeconds(toggleInterval);
        }

        spriteRenderer.SetActive(true);
    }

    public void StartToggling()
    {
        if (toggleCoroutine != null)
        {
            StopCoroutine(toggleCoroutine);
        }
        toggleCoroutine = StartCoroutine(ToggleSprite());
    }
}