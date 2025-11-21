using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using DG.Tweening;


public class EnemyScript : MonoBehaviour, IDamageable
{
    public float maxHealth;

    //public List<EntitySO> enemyDataList;
    public EntitySO enemyData;
    public float health { get; set; }

    public EnemyUI enemyUI;
    public ScoreUI scoreUI;
    public MechanicGame mechanicGame;
    public Animator animator;

    public void Start()
    {
        transform.DOMove(new Vector3(5.54f, 0, 0), 2);
        mechanicGame = GameObject.Find("Manager").GetComponent<MechanicGame>();
        scoreUI = GameObject.Find("Manager").GetComponent<ScoreUI>();
        enemyUI = GetComponent<EnemyUI>();
        animator = GetComponent<Animator>();
        health = enemyData.hp;
        maxHealth = health;
    }

    public void TakeDamage(float damage)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.attack);
        health -= damage;
        enemyUI.UpdateUI();
        if (health <= 0)
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.death);
            animator.SetTrigger("death");
            scoreUI.enemyDefeatedCount++;
            scoreUI.UpdateScore(2000);
            StartCoroutine(deleteChar());
        }
    }
    private IEnumerator deleteChar()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
