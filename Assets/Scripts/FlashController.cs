using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.UI;

public class FlashController : MonoBehaviour
{
    private Image img;
    // Start is called before the first frame update
    void Awake()
    {
        img = GetComponent<Image>();
        img.color = Color.clear;
    }

    // Update is called once per frame
    public void Flash()
    {
        img.DORewind();
        img.color = new Color(1, 1, 1, 1);
        img.DOFade(0, 1.0f)
            .SetEase(Ease.OutQuart);
    }

    public void DarkFlash()
    {
        img.color = new Color(0, 0, 0, 0);
        img.DOFade(1.0f, 0.1f)
            .SetEase(Ease.Linear);
    }

    public void DarkFlashDone()
    {
        img.color = new Color(0, 0, 0, 1);
        img.DOFade(0, 0.75f)
            .SetEase(Ease.OutQuart);
    }
}
