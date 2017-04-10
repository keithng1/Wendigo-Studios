using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockBehavior : MonoBehaviour {

    public float duration = 2;
    public int damage;
    public  List<GameObject> target;

    private float startTime;
    private GameManagerBehavior gameManager;

    void OnEnemyDestroy(GameObject enemy)
    {
        print("destroy");
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
    void Start ()
    {
        startTime = Time.time;
        GameObject gm = GameObject.Find("GameManager");
        gameManager = gm.GetComponent<GameManagerBehavior>();
    }

	// Update is called once per frame
	void Update () {
        // 1 

        if (Time.time - startTime < duration)
        {
            for (int i = 0; i < target.Count; i++)
            {
                if (target[i] != null)
                {
                    target[i].GetComponent<MoveEnemy>().setShock(true);
                    // 3
                    Transform healthBarTransform = target[i].transform.FindChild("HealthBar");
                    HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
                    healthBar.currentHealth -= Mathf.Max(damage, 0);
                    // 4
                    if (healthBar.currentHealth <= 0)
                    {
                        Destroy(target[i]);
                        AudioSource audioSource = target[i].GetComponent<AudioSource>();
                        AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);

                      gameManager.Gold += 50;
                    }
                }

            }
        }
        else
        {
            for (int i = 0; i < target.Count; i++)
            {
                if (target[i] != null)
                {
                    target[i].GetComponent<MoveEnemy>().setShock(false);
                }
            }
            Destroy(gameObject);
        }
    }
}
