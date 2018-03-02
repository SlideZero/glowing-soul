using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarAlma : MonoBehaviour {

    public Transform _enemigo2, _enemigo1, _alma;
    public float _duracionDeRecarga;
    public float _tiempoDeRecarga;
    private bool _cambioUsado = false;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        if (_cambioUsado && _tiempoDeRecarga > 0)
        {
            _tiempoDeRecarga -= Time.deltaTime;
        }
        else if (_tiempoDeRecarga <= 0)
        {
            _tiempoDeRecarga = _duracionDeRecarga;
            _cambioUsado = false;
        }

        if (Input.GetKeyDown(KeyCode.T) && !_cambioUsado)
        {
            _cambioUsado = true;

            if (transform.position != _enemigo2.position)
            {
                _enemigo1.SetParent(null);
                transform.position = _enemigo2.position;
                _enemigo2.SetParent(_alma);
            }
            else if (transform.position != _enemigo1.position)
            {
                _enemigo2.SetParent(null);
                transform.position = _enemigo1.position;
                _enemigo1.SetParent(_alma);
            }
        }
    }
}
