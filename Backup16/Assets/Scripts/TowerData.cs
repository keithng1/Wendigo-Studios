﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TowerLevel
{
    public int cost;
    public GameObject visualization;
    public GameObject bullet;
    public float fireRate;
}

public class TowerData : MonoBehaviour
{

    public List<TowerLevel> levels;
    private TowerLevel currentLevel;
    private GameManagerBehavior gameManager;

    public TowerLevel CurrentLevel
    {
        get
        {
            return currentLevel;
        }

        set
        {
            currentLevel = value;
            int currentLevelIndex = levels.IndexOf(currentLevel);

            GameObject levelVisualization = levels[currentLevelIndex].visualization;
            print("here");
            for (int i = 0; i < levels.Count; i++)
            {
                if (levelVisualization != null)
                {
                    if (i == currentLevelIndex)
                    {
                        levels[i].visualization.SetActive(true);
                    }
                    else
                    {
                        levels[i].visualization.SetActive(false);
                    }
                }
            }
        }
    }

    public int getSellPrice()
    {
        int index = 0;
        TowerLevel tl = levels[index];
        int cost = tl.cost;
        while(CurrentLevel != tl)
        {
            tl = levels[index];
            cost += tl.cost;
        }
        return cost / 2;
    }

    void OnEnable()
    {
        CurrentLevel = levels[0];
    }

    public TowerLevel getNextLevel()
    {
        int currentLevelIndex = levels.IndexOf(currentLevel);
        int maxLevelIndex = levels.Count - 1;
        if (currentLevelIndex < maxLevelIndex)
        {
            return levels[currentLevelIndex + 1];
        }
        else
        {
            return null;
        }
    }

    public void increaseLevel()
    {
        int currentLevelIndex = levels.IndexOf(currentLevel);
        if (currentLevelIndex < levels.Count - 1)
        {
            CurrentLevel = levels[currentLevelIndex + 1];
        }
    }

    void OnMouseUp()
    {
        //TODO: Upgrade or Destroy tower

        //if chose upgrade
        if (transform.parent.name.Contains("Select"))
        {
            transform.parent.parent.gameObject.GetComponent<PlaceTower>().placeTower(gameObject);
        }
        else
        {
            transform.parent.gameObject.GetComponent<PlaceTower>().showUpgrade();
        }
    }

    public bool canUpgradeMonster()
    {
        TowerLevel nextLevel = getNextLevel();
        if (nextLevel != null && nextLevel.cost <= gameManager.Gold)
        {
            return true;
        }
        return false;
    }

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
