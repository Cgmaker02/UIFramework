using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MathDrop : MonoBehaviour, IDropHandler
{
    private Image _thisImage;
    [SerializeField] private Text _winText;
    [SerializeField] private AudioSource _audio;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("THERE YOU ARE");
        if (eventData.pointerDrag.name == "TheAnswer")
        {
            Debug.Log("I see you");
            eventData.pointerDrag.GetComponent<MathDraggable>()._oldPosition = _thisImage.rectTransform.localPosition;
            _winText.gameObject.SetActive(true);
            _audio.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _thisImage = GetComponent<Image>();
        _winText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
