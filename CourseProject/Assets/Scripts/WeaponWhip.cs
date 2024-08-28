using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWhip : MonoBehaviour
{
    [SerializeField] float cooldown = 4f;
    [SerializeField] GameObject leftWhip;
    [SerializeField] GameObject rightWhip;
    [SerializeField] int whipDamage = 1;
    [SerializeField] Vector2 whipAttackSize = new Vector2(4f,2f);

    Collider2D[] colliders;

    float timer;

    PlayerMovement playerMovement;

    private void Start()
    {
        timer = cooldown;
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    void Update()
    {
        timer -= Time.deltaTime; 
        if (timer < 0)
        {
            Attack();
        }
    }

    private void Attack()
    {
        timer = cooldown;

        if(playerMovement.lastHorizontalVector > 0)
        {
            rightWhip.SetActive(true);
            colliders = Physics2D.OverlapBoxAll(rightWhip.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
        else if(playerMovement.lastHorizontalVector < 0)
        {
            leftWhip.SetActive(true);
            colliders = Physics2D.OverlapBoxAll(leftWhip.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for(int i = 0; i < colliders.Length; i++)
        {
            Enemy e = colliders[i].GetComponent<Enemy>();
            if(e != null)
            {
                e.TakeDamage(whipDamage);
            }
        }
    }
}
