using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

    int spawnDistance = 1000;

    float gameTime = 0;
    float newTime = 0;

    public List<GameObject> enemyShips = new List<GameObject>();
    public GameObject enemyShip;

    Vector3 spawnPoint = new Vector3();

    // Use this for initialization
    void Start()
    {
        newTime = gameTime + 1;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        Quaternion rotateToCenter = Quaternion.LookRotation(-transform.forward, Vector3.up);
        if (newTime <= gameTime)
        {
            newTime = gameTime + 1;
            PickSpawnDirection();
            PickSpawnLocation();
            GameObject enemyShipCopy = Instantiate(enemyShip, spawnPoint, rotateToCenter);
        }
    }

    void PickSpawnDirection()
    {
        float newDirection = Random.Range(-90, 90);
        Vector3 newVector = new Vector3(0, newDirection, 0);

        transform.Rotate(newVector);

        Debug.DrawRay(transform.position, transform.forward, Color.cyan, 0.5f);
    }
    void PickSpawnLocation()
    {
        spawnPoint = transform.forward * spawnDistance;
        Debug.DrawLine(transform.position, spawnPoint, Color.white, 0.5f);
    }

    public void SpawnEnemyShip()
    {

    }
}
