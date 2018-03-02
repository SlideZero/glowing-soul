using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour {

	public Transform pauseMenu;
	public Transform player;
    public GameObject _iconoPausa;
    public GameObject _playText;

	// Use this for initialization
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Pause ();
		}
	}

    // Update is called once per frame
    public void Pause()
    {
        if (player.gameObject != null)
        {
            if (pauseMenu.gameObject.activeInHierarchy == false)
            {
                pauseMenu.gameObject.SetActive(true);
                _playText.SetActive(false);
                Time.timeScale = 0f;
                player.GetComponent<Apuntado>().enabled = false;
                _iconoPausa.SetActive(true);
            }

            else
            {
                pauseMenu.gameObject.SetActive(false);
                _playText.SetActive(true);
                Time.timeScale = 1f;
                player.GetComponent<Apuntado>().enabled = true;
                _iconoPausa.SetActive(false);
            }
        }
    }

 
	public void SceneChange (string _siguienteEscena) {
		StartCoroutine(CargarEscena(_siguienteEscena));
		Debug.Log ("Menu");
	}

	IEnumerator CargarEscena(string _siguienteEscena){
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_siguienteEscena);
        Time.timeScale = 1;
        while (!asyncLoad.isDone){
			yield return null;
		}
	}
    
	public void ExitGame () {
		Application.Quit ();
		Debug.Log ("Exit Game");
	}
}
