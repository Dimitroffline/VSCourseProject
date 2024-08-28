using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHealth = 500;
    public int currentHealth = 500;

    [SerializeField] StatusBar healthBar;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetValue(currentHealth, maxHealth);

        if(currentHealth <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
