using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour {

    private const string FIREWEAPON = "Fire1";
    private const string FIREMISSILE = "Fire2";

    bool isPlayer;
    // Master List/Array
    FirePointControl[] firePoints;

    // Ready Weapon Types
    List<FirePointControl> AllBullets;
    List<FirePointControl> AllMissiles;

    // Weapon Stagger
    int currentBulletIndex;
    int currentMissileIndex;
    float timeToFire;

    public GameObject target;
    private bool hasLock = false;

    // Use this for initialization
    void Start () {

        if(GetComponentInParent<MovementControlScript>() != null)
            isPlayer = GetComponentInParent<MovementControlScript>().isPlayerShip;

        // Initialise variables
        currentBulletIndex = 0;
        currentMissileIndex = 0;
        timeToFire = 0;

        // Initialise weapon lists
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
                Debug.Log("Bullet Weapons: " + AllBullets.Count);
            }
            if (fpc.thisIsA == FirePointControl.ProjectileType.Missile)
            {
                AllMissiles.Add(fpc);
                Debug.Log(message: "Missile Weapons: " + AllBullets.Count);
            }

        }
        
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton(FIREWEAPON) && isPlayer)
        {
            FireBullets();
            
        }
        if (Input.GetButton(FIREMISSILE) && isPlayer)
        {
            SetMissileTarget();
            if (hasLock)
                FireMissiles();
        }
		
	}

    public void FireBullets()
    {
        currentBulletIndex = WeaponCycle(AllBullets, currentBulletIndex);
    }

    void FireMissiles()
    {
        currentMissileIndex = WeaponCycle(AllMissiles, currentMissileIndex);
    }

    int WeaponCycle(List<FirePointControl> weapons, int index)
    {
        
        if (weapons.Count == 0)
            return 0;
        else
        {
            if (Time.time >= timeToFire)
            {
                timeToFire = Time.time + 1 / weapons[index].fireRate / weapons.Count;
                //Debug.Log(index);
                weapons[index].Shoot();
                //Debug.Log("Pju! Pju!");
                index = (index  + 1) % weapons.Count;
            }
            return index;
        }
    }

    private void SetMissileTarget()
    {
        Debug.DrawRay(transform.position + transform.forward * 10, transform.forward, Color.white, 500);
        RaycastHit info;
        Physics.Raycast(transform.position + transform.forward*10, transform.forward, out info, 500);

        if (info.collider)
        {
            target = info.transform.gameObject;
            hasLock = true;
        }
        else
            hasLock = false;
    }
}
