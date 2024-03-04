using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]private bool enableMap;
    [SerializeField]private GameObject mapCanvas;

    // Start is called before the first frame update
    void Awake()
    {
        enableMap = false;
    }

    async void Start()
    {
        while(true)
        {
            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Q));
            enableMap = !enableMap;
            mapCanvas.SetActive(enableMap);
        }
    }
}
