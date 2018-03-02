using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apuntado : MonoBehaviour {

	private Ray _posicionMouse;
	public GameObject _balaPrefab;
	private GameObject _bala;
	private Vector3 direccion;
	private Rigidbody _rb;

    public GameObject _transferencia;
    AudioSource _audioTransferencia;

    //Para el coldown
    public float _tiempoRefresco = 3;
	private float _timerRefresco = 0;
	private bool _enRefresco = false;

	//Cadencia
	public float _cadencia = 0.5f;
	private float _timerCadencia = 0;
	private bool _disparando = false;

	public GameObject _balaNormal;
	public float _cadenciaBala = 0.5f;
	private float _timerCadenciaBala = 0;
	private bool _disparandoBala = false;

	public GameObject _dashParticles;
	public float _cadenciaDash = 0.5f;
	private float _timerDash = 0;
	private bool _dashing = false;
	public float _dashForce = 5;

    public GameObject _disparoEnemigo;
    AudioSource _audioDisparo;

    public GameObject _dashEnemigo;
    AudioSource _audioDash;

    public GameObject _Refresco;
    AudioSource _audioRefresco;

    public GameObject _noTransferir;
    AudioSource _audioNoPermitido;

    public GameObject _lineasParticula;

    // Use this for initialization
    void Start () {
		_rb = GetComponent<Rigidbody>();
        _transferencia = GameObject.Find("Transferencia");
        _audioTransferencia = _transferencia.GetComponent<AudioSource>();

        _disparoEnemigo = GameObject.Find("DisparoEnemigo");
        _audioDisparo = _disparoEnemigo.GetComponent<AudioSource>();

        _dashEnemigo = GameObject.Find("Dash");
        _audioDash = _dashEnemigo.GetComponent<AudioSource>();

        _Refresco = GameObject.Find("Refresco");
        _audioRefresco = _Refresco.GetComponent<AudioSource>();

        _noTransferir = GameObject.Find("NoTransferir");
        _audioNoPermitido = _noTransferir.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update()
	{

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

		if(_disparandoBala)
		{
			if(_timerCadenciaBala < _cadenciaBala)
			{
				_timerCadenciaBala += Time.deltaTime;
			}else
			{
				_disparandoBala = false;
			}
		}
		
		if(_enRefresco)
		{
			if(_timerRefresco < _tiempoRefresco)
			{
				_timerRefresco += Time.deltaTime;
			}else
			{
                _lineasParticula.SetActive(true);
                _audioRefresco.Play();
                _enRefresco = false;
			}
		}

		if(_dashing)
		{
			if(_timerDash < _cadenciaDash)
			{
				_timerDash += Time.deltaTime;
				if(_timerDash > _cadenciaDash / 10f){
					_rb.velocity = new Vector3(0,0,0);
				}

			}else
			{
				_dashing = false;
			}

		}else{
			_rb.velocity = new Vector3(0,0,0);
		}
		//Plane playerPlane = new Plane(transform.up, transform.position);

		_posicionMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
		//_posicionMouse.z = 0;
		//float _distanciaHit = 0;

		RaycastHit hit;

		if(Physics.Raycast(_posicionMouse, out hit, 1 << 8)){

			//_posicionMouse = hit.point;
			//Debug.Log(hit.point);

			direccion = (hit.point - transform.position).normalized;

			Debug.DrawRay(transform.position, direccion * 5, Color.black);
		}

        if (!_enRefresco)
        {
            if (Input.GetMouseButtonDown(0) && !_disparando)
            {

                _audioTransferencia.Play();
                _bala = Instantiate(_balaPrefab, transform.position + direccion, Quaternion.LookRotation(direccion));
                _bala.GetComponent<BalaAlma>().GuardarJugador(gameObject);
                _disparando = true;
                _timerCadencia = 0;
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("WAHWAH");
            _audioNoPermitido.Play();
        }

        DisparoBala();
		Dash();

		

		//playerPlane.Raycast (_posicionMouse, out _distanciaHit);
		//Debug.Log(_posicionMouse.GetPoint(_distanciaHit));

		
	}

	void Dash(){
		if(transform.GetChild(0).GetComponent<EnemigoBasico>()._tipo == "Piramide")
		{

			if(_dashing && (_timerDash < _cadenciaDash / 10f)){

                Instantiate(_dashParticles, transform.position , Quaternion.LookRotation(direccion));
			}
			if (Input.GetMouseButtonDown(1) && !_dashing){

                /*_bala = Instantiate(_balaNormal, transform.position + direccion * 2f, Quaternion.LookRotation(direccion));
				_bala.GetComponent<Bala>().GuardarJugador(gameObject);
				*/
                //_rb.MovePosition(transform.position + direccion * _dashForce * Time.deltaTime);
                _audioDash.Play();
                _rb.AddForce(direccion * _dashForce, ForceMode.VelocityChange);
				_dashing = true;
				_timerDash = 0;
			}
		}

	}

	void DisparoBala(){
		if(transform.GetChild(0).GetComponent<EnemigoBasico>()._tipo == "Dode")
		{

			if (Input.GetMouseButtonDown(1) && !_disparandoBala){
                _audioDisparo.Play();
                _bala = Instantiate(_balaNormal, transform.position + direccion * 2f, Quaternion.LookRotation(direccion));
				_bala.GetComponent<Bala>().GuardarJugador(gameObject);
				_disparandoBala = true;
				_timerCadenciaBala = 0;
			}
		}
	}

	public void EnRefresco()
	{
		_enRefresco = true;
		_timerRefresco = 0;
	}

	public bool EstaRefrescando()
	{
		return _enRefresco;
	}

}
