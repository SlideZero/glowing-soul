using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarObjeto : MonoBehaviour {

	public float _velocidadX = 0;
	public float _VelocidadY = 0;
	public float _velocidadZ = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//transform.Rotate(new Vector3(20f,30f,0f)*Time.deltaTime);	
		transform.Rotate(_velocidadX*Time.deltaTime, _VelocidadY*Time.deltaTime, _velocidadZ*Time.deltaTime, Space.World);
	}
}
