using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private Text healthInfo;

    private float currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        healthInfo.text = currentHealth.ToString();
    }

	public void Heal(float health)
    {
        currentHealth += health;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Death();
        }
    }

    private void Death()
    {
        Time.timeScale = 0;
    }
}
