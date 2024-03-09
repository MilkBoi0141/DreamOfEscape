using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigationController : MonoBehaviour
{
    [SerializeField]private GameObject player;
    [SerializeField]private Animator enemyAnim;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyAnim.SetBool("isWalking", true);
            Debug.Log("walk");
            agent.SetDestination(player.transform.position);
        }
    }

    private async void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            await UniTask.Delay(TimeSpan.FromSeconds(2.0f));

            //止まる実装

            enemyAnim.SetBool("isWalking", false);
            Debug.Log("stay");
            agent.SetDestination(transform.position);
        }
    }
}
