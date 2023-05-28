using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MathDraggable : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private Image _image;
    [SerializeField] private Image _dropbox;
    public Vector3 _oldPosition;
    private CanvasGroup _group;

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        _group = GetComponent<CanvasGroup>();
        _oldPosition = _image.rectTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void ResetPosition()
    {
        _image.rectTransform.localPosition = _oldPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ResetPosition();
        _image.raycastTarget = true;
        _group.blocksRaycasts = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _image.raycastTarget = false;
        _group.blocksRaycasts = false;
    }
}
