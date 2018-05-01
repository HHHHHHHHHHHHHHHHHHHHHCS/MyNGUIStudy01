using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCD : MonoBehaviour
{
    [SerializeField]
    private float maxCDTime = 5f;

    private UISprite skillMask;
    private UILabel skillCDTime;

    private bool isCDing;
    private float timer;


    private void Awake()
    {
        UIEventListener.Get(gameObject).onClick += ClickSkillButton;
        skillMask = transform.Find("CD_Mask").GetComponent<UISprite>();
        skillCDTime = transform.Find("CD_Time").GetComponent<UILabel>();
        SetIsUsed(false);
    }

    private void Update()
    {
        if (isCDing && timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SetIsUsed(false);
            }
            else
            {
                skillMask.fillAmount = timer / maxCDTime;
                skillCDTime.text = timer.ToString("f1");
            }
        }
    }

    private void ClickSkillButton(GameObject go)
    {

        if(isCDing)
        {
            Debug.Log("还在CD");
        }
        else
        {
            SetIsUsed(true);
            Debug.Log("使用技能");
        }
    }

    private void SetIsUsed(bool bo = false)
    {
        skillMask.gameObject.SetActive(bo);
        skillCDTime.gameObject.SetActive(bo);
        isCDing = bo;
        if(bo)
        {
            timer = maxCDTime;
        }
    }
}
