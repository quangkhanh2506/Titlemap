using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayDialog : BaseDialog
{
    public List<GameObject> lsLives = new List<GameObject>();
    private float timer;
    public override void OnSetup(DialogParam param)
    {
        for(int i = 0; i < lsLives.Count; i++)
        {
            lsLives[i].SetActive(true);
        }
        base.OnSetup(param);
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }
    public void OnClickPause()
    {
        SoundManager.Instance.PlaySFX(SFXIndex.ClickFX);
        //hien ra man hinh pause
        GameManager.Instance.isPlaying = false;
        DialogManager.Instance.ShowDialog(DialogIndex.PauseDialog, null);
    }

    public void OnClickAttack()
    {
        // cho player attack
        GameManager.Instance.transPlayer.GetComponent<PlayerInput>().OnClickPlayerAttack();
    }

    public void OnClickJump()
    {
        GameManager.Instance.transPlayer.GetComponent<PlayerInput>().OnClickPlayerJump();
    }
    public void LoseLife(int playerHp)
    {

        for(int i = lsLives.Count - 1; i >= playerHp; i--)
        {
            if (lsLives[i].activeSelf)
            {
                lsLives[i].SetActive(false);
            }
            if(playerHp == 0)
            {
                // speed Run
                int curScore = 1000 - Mathf.RoundToInt(timer);
                if (curScore <= 0)
                {
                    curScore = 0;
                }

                GameManager.Instance.ShowDialogGameOver(new GameOverParam {score = Mathf.RoundToInt(timer)});
            }
        }
    }
}
