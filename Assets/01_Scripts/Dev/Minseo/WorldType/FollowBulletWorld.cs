using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowBulletWorld : MonoBehaviour
{
    [SerializeField]
    private GameObject BigObjectWorld;
    [SerializeField]
    private GameObject bullet_1;
    [SerializeField]
    private GameObject boss;
    [SerializeField]
    private GameObject timerObject;
    [SerializeField]
    private GameObject timer1;

    public Text timer2;
    public float time;
    private float countDown;

    private void Start()
    {
        countDown = time;
    }

    private void Update()
    {
        if (Mathf.Floor(countDown) <= 0)
        {
            bullet_1.SetActive(false);
            BigObjectWorld.SetActive(true);
            timerObject.SetActive(false);
            boss.SetActive(false);
        }
        else
        {
            countDown -= Time.deltaTime;
            timer2.text = Mathf.Floor(countDown).ToString();
        }
    }
}
