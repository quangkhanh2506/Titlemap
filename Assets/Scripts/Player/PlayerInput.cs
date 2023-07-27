using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 dir;
    public PlayerdataBinding playerdataBinding;
    public PlayerMoment PlayerMoment;
    private bool isplayingFootstep = false;
    public VariableJoystick Joystick;

    public Transform DistanceAttack;
    public float distanceAttack = 1f;
    public int attackDamage = 1;
    public LayerMask enemyLayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init()
    {
        playerdataBinding = GetComponent<PlayerdataBinding>();
        PlayerMoment = GetComponent<PlayerMoment>();
    } 

    // Update is called once per frame
    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal") + Joystick.Horizontal;
        dir.y = Input.GetAxisRaw("Vertical") + Joystick.Vertical;

        playerdataBinding.Speed = dir.magnitude;

        if (dir.magnitude > 0)
        {
            if (!isplayingFootstep)
            {
                isplayingFootstep = true;
                SoundManager.Instance.PlaySFX(SFXIndex.FootStepFX, true);
            }
        }
        else
        {
            isplayingFootstep = false;
            SoundManager.Instance.StopSFX(SFXIndex.FootStepFX);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayerMoment.Jump();
            playerdataBinding.Jump = true;
        }
        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    playerdataBinding.Attack = true;
        //    Collider2D[] hit = Physics2D.OverlapCircleAll(DistanceAttack.position, distanceAttack, enemyLayers);
        //    foreach (Collider2D enemy in hit)
        //    {
        //        Debug.Log("We hit " + enemy.name);
        //        if (enemy.name == "Dragon (1)")
        //        {
        //            enemy.GetComponent<BossUI>().SetHPBoss(attackDamage);
        //        }
        //        else if(enemy.name == "blast(Clone)")
        //        {
        //            enemy.GetComponent<Blast>().DestroyBlast();
        //        }
        //        else
        //        {
        //            enemy.GetComponent<EmerySystem>().EneryDie();
        //        }
        //    }
        //}
    }

    public void OnClickPlayerJump()
    {
        PlayerMoment.Jump();
        playerdataBinding.Jump = true;
    }

    public void OnClickPlayerAttack()
    {
        playerdataBinding.Attack = true;
        Collider2D[] hit = Physics2D.OverlapCircleAll(DistanceAttack.position, distanceAttack,enemyLayers);
        foreach(Collider2D enemy in hit)
        {
            Debug.Log("We hit " + enemy.name);
            if (enemy.name == "Dragon (1)")
            {
                enemy.GetComponent<BossUI>().SetHPBoss(attackDamage);
            }
            else if (enemy.name == "blast(Clone)")
            {
                enemy.GetComponent<Blast>().DestroyBlast();
            }
            else
            {
                enemy.GetComponent<EmerySystem>().EneryDie();
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if(DistanceAttack == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(DistanceAttack.position, distanceAttack);
    }
    
}
