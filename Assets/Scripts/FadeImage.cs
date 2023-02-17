using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    [Header("�ŏ�����t�F�[�h�C�����������Ă��邩�ǂ���")] public bool firstFadeInComp;

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
            return; //�t�F�[�h�C���A�t�F�[�h�A�E�g���ɐV���ȃA�N�V���������Ȃ�����
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
            return; //�t�F�[�h�C���A�t�F�[�h�A�E�g���ɐV���ȃA�N�V���������Ȃ�����
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

    //�t�F�[�h�C����
    private void FadeInUpdate()
    {
        if (timer < 1f)
        {
            img.color = new Color(1, 1, 1, 1 - timer); //���̉摜���g���̈Ӗ��iUGUI��color�͏�Z�j
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

    //�t�F�[�h�C������
    private void FadeInComplete()
    {
        img.color = new Color(1, 1, 1, 0);
        img.fillAmount = 0;
        img.raycastTarget = false; //�����蔻��off
        timer = 0.0f;
        fadein = false;
        compFadeIn = true;
    }

    //�t�F�[�h�A�E�g����
    private void FadeOutComplete()
    {
        img.color = new Color(1, 1, 1, 1);
        img.fillAmount = 1;
        img.raycastTarget = false; //�����蔻��off
        timer = 0.0f;
        fadeout = false;
        compFadeOut = true;
    }
}
