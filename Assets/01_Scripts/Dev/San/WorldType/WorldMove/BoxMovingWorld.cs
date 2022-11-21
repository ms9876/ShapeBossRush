using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovingWorld : WorldType, WorldMove
{
    BoxMovingWorldData _worldData;
    int index = 0;
    List<int> damageLists = new List<int>();
    float time = 3f;
    float returnTime = 1f;
    float shortReturntime = 0.2f;
    float delay = 0.3f;
    float shortDelay = 0.05f;

    

    public void DamageCheck()
    {
        
        
    }

    public void WorldPlay()
    {
        if (Input.GetKeyDown(LeftKey))
        {
            if((index+1) % 7 != 1)
            {
                index--;
            }
        }
        if (Input.GetKeyDown(RightKey))
        {
            if((index+1) % 7 != 0)
            {
                index++;
            }
        }
        if (Input.GetKeyDown(UpKey))
        {
            if (!(index - 7 < 0))
            {
                index -= 7;
            }
            
        }
        if (Input.GetKeyDown(DownKey))
        {
            if(!(index + 7 > _worldData.SaveBlockData.Length - 1))
            {
                index += 7;
            }
        }
        if (damageLists != null)
        {
            for (int i = 0; i < damageLists.Count; i++)
            {
                if (index == damageLists[i])
                {
                    index = 17;
                }
            }
        }
        SetPos();
    }

    public void WorldSetting()
    {
        PoolableMono world = PoolManager.Instance.Pop("BoxMovingWorld");
        _worldData = world.GetComponent<BoxMovingWorldData>();
        index = 17;
        SetPos();
    }
    public void SetPos()
    {
        PlayerTransform.position = _worldData.SaveBlockData[index].transform.position;
    }
    public float DamagedTiles(int[] index)
    {
        StartCoroutine(DamagedTilescoroutine(index));
        return returnTime;
    }
    IEnumerator DamagedTilescoroutine(int[] index)
    {
        float currentTime = 0f;
        while (currentTime < time)
        {
            yield return new WaitForEndOfFrame();
            for (int i=0; i<index.Length; i++)
            {
                Color color = Color.white;
                color.r = Mathf.Lerp(Color.white.r, Color.red.r, currentTime / time);
                color.g = Mathf.Lerp(Color.white.g, Color.red.g, currentTime / time);
                color.b = Mathf.Lerp(Color.white.b, Color.red.b, currentTime / time);
                _worldData.SaveBlockData[index[i]].Sprite.color = color;
                currentTime += Time.deltaTime;
            }
        }
        for (int i = 0; i < index.Length; i++)
        {
            _worldData.SaveBlockData[index[i]].Sprite.color = Color.red;
        }
        yield return new WaitForSeconds(delay);
        for(int i=0; i<index.Length; i++)
        {
            _worldData.SaveBlockData[index[i]].Sprite.color = Color.black;
            damageLists.Add(index[i]);
        }
        yield return new WaitForSeconds(delay);
        for (int i = 0; i < index.Length; i++)
        {
            _worldData.SaveBlockData[index[i]].Sprite.color = Color.white;
        }
    }
    //제작 필요
    // 월드리셋, 월드맵데이터, 데미지드타일을 맵 생성으로 바꾸고 도착좌표와 시간 변수 추가하기
    
}
