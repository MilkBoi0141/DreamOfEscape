using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]private GameObject player;
    [SerializeField]private Animator enemyAnim;
    [SerializeField]private AudioClip attackSound;
    [SerializeField]private AudioClip staySound;    

    NavMeshAgent agent;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInParent<NavMeshAgent>();
        audioSource = GetComponentInParent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.clip = attackSound;
            audioSource.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyAnim.SetBool("isWalking", true);
            agent.SetDestination(player.transform.position);
        }
    }

    private async void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.clip = staySound;
            audioSource.Play();
            await UniTask.Delay(TimeSpan.FromSeconds(2.0f));

            //止まる実装
            enemyAnim.SetBool("isWalking", false);
            Debug.Log("stay");
            agent.SetDestination(transform.position);
        }
    }
}
