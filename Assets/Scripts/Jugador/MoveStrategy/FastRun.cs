using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastRun : IMovementStrategy
{
    public void Move(PlayerMovement player)
    {
        player.rb2d.velocity = new Vector2(player.velocidadJugador * 1.5f, player.rb2d.velocity.y);
        player.animator.SetBool("Run", true);
    }
}