using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTct : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (WorldManager.instance.WorldState != WorldState.BoxMoving)
        {
            this.gameObject.SetActive(false);
        }
    }
}
