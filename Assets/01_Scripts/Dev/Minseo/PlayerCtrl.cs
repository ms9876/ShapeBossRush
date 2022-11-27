using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public static bool _noDie = false;

    [SerializeField]
    private GameObject diePanel;
    [SerializeField]
    private GameObject boss;

    public float speed;
    public float radius;
    public Vector2 center;

    private float angle = 0;
    private float direction = -1;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            direction *= -1;
        }

        angle += Time.deltaTime * speed * direction;

        if (angle >= 360f)
        {
            angle = 0;
        }

        Vector2 pos = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        transform.position = pos.normalized * radius + center;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            diePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
