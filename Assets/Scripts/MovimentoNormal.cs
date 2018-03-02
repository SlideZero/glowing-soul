using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoNormal : MonoBehaviour {

	private Rigidbody _rb;
	private float _velocidad = 15f;
	public float _velocidadCubo;
	public float _velocidadDode;
	public float _velocidadPiramide ;
    public float _velocidadDona;
	private float _h;//Axis horizontal
	private float _v;//Axis vertival
	private Vector3 _movimiento;
	public bool _dentro = true;
	public float _boundsX;
	public float _boundsZ;
	private Vector3 newPos;

    public float _tiempoMuerte = 15;
    private float _timerMuerte;
    public GameObject _spriteRojo;
    private bool _encendido = false;
    private float _tiempoEncendido = 1f;

    public GameObject _muerteJugador;
    AudioSource _audioMuerte;
    // Use this for initialization
    void Start () 
	{
		_rb = GetComponent<Rigidbody>();
		_boundsX -= 0.5f;
		_boundsZ -= 0.5f;

        _muerteJugador = GameObject.Find("MuerteJugador");
        _audioMuerte = _muerteJugador.GetComponent<AudioSource>();

        _timerMuerte = _tiempoMuerte;
    }
	
	// Update is called once per frame
	void Update()
	{
		_h = Input.GetAxisRaw("Horizontal");
		_v = Input.GetAxisRaw("Vertical");

		if(_h != 0 || _v != 0){

			Movimento(_h, _v);
		}

        CronometroMuerte();

		if(transform.GetChild(0).GetComponent<EnemigoBasico>()._tipo == "Dode")
			_velocidad = _velocidadDode;
		else if(transform.GetChild(0).GetComponent<EnemigoBasico>()._tipo == "Cubo")
			_velocidad = _velocidadCubo;
		else if(transform.GetChild(0).GetComponent<EnemigoBasico>()._tipo == "Piramide")
			_velocidad = _velocidadPiramide;
        else if (transform.GetChild(0).GetComponent<EnemigoBasico>()._tipo == "Dona")
            _velocidad = _velocidadDona;
    }


	void Movimento(float h, float v)
	{
		

		if (transform.position.x < _boundsX && transform.position.x > -_boundsX && transform.position.z < _boundsZ && transform.position.z > -_boundsZ) {
			_movimiento.Set (h, 0, v);
			_movimiento = _movimiento.normalized * _velocidad;

			_rb.MovePosition (transform.position + _movimiento * Time.deltaTime);
		} else {
			
			if(transform.position.x >= _boundsX){
				newPos = new Vector3 (_boundsX - 0.1f, 0, transform.position.z);
			}
			if(transform.position.x <= -_boundsX){
				newPos = new Vector3 (-_boundsX + 0.1f, 0, transform.position.z);
			}
			if(transform.position.z >= _boundsZ){
				newPos = new Vector3 (transform.position.x, 0, _boundsZ - 0.1f);
			}
			if(transform.position.z <= -_boundsZ){
				newPos = new Vector3 (transform.position.x, 0, -_boundsZ + 0.1f);
			}

			transform.position = newPos;
		}
	}

	void OnTriggerEnter(Collider other){

		if(other.tag == "BalaEnemigo")
		{
            _audioMuerte.Play();
            Destroy(gameObject);
		}

		if(other.tag == "Enemigo")
		{
			if(other.GetComponent<EnemigoBasico>()._poseido == false)
			{
                _audioMuerte.Play();
                Destroy(gameObject);
			}
			
		}

		if(other.tag == "EnemigoDode")
		{
			if(other.GetComponent<EnemigoDodecaedro>()._poseido == false)
			{
				Destroy(gameObject);
			}
			
		}
		
	}

    void CronometroMuerte()
    {
        _timerMuerte -= Time.deltaTime;

        if (_timerMuerte <= 0)
        {
            _audioMuerte.Play();
            Destroy(gameObject);
        }

        if(_timerMuerte <= 7)
        {
            
            if( _timerMuerte % _tiempoEncendido <= 0.05 && _timerMuerte % _tiempoEncendido >= -0.05)
            {
                Debug.Log("Omaewa");
                if (!_encendido)
                {
                    _spriteRojo.SetActive(true);
                    _encendido = true;
                }
                else { 
                    _spriteRojo.SetActive(false);
                    _encendido = false;
                }

                //_tiempoEncendido -= Time.deltaTime / 5;
            }
        }
    }

    public void MorirTiempo()
    {
        _timerMuerte = _tiempoMuerte;
        _tiempoEncendido = 1f;
        _spriteRojo.SetActive(false);
        _encendido = false;
    }

}
