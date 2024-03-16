using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleManager : MonoBehaviour
{
    public Text pressButonText;
    public Image img;

    AudioSource snapSound;

    void Awake()
    {
        snapSound = GetComponent<AudioSource>();
    }

#pragma warning disable UNT0006 // Incorrect message signature
    async UniTask Start()
#pragma warning restore UNT0006 // Incorrect message signature
    {
        pressButonText.DOFade(0.2f, 2.0f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo);

        await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Space), cancellationToken: destroyCancellationToken);
        pressButonText.DORewind();
        snapSound.Play();

        img.DOFade(1.0f, 1.0f)
            .SetEase(Ease.Linear);
        await UniTask.Delay(2000);

        SceneManagement.ToStage1();
    }
}
