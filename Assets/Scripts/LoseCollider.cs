using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        print("Trigger: " + collision.gameObject.name);
        levelManager.LoadLevel("Lose");

    }
}
