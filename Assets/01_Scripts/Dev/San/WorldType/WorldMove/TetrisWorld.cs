using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisWorld : WorldType, WorldMove
{

    public void DamageCheck()
    {
        Collider2D hit = Physics2D.OverlapBox(Player.Colider.bounds.center,
            Player.Colider.bounds.size,
            0,
            DamageAbleLayer);
        if (hit != null)//블럭이 바닥에 닿았는지 확인하는 코드 필요
        {
            Destroy(hit.gameObject);
            Player.TakeDamage(1);
        }
    }

    public void WorldPlay()
    {
        
    }
}
