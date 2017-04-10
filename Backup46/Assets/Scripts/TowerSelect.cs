using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelect : MonoBehaviour {

    public GameObject towerSelectMenu;

    bool MouseOnObject  = false;

    private GameObject menu;



 void OnMouseEnter()
    {

        MouseOnObject = true;

    }

    void OnMouseExit()
    {

        MouseOnObject = false;

    }


    void OnMouseDown()
    {

        Vector3 p = transform.position;
        menu = Instantiate(towerSelectMenu, new Vector3(0, 0, 0), Quaternion.identity);
        menu.transform.GetChild(0).gameObject.transform.position = p;
    }



        // Use this for initialization
      void Start () {
        gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {




        if (Input.GetButtonDown("Fire1") && !MouseOnObject)
        {
            Destroy(menu);
        }




    }
}
