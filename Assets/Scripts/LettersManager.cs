using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LettersManager : MonoBehaviour
{
    [SerializeField] private Text[] _letterText;
    private string[] _alphabet = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H",
    "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X",
    "Y", "Z"};



    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < _letterText.Length; i++)
        {
            _letterText[i].text = _alphabet[Random.Range(0, _alphabet.Length)].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
