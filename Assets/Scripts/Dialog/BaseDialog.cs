using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDialog : MonoBehaviour
{
    public DialogIndex dialogIndex;
    private RectTransform RectTrans;

    private void Awake()
    {
        RectTrans = GetComponent<RectTransform>();
    }
    public virtual void Init()
    {
        
    }

    public virtual void OnSetup(DialogParam param)
    {

    }

    public void ShowDialog(DialogParam param)
    {
        gameObject.SetActive(true);
        OnSetup(param);
    }

    public void HideDialog()
    {
        gameObject.SetActive(false);
    }
}
