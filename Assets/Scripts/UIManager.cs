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
    [SerializeField]private Image jumpImage;
    [SerializeField]private Image enemyImage;

    // Start is called before the first frame update
    async void Start()
    {
        startImage.DOFade(0.7f, 1.5f)
            .SetEase(Ease.InQuart);
        await UniTask.Delay(3500);
        startImage.DOFade(0.0f, 1.5f);
    }

    public async void ShowSwitchUI()
    {
        switchImage.DOFade(0.7f, 1.0f)
            .SetEase(Ease.InQuart);
        await UniTask.Delay(3500);
        switchImage.DOFade(0.0f, 1.5f);
    }

    public async void ShowJumpUI()
    {
        jumpImage.DOFade(0.7f, 1.0f)
            .SetEase(Ease.InQuart);
        await UniTask.Delay(3500);
        jumpImage.DOFade(0.0f, 1.5f);
    }

    public async void EnemyUI()
    {
        enemyImage.DOFade(0.7f, 1.0f)
            .SetEase(Ease.InQuart);
        await UniTask.Delay(3500);
        enemyImage.DOFade(0.0f, 1.5f);
    }
}
