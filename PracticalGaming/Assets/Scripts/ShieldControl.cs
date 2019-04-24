using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldControl : MonoBehaviour {

    public bool player;
    public GameObject shieldFX;
    

	// Use this for initialization
	void Start () {
        if (GetComponentInParent<MovementControlScript>() != null)
            player = GetComponentInParent<MovementControlScript>().isPlayerShip;

        if (player)
            this.tag = "PlayerShield";
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
    }

    public void Destroyed()
    {
        Destroy(transform.parent.gameObject);
    }
}
