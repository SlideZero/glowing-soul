using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPiramide : EnemigoCubo {

    private bool _jugadorUbicado = false;
    private Vector3 _ubicacionJugador;

    //Para cooldown de movimiento
    public float _refrescoMovimiento = 3;
    private float _timerMovimiento = 0;
    private bool _enRefresco = false;

    // Use this for initialization
    void Start () {
        _rb = GetComponent<Rigidbody>();
        _jugador = GameObject.Find("Jugador");
    }
	
	// Update is called once per frame
	void Update () {
        if (_poseido)
        {
            SeguirPadre();
        }
        else if (!_poseido)
        {
            MoverRapido();
        }

        //Validacion de cooldown de movimiento
        if (_enRefresco)
        {
            if (_timerMovimiento < _refrescoMovimiento)
            {
                _timerMovimiento += Time.deltaTime;
            }
            else
            {
                _enRefresco = false;
            }
        }
    }

    //Movimiento rapido a la ultima posicion del jugador
    protected void MoverRapido()
    {
        if (transform.position != _ubicacionJugador)
            _jugadorUbicado = false;
        else if (transform.position == _ubicacionJugador)
        {
            _jugadorUbicado = true;
        }

        if (!(_jugador == null) && !_jugadorUbicado)
        {
            transform.position = Vector3.MoveTowards(transform.position, _ubicacionJugador, _velocidad * Time.deltaTime);
        }
        else if (_jugadorUbicado && !_enRefresco)
        {
            _enRefresco = true;
            _timerMovimiento = 0;

            if(!(_jugador == null))
                _ubicacionJugador = _jugador.transform.position;
        }
    }

}
