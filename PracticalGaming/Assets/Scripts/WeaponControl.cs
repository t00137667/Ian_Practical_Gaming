using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour {
    private const string FIREWEAPON = "Fire1";



    // Master List/Array
    FirePointControl[] firePoints;

    // Ready Weapon Types
    List<FirePointControl> AllBullets;
    List<FirePointControl> AllMissiles;

    // 

    // Use this for initialization
    void Start () {
        AllBullets = new List<FirePointControl>();
        AllMissiles = new List<FirePointControl>();
        // Retrieve attached firepoints
        firePoints = gameObject.GetComponentsInChildren<FirePointControl>();
        Debug.Log("Retrieved firepoints");

        // Place firepoints into corresponding lists
        foreach (FirePointControl fpc in firePoints)
        {
            if (fpc.thisIsA == FirePointControl.ProjectileType.Bullet)
            {
                AllBullets.Add(fpc);
                Debug.Log(AllBullets.Count);
            }
            if (fpc.thisIsA == FirePointControl.ProjectileType.Missile)
            {
                AllMissiles.Add(fpc);
                Debug.Log(AllBullets.Count);
            }
        }

        
        
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton(FIREWEAPON))
        {
            foreach (FirePointControl fpc in AllBullets)
            {
                fpc.Shoot();
            }
            //firePoints[currentGunIndex].Shoot();
            Debug.Log("Pju! Pju!");
        }
		
	}
}
