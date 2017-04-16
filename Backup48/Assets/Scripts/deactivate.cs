using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class deactivate : MonoBehaviour, IPointerClickHandler
{

    //public event System.Action onCanvasClicked;

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    if (onCanvasClicked != null)
    //        onCanvasClicked();
    //}
    public void OnPointerClick(PointerEventData eventData)
    {
        print("wew");
        transform.parent.gameObject.GetComponent<UpDesBehavior>().deactivate();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }
}
