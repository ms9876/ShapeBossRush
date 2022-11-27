using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlaySecondBoss : MonoBehaviour
{
    [SerializeField]
    private float camaraOrthSize = 8;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CameraActionLoop");
    }

    IEnumerator CameraActionLoop()
    {
        while (true)
        {
            float rdValue = Random.Range(3f, 5f);
            CameraManager.instance.ShakeCam(0.4f, rdValue);
            CameraManager.instance.ZoomSwitchingCam(0.4f, rdValue + camaraOrthSize, 0);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
