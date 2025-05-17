using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class IdleState : Istate
{
    private PlayerController player;
    public void Enter(PlayerController player) 
    {
        Debug.Log("Idle");
    }
    public void Update(PlayerController player) 
    {
        if (Physics.Raycast(player.transform.position, Vector3.down, out RaycastHit hit, 1.1f))
        {
            if (!hit.collider.CompareTag("Fild"))
            {
                player.ChangeState(new JumpState());
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            player.ChangeState(new ChargeState());
        }
    }
    public void Exit(PlayerController player) { }
}

public class JumpState : Istate
{
    private PlayerController player;
    private PlayerMove playerMove;
    public void Enter(PlayerController player)
    {
        Debug.Log("มกวม");
    }
    public void Update(PlayerController player)
    {
        if (Physics.Raycast(player.transform.position, Vector3.down, out RaycastHit hit, 1.1f))
        {
            if (hit.collider.CompareTag("Fild"))
            {
                player.ChangeState(new IdleState());
            }
        }
    }
    public void Exit(PlayerController player) { }
}

public class ChargeState : Istate
{
    private PlayerController player;
    private PlayerMove playerMove;
 
    public void Enter(PlayerController player)
    {
    }
    public void Update(PlayerController player)
    {
        if (Input.GetButton("Jump"))
        { }
            
        
        else
        {
            player.ChangeState(new IdleState());
        }
    }
    public void Exit(PlayerController player)
    {}
}
