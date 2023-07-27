using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isPlaying = false;
    public Transform transDefaultPlayer;
    public Transform transPlayer;
    private int hpPlayer;

    public List<FSMSystem> lsEnemies = new List<FSMSystem>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void OnSetup()
    {
        //lsEnemies.Clear();
        transPlayer.position = transDefaultPlayer.position;
        hpPlayer = 3;
        transPlayer.GetComponent<PlayerdataBinding>().Speed = 0;
        for(int i = 0; i < lsEnemies.Count; i++)
        {
            lsEnemies[i].gameObject.SetActive(true);
            lsEnemies[i].OnSetup();
        }
    }

    public void PlayerHurt()
    {
        hpPlayer--;
        GamePlayDialog gamePlayDialog = (GamePlayDialog)DialogManager.Instance.FindVisibleDialog(DialogIndex.GamePlayDialog);
        if(gamePlayDialog != null)
        {
            gamePlayDialog.LoseLife(hpPlayer);
        }
        gamePlayDialog.LoseLife(hpPlayer);
    }

    public void ShowDialogGameOver(GameOverParam gameOverParam)
    {
        isPlaying = false;
        DialogManager.Instance.ShowDialog(DialogIndex.GameOverDialog, gameOverParam);
    }

    public void ShowDialosVitory()
    {
        isPlaying = false;
        DialogManager.Instance.ShowDialog(DialogIndex.VictoryDialog,null);
    }

    public void onRestartGame()
    {
        OnSetup();
        // disable Loading
    }
}
