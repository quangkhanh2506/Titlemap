using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

    private Dictionary<DialogIndex, BaseDialog> dicDialog = new Dictionary<DialogIndex, BaseDialog>();
    public DialogIndex curDialog;
    public List<BaseDialog> lsShow = new List<BaseDialog>();

    public List<BaseDialog> lsDialog = new List<BaseDialog>();
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    public void Init(UnityAction callback)
    {
        //for(DialogIndex i = DialogIndex.PauseDialog; i < DialogIndex.Count; i++)
        //{
        //    lsDialog[(int)i].transform.SetParent(transform);

        //    RectTransform rectTrans = lsDialog[(int)i].GetComponent<RectTransform>();
        //    rectTrans.offsetMax = Vector2.zero;
        //    rectTrans.offsetMin = Vector2.zero;

        //    BaseDialog baseDialog = lsDialog[(int)i].GetComponent<BaseDialog>();
        //    baseDialog.Init();

        //    dicDialog.Add(i, lsDialog[(int)i]);
        //    lsDialog[(int)i].gameObject.SetActive(false);
        //}

        for (int i = 0; i < lsDialog.Count; i++)
        {
            lsDialog[i].transform.SetParent(transform);

            BaseDialog baseDialog = lsDialog[i].GetComponent<BaseDialog>();
            baseDialog.Init();
            
            RectTransform rectTrans = lsDialog[i].GetComponent<RectTransform>();
            rectTrans.offsetMax = Vector2.zero;
            rectTrans.offsetMin = Vector2.zero;

            dicDialog.Add(baseDialog.dialogIndex, lsDialog[i]);
            lsDialog[i].gameObject.SetActive(false);
        }
        callback.Invoke();
    }
    public void ShowDialog(DialogIndex index, DialogParam param)
    {
        BaseDialog baseDialog = dicDialog[index];
        baseDialog.ShowDialog(param);
        lsShow.Add(baseDialog);
    }

    public void HideDialog(DialogIndex index)
    {
        BaseDialog baseDialog = FindVisibleDialog(index);
        if (baseDialog != null)
        {
            baseDialog.HideDialog();
            lsShow.Remove(baseDialog);
        }
    }

    public void HideDialog(BaseDialog baseDialog)
    {
        baseDialog.HideDialog();
        lsShow.Remove(baseDialog);
    }

    public BaseDialog FindVisibleDialog(DialogIndex index)
    {
        for(int i = 0; i < lsShow.Count; i++)
        {
            if (lsShow[i].dialogIndex == index)
            {
                return lsShow[i];
            }
        }
        return null;
    }

    public void HideAllDialog()
    {
        for(DialogIndex i = 0; i < DialogIndex.Count; i++)
        {
            HideDialog(i);
        }
        lsShow.Clear();
    }

    void Start()
    {
        Init(() =>
        {
            ShowDialog(DialogIndex.StartDialog,null);
            SoundManager.Instance.PlayBGM(BGMIndex.UIBGM);
        });
        ShowDialog(DialogIndex.StartDialog, null);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowDialog(DialogIndex.GameOverDialog, new GameOverParam { score = 100 });
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShowDialog(DialogIndex.VictoryDialog,null);
        }
    }

    //public void checksingleton()
    //{

    //}
}

public enum DialogIndex
{
    PauseDialog,
    StartDialog,
    GamePlayDialog,
    GameOverDialog,
    VictoryDialog,
    Count,
}

public class DialogParam
{

}

public class GameOverParam:DialogParam
{
    public int score;
}