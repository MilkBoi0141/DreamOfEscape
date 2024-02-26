using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float _speed = 5.0f;
    [SerializeField]private bool _canJump = false;

    // Start is called before the first frame update
    private async void Start()
    {
        while(true)
        {
            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            if (_canJump == true)
            {
                transform.position += new Vector3(0, 50, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * _speed * Time.deltaTime;

        transform.Translate(x, 0, z);
    }

    void OnTriggerStay(Collider other)
    {
        CheckFloor checkFloor = other.gameObject.GetComponent<CheckFloor>();
        _canJump = checkFloor.existStage;
    }
}
