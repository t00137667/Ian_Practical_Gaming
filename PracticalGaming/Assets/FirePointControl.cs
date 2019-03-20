using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointControl : MonoBehaviour {


    public enum ProjectileType { Bullet, Missile, etc}

    public ProjectileType thisIsA;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void YouAreABullet()
    {
        thisIsA = ProjectileType.Bullet;
    }

    internal float FireRate()
    {
        // Returns the rate of fire of the weapon as shots per second
        switch (thisIsA)
        {
            case ProjectileType.Bullet: 
                break;
            case ProjectileType.Missile:
                break;
            default:break;
        }

        return 0;
    }
}
