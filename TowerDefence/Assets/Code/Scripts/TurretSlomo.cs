using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TurretSlomo : Turret // Classe TurretSlomo: Representa uma torre que reduz a velocidade dos inimigos.

{

    [SerializeField] private float aps = 4f;    // Taxa de ataques por segundo da torre.

    [SerializeField] private float FreezeTime = 1f;    // Duração do efeito de congelamento em segundos.


    // Start is called before the first frame update
    private void Update()    // Método chamado a cada quadro para verificar se deve congelar inimigos.

    {
        timeUntilFire += Time.deltaTime;        // Aumenta o tempo até o próximo disparo.

        if (timeUntilFire >= 1f / aps)        // Verifica se é hora de aplicar o efeito de congelamento.

        {
            FreezeEnemies();// Aplica o efeito de congelamento aos inimigos.
            timeUntilFire = 0f;// Reseta o tempo até o próximo disparo.
        }

    }
    private void FreezeEnemies() // Método que congela inimigos dentro do alcance da torre.
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);         // Realiza um CircleCast para detectar inimigos dentro do alcance.

        if (hits.Length > 0)        // Se houver inimigos detectados, aplica o efeito de congelamento.

        {
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];

                EnemyMovement em = hit.transform.GetComponent<EnemyMovement>();                // Obtém o componente de movimento do inimigo.

                em.UpdateSpeed(0.5f);                // Reduz a velocidade do inimigo.

                StartCoroutine(ResetEnemySpeed(em));                // Inicia a corrotina para resetar a velocidade após o tempo de congelamento.

            }
        }
    }
    private IEnumerator ResetEnemySpeed(EnemyMovement em)     //reseta a velocidade do inimigo após o tempo de congelamento.

    {
        yield return new WaitForSeconds(FreezeTime);        // Espera pelo tempo de congelamento.

        em.ResetSpeed();        // Reseta a velocidade do inimigo ao seu valor original.

    }
}