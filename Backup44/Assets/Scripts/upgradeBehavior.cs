﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeBehavior : MonoBehaviour {

    void OnMouseUp()
    {
        transform.parent.gameObject.GetComponent<UpDesBehavior>().upgradeTower();
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

}
