using System;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
    [SerializeField] private Transform savePosition;

    private void Update()
    {
        savePosition = GameManager.instance.GetSpawnPoint();
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        var gameObjectRB = other.GetComponent<Rigidbody2D>();
        gameObjectRB.position = savePosition.position;
        gameObjectRB.linearVelocity = Vector2.zero;
    }
}
