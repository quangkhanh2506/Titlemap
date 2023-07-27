using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StartDialog : BaseDialog
{
    public RectTransform rectBtnStart;
    public RectTransform rectContentBtns;

    public Image imgFace;

    public override void OnSetup(DialogParam param)
    {
        imgFace.DOFade(0, 1).OnComplete(() =>
        {
            rectContentBtns.DOAnchorPosY(-250, 1, false).OnComplete(() =>
            {
                rectBtnStart.DOAnchorPosY(0, 1, false);
            });
        }).SetDelay(1);
        rectBtnStart.DOShakeRotation(1, 30, 1, 50, true);
        rectBtnStart.DOScale(1.2f, 3).SetLoops(-1,LoopType.Yoyo);




        base.OnSetup(param);
    }

    public void OnClickStart()
    {
        SoundManager.Instance.PlaySFX(SFXIndex.ClickFX);
        imgFace.DOFade(1, 1).OnComplete(() =>
        {  
            //chuyen qua man hinh gameplay
            DialogManager.Instance.ShowDialog(DialogIndex.GamePlayDialog, null);
            DialogManager.Instance.HideDialog(this);          
            SoundManager.Instance.PlayBGM(BGMIndex.GameplayBGM);
            GameManager.Instance.OnSetup();
        });
    }

    public void OnClickShop()
    {
        SoundManager.Instance.PlaySFX(SFXIndex.ClickFX);
        //chuyen qua man hinh shop
    }
    public void OnClickRate()
    {
        SoundManager.Instance.PlaySFX(SFXIndex.ClickFX);
        //hien URL rate
        Application.OpenURL("https://www.google.com.vn/?hl=vi");
    }
    public void OnClickShare()
    {
        SoundManager.Instance.PlaySFX(SFXIndex.ClickFX);
        //hien URL share
        Application.OpenURL("https://www.youtube.com/");
    }

}
