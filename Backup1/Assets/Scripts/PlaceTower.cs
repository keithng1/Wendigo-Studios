using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour {

    public GameObject towerPrefab;
    private GameObject monster;
    //private GameManagerBehavior gameManager;

    // Use this for initialization
    void Start () {
        if (canPlaceMonster())
        {
            monster = (GameObject)Instantiate(towerPrefab, transform.position, Quaternion.identity);

            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);

            gameManager.Gold -= monster.GetComponent<MonsterData>().CurrentLevel.cost;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
