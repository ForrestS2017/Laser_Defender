using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    private int timesHit;
    private LevelManager levelManager;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    bool isBreakable;

    // Use this for initialization
    void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        isBreakable = (this.tag == "Breakable");
        if(isBreakable) breakableCount++;
        print("Bricks:" + breakableCount);

        timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isBreakable = (this.tag == "Breakable");
        if (isBreakable) HandleHits();
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }

    void HandleHits()
    {
        int maxHits = hitSprites.Length + 1;
        timesHit++;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
