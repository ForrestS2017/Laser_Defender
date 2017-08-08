using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float speed = 10f;
    public float spawnDelay = 0.5f;
    float xmin = 0f;
    float xmax = 0f;
    private float padding = 5;

	// Use this for initialization
	void Start ()
    {
        SpawnUntilFull();

        GetCameraEdges();
    }

    private void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }

    private void SpawnUntilFull()
    {
        Transform FreePosition = NextFreePosition();
        if(FreePosition)
        {
            GameObject enemy = Instantiate(enemyPrefab, FreePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = FreePosition;
        }
        if (NextFreePosition())
        {
            Invoke("SpawnUntilFull", spawnDelay);
        }
    }

    private void GetCameraEdges()
    {
        float cameraDistance = transform.position.z - Camera.main.transform.position.z;
        Vector3 topleft = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, cameraDistance));  //this takes relative values. so 0.5 if the mouse is in the middle
        Vector3 bottomright = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, cameraDistance));
        xmin = topleft.x + padding; print(xmax);
        xmax = bottomright.x - padding; print(xmin);
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height,0));
    }

	// Update is called once per frame
	void Update () {
        if (transform.position.x < xmin)
        {
            speed *= -1;
            transform.position += Vector3.right * 0.1f;
        }
        if (transform.position.x >= xmax)
        {
            speed *= -1;
            transform.position += Vector3.left * 0.1f;
        } 
        float x =  speed * Time.deltaTime;
        float y =  speed * (0.5f*Mathf.Sin(Time.time * speed)) * Time.deltaTime;
        Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position += new Vector3(x, y, transform.position.z);


        if (AllMembersDead())
        {
            print("ENEMIES KILLED");
            SpawnUntilFull();
        }
    }

    Transform NextFreePosition()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount <= 0)
            {
                return childPositionGameObject;
            }
        }
        return null;
    }

    private bool AllMembersDead()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }
}
