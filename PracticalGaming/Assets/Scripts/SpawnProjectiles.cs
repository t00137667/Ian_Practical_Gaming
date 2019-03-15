using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectiles : MonoBehaviour {

    FirePointControl[] firePoints;

    List<FirePointControl> AllBullets;
    List<FirePointControl> Allmissile;
    // Use this for initialization
    void Start () {

        
        firePoints = gameObject.GetComponentsInChildren<FirePointControl>();

        firePoints[0].YouAreABullet();
        AllBullets.Add(firePoints[0]);

        
    }
	
	// Update is called once per frame
	void Update () {

     //   if (Input.GetKey(KeyCode.Space)) firePoints[currentGunIndex].Shoot();
		
	}
}
