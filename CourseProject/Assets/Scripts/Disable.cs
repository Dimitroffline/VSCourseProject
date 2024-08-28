using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    [SerializeField] float cooldown = 1f;
    float timer;

    private void OnEnable()
    {
        timer = cooldown;
    }

    private void LateUpdate()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
