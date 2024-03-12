using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleManager : MonoBehaviour
{
    public Text pressButonText;

#pragma warning disable UNT0006 // Incorrect message signature
    async UniTask Start()
#pragma warning restore UNT0006 // Incorrect message signature
    {
        pressButonText.DOFade(0.2f, 1.5f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo);

        await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Space), cancellationToken: destroyCancellationToken);

        pressButonText.DORewind();

        SceneManagement.ToMain();
    }
}
