using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : BaseDialog
{
    public Text txtScore;
    public override void OnSetup(DialogParam param)
    {
        GameOverParam gameOverParam = (GameOverParam)param;
        txtScore.text = "SCORE: " + gameOverParam.score;

        base.OnSetup(param);
    }

    public void OnClickHome()
    {
        // Hien thi ra man hinh Start
        SoundManager.Instance.PlaySFX(SFXIndex.ClickFX);
        DialogManager.Instance.ShowDialog(DialogIndex.StartDialog, null);
        DialogManager.Instance.HideDialog(DialogIndex.GamePlayDialog);
        DialogManager.Instance.HideDialog(this);
    }

    public void OnClickRestart()
    {
        SoundManager.Instance.PlaySFX(SFXIndex.ClickFX);
        // Restart game
        GameManager.Instance.onRestartGame();
        DialogManager.Instance.HideDialog(this);
    }

    

}
