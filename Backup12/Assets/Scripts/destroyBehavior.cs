﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBehavior : MonoBehaviour {

    void OnMouseUp()
    {
        transform.parent.parent.gameObject.GetComponent<PlaceTower>().destroyTower();
    }
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
