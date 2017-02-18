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

        tower = (GameObject)Instantiate(towerList[towerIndex], transform.position, Quaternion.identity);
        gameManager.Gold -= tower.GetComponent<TowerData>().CurrentLevel.cost;

        Destroy(gameObject);
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
