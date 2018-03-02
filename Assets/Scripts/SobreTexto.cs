using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SobreTexto : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Text theText;
    public AudioSource _audioBotonSobre;
    public AudioSource _audioBotonClick;

   

    public void OnPointerEnter(PointerEventData eventData)
    {
        _audioBotonSobre.Play();
        theText.color = Color.yellow; 

    }

   /* public void Play(AudioSource ClickSound)
    {
            _audioBotonClick.Play();
    }*/

    public void OnPointerExit(PointerEventData eventData)
    {
        theText.color = Color.white; 
    }
}