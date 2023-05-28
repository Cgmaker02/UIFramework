using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    [SerializeField] private Text _timeText;
    private float _currentTime;

    // Start is called before the first frame update
    void Start()
    {
        _currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(_currentTime);
        _timeText.text = time.ToString(@"mm\:ss");
    }
}
