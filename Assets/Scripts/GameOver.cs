using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public GameObject Player;
	public Transform gameOverMenu;
    public GameObject _scoreController;


    // Use this for initialization
    void Start () {
        
    }

	void Update () {
		GameOverMenu ();


	}
	 
	// Update is called once per frame
	public void GameOverMenu () {
		if (Player == null) {
			gameOverMenu.gameObject.SetActive (true);
		}
	}


	public void Restart (string _RestartScene) {
		SceneManager.LoadScene (_RestartScene);
	}


}
