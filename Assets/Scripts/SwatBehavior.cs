using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatBehavior : MonoBehaviour {

	public float duration = 2f;
	public float damage;
	public List<GameObject> target;

	private float startTime;
	private GameManagerBehavior gameManager;

	void OnEnemyDestroy(GameObject enemy)
	{
		print("remove");
		target.Remove(enemy);
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		// 2
		if (other.gameObject.tag.Equals("Enemy"))
		{
			target.Add(other.gameObject);
			EnemyDestructionDelegate del =
				other.gameObject.GetComponent<EnemyDestructionDelegate>();
			del.enemyDelegate += OnEnemyDestroy;
		}
	}
	// 3
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals("Enemy"))
		{
			target.Remove(other.gameObject);
			EnemyDestructionDelegate del =
				other.gameObject.GetComponent<EnemyDestructionDelegate>();
			del.enemyDelegate -= OnEnemyDestroy;
		}
	}



	// Use this for initialization
	void Start()
	{
		startTime = Time.time;
		GameObject gm = GameObject.Find("GameManager");
		gameManager = gm.GetComponent<GameManagerBehavior>();

        print("Here: " + target.Count);
		if (target.Count > 0)
		{
			Vector3 direction = gameObject.transform.position - target[0].transform.position;
            print("DIRECTION: "+direction.y+" "+direction.x);
            if (direction.y > 0)
            {
                transform.rotation = Quaternion.AngleAxis(190,
                new Vector3(0, 0, 1));
            }
			
		}

	}

	// Update is called once per frame
	void Update () {
		if (Time.time - startTime < duration)
		{
			for (int i = 0; i < target.Count; i++)
			{
				if (target[i] != null)
				{
					// 3
					Transform healthBarTransform = target[i].transform.FindChild("HealthBar");
					HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
					healthBar.currentHealth -= Mathf.Max(damage, 0);
					Animator anim = target [i].GetComponent<Animator> ();
					MoveEnemy move = target [i].GetComponent<MoveEnemy> ();
					// 4
					if (healthBar.currentHealth <= 0)
					{
						anim.SetBool ("isDead", true);
						move.setDead (true);
						AudioSource audioSource = target[i].GetComponent<AudioSource>();
						AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
						Destroy(target[i], 2f);

						gameManager.Gold += 30;
					}
				}

			}

		}
		else
		{

			Destroy(gameObject);
		}
	}
}
