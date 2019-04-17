using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        

        if (GetComponentInChildren<ParticleSystem>() != null)
        {
            GameObject.Destroy(gameObject, gameObject.GetComponentInChildren<ParticleSystem>().main.duration);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
