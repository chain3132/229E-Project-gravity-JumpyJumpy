using System;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.pickup);
            GameManager.instance.SetKey();
            Destroy(gameObject);
        }
        
    }
}
