using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expandir : MonoBehaviour {

	public float lifeTime = 3f;
	public float _speedScale = 5f;
	Vector3 _scale;


	// Use this for initialization
	void Start () {
		Invoke ("Morir", lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		_scale = transform.localScale;

		_scale.x += Time.deltaTime * _speedScale;
		_scale.y += Time.deltaTime * _speedScale;
		_scale.z += Time.deltaTime * _speedScale;

		transform.localScale = _scale;

	}

	void Morir (){
		Destroy (gameObject);
	}
}
