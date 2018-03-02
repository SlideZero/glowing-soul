using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaAlma : MonoBehaviour {

	private Rigidbody _rb;
	public float velocidad = 3;
	private GameObject Jugador;
    private GameObject _lineasParticula;
    // Use this for initialization
    void Start()
	{
		_rb = GetComponent<Rigidbody>();
        _lineasParticula = GameObject.FindWithTag("ParticulaSoul");
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
		if(other.tag == "Enemigo")
		{
			

			if (Jugador.transform.GetChild(0).position != other.transform.position)
			{
                _lineasParticula.SetActive(false);
                Jugador.GetComponent<MovimentoNormal>().MorirTiempo();
                Jugador.GetComponent<Apuntado>().EnRefresco();
				Jugador.transform.GetChild(0).GetComponent<EnemigoBasico>().Desposeer();
                Jugador.transform.GetChild(0).GetComponent<Collider>().enabled = true;
                Jugador.transform.GetChild(0).SetParent(null);
	            Jugador.transform.position = other.transform.position;
	            other.transform.SetParent(Jugador.transform);
	            other.GetComponent<EnemigoBasico>().Poseer();
                other.GetComponent<Collider>().enabled = false;

                Destroy(gameObject);
			}
		}

		if(other.tag == "EnemigoCubo")
		{


			if (Jugador.transform.GetChild(0).position != other.transform.position)
			{
				Jugador.GetComponent<Apuntado>().EnRefresco();
				Jugador.transform.GetChild(0).GetComponent<EnemigoCubo>().Desposeer();
				Jugador.transform.GetChild(0).SetParent(null);
	            Jugador.transform.position = other.transform.position;
	            other.transform.SetParent(Jugador.transform);
	            other.GetComponent<EnemigoCubo>().Poseer();

	            Destroy(gameObject);
			}
		}

		if(other.tag == "EnemigoDode")
		{

			if (Jugador.transform.GetChild(0).position != other.transform.position)
			{
				Jugador.GetComponent<Apuntado>().EnRefresco();
				Jugador.transform.GetChild(0).GetComponent<EnemigoDodecaedro>().Desposeer();
				Jugador.transform.GetChild(0).SetParent(null);
	            Jugador.transform.position = other.transform.position;
	            other.transform.SetParent(Jugador.transform);
	            other.GetComponent<EnemigoDodecaedro>().Poseer();

	            Destroy(gameObject);
			}
		}

	}
}
