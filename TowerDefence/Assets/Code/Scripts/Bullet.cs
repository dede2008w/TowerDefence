using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour // Classe Bullet: Representa um projétil que causa dano a inimigos.

{
    [SerializeField] private Rigidbody2D rb;    // Componente Rigidbody2D usado para movimentar o projétil.

    [SerializeField] private float bulletSpeed = 5f;    // Velocidade do projétil.

    [SerializeField] private int bulletDamage = 1;    // Dano causado pelo projétil ao colidir com um inimigo.

    private Transform target;    // Referência ao alvo que o projétil deve seguir.

    public void SetTarget(Transform _target)    // Método para definir o alvo do projétil.

    {
        target = _target;// Define o alvo do projétil.
    }
    private void FixedUpdate()    // Método chamado a cada quadro de física.

    {
        if (!target) return;        // Se não houver um alvo, sai do método.

        Vector2 direction = (target.position - transform.position).normalized;        // Calcula a direção do projétil em direção ao alvo e normaliza a direção.

        rb.velocity = direction * bulletSpeed;        // Define a velocidade do Rigidbody2D para mover o projétil em direção ao alvo.

    }
    private void OnCollisionEnter2D(Collision2D other)     // Método chamado quando o projétil colide com outro objeto.

    {
        other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);         // Aplica dano ao componente de saúde do objeto colidido.

        Destroy(gameObject);        // Destrói o objeto do projétil após a colisão.

    }
}