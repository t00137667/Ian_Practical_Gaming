using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldControl : MonoBehaviour {

    public bool player;
    public GameObject shieldFX;
    

	// Use this for initialization
	void Start () {
        //shieldFX.GetComponent<ParticleSystem>().Stop();
        player = GetComponentInParent<MovementControlScript>().isPlayerShip;
        
        //shieldFX = GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        //ShieldCleanUp();
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
        if (other.tag == "Projectile" && GetComponentInParent<MovementControlScript>().isPlayerShip)
        {
            Debug.Log("Enemy Shot has Hit");
            shieldFX.GetComponent<ParticleSystem>().Play();
            if (shieldFX == null)
            {
                Debug.Log("Nope");
            }
            
        }


        if (other.tag == "PlayerProjectile" && !GetComponentInParent<MovementControlScript>().isPlayerShip)
        {
            Debug.Log("Enemy Shield has been hit");
            //
            //shield = new GameObject();
            //shield = 
            GameObject shield = Instantiate(shieldCopy, transform.position, transform.rotation, gameObject.transform);
            shield.AddComponent<ParticleAutoDestroy>();
            shield.GetComponent<ParticleSystem>().Play();

        }
    }
}
