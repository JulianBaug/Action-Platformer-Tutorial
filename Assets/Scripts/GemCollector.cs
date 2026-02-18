using System;
using UnityEngine;

public class GemCollector : MonoBehaviour
{
    public int totalGemsCollected = 0;
    public LabeledIntUI ui;

    private void Start()
    {
        if (ui != null)
        {
            ui.SetLabel("Gems: ");
            ui.SetValue(totalGemsCollected);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gem") == false)
        {
            return;
        }

        totalGemsCollected += 1;

        if (ui != null)
        {
            ui.SetValue(totalGemsCollected);
        }

        other.gameObject.SetActive(false);
    }
}