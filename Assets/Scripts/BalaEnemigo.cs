using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigo : MonoBehaviour {

	private Rigidbody _rb;
	public float velocidad = 3;

    // Use this for initialization
    void Start()
	{
		_rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		Avanzar();
	}

	void Avanzar()
	{
		_rb.AddForce(transform.forward * velocidad, ForceMode.VelocityChange);
	}

	void OnTriggerEnter(Collider other)
	{	

		if(other.tag != "Plane" && other.tag != "Enemigo")
		Destroy(gameObject);
	}
}
