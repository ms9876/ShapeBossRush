using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class BoxMovingWorld : WorldType, WorldMove
{
    [SerializeField]
    private TextMeshProUGUI timeTxt;
    BoxMovingWorldData _worldData;
    int index = 0;
    int arriveIndex = 0;
    List<int> NotBlock = new List<int>();
    bool isDamaged = false;
    float returnTime = 0.2f;
    float shortDelay = 0.05f;

    int[] basicMapData =
        { 0, 1, 2, 3, 4, 5, 6,
        7, 8, 9, 10, 11, 12, 13,
        14, 15, 16, 17, 18, 19, 20,
        21, 22, 23, 24, 25, 26, 27
    };

    public void DamageCheck()
    {
        if (isDamaged)
        {
            Player.TakeDamage(1);
        }
        
    }
    public void WorldPlay()
    {
        if (Input.GetKeyDown(LeftKey))
        {
            if((index+1) % 7 != 1)
            {
                index--;
                SetPos();
            }
        }
        if (Input.GetKeyDown(RightKey))
        {
            if((index+1) % 7 != 0)
            {
                index++;
                SetPos();
            }
        }
        if (Input.GetKeyDown(UpKey))
        {
            if (!(index - 7 < 0))
            {
                index -= 7;
                SetPos();
            }
            
        }
        if (Input.GetKeyDown(DownKey))
        {
            if(!(index + 7 > _worldData.SaveBlockData.Length - 1))
            {
                index += 7;
                SetPos();
            }
        }
        if (NotBlock != null)
        {
            for (int i = 0; i < NotBlock.Count; i++)
            {
                if (index == NotBlock[i])
                {
                    ResetPos();
                    CameraManager.instance.ShakeCam(0.5f, 8f);
                }
            }
        }
        
    }

    public void WorldSetting()
    {
        PoolableMono world = PoolManager.Instance.Pop("BoxMovingWorld");
        _worldData = world.GetComponent<BoxMovingWorldData>();
        timeTxt.gameObject.SetActive(true);
        ResetPos();
    }
    public void SetPos()
    {
        PlayerTransform.position = _worldData.SaveBlockData[index].transform.position;
    }
    public void ResetPos()
    {
        index = 17;
        SetPos();
    }
    public float MapSetting(WorldData worldData)
    {
        StartCoroutine(MapSettingcoroutine(worldData));
        return worldData.time+returnTime;
    }
    IEnumerator MapSettingcoroutine(WorldData worldData)
    {
        int[] mapIndex = worldData.mapData;
        arriveIndex = worldData.arrivePoint;
        float rimitTime = worldData.time;
        ResetPos();
        yield return new WaitForSeconds(shortDelay);
        NotBlock.Clear();
        foreach(int box in basicMapData)
        {
            _worldData.SaveBlockData[box].Sprite.color = Color.black;
            NotBlock.Add(box);
        }
        foreach(int block in mapIndex)
        {
            _worldData.SaveBlockData[block].Sprite.color = Color.white;
            NotBlock.Remove(block);
        }
        _worldData.SaveBlockData[arriveIndex].Sprite.color = Color.yellow;
        float currentTime = rimitTime;
        
        while (currentTime >= 0)
        {
            yield return new WaitForEndOfFrame();
            timeTxt.text = string.Format("{0:f2}", currentTime);
            currentTime -= Time.deltaTime;
        }
        timeTxt.text = "0.00";
        CameraManager.instance.ZoomSwitchingCam(returnTime, 9, shortDelay);
        if(index != arriveIndex)
        {
            isDamaged = true;
        }
    }
    //제작 필요
    // 월드리셋, 월드맵데이터, 데미지드타일을 맵 생성으로 바꾸고 도착좌표와 시간 변수 추가하기
    
}

public struct WorldData
{
    public int[] mapData;
    public int arrivePoint;
    public float time;

    public WorldData(int[] mapData, int arrivePoint, float time)
    {
        this.mapData = mapData;
        this.arrivePoint = arrivePoint;
        this.time = time;
    }
    // 0  1  2  3  4  5  6
    // 7  8  9 10 11 12 13
    //14 15 16 17 18 19 20
    //21 22 23 24 25 26 27
}
