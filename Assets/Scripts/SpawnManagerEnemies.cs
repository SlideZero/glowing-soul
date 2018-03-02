using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerEnemies : MonoBehaviour {

	private float _UbiacionDeSpawn = 0;
	[Header ("Enemies Prefabs")]
	public GameObject[] Enemies;
    private int _puntaje;


	[Header ("Atributos")]

	public float spawnTime = 3f;
	private float _timerSpawn = 0;
	public Vector3 spawnPositionMin;
	public Vector3 spawnPositionMax;

	private Vector3 spawnPosition;



	// Use this for initialization
	void Start () {
		//InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

    private void Update()
    {
    	if(_timerSpawn < spawnTime)
    	{
    		_timerSpawn += Time.deltaTime;
    	}else{

    		Spawn();
    		_timerSpawn = 0;
    	}

        _puntaje = GetComponent<ControladorEscena>().EnviarPuntos();
    }

    // Update is called once per frame
    void Spawn () {
		//spawnPositionMin.x = Random.Range (-17, 17);
		spawnPositionMin.y = 0;
		//spawnPositionMin.z = Random.Range (-17, 17);

		_UbiacionDeSpawn = Random.Range (0, 4);

		if (_UbiacionDeSpawn == 0) // cuando x es menor
		{
			spawnPosition.x = spawnPositionMin.x;
			spawnPosition.z = Random.Range (spawnPositionMin.z, spawnPositionMax.z);
		} 
		else if (_UbiacionDeSpawn == 1) // cuando x es mayor
		{
			spawnPosition.x = spawnPositionMax.x;
			spawnPosition.z = Random.Range (spawnPositionMin.z, spawnPositionMax.z);
		}
		else if (_UbiacionDeSpawn == 2) // cuando z es menor
		{
			spawnPosition.z = spawnPositionMin.z;
			spawnPosition.x = Random.Range (spawnPositionMin.x, spawnPositionMax.x);
		}
		else if (_UbiacionDeSpawn == 3) // cuando z es mayor
		{
			spawnPosition.z = spawnPositionMax.z;
			spawnPosition.x = Random.Range (spawnPositionMin.x, spawnPositionMax.x);
		}

		//Instantiate(Enemies[Random.Range(0,3)], spawnPosition, Quaternion.identity);
		AlgoritmoSpawn();
		
			
	}

	void AlgoritmoSpawn(){

		if(_puntaje < 100)
		{	
			spawnTime = 2.5f;
			if(Random.Range(0,100) < 60)
			{
				Instantiate(Enemies[0], spawnPosition, Quaternion.identity);
			}else
			{
				Instantiate(Enemies[1], spawnPosition, Quaternion.identity);
			}
		}else if(_puntaje < 200)
		{
			spawnTime = 2f;
			if(Random.Range(0,100) < 60)
			{
				Instantiate(Enemies[0], spawnPosition, Quaternion.identity);
			}else
			{
				Instantiate(Enemies[1], spawnPosition, Quaternion.identity);
			}
		}else if(_puntaje < 300)
		{
			spawnTime = 1.5f;
			if(Random.Range(0,100) < 50)
			{
				Instantiate(Enemies[0], spawnPosition, Quaternion.identity);
			}else if(Random.Range(0,100) < 80)
			{
				Instantiate(Enemies[2], spawnPosition, Quaternion.identity);
			}else
			{
				Instantiate(Enemies[1], spawnPosition, Quaternion.identity);
			}
		}else if(_puntaje < 450)
		{
			spawnTime = 1f;
			if(Random.Range(0,100) < 40)
			{
				Instantiate(Enemies[0], spawnPosition, Quaternion.identity);
			}else if(Random.Range(0,100) < 70)
			{
				Instantiate(Enemies[2], spawnPosition, Quaternion.identity);
			}else if (Random.Range(0, 100) < 80)
            {
				Instantiate(Enemies[1], spawnPosition, Quaternion.identity);
			}
            else
            {
                Instantiate(Enemies[3], spawnPosition, Quaternion.identity);
            }
        }
        else if (_puntaje >= 450)
        {
            spawnTime = 0.5f;
            if (Random.Range(0, 100) < 40)
            {
                Instantiate(Enemies[0], spawnPosition, Quaternion.identity);
            }
            else if (Random.Range(0, 100) < 70)
            {
                Instantiate(Enemies[2], spawnPosition, Quaternion.identity);
            }
            else if (Random.Range(0, 100) < 80)
            {
                Instantiate(Enemies[1], spawnPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(Enemies[3], spawnPosition, Quaternion.identity);
            }
        }
    }
}
