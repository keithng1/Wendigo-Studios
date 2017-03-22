using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpDesBehavior : MonoBehaviour {

    private GameObject node;
    // Use this for initialization

    public void placeTower(GameObject obj)
    {
        node.GetComponent<PlaceTower>().placeTower(obj);
        gameObject.SetActive(false);
    }

    public void deactivate()
    {
        node = null;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public void activate(GameObject nd)
    {
        node = nd;
        Vector3 vec = transform.position;
        vec.x = nd.transform.position.x;
        vec.y = nd.transform.position.y;

        transform.position = vec;
        for (int i=0; i<transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    } 
    void Start () {
		
	}
    

    // Update is called once per frame
    void Update () {
    }
}
