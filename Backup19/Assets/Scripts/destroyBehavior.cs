using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBehavior : MonoBehaviour {

    void OnMouseUp()
    {
    }
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {


                if (hit.collider.gameObject == this.gameObject)
                {
                    transform.parent.parent.gameObject.GetComponent<PlaceTower>().destroyTower();
                }
            }
            else
            {
                transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
