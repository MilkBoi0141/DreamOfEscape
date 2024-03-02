using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]private bool enableMap = false;
    [SerializeField]private GameObject mapCanvas;

    // Start is called before the first frame update
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
