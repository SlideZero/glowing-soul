using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

	private Rigidbody _rb;
	public float velocidad = 3;
	private GameObject Jugador;

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

	public void GuardarJugador(GameObject jugador)
	{
		Jugador = jugador;
	}

	void OnTriggerEnter(Collider other)
	{	
		if(!(Jugador == null)){
			if (Jugador.transform.GetChild(0) != other.transform)
			{
				if(other.tag != "Plane" && other.tag != "Player")
				Destroy(gameObject);
			}
		}
		
	}

}
