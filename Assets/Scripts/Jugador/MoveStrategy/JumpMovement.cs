using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMovement : IMovementStrategy
{
    public void Move(PlayerMovement player)
    {
        if (CheckGround.isGrounded)
        {
            player.rb2d.velocity = new Vector2(player.rb2d.velocity.x, player.velocidadSalto);
        }
    }
}
