using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBar : MonoBehaviour
{
    [SerializeField] Transform bar;

    public void SetValue(int current, int max)
    {
        float value = (float)current / max;

        if (value < 0f)
        {
            value = 0f;
        }

        bar.transform.localScale = new Vector3(value, 1f, 1f);
    }
}
