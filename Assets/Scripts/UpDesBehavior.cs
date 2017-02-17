using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpDesBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //RaycastHit hit = new RaycastHit();
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            int children = gameObject.transform.childCount;
            bool stat = false;
            for( int j=0; j<children; j++)
            {
                if(EventSystem.current.currentSelectedGameObject == gameObject.transform.GetChild(j))
                {
                    stat = true;
                    print("yezz");
                }
            }
            if (stat == false)
            {
                print("222");
            }
            //if(EventSystem.current.currentSelectedGameObject!=gameObject.transform.GetChild(0) && EventSystem.current.currentSelectedGameObject != gameObject.transform.GetChild(1))
            //{
            //    gameObject.SetActive(false)
            //}
            //print("222");
            //if (Physics.Raycast(ray, out hit))
            //{
            //    print("111");
            //    if (hit.collider.gameObject == this.gameObject)
            //    {
            //    }
            //}
            //else
            //{
            //    gameObject.SetActive(false);
            //}
        }
    }
}
