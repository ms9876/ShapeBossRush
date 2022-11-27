using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigObjectWorld : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet_0;
    [SerializeField]
    private GameObject timerObject;
    [SerializeField]
    private GameObject timer1;
    [SerializeField]
    private GameObject rotateWorld;

    public Text timer;
    public float time;
    private float countDown;

    private void Start()
    {
        bullet_0.SetActive(true);
        timerObject.SetActive(true);
        countDown = time;
    }

    private void Update()
    {
        if (Mathf.Floor(countDown) <= 0)
        {
            bullet_0.SetActive(false);
            timerObject.SetActive(false);
            rotateWorld.SetActive(true);
            timer1.SetActive(true);
            GameObject.Find("GameManager").transform.GetChild(1).GetComponent<BulletSize>().enabled = false;
            GameObject.Find("GameManager").transform.GetChild(2).GetComponent<BulletSize>().enabled = false;
            GameObject.Find("GameManager").transform.GetChild(3).GetComponent<BulletSize>().enabled = false;
            GameObject.Find("GameManager").transform.GetChild(4).GetComponent<BulletSize>().enabled = false;
            GameObject.Find("GameManager").transform.GetChild(5).GetComponent<BulletSize>().enabled = false;


        }
        else
        {
            countDown -= Time.deltaTime;
            timer.text = Mathf.Floor(countDown).ToString();
        }
    }
}
