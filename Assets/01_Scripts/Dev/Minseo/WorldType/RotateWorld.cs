using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateWorld : WorldType
{
    [SerializeField]
    private GameObject Clear;
    [SerializeField]
    private GameObject timerObject;
    [SerializeField]
    private GameObject map;
    [SerializeField]
    private GameObject rotate;
    [SerializeField]
    private GameObject player;

    public Text timer;
    public float time;
    private float countDown;

    private void Start()
    {
        rotate.SetActive(true);
        countDown = time;
    }

    private void Update()
    {
        if(Mathf.Floor(countDown) <= 0)
        {
            Clear.SetActive(true);
            timerObject.SetActive(false);
            map.SetActive(false);
            player.SetActive(false);
        }
        else
        {
            countDown -= Time.deltaTime;
            timer.text = Mathf.Floor(countDown).ToString();
        }
    }
}
