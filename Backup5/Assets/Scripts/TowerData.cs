using System.Collections;
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

public class TowerData : MonoBehaviour {

    public List<TowerLevel> levels;
    private TowerLevel currentLevel;

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
            if(currentLevelIndex > 0) levels[currentLevelIndex-1].visualization.SetActive(false);
            levels[currentLevelIndex].visualization.SetActive(true);
        }
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

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
