using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpDesBehavior : MonoBehaviour {


    bool MouseOnObject = false;

    // Use this for initialization
    void Start () {
		
	}

    void OnMouseOver()
    {

        MouseOnObject = true;

    }

    void OnMouseEnter()
    {

        MouseOnObject = true;

    }

    void OnMouseExit()
    {

        MouseOnObject = false;

    }

    // Update is called once per frame
    void Update () {
        print(MouseOnObject);
        if (Input.GetButtonDown("Fire1") && !MouseOnObject)
        {
            gameObject.SetActive(false);
        }
    }
}
