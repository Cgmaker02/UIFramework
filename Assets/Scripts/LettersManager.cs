using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LettersManager : MonoBehaviour
{
    [SerializeField] private Text[] _letterText;
    [SerializeField] private AudioSource _audioClick;
    private int[] _answers = new int[4];
    private int _correctAnswer = 100;




    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _letterText.Length; i++)
        {
            _letterText[i].text = Random.Range(10, 99).ToString();
            _answers[i] = int.Parse(_letterText[i].text);
        }

        for(int i = 0; i < _answers.Length; i++)
        {
            if (_answers[i] < _correctAnswer)
            {
                _correctAnswer = _answers[i];
            }
        }
        Debug.Log(_correctAnswer);
        for(int i = 0; i < _answers.Length; i++)
        {
            if (_answers[i] == _correctAnswer)
            {
                _letterText[i].gameObject.GetComponentInParent<Image>().name = "TheAnswer";
            }
        }
    }

    public void ResetGame()
    {
        _audioClick.Play();
        SceneManager.LoadScene(2);
    }
}
