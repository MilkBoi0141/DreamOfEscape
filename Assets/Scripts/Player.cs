using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float speed = 5.0f;
    [SerializeField]private bool canJump = false;
    [SerializeField]private int floorVal = 1;
    
    [SerializeField]public GameObject mainCmaera;
    [SerializeField]public Canvas mapCanvas;

    // Start is called before the first frame update
    private async void Start()
    {
        while(true)
        {
            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            if (canJump == true)
            {
                if (floorVal == 1)
                {
                    transform.position += new Vector3(0, 50, 0);
                    floorVal = 2;
                }else if(floorVal == 2)
                {
                    transform.position += new Vector3(0, -50, 0);
                    floorVal = 1;
                }
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        MovePlayer();
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
        transform.Translate(x, 0, z);
    }

    private void OnTriggerStay(Collider _other)
    {
        //ジャンプの可能不可能に関する実装
        CheckFloor checkFloor = _other.gameObject.GetComponent<CheckFloor>();
        canJump = checkFloor.existOtherStage;

        //カメラ遷移に関する実装
        mainCmaera.transform.position = _other.gameObject.transform.position + new Vector3(0, 20, -8);
    }
}
