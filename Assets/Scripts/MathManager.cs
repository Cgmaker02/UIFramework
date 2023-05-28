using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MathManager : MonoBehaviour
{
    [SerializeField] private Text _quest1;
    [SerializeField] private Text _quest2;
    [SerializeField] private Text[] _answers;
    [SerializeField] private AudioSource _audio;
    private int _num1;
    private int _num2;
    public int[] _answer = new int[6];

    // Start is called before the first frame update
    void Start()
    {
        _quest1.text = Random.Range(0, 10).ToString();
        _num1 = int.Parse(_quest1.text);
        _quest2.text = Random.Range(0, 10).ToString();
        _num2 = int.Parse(_quest2.text);
        _answer[0] = _num1 + _num2;
        _answer[1] = _num1 + _num2 + 1;
        _answer[2] = _num1 + _num2 - 1;
        _answer[3] = _num1 + _num2 + 2;
        _answer[4] = _num1 + _num2 - 2;
        _answer[5] = _num1 + _num2 + 3;

        

        System.Random random = new System.Random();
        
        for(int i =0; i < _answers.Length; i++)
        {
            int j = random.Next(i, _answer.Length);
            var temp = _answer[i];
            _answer[i] = _answer[j];
            _answer[j] = temp;

            _answers[i].text = _answer[i].ToString();
        }

        for(int i =0; i < _answer.Length; i++)
        {
            if (_answer[i] == _num1 + _num2)
            {
                _answers[i].gameObject.GetComponentInParent<Image>().name = "TheAnswer";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ResetGame()
    {
        _audio.Play();
        SceneManager.LoadScene(1);
    }
    
}
