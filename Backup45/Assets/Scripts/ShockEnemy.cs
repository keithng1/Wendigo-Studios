using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockEnemy : MonoBehaviour {

    public List<GameObject> enemiesInRange;
    private float lastShotTime;
    private TowerData towerData;

    private bool firstShot;
    private ShockBehavior shock;
    // 1
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // 2
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
        }
    }
    // 3
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }

    void Shock()
    {
        print("Shock");
        GameObject bulletPrefab = towerData.CurrentLevel.bullet;
        // 1 
        Vector3 startPosition = gameObject.transform.position;
        startPosition.z = bulletPrefab.transform.position.z;

        // 2 
        GameObject newBullet = (GameObject)Instantiate(bulletPrefab);
        newBullet.transform.position = startPosition;
        ShockBehavior bulletComp = newBullet.GetComponent<ShockBehavior>();
        shock = bulletComp;
        bulletComp.target = enemiesInRange;

        // 3 
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
    }
    // Use this for initialization
    void Start () {
        enemiesInRange = new List<GameObject>();
        lastShotTime = Time.time;
        towerData = gameObject.GetComponentInChildren<TowerData>();
        firstShot = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (enemiesInRange.Count >0)
        {
            if(shock== null) { 

                if (firstShot || Time.time - lastShotTime > towerData.CurrentLevel.fireRate)
                {
                    firstShot = false;
                    Shock();
                    lastShotTime = Time.time;
                }
            }
        }
    }
}
