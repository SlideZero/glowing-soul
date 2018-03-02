using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorEscena : MonoBehaviour {

    public Text _puntaje;
    public Text _puntajeNuevo;
    public Text _puntajeNormal;

    public int _puntajeTotal = 400;
    public Text _refresco;
    public GameObject _jugador;
    private Apuntado _apuntado;
    public Image _imagenRefresco;
    private bool _enRefresco;
    public Sprite _refrescoHabilitado;
    public Sprite _refrescoInhabilitado;

    private float _timerSecond = 0;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        _apuntado = _jugador.gameObject.GetComponent<Apuntado>();
        //_puntajeNuevo.text = PlayerPrefs.GetInt("puntajeMayor", 0).ToString();
	}
	
	// Update is called once per frame
	void Update () {

        if (_jugador == null)
            HighScore();
        

        if (_timerSecond <= 1)
        {
            _timerSecond += Time.deltaTime;
        }
        else
        {
            _timerSecond = 0;
            if(!(_jugador == null))
                SubirPuntos(1);
        }

        _puntaje.text = _puntajeTotal.ToString();

        _extraerRefresco();
        if (!_enRefresco)
            _imagenRefresco.sprite = _refrescoHabilitado;
        else
            _imagenRefresco.sprite = _refrescoInhabilitado;
	}

    void _extraerRefresco()
    {
        _enRefresco = _apuntado.EstaRefrescando();
    }

    public void SubirPuntos(int puntos)
    {
        _puntajeTotal += puntos;
    }

    public int EnviarPuntos()
    {
        return _puntajeTotal;
    }

    public void HighScore()
    {
        _puntajeNormal.text = "SCORE " + _puntajeTotal.ToString();


        if (_puntajeTotal > PlayerPrefs.GetInt("puntajeMayor", 0))
        {
            PlayerPrefs.SetInt("puntajeMayor", _puntajeTotal);

            PlayerPrefs.Save();
            _puntajeNuevo.text = "HIGH SCORE " + PlayerPrefs.GetInt("puntajeMayor").ToString();
        }
        else {
            _puntajeNuevo.text = "HIGH SCORE " + PlayerPrefs.GetInt("puntajeMayor").ToString();
        }
    }
}
