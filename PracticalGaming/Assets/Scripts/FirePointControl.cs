﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointControl : MonoBehaviour {


    public enum ProjectileType { Bullet, Missile, etc}

    public List<GameObject> projectilesTypes = new List<GameObject>();
    private GameObject projectileType;
    private bool isPlayerShip;

    // Weapon Fire Rates
    private float fireRateBullet = 4;
    private float fireRateMissile = 1;

    public float timeToFire = 0;
    public float fireRate = 0;

    // Projectile Life
    private float lifeSpanBullet = 30;
    private float lifeSpanMissile = 60;

    // Projectile Speeds
    private float projectileSpeedBullet = 150;
    private float projectileSpeedMissile = 100;

    public float projectileSpeed;

    // Projectile Strength
    private float projectileStrengthBullet = 10.00f;
    private float projectileStrengthMissile = 75.00f;

    public float projectileStrength;


    private AudioSource source;

   

    public ProjectileType thisIsA;

    void Awake()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {

        switch (thisIsA)
        {
            case ProjectileType.Bullet:
                projectileType = projectilesTypes[0];
                fireRate = fireRateBullet;
                projectileSpeed = projectileSpeedBullet;
                projectileStrength = projectileStrengthBullet;
                
                break;
            case ProjectileType.Missile:
                projectileType = projectilesTypes[1];
                fireRate = fireRateMissile;
                projectileSpeed = projectileSpeedMissile;
                projectileStrength = projectileStrengthMissile;
                break;
            default:
                break;
        }
        if (GetComponentInParent<MovementControlScript>() != null)
            isPlayerShip = GetComponentInParent<MovementControlScript>().isPlayerShip;
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
                projectile.GetComponent<Projectile>().strength = projectileStrength;
                projectile.GetComponent<Projectile>().YouAreABullet();
                if(isPlayerShip)
                    projectile.tag = "PlayerProjectile";
                source.PlayOneShot(FindObjectOfType<GameManagerScript>().gunShot);
                break;
            case ProjectileType.Missile:
                projectile = Instantiate(projectileType, transform.position, forward);
                projectile.GetComponent<Projectile>().strength = projectileStrength;
                projectile.GetComponent<Projectile>().YouAreAMissile();
                projectile.GetComponent<Projectile>().target = GetComponentInParent<WeaponControl>().target;
                if (isPlayerShip)
                    projectile.tag = "PlayerProjectile";
                source.PlayOneShot(FindObjectOfType<GameManagerScript>().missile);
                break;
            default:
                break;
        }
    }
}
