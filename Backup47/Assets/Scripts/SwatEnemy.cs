using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatEnemy : MonoBehaviour {

	public List<GameObject> enemiesInRange;
	private float lastShotTime;
	private TowerData towerData;

	private bool firstShot;
	private SwatBehavior swatt;

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

	void Swatt()
	{
		GameObject bulletPrefab = towerData.CurrentLevel.bullet;
		// 1 
		Vector3 startPosition = gameObject.transform.position;
		startPosition.z = bulletPrefab.transform.position.z;

		// 2 
		GameObject newBullet = (GameObject)Instantiate(bulletPrefab);
		newBullet.transform.position = startPosition;
		SwatBehavior bulletComp = newBullet.GetComponent<SwatBehavior>();
		swatt = bulletComp;
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
	}

	// Update is called once per frame
	void Update()
	{
		if (enemiesInRange.Count > 0)
		{
			if (swatt==null && (firstShot || Time.time - lastShotTime > towerData.CurrentLevel.fireRate))
			{
				firstShot = false;
				Swatt();
				lastShotTime = Time.time;
			}
			// 3


		}
	}
}
