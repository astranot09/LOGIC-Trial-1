using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour, IDamageable
{
    public float maxHealth;
    public EntitySO playerData;
    public float health { get; set; }

    public PlayerUI playerUI;

    public Animator animator;
    public void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        animator = GetComponent<Animator>();
        health = playerData.hp;
        maxHealth = health;
        playerUI.UpdateUI();
    }
    public void TakeDamage(float damage)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.attack);
        health -= damage;
        playerUI.UpdateUI();
        if (health <= 0)
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.death);
            animator.SetTrigger("death");
            GameManager.instance.loseManager();
            StartCoroutine(deleteChar());
        }
    }
    private IEnumerator deleteChar()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
