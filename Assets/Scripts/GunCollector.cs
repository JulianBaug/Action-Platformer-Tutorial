using System;
using UnityEngine;

public class GunCollector : MonoBehaviour
{
    public bool gunCollected = false;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gun") == false)
        {
            return;
        }

        gunCollected = true;


        other.gameObject.SetActive(false);
    }
}