using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class Manager : MonoBehaviour
{
    [SerializeField] public GameObject[] _image;
    [SerializeField] private GameObject _grid;
    [SerializeField] private GameObject _firstReveal;
    [SerializeField] private GameObject _secondReveal;
    [SerializeField] private GameObject _firstCover;
    [SerializeField] private GameObject _secondCover;
    [SerializeField] private Card _card;
    [SerializeField] private GameObject _button1;
    [SerializeField] private GameObject _button2;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioSource _audioSource2;
    [SerializeField] private Text _winText;
    [SerializeField] private Text _timeText;
    private float _currentTime;
    private int _guess = 0;
    private int _guessRight = 0;

    // Start is called before the first frame update
    void Start()
    {
        _winText.gameObject.SetActive(false);
        _timeText.text = "0:00";
        _currentTime = 0;

        System.Random random = new System.Random();

        for(int i =0; i < 10; i++)
        {
            int j = random.Next(i, 10);
            var temp = _image[i];
            _image[i] = _image[j];
            _image[j] = temp;

            GameObject Card = Instantiate(_image[i], transform.position, Quaternion.identity);
            Card.transform.SetParent(_grid.transform);
        }
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(_currentTime);
        _timeText.text = time.ToString(@"mm\:ss") ;

        if(Input.GetMouseButtonDown(0))
        {
            {
                var temp = EventSystem.current.currentSelectedGameObject;
                if (temp != null && temp != _button1 && temp != _button2)
                {
                    Debug.Log("Card Revealed");
                    CardRevealed(temp, temp);
                }
            }
        }
    }
    public void ResetCards()
    {
        SceneManager.LoadScene(0);
    }

    public void CardRevealed(GameObject card, GameObject card2)
    {
        _guess++;
        if (_guess == 1)
        {
            _firstReveal = card;
            _firstCover = EventSystem.current.currentSelectedGameObject.GetComponent<Card>()._cover;
            Debug.Log(card);
        }
        else if(_guess == 2)
        {
            _secondReveal = card2;
            _secondCover = EventSystem.current.currentSelectedGameObject.GetComponent<Card>()._cover;
            Debug.Log(card2);
            Debug.Log("second card is active");
            StartCoroutine(CheckMatch());
            _guess = 0;
        }
        else
        {
            _guess = 0;
        }
       
    }

    IEnumerator CheckMatch()
    {
        if (_firstReveal.tag == _secondReveal.tag)
        {
            Debug.Log("Match");
            _audioSource.Play();
            _guessRight++;

            if(_guessRight == 5)
            {
                _secondCover.SetActive(false);
                _winText.gameObject.SetActive(true);
            }
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            _firstCover.SetActive(true);
            _secondCover.SetActive(true);
            Debug.Log("No Match");
        }
    }

    public void ButtonSound()
    {
        _audioSource2.Play();
    }
}
