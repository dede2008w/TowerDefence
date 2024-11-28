using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb; // Rigidbody do inimigo
    [SerializeField] private float moveSpeed = 2f; // Velocidade de movimento do inimigo
    [SerializeField] private int currentWorth = 50;
    private Transform target; // Alvo atual
    private int pathIndex = 0; // �ndice do caminho
    private float baseSpeed; // Velocidade base do inimigo
    

    private void Start()
    {
        baseSpeed = moveSpeed; // Armazena a velocidade base
        target = LevelManager.main.path[pathIndex]; // Define o primeiro alvo
    }

    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f) // Verifica se chegou ao alvo
        {
            pathIndex++; // Avan�a para o pr�ximo caminho

            if (pathIndex == LevelManager.main.path.Length) // Se chegou ao final do caminho
            {
                OnMorte();
                LevelManager.main.GameOver();
                EnemySpawner.onEnemyDestroy.Invoke(); // Notifica que o inimigo foi destru�do
                Destroy(gameObject); // Remove o inimigo da cena
                return;
            }
            else
            {
                target = LevelManager.main.path[pathIndex]; // Atualiza o alvo
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized; // Calcula a dire��o
        rb.velocity = direction * moveSpeed; // Move o inimigo
    }

    public void UpdateSpeed(float newSpeed) // Atualiza a velocidade do inimigo
    {
        moveSpeed = newSpeed;
    }

    public void ResetSpeed() // Reseta a velocidade do inimigo
    {
        moveSpeed = baseSpeed;


    }

    

    // M�todo chamado quando o inimigo morre
    public virtual void OnMorte()
    {
        EnemySpawner.onEnemyDestroy.Invoke(); // Invoca evento de destrui��o do inimigo
        Destroy(gameObject); // Destroi o objeto inimigo
        LevelManager.main.IncreaseCurrency(currentWorth); // Aumenta a moeda do jogador
    }
    
}