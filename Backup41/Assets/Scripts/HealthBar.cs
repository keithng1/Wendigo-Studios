using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {


    public float maxHealth = 100;
    public float currentHealth = 100;
    private float originalScale;

    public void waveScale(int wave)
    {
        for(int i=0; i< wave; i++)
        {
            maxHealth += (float)(maxHealth * 0.3);
        }
        currentHealth = maxHealth;
    } 

    // Use this for initialization
    void Start()
    {
        originalScale = gameObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x = currentHealth / maxHealth * originalScale;
        gameObject.transform.localScale = tmpScale;
    }
}
