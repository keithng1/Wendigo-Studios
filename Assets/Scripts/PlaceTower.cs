using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceTower : MonoBehaviour
{
    public List<GameObject> towerList;
    private GameObject tower;
    private GameManagerBehavior gameManager;

    public void clickOutside()
    {
        transform.Find("Upgrade").gameObject.SetActive(false);
        transform.Find("Select").gameObject.SetActive(false);
    }
    public void showUpgrade()
    {
        GameObject upgrade = transform.Find("Upgrade").gameObject;
        if (tower.GetComponent<TowerData>().getNextLevel() != null)
        {
            upgrade.transform.Find("Up Price").GetComponent<TextMesh>().text = "-$" + tower.GetComponent<TowerData>().getNextLevel().cost;
            upgrade.transform.Find("Sell Price").GetComponent<TextMesh>().text = "+$" + tower.GetComponent<TowerData>().getSellPrice();
        }
        else
        {
            upgrade.transform.Find("Sell Price").GetComponent<TextMesh>().text = "+$" + tower.GetComponent<TowerData>().getSellPrice();
            upgrade.transform.Find("upgrade").gameObject.SetActive(false);
            upgrade.transform.Find("Up Price").gameObject.SetActive(false);
        }
        upgrade.SetActive(true);
    }

    public void upgradeTower()
    {
        if (tower.GetComponent<TowerData>().canUpgradeMonster())
        {
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);

            gameManager.Gold -= tower.GetComponent<TowerData>().CurrentLevel.cost;
            tower.GetComponent<TowerData>().increaseLevel();
            transform.Find("Upgrade").gameObject.SetActive(false);

        }

    }


    public void destroyTower()
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
        
        gameManager.Gold += tower.GetComponent<TowerData>().getSellPrice();
        transform.Find("Spot").gameObject.SetActive(true);

        GameObject upgrade = transform.Find("Upgrade").gameObject;
        upgrade.transform.Find("upgrade").gameObject.SetActive(true);
        upgrade.transform.Find("Up Price").gameObject.SetActive(true);

        Destroy(tower);
        upgrade.gameObject.SetActive(false);
    }

    public void clickSpot()
    {
        transform.Find("Select").gameObject.SetActive(true);
    }

    public void placeTower(GameObject obj)
    {
        Vector3 temp = obj.transform.localScale;
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);

        GameObject spot = transform.Find("Spot").gameObject;
        GameObject select = transform.Find("Select").gameObject;
        tower = (GameObject)Instantiate(obj, transform.position, Quaternion.identity);
        tower.transform.parent = transform;
        tower.transform.localScale = temp;
        gameManager.Gold -= tower.GetComponent<TowerData>().CurrentLevel.cost;
        spot.SetActive(false);
        select.SetActive(false);

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
