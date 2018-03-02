using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaminoDash : MonoBehaviour {

	public float _timepoMuerte;
	
	// Update is called once per frame
	void Start () {

		Invoke("Collision", 0.4f);
		Invoke("Morir", _timepoMuerte);
		
	}

	void Morir()
	{
		Destroy(gameObject);
	}

	void Collision()
	{
		GetComponent<BoxCollider>().enabled = true;
	}
}
