using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    float gameTime = 0;
    float newTime = 0;

    SpawnerScript spawner;

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

            spawner.SpawnEnemyShip(0);
        }
    }

}
