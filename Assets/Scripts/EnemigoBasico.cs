using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBasico : MonoBehaviour {

    public bool _poseido = false;
    public string _color;
    public string _tipo;
    private int puntos;
    public GameObject _muerteEnemigo;
    AudioSource _audioMuerte;

    private void Start()
    {
        _muerteEnemigo = GameObject.Find("ExplosionEnemigo");
        _audioMuerte = _muerteEnemigo.GetComponent<AudioSource>();

        if (_tipo == "Cubo")
            puntos = 10;
        else if (_tipo == "Dode")
            puntos = 20;
        else if (_tipo == "Piramide")
            puntos = 30;
        else if (_tipo == "Dona")
            puntos = 40;
    }

    private void Update()
    {
        if (_poseido)
        {   
            SeguirPadre();
        }
    }

    public void Poseer()
    {
        _poseido = true;
        
    }

    public void Desposeer()
    {
        _poseido = false;
        
    }

    protected void SeguirPadre(){

         if(!(transform.parent == null))
            transform.position = transform.parent.transform.position;
    }

    protected void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bala" && _poseido == false)
        {
            GameObject.Find("GameManager").GetComponent<ControladorEscena>().SubirPuntos(puntos);
            _audioMuerte.Play();
            Destroy(gameObject);
        }
    } 

}
