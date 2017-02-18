using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotBehavior : MonoBehaviour {

    void OnMouseUp()
    {
        transform.parent.gameObject.GetComponent<PlaceTower>().clickSpot();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
