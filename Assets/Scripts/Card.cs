using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    [SerializeField] public GameObject _cover;
    [SerializeField] public int _value;
    [SerializeField] private Card[] _cards;
    private GameObject _object;
    private Manager _manager;
    private int _choice;
   

    private void Start()
    {
        _manager = GameObject.FindObjectOfType<Manager>();
    }

    public void FlipCard()
    {
        _cover.gameObject.SetActive(false);
    }

    public void CoverCard()
    {
        _cover.gameObject.SetActive(true);
    }
}

