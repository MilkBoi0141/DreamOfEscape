using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField]private GameObject mainCmaera;
    [SerializeField]private GameObject playerPoint;
    [SerializeField]private Vector3 prevPos;
    [SerializeField]private Vector3 delta;
    [SerializeField]private float speed = 5.0f;
    [SerializeField]private int floorVal = 1;
    [SerializeField]private bool canJump = false;

    // Start is called before the first frame update
    private async void Start()
    {
        prevPos = transform.position;
        while(true)
        {
            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            if (canJump == true)
            {
                if (floorVal == 1)
                {
                    transform.position += new Vector3(0, 50, 0);
                    floorVal = 2;
                    prevPos += new Vector3(0, 50, 0);
                    playerPoint.layer = 8;
                }else if(floorVal == 2)
                {
                    transform.position += new Vector3(0, -50, 0);
                    floorVal = 1;
                    prevPos += new Vector3(0, -50, 0);
                    playerPoint.layer = 7;
                }
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    //プレイヤーの移動を実装
    public void MovePlayer()
    {
        //シフト押しながら移動でダッシュ
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10.0f;
        }
        else 
        {
            speed = 5.0f;
        }

        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position += new Vector3(x, 0, z);
    }

    //プレイヤーの回転を実装
    public void RotatePlayer()
    {
        delta = transform.position - prevPos;
        prevPos = transform.position;
        if (delta == Vector3.zero)
        {
            return;
        }
        transform.rotation = Quaternion.LookRotation(delta, Vector3.up);
    }

    private void OnTriggerStay(Collider _other)
    {
        if (_other.gameObject.CompareTag("Stage"))
        {
            //ジャンプの可能不可能に関する実装
            CheckFloor checkFloor = _other.gameObject.GetComponent<CheckFloor>();
            canJump = checkFloor.existOtherStage;

            //カメラ遷移に関する実装
            mainCmaera.transform.position = _other.gameObject.transform.position + new Vector3(0, 20, -8);
        }
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.CompareTag("Goal"))
        {
            SceneManagement.ToGoal();
        }
    }
}
