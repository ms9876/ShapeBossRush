using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRotateController : MonoBehaviour
{
    public GameObject obj;
    public float rotateAmount = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotate = obj.transform.eulerAngles;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rotate.z -= rotateAmount;
            Debug.Log( rotate.z);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rotate.z += rotateAmount;
            Debug.Log(rotate.z);
        }
        if (Input.GetKeyDown(KeyCode.Space))
            rotate.z = -30f;

        obj.transform.rotation = Quaternion.Euler(rotate);

        Debug.Log(obj.transform.eulerAngles);
    }
}
