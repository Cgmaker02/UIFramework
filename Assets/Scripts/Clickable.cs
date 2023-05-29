using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Text _winText;
    [SerializeField] private AudioSource _audio;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.pointerClick.name == "TheAnswer")
        {
            _winText.text = "Correct";
            _audio.Play();
        }
        else
        {
            _winText.text = "Wrong Answer";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
