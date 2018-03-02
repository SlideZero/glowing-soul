using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoDodecaedro : EnemigoCubo {

    private Vector3 direccion;
    public GameObject _balaPrefab;

    public float _cadencia = 0.5f;
    private float _timerCadencia = 0;
    private bool _disparando = false;

    public GameObject _disparoEnemigo;
    AudioSource _audioDisparo;
    // Use this for initialization
    void Start () {
		_rb = GetComponent<Rigidbody>();
        _jugador = GameObject.Find("Jugador");

        _disparoEnemigo = GameObject.Find("DisparoEnemigo");
        _audioDisparo = _disparoEnemigo.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if(_disparando)
        {
            if(_timerCadencia < _cadencia)
            {
                _timerCadencia += Time.deltaTime;
            }else
            {
                _disparando = false;
            }
        }

        if(_poseido)
        {
            SeguirPadre();
        }
        else if(!_poseido)
        {
            Mover();
            Disparar();
        }
        
    }

    void Disparar()
    {
        if(!_disparando)
        {   

            if(!(_jugador == null)){
                _audioDisparo.Play();
                direccion = (_jugador.transform.position - transform.position).normalized;
                Instantiate(_balaPrefab, transform.position + direccion * 1.5f, Quaternion.LookRotation(direccion));
                _disparando = true;
                _timerCadencia = 0;
                
            }
        }
    }

    
}
