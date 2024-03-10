using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cysharp.Threading.Tasks;

public class UIManager : MonoBehaviour
{
    [SerializeField]private Image startImage;
    [SerializeField]private Image switchImage;

    // Start is called before the first frame update
    async void Start()
    {
        startImage.DOFade(1.0f, 2.5f)
            .SetEase(Ease.InQuart);
        
        await UniTask.Delay(5000);

        startImage.DOFade(0.0f, 1.5f);
    }

    public async void ShowSwitchUI()
    {
        switchImage.DOFade(1.0f, 1.0f)
            .SetEase(Ease.InQuart);
        
        await UniTask.Delay(4000);

        switchImage.DOFade(0.0f, 1.5f);
    }
}
