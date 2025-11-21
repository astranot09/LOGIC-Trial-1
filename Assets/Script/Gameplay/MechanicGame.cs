using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
public class MechanicGame : MonoBehaviour
{
    public bool playerChoose = false;
    public bool enemyChoose = false;
    public string inputPlayer;
    public string inputEnemy;

    public EnemyScript enemyScript;
    public PlayerScript playerScript;
    public CardReveal cardReveal;
    public ScoreUI scoreUI;

    public Animator animatorPlayer;
    public Animator animatorEnemy;

    public TMP_Text result;

    AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        cardReveal = GetComponent<CardReveal>();
        scoreUI = GetComponent<ScoreUI>();
        result.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!playerScript)
            playerScript = GameObject.Find("Player")?.GetComponent<PlayerScript>();
        if (!enemyScript)
            enemyScript = GameObject.FindGameObjectWithTag("Enemy")?.GetComponent<EnemyScript>();
        if (!animatorPlayer)
            animatorPlayer = GameObject.Find("Player")?.GetComponent<Animator>();
        if (!animatorEnemy)
            animatorEnemy = GameObject.FindGameObjectWithTag("Enemy")?.GetComponent<Animator>();
    }

    public void Check()
    {
        if (!playerChoose || !enemyChoose) return;

        cardReveal.cardReveal();
        scoreUI.playCount++;
        //audioManager.PlaySFX(audioManager.attack);
        switch (inputPlayer)
        {
            case "rock":
                if (inputEnemy == "rock")
                {
                    result.text = "Tie";
                    //playerScript.TakeDamage(0f);
                    //enemyScript.TakeDamage(0f);
                    StartCoroutine(resultUI("Tie"));
                    Debug.Log("Tie");
                }

                else if (inputEnemy == "paper")
                {
                    animatorEnemy.SetTrigger("attack");
                    playerScript.TakeDamage(enemyScript.enemyData.damage);
                    Debug.Log("Lose");
                    StartCoroutine(resultUI("Lose"));
                    //   animatorEnemy.SetBool("attack", false);
                }
                else
                {
                    animatorPlayer.SetTrigger("attack");
                    enemyScript.TakeDamage(playerScript.playerData.damage);
                    Debug.Log("Win");
                    StartCoroutine(resultUI("Win"));
                    //   animatorPlayer.SetBool("attack", false);
                }
                break;

            case "paper":
                if (inputEnemy == "paper")
                {
                    //playerScript.TakeDamage(0f);
                    //enemyScript.TakeDamage(0f);
                    StartCoroutine(resultUI("Tie"));
                    Debug.Log("Tie");
                }
                else if (inputEnemy == "scissor")
                {
                    animatorEnemy.SetTrigger("attack");
                    playerScript.TakeDamage(enemyScript.enemyData.damage);
                    Debug.Log("Lose");
                    StartCoroutine(resultUI("Lose"));
                    //  animatorEnemy.SetBool("attack", false);
                }
                else
                {
                    animatorPlayer.SetTrigger("attack");
                    enemyScript.TakeDamage(playerScript.playerData.damage);
                    Debug.Log("Win");
                    StartCoroutine(resultUI("Win"));
                    //   animatorPlayer.SetBool("attack", false);
                }
                break;

            case "scissor":
                if (inputEnemy == "scissor")
                {
                    //playerScript.TakeDamage(0f);
                    //enemyScript.TakeDamage(0f);
                    StartCoroutine(resultUI("Tie"));
                    Debug.Log("Tie");
                }
                else if (inputEnemy == "rock")
                {
                    animatorEnemy.SetTrigger("attack");
                    playerScript.TakeDamage(enemyScript.enemyData.damage);
                    Debug.Log("Lose");
                    StartCoroutine(resultUI("Lose"));
                    //  animatorEnemy.SetBool("attack", false);
                }
                else
                {
                    animatorPlayer.SetTrigger("attack");
                    enemyScript.TakeDamage(playerScript.playerData.damage);
                    Debug.Log("Win");
                    StartCoroutine(resultUI("Win"));
                    // animatorPlayer.SetBool("attack", false);
                }
                break;
        }
    }
    public void randomEnemyCard()
    {
        if (!enemyChoose)
        {
            int index = Random.Range(0, 102);
            index = index % 3;
            if(index == 0)
            {
                inputEnemy = "rock";
                enemyChoose = true;
            }
            if (index == 1)
            {
                inputEnemy = "paper";
                enemyChoose = true;
            }
            if (index == 2)
            {
                inputEnemy = "scissor";
                enemyChoose = true;
            }
        }
    }

    private IEnumerator resultUI(string x)
    {
        if (x == "Tie")
        {
            result.gameObject.SetActive(true);
            result.text = "Tie";
            yield return new WaitForSeconds(1);
            result.gameObject.SetActive(false);
        }
        else if (x == "Win")
        {
            result.gameObject.SetActive(true);
            result.text = "Player Win";
            yield return new WaitForSeconds(1);
            result.gameObject.SetActive(false);
        }
        else if (x == "Lose")
        {
            result.gameObject.SetActive(true);
            result.text = "Enemy Win";
            yield return new WaitForSeconds(1);
            result.gameObject.SetActive(false);
        }
    }
}

