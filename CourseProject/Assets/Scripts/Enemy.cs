using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int Health = 50;
    [SerializeField] int Damage = 1;

    GameObject targetGameObject;
    Transform targetDestination;
    Character targetCharacter;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if(targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Character>();
        }

        targetCharacter.TakeDamage(Damage);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if(Health < 1) 
        {
            Destroy(gameObject);
        }
    }

    public void SetTarget(GameObject target)
    {

        targetGameObject = target;
        targetDestination = target.transform;
    }
}
