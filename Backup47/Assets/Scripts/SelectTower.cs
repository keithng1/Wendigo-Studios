using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectTower : MonoBehaviour, IPointerClickHandler
{

    public GameObject towerPrefab;

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.parent.gameObject.GetComponent<UpDesBehavior>().placeTower(towerPrefab);
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
