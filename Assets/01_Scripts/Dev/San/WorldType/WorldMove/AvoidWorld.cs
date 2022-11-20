using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidWorld : WorldType, WorldMove
{
    private List<Vector2> lineList = new List<Vector2>();
    private int currentIndex = 0;
    [SerializeField]
    private GameObject _line;


    public void DamageCheck()
    {



        Collider2D hit = Physics2D.OverlapCircle(PlayerTransform.position, Player.Colider.radius,0,DamageAbleLayer);
        if (hit != null)
        {
            Destroy(hit.gameObject);
            Player.TakeDamage(1);
        }
    }
    public void WorldPlay()
    {
        if (Input.GetKeyDown(LeftKey))
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = 0;
                return;
            }
            SetPos();
            Player.ViewLeft();
        }
        if (Input.GetKeyDown(RightKey))
        {
            currentIndex++;
            if (currentIndex > lineList.Count - 1)
            {
                currentIndex = lineList.Count - 1;
                return;
            }
            SetPos();
            Player.ViewRight();
        }
    }
    public void WorldSetting(Vector2[] lines)
    {
        lineList.Clear();
        foreach (Vector2 line in lines)
        {
            lineList.Add(line);
            //Instantiate(_line, line, Quaternion.identity);
        }
        currentIndex = lineList.Count / 2 + 1;
    }
    private void SetPos()
    {
        PlayerTransform.position = lineList[currentIndex];
    }
}
