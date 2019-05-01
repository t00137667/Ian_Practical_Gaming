using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class GameManagerScript : MonoBehaviour {

    float gameTime = 0;
    float newTime = 0;

    SpawnerScript spawner;
    public AudioClip gunShot;
    public AudioClip missile;
    public AudioClip shieldHit;
    public AudioClip shipDeath;

    AudioSource source;

    static List<GameObject> EnemyShips = new List<GameObject>();
    MovementControlScript player;
    int shipCount = 1;

    static TargetObjective target;

    private void Awake()
    {
        target = FindObjectOfType<TargetObjective>();
        player = FindObjectOfType<MovementControlScript>();

        source = gameObject.AddComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        newTime = gameTime + 1;

        spawner = GetComponentInChildren<SpawnerScript>();

        
    }
	
	// Update is called once per frame
	void Update () {
        gameTime += Time.deltaTime;

        if (newTime <= gameTime)
        {
            newTime = gameTime + 1;

            if (shipCount < 20)
            {
                spawner.SpawnEnemyShip(0);
                AddEnemyShip();
            }
            CheckIfInRange();
        }
        
        if (target == null || player == null)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    public void AddEnemyShip()
    {
        EnemyShips.Add(SpawnerScript.GetShip());
        shipCount = EnemyShips.Count;
    }

    public static Transform RequestTargetPosition()
    {
        return target.transform;
    }

    private void CheckIfInRange()
    {
        foreach(GameObject g in EnemyShips)
        {
            if (g != null)
            {
                if (g.GetComponent<MovementControlScript>().inRange)
                {
                    g.GetComponentInChildren<WeaponControl>().FireBullets();
                    g.GetComponentInChildren<WeaponControl>().FireBullets();
                }
            }
            
        }
    }

    public void DestroyShip(GameObject g)
    {
        
        EnemyShips.Remove(g);

        source.PlayOneShot(shipDeath);

        Destroy(g);
    }
}
