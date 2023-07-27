using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : BaseDialog
{
    public override void OnSetup(DialogParam param)
    {

        base.OnSetup(param);
    }

    public void OnClickHome()
    {
        SoundManager.Instance.PlaySFX(SFXIndex.ClickFX);
        // Hien thi ra man hinh Start
        DialogManager.Instance.HideAllDialog();
        DialogManager.Instance.ShowDialog(DialogIndex.StartDialog, null);

    }

    public void OnClickRestart()
    {
        SoundManager.Instance.PlaySFX(SFXIndex.ClickFX);
        GameManager.Instance.onRestartGame();
        DialogManager.Instance.HideDialog(this);
    }

   
}
