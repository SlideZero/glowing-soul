using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControladorEscenas : MonoBehaviour {

    public GameObject _panel;
    public GameObject _Creditos;

    void Update()
    {
        if (_Creditos.active == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _panel.SetActive(true);
                _Creditos.SetActive(false);
            }
        }
    }

    public void SiguienteEscena(string _siguienteEscena)
    {
        StartCoroutine(LoadYourAsyncScene(_siguienteEscena));
    }

    IEnumerator LoadYourAsyncScene(string _siguienteEscena)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_siguienteEscena);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }

    public void MostrarCreditos()
    {
        _panel.SetActive(false);
        _Creditos.SetActive(true);
    }
}
