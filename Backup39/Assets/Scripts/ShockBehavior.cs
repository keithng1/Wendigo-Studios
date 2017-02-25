using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockBehavior : MonoBehaviour {

    public float duration = 3;
    public int damage;
    public  List<GameObject> target;

    private float startTime;

    // Use this for initialization
    void Start () {
		
	}
	
    public void addTarget(GameObject obj)
    {
        startTime = Time.time;
        target.Add(obj);
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
                    //Transform healthBarTransform = target.transform.FindChild("HealthBar");
                    //HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
                    //healthBar.currentHealth -= Mathf.Max(damage, 0);
                    // 4
                    //if (healthBar.currentHealth <= 0)
                    //{
                    //    Destroy(target);
                    //    AudioSource audioSource = target.GetComponent<AudioSource>();
                    //    AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);

                    //    gameManager.Gold += 50;
                    //}
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
