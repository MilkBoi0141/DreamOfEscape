using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private GameObject mainCmaera;
    [SerializeField]private GameObject playerPoint;
    [SerializeField]private GameObject UIManager;
    [SerializeField]private GameObject flashController;
    [SerializeField]private Vector3 prevPos;
    [SerializeField]private Vector3 delta;
    [SerializeField]private float speed = 6.0f;
    [SerializeField]private float rotateSpeed = 10.0f;
    [SerializeField]private int floorVal = 1;
    [SerializeField]private bool canJump = false;
    private UIManager uIManager;
    public static bool canGoal = false;

    public Material Emittion;

    AudioSource snapSound;

    void Awake()
    {
        canGoal = false;
        snapSound = GetComponent<AudioSource>();
        uIManager = UIManager.GetComponent<UIManager>();
    }

    // Start is called before the first frame update
#pragma warning disable UNT0006 // Incorrect message signature
    private async UniTask Start()
#pragma warning restore UNT0006 // Incorrect message signature
    {
        flashController.SendMessage("DarkFlashDone");
        prevPos = transform.position;
        await UniTask.WaitUntil(() => canJump, cancellationToken: destroyCancellationToken);
        uIManager.ShowJumpUI();
        while(true)
        {
            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Space), cancellationToken: destroyCancellationToken);
            if (canJump == true)
            {
                snapSound.Play();
                flashController.SendMessage("Flash");
                if (floorVal == 1)
                {
                    transform.position += new Vector3(0, 50, 0);
                    floorVal = 2;
                    prevPos += new Vector3(0, 50, 0);
                    playerPoint.layer = 8;
                }
                else if(floorVal == 2)
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
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        //シフト押しながら移動でダッシュ
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10.0f;
        }
        else
        {
            speed = 6.0f;
        }
    }

    //プレイヤーの回転を実装
    public void RotatePlayer()
    {
        delta = transform.position - prevPos;
        prevPos = transform.position;
        if (delta.magnitude > 0.005f)
        {
        transform.forward = Vector3.Slerp(transform.forward, delta, Time.deltaTime * rotateSpeed);
        }
    }


    private async void OnCollisionEnter(Collision _col)
    {   
        if (_col.gameObject.CompareTag("Enemy"))
        {
            flashController.SendMessage("DarkFlash");
            await UniTask.Delay(250);
            SceneManagement.ToGameOver();
        }
    }

    private async void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.CompareTag("StageGoal"))
        {
            if (canGoal)
            {
                flashController.SendMessage("DarkFlash");
                await UniTask.Delay(250);
                SceneManagement.ToStageGoal();
            }
        }
        else if (_other.gameObject.CompareTag("Goal"))
        {
            if (canGoal)
            {
                flashController.SendMessage("DarkFlash");
                await UniTask.Delay(250);
                SceneManagement.ToGoal();
            }
        }

        if (_other.gameObject.CompareTag("Switch"))
        {
            if (!canGoal){
                uIManager.ShowSwitchUI();
            }
        }
    }

    private void OnTriggerStay(Collider _other)
    {
        if (_other.gameObject.CompareTag("Stage"))
        {
            CheckFloor checkFloor = _other.gameObject.GetComponent<CheckFloor>();
            canJump = checkFloor.existOtherStage;

            //カメラ遷移に関する実装
            mainCmaera.transform.position = _other.gameObject.transform.position + new Vector3(0, 20, -8);
        }
    }
}
