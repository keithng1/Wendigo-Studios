using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpDesBehavior : MonoBehaviour {

    private GameObject node;
    private Vector3 origpos;
    // Use this for initialization

    public void placeTower(GameObject obj)
    {
        node.GetComponent<PlaceTower>().placeTower(obj);
        deactivate();
    }

    public void destroyTower()
    {
        node.GetComponent<PlaceTower>().destroyTower();
        deactivate();
    }

    public void upgradeTower()
    {
        node.GetComponent<PlaceTower>().upgradeTower();
        deactivate();
    }

    public void deactivate()
    {
        print("deac");
        node = null;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        transform.position = origpos;
    }
    public void activate(GameObject nd)
    {
        if (gameObject.name == "Select")
        {
            GameObject.Find("Upgrade").GetComponent<UpDesBehavior>().deactivate();
        }

        if (gameObject.name == "Upgrade")
        {
            GameObject.Find("Select").GetComponent<UpDesBehavior>().deactivate();
        }
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
        origpos = transform.position;
    }
    

    // Update is called once per frame
    void Update ()
    {
        EventSystem eventSystem = EventSystem.current;
        if (Input.GetMouseButtonDown(0))
        {
            if (!eventSystem.IsPointerOverGameObject()) { 
                deactivate();
            }
            
        }
    }
}
