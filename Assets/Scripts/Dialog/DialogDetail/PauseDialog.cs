using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseDialog : BaseDialog
{
    public override void OnSetup(DialogParam param)
    {
        base.OnSetup(param);
    }
    public void OnClickContinue()
    {
        DialogManager.Instance.HideDialog(this);
    }
    public void OnClickRestart()
    {
        SoundManager.Instance.PlaySFX(SFXIndex.ClickFX);
        // Resart Game
        GameManager.Instance.onRestartGame();
        DialogManager.Instance.HideDialog(this);
    }
    public void OnClickHome()
    {
        SoundManager.Instance.PlaySFX(SFXIndex.ClickFX);
        // Hien thi ra man hinh Start
        DialogManager.Instance.ShowDialog(DialogIndex.StartDialog, null);
        DialogManager.Instance.HideDialog(DialogIndex.GamePlayDialog);
        DialogManager.Instance.HideDialog(this);
    }


}
