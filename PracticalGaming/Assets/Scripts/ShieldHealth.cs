using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldHealth : MonoBehaviour {

    public double MAXHEALTH;
    private const int BASEHEALTH = 100;
    private const double UPPER_REGEN = 1;
    private const double SHEILD_REGEN = 5;
    private double health;
    private double healthPercent;

    HealthBarController healthBar;
    Slider healthSlider;

    float time = 0;

    // Use this for initialization
    void Start () {
        if (health == 0)
            health = MAXHEALTH;
        if (MAXHEALTH == 0)
            MAXHEALTH = BASEHEALTH;
            

        if (GetComponentInParent<MovementControlScript>() != null)
        {
            if (GetComponentInParent<MovementControlScript>().isPlayerShip)
            {
                healthBar = GameObject.Find("PlayerHealth").GetComponent<HealthBarController>();
                healthSlider = healthBar.GetComponent<Slider>();
            }
            
        }

        if (GetComponentInParent<TargetObjective>() != null)
        {
            healthBar = GameObject.Find("BaseHealth").GetComponent<HealthBarController>();
            healthSlider = healthBar.GetComponent<Slider>();
        }

        if (healthSlider != null)
        {
            healthSlider.value = (float)health;
            Debug.Log("Starting Health: "+ health);
        }
	}
	
	// Update is called once per frame
	void Update () {


        // Manages the Shield Health Regeneration over Time
        if (health < MAXHEALTH)
        {
            if(health < (MAXHEALTH * 4) / 5)
            {
                health += SHEILD_REGEN * Time.deltaTime;
            }
            else
            {
                health += UPPER_REGEN * Time.deltaTime;
            }

            if (health > MAXHEALTH)
            {
                health = MAXHEALTH;
                Debug.Log("Sheild Regen'd to Full");
            }
            if (time>= 1)
            {
                Debug.Log("Enemy Ship health" + health);
                time += Time.deltaTime;
            }
        }
        if (healthSlider != null)
        {
            healthPercent = (health / MAXHEALTH) * 100;
            healthSlider.value = (float)healthPercent;
        }
    }

    public void AdjustHealth(double hitStrength)
    {
        health -= hitStrength;
        if (health <= 0)
        {
            Debug.Log("Ship Destroyed");
            health = 0;
            GetComponentInParent<ShieldControl>().Destroyed();
            
        }
    }
}
