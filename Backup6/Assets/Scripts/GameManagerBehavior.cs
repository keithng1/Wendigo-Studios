using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehavior : MonoBehaviour {

    private int wave;
    private int gold;
    private int health;
    public bool gameOver = false;

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
                //waveLabel.text = "WAVE: " + (wave + 1);
            }
        }
    }

    public int Gold
    {
        get { return gold; }
        set
        {
            gold = value;
            //goldLabel.GetComponent<Text>().text = "GOLD: " + gold;
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
