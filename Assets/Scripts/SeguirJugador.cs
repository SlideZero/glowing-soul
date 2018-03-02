using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJugador : MonoBehaviour {

	public Transform _jugador;
	
	// Update is called once per frame
	void Update () {

		if(!(_jugador == null))
			transform.position = _jugador.position;
	}
}
