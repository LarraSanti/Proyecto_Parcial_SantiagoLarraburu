using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalRun : IMovementStrategy
{
    public void Move(PlayerMovement player)
    {
        // Ajuste para que el movimiento a la izquierda sea negativo
        float direction = player.spriteRenderer.flipX ? -1 : 1;
        player.rb2d.velocity = new Vector2(player.velocidadJugador * direction, player.rb2d.velocity.y);
        player.animator.SetBool("Run", true);
    }
}