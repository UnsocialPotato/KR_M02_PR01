using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivingPlayerState : IPlayerState
{
    Player mPlayer;
    Rigidbody rbPlayer;

    public void Enter(Player player)
    {
        Debug.Log("Enter State: Diving");
        rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.AddForce(0, -5000 * Time.deltaTime, 0, ForceMode.VelocityChange);
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        if (Physics.Raycast(rbPlayer.transform.position, Vector3.down, 0.5f))
        {
            IPlayerState nextState;
            if (Input.GetKey(KeyCode.S))
            {
                nextState = new DuckingPlayerState();
            }
            else
            {
                nextState = new StandingPlayerState();
            }
            nextState.Enter(player);
        }
    }
}
