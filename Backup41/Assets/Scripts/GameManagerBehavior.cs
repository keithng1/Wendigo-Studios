using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManagerBehavior : MonoBehaviour {
    public Text goldLabel;
    public Text waveLabel;
    private int wave;
    private int gold;
    private int health;
    public bool gameOver = false;

    public List<GameObject> paths;
    private int finishNum;

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            //healthLabel.text = "HEALTH: " + health;

            if (health <= 0 && !gameOver)
            {
                gameOver = true;
            }
        }
    }


    public int Wave
    {
        get { return wave; }
        set
        {
            wave = value;
            if (!gameOver)
            {  
                waveLabel.text = "Wave: " + (wave + 1) +"/7";
            }
        }
    }

    public int Gold
    {
        get { return gold; }
        set
        {
            gold = value;
            goldLabel.GetComponent<Text>().text = "$ " + gold;
        }
    }

    public void finish()
    {
        finishNum++;
        if(finishNum == paths.Count)
        {
            finishNum = 0;
            Wave++;
            Gold = Mathf.RoundToInt(Gold * 1.1f);
        }
    }
    // Use this for initialization
    void Start () {
		Gold = 1000;
        Wave = 0;
        Health = 5;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
