using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private Text healthInfo;
    [SerializeField] private GameObject damageFlash;
    [SerializeField]
    private GameObject deadScreen;
    [SerializeField] private GameObject infoText;

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
        StartCoroutine(flashDamageScreen());

        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Death();
        }
    }

    IEnumerator flashDamageScreen()
    {
        damageFlash.SetActive(true);
        yield return new WaitForSeconds(0.07f);
        damageFlash.SetActive(false);
    }
    private void Death()
    {
        StartCoroutine(Restart());
        Time.timeScale = 0.5f;
        infoText.SetActive(true);
        infoText.GetComponent<Text>().text = "GAME OVER";
        deadScreen.SetActive(true);
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
}
