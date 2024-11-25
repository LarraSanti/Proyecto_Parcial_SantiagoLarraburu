using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : ICommand
{
    private PlayerMovement player;
    private IMovementStrategy strategy;

    public JumpCommand(PlayerMovement player, IMovementStrategy strategy)
    {
        this.player = player;
        this.strategy = strategy;
    }

    public void Execute()
    {
        player.SetMovementStrategy(strategy);
        player.Jump();
    }
}