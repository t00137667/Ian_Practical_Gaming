using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float fireRate;
    public float lifeSpan;

    private float time;

    //public Projectile(float speed)
    //{
    //    this.speed = speed;
    //}

	// Use this for initialization
	void Start () {
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * (speed * Time.deltaTime);
        time += Time.deltaTime;

        if (time >= lifeSpan)
        {
            projectileTimeOut();
        }

	}

    void projectileTimeOut()
    {
        speed = 0;

        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        speed = 0;

        Destroy(gameObject);
    }
}
