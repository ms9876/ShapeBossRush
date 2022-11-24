using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    public Image _color;

    private void Start()
    {
        _color = GetComponent<Image>();

        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            _color.color = Color.blue;

            yield return new WaitForSeconds(0.1f);

            _color.color = Color.white;

            yield return new WaitForSeconds(0.1f);
        }
    }
}