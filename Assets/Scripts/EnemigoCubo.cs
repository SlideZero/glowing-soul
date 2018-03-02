
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoCubo : EnemigoBasico
{

    [SerializeField] protected Rigidbody _rb;
    public float _velocidad;
    protected Vector3 _direccion;
    [SerializeField] protected GameObject _jugador;

    // Use this for initialization
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _jugador = GameObject.Find("Jugador");
    }

    // Update is called once per frame
    void  Update()
    {

        if(_poseido)
        {
            SeguirPadre();
        }
        else if(!_poseido)
        {
            Mover();
        }

        
    }

    protected void Mover()
    {   

        if(!(_jugador == null))
        {
            _direccion = (_jugador.transform.position - transform.position).normalized;
            _rb.MovePosition(transform.position + _direccion * _velocidad * Time.deltaTime);
        }
        
    }

}