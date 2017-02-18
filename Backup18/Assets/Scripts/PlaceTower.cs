using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceTower : MonoBehaviour
{
    public List<GameObject> towerList;
    private GameObject tower;
    private GameManagerBehavior gameManager;
    public GameObject upgradePrefab;
    public GameObject selectPrefab;
    private GameObject upgrade;
    private GameObject select;

    public void showUpgrade()
    {
        if (upgrade == null)
        {
            upgrade = (GameObject)Instantiate(upgradePrefab, transform.position, Quaternion.identity);
            upgrade.transform.Find("Up Price").GetComponent<TextMesh>().text = "-$" + tower.GetComponent<TowerData>().getNextLevel().cost;
            upgrade.transform.Find("Sell Price").GetComponent<TextMesh>().text = "+$" + tower.GetComponent<TowerData>().getSellPrice();

        }
    }

    public void upgradeTower()
    {
        if (tower.GetComponent<TowerData>().canUpgradeMonster())
        {
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);
        
            GameObject upgrade = transform.Find("Upgrade(Clone)").gameObject;
            tower.GetComponent<TowerData>().increaseLevel();
            gameManager.Gold -= tower.GetComponent<TowerData>().CurrentLevel.cost;

            Destroy(upgrade);
        }
        
    }


    public void destroyTower()
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
        
        gameManager.Gold += tower.GetComponent<TowerData>().getSellPrice();
        Destroy(tower);
        transform.Find("Spot").gameObject.SetActive(true);

        Destroy(upgrade);
    }

    public void clickSpot()
    {
        if (select == null)
        {

            select = (GameObject)Instantiate(selectPrefab, transform.position, Quaternion.identity);
            select.transform.parent = transform;
        }
    }

    public void placeTower(GameObject obj)
    {
        Vector3 temp = obj.transform.localScale;
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);

        GameObject spot = transform.Find("Spot").gameObject;
        GameObject select = transform.Find("Select(Clone)").gameObject;
        tower = (GameObject)Instantiate(obj, transform.position, Quaternion.identity);
        tower.transform.parent = transform;
        tower.transform.localScale = temp;
        gameManager.Gold -= tower.GetComponent<TowerData>().CurrentLevel.cost;
        spot.SetActive(false);
        Destroy(select);

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
