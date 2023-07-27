 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    public Slider hpSlider;
    public int maxHP = 1;
    private int curHP;
    public Text txtNameBoss;

    public int CurHP { 
        get 
        { return curHP; }
        set
        { 
            curHP = value;
            if (curHP <= 0)
            {
                curHP = 0;
                //boss die
                GameManager.Instance.ShowDialosVitory();
            }
            hpSlider.value = (float)curHP / maxHP;
        }
    }

    public void OnSetup(int maxHP, string nameBoss)
    {
        this.maxHP = maxHP;
        CurHP = maxHP;
        hpSlider.value = 1;
        txtNameBoss.text = nameBoss;
    }

    public void SetHPBoss(int value)
    {
        CurHP -= value;
       
    }

    // Update is called once per frame
    void Update()
    {

    }
}
