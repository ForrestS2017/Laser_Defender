using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    public LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger: " + collision.gameObject.name);
        levelManager.LoadLevel("Lose");

    }
}
