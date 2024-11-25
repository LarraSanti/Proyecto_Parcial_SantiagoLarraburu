using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveRightCommand : ICommand
{
    private PlayerMovement player;
    private IMovementStrategy strategy;

    public MoveRightCommand(PlayerMovement player, IMovementStrategy strategy)
    {
        this.player = player;
        this.strategy = strategy;
    }

    public void Execute()
    {
        player.SetMovementStrategy(strategy);
        player.MoveRight();
    }
}