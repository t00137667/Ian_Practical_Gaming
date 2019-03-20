using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour {

    // Master List/Array
    FirePointControl[] firePoints;

    // Ready Weapon Types
    List<FirePointControl> AllBullets;
    List<FirePointControl> AllMissiles;

    // 

    // Use this for initialization
    void Start () {

        // Retrieve attached firepoints
        firePoints = gameObject.GetComponentsInChildren<FirePointControl>();

        // Place firepoints into corresponding lists
        foreach (FirePointControl fpc in firePoints)
        {
            if (fpc.thisIsA == FirePointControl.ProjectileType.Bullet)
            {
                AllBullets.Add(fpc);
            }
            if (fpc.thisIsA == FirePointControl.ProjectileType.Missile)
            {
                AllMissiles.Add(fpc);
            }
        }

        
        
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("fire1"))
        {
            //firePoints[currentGunIndex].Shoot();
        }
		
	}
}
