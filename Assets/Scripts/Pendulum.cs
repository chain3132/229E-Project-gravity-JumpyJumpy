using System;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public float initialForce = 100f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.AddForce(Vector2.right * initialForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.hit);

        }
    }
}
