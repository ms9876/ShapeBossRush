using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidWorld : WorldType, WorldMove
{
    private List<Vector2> lineList = new List<Vector2>();
    private int currentIndex = 0;
    [SerializeField]
    private string _line;


    public void DamageCheck()
    {
        Collider2D hit = Physics2D.OverlapCircle(PlayerTransform.position, Player.Colider.radius,0,DamageAbleLayer);
        if (hit != null)
        {
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
            PoolableMono lineObj = PoolManager.Instance.Pop(_line);
            lineObj.transform.position = line;
        }
        currentIndex = lineList.Count / 2;
        SetPos();
        Player.ViewRight();
    }
    private void SetPos()
    {
        PlayerTransform.position = lineList[currentIndex];
    }
    private void BossAttack(int lineNumber)
    {
        if(lineNumber < 0 || lineNumber > lineList.Count - 1)
        {
            return;
        }
        PoolableMono bullet = PoolManager.Instance.Pop("BossAttackAvoidWorld");
        bullet.transform.position = new Vector2(lineList[lineNumber].x, 0.5f);

    }
    public float BossAttackPattern(int[] lineNumber, float delay)
    {
        StartCoroutine(BossAttackCoroutine(lineNumber, delay));
        return delay * lineNumber.Length;
    }
    public float BossContinuousAttack(int[] lineNumbers, int repeat, float delay)
    {
        StartCoroutine(BossContinuousAttackCoroutine(lineNumbers, repeat, delay));
        return repeat * delay;
    }
    public float BossContinuousAttack(int lineNumber, int repeat, float delay)
    {
        StartCoroutine(BossContinuousAttackCoroutine(lineNumber, repeat, delay));
        return repeat * delay;
    }

    IEnumerator BossContinuousAttackCoroutine(int[] lineNums, int repeat, float delay)
    {
        for(int i=0; i<repeat; i++)
        {
            foreach(int lineNum in lineNums)
            {
                BossAttack(lineNum);
            }
            yield return new WaitForSeconds(delay);
        }
    }
    IEnumerator BossContinuousAttackCoroutine(int lineNum, int repeat, float delay)
    {
        for (int i = 0; i < repeat; i++)
        {
            BossAttack(lineNum);
            yield return new WaitForSeconds(delay);
        }
    }
    IEnumerator BossAttackCoroutine(int[] lineNumbers, float delay)
    {
        foreach(int lineNum in lineNumbers)
        {
            BossAttack(lineNum);
            yield return new WaitForSeconds(delay);
        }
    }
}
