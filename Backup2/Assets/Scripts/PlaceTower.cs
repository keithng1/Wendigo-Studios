using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour {

    public GameObject towerPrefab;
    private GameObject tower;
    private GameManagerBehavior gameManager;

    private bool canPlaceMonster()
    {
        //int cost = towerPrefab.GetComponent<TowerData>().levels[0].cost;
        //return tower == null && gameManager.Gold >= cost;
        return tower == null;
    }

    private bool canUpgradeMonster()
    {
        //if (tower != null)
        //{
        //    TowerData towerData = tower.GetComponent<TowerData>();
        //    TowerData nextLevel = towerData.getNextLevel();
        //    if (nextLevel != null && nextLevel.cost <= gameManager.Gold)
        //    {
        //        return true;
        //    }
        //}
        return false;
    }

    void OnMouseUp()
    {
        if (canPlaceMonster())
        {
            tower = (GameObject)Instantiate(towerPrefab, transform.position, Quaternion.identity);

            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);

            //gameManager.Gold -= tower.GetComponent<MonsterData>().CurrentLevel.cost;
        }
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
