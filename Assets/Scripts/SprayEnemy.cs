using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayEnemy : MonoBehaviour {

    public List<GameObject> enemiesInRange;
    private float lastShotTime;
    private TowerData towerData;

    private bool firstShot;
    private SprayBehavior spray;
	private SpriteRenderer[] spriteRenderers;
	[SerializeField] private Sprite idle;
	[SerializeField] private Sprite attack;

    void OnEnemyDestroy(GameObject enemy)
    {
        print("remove");
        enemiesInRange.Remove(enemy);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
            EnemyDestructionDelegate del =
                other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
            EnemyDestructionDelegate del =
                other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate -= OnEnemyDestroy;
        }
    }

    void Spray()
    {
		foreach (SpriteRenderer renderer in spriteRenderers) {
			if (renderer.transform.parent != null) {
				Debug.Log ("Change sprite");
				renderer.sprite = attack;
			}
		}
        GameObject bulletPrefab = towerData.CurrentLevel.bullet;
        // 1 
		Vector3 startPosition = gameObject.transform.Find("Spray Spawn").transform.position;
        startPosition.z = bulletPrefab.transform.position.z;

        // 2 
        GameObject newBullet = (GameObject)Instantiate(bulletPrefab);
        newBullet.transform.position = startPosition;
        SprayBehavior bulletComp = newBullet.GetComponent<SprayBehavior>();
        spray = bulletComp;
        bulletComp.target.Add(enemiesInRange[0]);

        // 3 
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
    }

    // Use this for initialization
    void Start()
    {
        enemiesInRange = new List<GameObject>();
        lastShotTime = Time.time;
        towerData = gameObject.GetComponentInChildren<TowerData>();
        firstShot = true;
		spriteRenderers = this.transform.GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		spriteRenderers = this.transform.GetComponentsInChildren<SpriteRenderer>();
		if (enemiesInRange.Count > 0) {
			if (spray == null) {
				foreach (SpriteRenderer renderer in spriteRenderers) {
					if (renderer.transform.parent != null) {
						renderer.sprite = idle;
					}
				}
			}
			if (spray == null && (firstShot || Time.time - lastShotTime > towerData.CurrentLevel.fireRate)) {
				
				firstShot = false;
				Spray ();
				lastShotTime = Time.time;
			}
			// 3
            

		} else if (enemiesInRange.Count <= 0) {
			foreach (SpriteRenderer renderer in spriteRenderers) {
				if (renderer.transform.parent != null) {
					renderer.sprite = idle;
				}
			}
		}
    }
}
