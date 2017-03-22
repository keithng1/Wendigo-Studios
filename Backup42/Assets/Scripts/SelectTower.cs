using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTower : MonoBehaviour {

    public GameObject towerPrefab;

    void OnMouseUp()
    {
         transform.parent.parent.gameObject.GetComponent<PlaceTower>().placeTower(towerPrefab);
    }

    // Use this for initialization
    void Start () {
        SpriteRenderer spriterenderer = towerPrefab.GetComponent<TowerData>().levels[0].visualization.GetComponent<SpriteRenderer>();
        gameObject.GetComponent<SpriteRenderer>().sprite = spriterenderer.sprite;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
