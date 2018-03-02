using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoTaurus : MonoBehaviour {

	public GameObject _areaDestruccion;
	private bool _una = false;
	private Rigidbody _rb;
	public float _velocidad;
	private GameObject _jugador;
    private Vector3 _direccion;

    public GameObject _Explocion;
    private AudioSource _audioExplocion;

    // Use this for initialization
    void Start () {
		_rb = GetComponent<Rigidbody>();
		_jugador = GameObject.Find("Jugador");

        _Explocion = GameObject.Find("Explocion");
        _audioExplocion = _Explocion.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		if (transform.GetComponent<EnemigoBasico> ()._poseido == true) {

			if(!_una)
			{
                _audioExplocion.Play();
				Instantiate (_areaDestruccion,transform.position, transform.rotation);
				_una = true;
			}
		}else
		{

			Mover();
			if(_una){

				Destroy(gameObject);
			}
		}
	}

	void Mover()
    {   

        if(!(_jugador == null))
        {
            _direccion = (_jugador.transform.position - transform.position).normalized;
            _rb.MovePosition(transform.position + _direccion * _velocidad * Time.deltaTime);
        }
        
    }
}
