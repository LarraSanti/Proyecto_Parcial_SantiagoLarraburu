using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float velocidadEnemigo = 0.5f; // Velocidad a la que el enemigo se moverá
    private bool moviendoADerecha = true; // Controla la dirección del movimiento

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damage");
            Destroy(collision.gameObject);
        }
    }

    void Start()
    {
        InvokeRepeating("CambiarDireccion", 0f, 0.5f);
    }

    void Update()
    {
        // Movimiento del enemigo basado en la dirección actual
        if (moviendoADerecha)
        {
            transform.Translate(Vector2.right * velocidadEnemigo * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * velocidadEnemigo * Time.deltaTime);
        }
    }

    void CambiarDireccion()
    {
        // Cambia la dirección del movimiento
        moviendoADerecha = !moviendoADerecha;

        // Opción: Voltear el sprite para que el enemigo mire hacia la dirección correcta
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
