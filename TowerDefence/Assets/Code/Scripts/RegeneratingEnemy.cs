using System.Collections;
using UnityEngine;

// Classe que representa um inimigo que regenera sa�de ao longo do tempo
public class RegeneratingEnemy : Health
{
    [SerializeField] private float regenerationRate = 1f; // Taxa de regenera��o de sa�de por segundo
    [SerializeField] private float maxHitPoints = 5f; // Pontos de vida m�ximos do inimigo

    private void Start()
    {
        hitPoints = maxHitPoints; // Inicializa os pontos de vida com o valor m�ximo
        StartCoroutine(RegenerateHealth()); // Inicia a coroutine para regenera��o de sa�de
    }

    private IEnumerator RegenerateHealth()
    {
        while (!isDestroyed) // Continua enquanto o inimigo n�o foi destru�do
        {
            if (hitPoints < maxHitPoints) // Verifica se os pontos de vida est�o abaixo do m�ximo
            {
                // Regenera sa�de de acordo com a taxa e o tempo passado
                hitPoints += regenerationRate * Time.deltaTime;
                hitPoints = Mathf.Min(hitPoints, maxHitPoints); // Garante que os pontos de vida n�o ultrapassem o m�ximo
            }
            yield return null; // Espera o pr�ximo frame antes de continuar
        }
    }

    // M�todo que recebe dano e o aplica � sa�de do inimigo
    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg); // Chama o m�todo base para aplicar dano
    }
}
