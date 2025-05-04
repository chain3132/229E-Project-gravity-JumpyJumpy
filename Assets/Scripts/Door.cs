using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private string levelName;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.instance.GetKey())
            {
                AudioManager.instance.PlaySFX(AudioManager.instance.unlock);
                SceneManager.LoadScene(levelName);
            }
        }
        
        
        
    }
}
