using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    public List<GameObject> towerList;
    private GameObject tower;
    private GameManagerBehavior gameManager;

    void OnMouseUp()
    {
        int towerIndex = 0;

        //TODO: Perform tower select
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);

        tower = (GameObject)Instantiate(towerList[1], transform.position, Quaternion.identity);
        gameManager.Gold -= tower.GetComponent<TowerData>().CurrentLevel.cost;

        Destroy(gameObject);
    }

    void clickSpot()
    {
        GameObject select = transform.Find("Select").gameObject;
        select.SetActive(true);
        GameObject spot = transform.Find("Spot").gameObject;

    }

    void placeTower(GameObject obj)
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);

        GameObject spot = transform.Find("Spot").gameObject;
        tower = (GameObject)Instantiate(obj, transform.position, Quaternion.identity);
        tower.transform.parent = transform;
        gameManager.Gold -= tower.GetComponent<TowerData>().CurrentLevel.cost;
        spot.SetActive(false);

    }

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
