using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float fireRate;
    public float lifeSpan;

    enum ProjectileType { Bullet, Missile, etc }
    ProjectileType thisIsA;

    public float strength;

    private float time;

	// Use this for initialization
	void Start () {
        time = 0;


        // Needs adjustment for actual play, just for testing at the moment
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

        switch (thisIsA) {
            case ProjectileType.Bullet:
                transform.position += transform.forward * (speed * Time.deltaTime);
                break;
            case ProjectileType.Missile:
                transform.position += transform.forward * (speed * Time.deltaTime);
                break;
            default:
                transform.position += transform.forward * (speed * Time.deltaTime);
                break;
        }



        //transform.position += transform.forward * (speed * Time.deltaTime);
        time += Time.deltaTime;

        if (time >= lifeSpan)
        {
            projectileTimeOut();
        }

	}

    void projectileTimeOut()
    {
        speed = 0;

        Destroy(gameObject);
    }

    public void YouAreABullet()
    {
        thisIsA = ProjectileType.Bullet;
    }
    public void YouAreAMissile()
    {
        thisIsA = ProjectileType.Missile;
    }

    void OnHit(Collider other)
    {
        speed = 0;
        other.GetComponentInChildren<ShieldHealth>().AdjustHealth(strength);       
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        speed = 0;
        if (collision.collider.tag == "Shield")
            Debug.Log("OnCollisionEnter");
        Destroy(gameObject);
    }
    // Handles impacts with Shield Colliders
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Shield" && this.tag == "PlayerProjectile")
        {
            Debug.Log("Shield Hit");
            OnHit(other);
        }

        //bool rolling = other.GetComponentInParent<MovementControlScript>().shipIs != MovementControlScript.ShipMovement.Normal;
        //// Checks if projectile hit the player, and they were not in a Roll
        //if (other.tag == "PlayerShield" && this.tag == "Projectile" && !rolling)
        //{
        //    Debug.Log("Player Shield Hit");
        //    OnHit(other);
        //}

        if (other.tag == "PlayerShield" && this.tag == "Projectile")
        {
            Debug.Log("Target Shield Hit");
            OnHit(other);
        }
    }
}
