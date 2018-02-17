using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    [SerializeField]
    private GameObject _prefabProgressBar;

    [SerializeField]
    private GameObject _prefabTimerPanel;

    // Use this for initialization
    float _timeLeft = 0f;
    float _totaltime = 0f;
    bool _timerplay = false;

    ProgressBar.ProgressRadialBehaviour _progressRadialHollow;
    GameObject _timerPanel;
    //GameObject cube;

    void Start () {
        
    }

    public void createTimer()
    {
        _timerPanel = Instantiate(_prefabTimerPanel);
        _timerPanel.transform.parent = gameObject.transform;
        _timerPanel.transform.localPosition = new Vector3(0, 150, 0);
        _timerPanel.transform.localScale = new Vector3(1, 1, 1);
        _progressRadialHollow = Instantiate(_prefabProgressBar).GetComponent<ProgressBar.ProgressRadialBehaviour>();
        _progressRadialHollow.transform.parent = gameObject.transform;
        _progressRadialHollow.GetComponent<RectTransform>().position = gameObject.transform.position;
        _progressRadialHollow.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }

    public void destroyTimer()
    {
        Destroy(_progressRadialHollow.gameObject);
    }

    void Update()
    {

        if (!_timerplay)
            return;
        _timeLeft -= Time.deltaTime;
        _progressRadialHollow.SetFillerSizeAsPercentage(_timeLeft/_totaltime * 100);
        if (_timeLeft < 0)
        {
            print("Timer Ended");
            //ring ring
        }
        _timerPanel.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = _timeLeft.ToString();
    }

    public void setTimer(float timer)
    {
        _timeLeft = timer;
        _totaltime = timer;
    }

    public void startTimer()
    {
        _timerplay = true;
    }

}
