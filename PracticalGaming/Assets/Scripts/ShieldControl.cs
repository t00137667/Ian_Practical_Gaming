﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldControl : MonoBehaviour {

    public bool player;
    public GameObject shieldFX;

    AudioSource source;

	// Use this for initialization
	void Start () {
        if (GetComponentInParent<MovementControlScript>() != null)
            player = GetComponentInParent<MovementControlScript>().isPlayerShip;

        if (player)
            this.tag = "PlayerShield";

       source = gameObject.AddComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnCollisionEnter(Collision collision)
    {
        //shieldFX.GetComponent<ParticleSystem>().Play();
        if (collision.collider.tag == "Projectile")
        {
            Debug.Log("Shield Collider HIT!");
            //shieldFX = Instantiate(shieldFX, transform.position, transform.rotation);
            //shieldFX.GetComponent<ParticleSystem>().Play();
        }
                
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject shieldCopy = shieldFX;

        // Allowing Player shots to pass though the players own shield
        if (other.tag == "Projectile" && player)
        {
            Debug.Log("Enemy Shot has Hit");

            GameObject shield = Instantiate(shieldCopy, transform.position, transform.rotation, gameObject.transform);
            shield.AddComponent<ParticleAutoDestroy>();
            shield.GetComponent<ParticleSystem>().Play();

            

        }

        // Player Shots to hit enemy shields
        if (other.tag == "PlayerProjectile" && !player)
        {
            Debug.Log("Enemy Shield has been hit");
            
            GameObject shield = Instantiate(shieldCopy, transform.position, transform.rotation, gameObject.transform);
            shield.AddComponent<ParticleAutoDestroy>();
            shield.GetComponent<ParticleSystem>().Play();

           
        }

        // Allowing Enemy shots to hit the objective
        if (other.tag == "Projectile" && GetComponentInParent<TargetObjective>() != null)
        {
            Debug.Log("Enemy Shot has Hit");

            GameObject shield = Instantiate(shieldCopy, transform.position, transform.rotation, gameObject.transform);
            shield.AddComponent<ParticleAutoDestroy>();
            shield.GetComponent<ParticleSystem>().Play();

            
        }
    }

    public void PlayHit()
    {
         source.PlayOneShot(FindObjectOfType<GameManagerScript>().shieldHit);
    }

    public void Destroyed()
    {
        StartCoroutine("Destroy");
        
    }

    IEnumerator Destroy()
    {

        while (true)
        {
            if (!source.isPlaying)
            {
                FindObjectOfType<GameManagerScript>().DestroyShip(transform.parent.gameObject);
            }

            yield return null;
        }
        
        
    }
}
