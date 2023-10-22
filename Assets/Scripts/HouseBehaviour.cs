using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HouseBehaviour : MonoBehaviour
{
    public float speed = .01f;
    public int lifePoints;
    public int initialLifePoints;
    private SpriteRenderer spriteRenderer;

    [Serializable]
    public struct AAA
    {
        public float lessThan;
        public Sprite sprite;
        public UnityEvent whenReached;
    }

    public List<AAA> stagesTest = new List<AAA>();
    private int currentStage = -1;

    private void Start()
    {
        lifePoints = initialLifePoints;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < stagesTest.Count; i++)
        {
            Debug.Log(currentStage);
            if (currentStage != i && (initialLifePoints - lifePoints) >= stagesTest[i].lessThan)
            {
                currentStage = i;
                spriteRenderer.sprite = stagesTest[i].sprite;
                break;
            }
        }
    }

    public void OnDead()
    {
        Destroy(gameObject);
        GameManager.instance.OnGameOver(); 
    }

    public void TakeDamage(int amount)
    {
        if (lifePoints <= 0) { return; }

        lifePoints -= amount;

        if (lifePoints <= 0) { OnDead(); }

    }
}
