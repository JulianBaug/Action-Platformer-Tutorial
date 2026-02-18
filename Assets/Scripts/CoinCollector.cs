using System;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int totalCoinCollected = 0;
    public LabeledIntUI ui;

    private void Start()
    {
        if (ui != null)
        {
            ui.SetValue2(totalCoinCollected);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin") == false)
        {
            return;
        }

        totalCoinCollected += 1;

        if (ui != null)
        {
            ui.SetValue2(totalCoinCollected);
        }

        other.gameObject.SetActive(false);
    }
}