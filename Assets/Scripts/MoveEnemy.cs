using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour {

    [HideInInspector]
    public GameObject[] waypoints;
    private int currentWaypoint = 0;
    private float lastWaypointSwitchTime;
    public float speed = 1.0f;

    private bool shocked = false;
    private float shockTime = 0;
    private float lastShock = 0;
	private bool isDead = false;

    private float lastPoison = 0;
    private bool poisoned = false;


    public float distanceToGoal()
    {
        float distance = 0;
        distance += Vector3.Distance(
            gameObject.transform.position,
            waypoints[currentWaypoint + 1].transform.position);
        for (int i = currentWaypoint + 1; i < waypoints.Length - 1; i++)
        {
            Vector3 startPosition = waypoints[i].transform.position;
            Vector3 endPosition = waypoints[i + 1].transform.position;
            distance += Vector3.Distance(startPosition, endPosition);
        }
        return distance;
    }

    private void RotateIntoMoveDirection()
    {
        //1
        Vector3 newStartPosition = waypoints[currentWaypoint].transform.position;
        Vector3 newEndPosition = waypoints[currentWaypoint + 1].transform.position;
        Vector3 newDirection = (newEndPosition - newStartPosition);
        //2
        float x = newDirection.x;
        float y = newDirection.y;
        float rotationAngle = Mathf.Atan2(y, x) * 180 / Mathf.PI;
        //3
        GameObject sprite = (GameObject)
            gameObject.transform.FindChild("Sprite").gameObject;
        sprite.transform.rotation =
            Quaternion.AngleAxis(rotationAngle, Vector3.forward);
    }

    public void setPoison(bool status)
    {
        if (status) lastPoison = Time.time;
        poisoned = status;
    }

    public void setShock(bool status)
    {
        if (status) lastShock = Time.time;
        shocked = status;
    }

	public void slowDown(){
	
	}

	public void setDead(bool status){
		isDead = status;
	}

	public bool getDead(){
		return isDead;
	}

    // Use this for initialization
    void Start () {
        transform.position = waypoints[0].transform.position;
        lastWaypointSwitchTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {

        GameManagerBehavior gameManager =
            GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
        Animator anim = gameObject.GetComponent<Animator>();
        
		if (!isDead) {
            if (poisoned)
            {
                Transform healthBarTransform = transform.FindChild("HealthBar");
                HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
                healthBar.currentHealth -= (Time.deltaTime * Mathf.Max(2, 0));
                // 4
                if (healthBar.currentHealth <= 0)
                {
                    AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                    AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
                    setDead(true);
                    anim.SetBool("isDead", true);
                    Destroy(gameObject, 2f);

                    gameManager.Gold += 50;
                }

                if (Time.time - lastPoison >= 8)
                {
                    poisoned = false;
                }
            }

            if (!shocked) {
				Vector3 startPosition = waypoints [currentWaypoint].transform.position;
				Vector3 endPosition = waypoints [currentWaypoint + 1].transform.position;
				// 2 
				float pathLength = Vector3.Distance (transform.position, endPosition);

                float actualSpeed = speed;
                if (poisoned)
                {
                    actualSpeed /= 2;
                }
				float totalTimeForPath = pathLength / actualSpeed;
				float currentTimeOnPath = Time.time - lastWaypointSwitchTime - shockTime;
				gameObject.transform.position = Vector3.Lerp (transform.position, endPosition, Time.deltaTime / totalTimeForPath);
				// 3 
				if (gameObject.transform.position.Equals (endPosition)) {
					if (currentWaypoint < waypoints.Length - 2) {
						// 3.a 
						currentWaypoint++;
						lastWaypointSwitchTime = Time.time;
						RotateIntoMoveDirection ();
						shockTime = 0;
					} else {
                        // 3.b 
                        Destroy (gameObject);

						AudioSource audioSource = gameObject.GetComponent<AudioSource> ();
						AudioSource.PlayClipAtPoint (audioSource.clip, transform.position);
						gameManager.Health -= 1;
					}
				}

			} else {
				shockTime += (Time.time - lastShock);
				lastShock = Time.time;
			}

		}
    }
}
