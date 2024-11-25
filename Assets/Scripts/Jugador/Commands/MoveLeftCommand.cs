using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftCommand : ICommand
{
    private PlayerMovement player;
    private IMovementStrategy strategy;

    public MoveLeftCommand(PlayerMovement player, IMovementStrategy strategy)
    {
        this.player = player;
        this.strategy = strategy;
    }

    public void Execute()
    {
        player.SetMovementStrategy(strategy);
        player.MoveLeft();
    }
}
