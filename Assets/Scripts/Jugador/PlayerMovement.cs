using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidadJugador = 2;
    public float velocidadSalto = 3;
    public Rigidbody2D rb2d;
    public Animator animator;
    public SpriteRenderer spriteRenderer; // Asegurar que esta referencia esté presente
    private IMovementStrategy movementStrategy;

    private ICommand moveRightCommand;
    private ICommand moveLeftCommand;
    private ICommand jumpCommand;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        // Inicializa las estrategias
        IMovementStrategy normalRun = new NormalRun();
        IMovementStrategy jump = new JumpMovement();

        // Inicializa los comandos con las estrategias
        moveRightCommand = new MoveRightCommand(this, normalRun);
        moveLeftCommand = new MoveLeftCommand(this, normalRun);
        jumpCommand = new JumpCommand(this, jump);
    }

    public void SetMovementStrategy(IMovementStrategy strategy)
    {
        this.movementStrategy = strategy;
    }

    public void MoveRight()
    {
        movementStrategy.Move(this);
        spriteRenderer.flipX = false;
    }

    public void MoveLeft()
    {
        movementStrategy.Move(this);
        spriteRenderer.flipX = true;
    }

    public void Jump()
    {
        movementStrategy.Move(this);
        animator.SetBool("Jump", true); // Asegurar que la animación de salto se active
    }

    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            moveRightCommand.Execute();
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            moveLeftCommand.Execute();
        }
        else
        {
            StopMoving();
        }

        if (Input.GetKey("space") && CheckGround.isGrounded)
        {
            jumpCommand.Execute();
        }

        // Verificar si el personaje está en el aire para manejar la animación de salto
        if (!CheckGround.isGrounded)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    private void StopMoving()
    {
        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        animator.SetBool("Run", false);
    }
}
