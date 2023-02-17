using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    [Header("最初からフェードインが完了しているかどうか")] public bool firstFadeInComp;

    private Image img = null;
    private int frameCount = 0;
    private bool fadein = false;
    private bool fadeout = false;
    private float timer = 0.0f;
    private bool compFadeIn = false;
    private bool compFadeOut = false;

    public void StartFadeIn()
    {
        if(fadein || fadeout)
        {
            return; //フェードイン、フェードアウト中に新たなアクションをしないため
        }
        fadein= true;
        compFadeIn= false;
        timer =0.0f;
        img.color = new Color(1, 1, 1, 1);
        img.fillAmount= 1;
        img.raycastTarget = true;
    }

    public bool IsFadeInComplete()
    {
        return compFadeIn;
    }

    public void StartFadeOut()
    {
        if (fadein || fadeout)
        {
            return; //フェードイン、フェードアウト中に新たなアクションをしないため
        }
        fadeout = true;
        compFadeOut = false;
        timer = 0.0f;
        img.color = new Color(1, 1, 1, 0);
        img.fillAmount = 0;
        img.raycastTarget = true;
    }

    public bool IsFadeOutComplete()
    {
        return compFadeOut;
    }

    void Start()
    {
        img = GetComponent<Image>();
        if (firstFadeInComp)
        {
            FadeInComplete();
        }
        else
        {
            StartFadeIn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (frameCount > 2)
        {
            if (fadein)
            {
                FadeInUpdate();
            }
            else if (fadeout)
            {
                FadeOutUpdate();
            }
        }
        ++frameCount;
    }

    //フェードイン中
    private void FadeInUpdate()
    {
        if (timer < 1f)
        {
            img.color = new Color(1, 1, 1, 1 - timer); //元の画像を使うの意味（UGUIのcolorは乗算）
            img.fillAmount = 1 - timer;
        }
        else
        {
            FadeInComplete();
        }
        timer += Time.deltaTime;
    }

    private void FadeOutUpdate()
    {
        if (timer < 1f)
        {
            img.color = new Color(1, 1, 1, timer); 
            img.fillAmount = timer;
        }
        else
        {
            FadeOutComplete();
        }
        timer += Time.deltaTime;
    }

    //フェードイン完了
    private void FadeInComplete()
    {
        img.color = new Color(1, 1, 1, 0);
        img.fillAmount = 0;
        img.raycastTarget = false; //当たり判定off
        timer = 0.0f;
        fadein = false;
        compFadeIn = true;
    }

    //フェードアウト完了
    private void FadeOutComplete()
    {
        img.color = new Color(1, 1, 1, 1);
        img.fillAmount = 1;
        img.raycastTarget = false; //当たり判定off
        timer = 0.0f;
        fadeout = false;
        compFadeOut = true;
    }
}
