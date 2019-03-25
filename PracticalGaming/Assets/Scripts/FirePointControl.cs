using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointControl : MonoBehaviour {


    public enum ProjectileType { Bullet, Missile, etc}

    public List<GameObject> projectilesTypes = new List<GameObject>();
    private GameObject projectileType;

    // Weapon Fire Rates
    private float fireRateBullet = 4;
    private float fireRateMissile = 1;

    public float timeToFire = 0;
    public float fireRate = 0;

    private float projectileSpeedBullet = 100;
    private float projectileSpeedMissile = 75;

    public float projectileSpeed;


    public ProjectileType thisIsA;
	// Use this for initialization
	void Start () {

        switch (thisIsA)
        {
            case ProjectileType.Bullet:
                projectileType = projectilesTypes[0];
                fireRate = fireRateBullet;
                projectileSpeed = projectileSpeedBullet;
                break;
            case ProjectileType.Missile:
                fireRate = fireRateMissile;
                break;
            default:
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void YouAreABullet()
    {
        thisIsA = ProjectileType.Bullet;
    }

    public void Shoot()
    {
        GameObject projectile;
        Quaternion forward = transform.rotation;
        switch (thisIsA)
        {
            case ProjectileType.Bullet:
                projectile = Instantiate(projectileType, transform.position, forward);
                break;
            case ProjectileType.Missile:
                break;
            default:
                break;
        }
    }
}
