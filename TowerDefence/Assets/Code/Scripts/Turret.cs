using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour//Iatacavel // Classe Turret: Representa uma torre que ataca inimigos dentro de um determinado alcance.

{
    [SerializeField] protected float targetingRange = 5f;    // Raio de alcance da torre para identificar inimigos.

    [SerializeField] protected LayerMask enemyMask;    // Máscara de camada para identificar quais objetos são inimigos.

    [SerializeField] protected GameObject bulletPrefab;    // Prefab do projétil que a torre irá disparar.

    [SerializeField] protected Transform firingPoint;    // Ponto de onde os projéteis serão disparados.

    [SerializeField] private float bps = 1f;    // Dano por segundo (disparos por segundo).

    protected Transform target;    // Referência ao inimigo alvo.

    protected float timeUntilFire;    // Tempo até o próximo disparo.


    public virtual void Atacar()    // Método virtual para atacar. Pode ser sobrescrito em classes derivadas.

    {
        //implementação nas classes derivadas.
    }
    // Update is called once per frame
    private void Update()    // Método chamado a cada quadro para verificar e atacar inimigos.

    {
        if (target == null)        // Se não houver alvo, procura um.

        {
            FindTarget();
            return;
        }
        if (!CheckTargetIsInRange())
        {
            target = null;        // Verifica se o alvo está fora do alcance.

        }
        else
        {
            timeUntilFire += Time.deltaTime;            // Aumenta o tempo até o próximo disparo.

            if (timeUntilFire >= 1f / bps)            // Verifica se é hora de disparar.

            {
                Shoot();// Realiza o disparo.
                timeUntilFire = 0f;  // Reseta o tempo até o próximo disparo.
            }
        }
    }
    protected virtual void Shoot()    // Método protegido para disparar um projétil.

    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);        // Instancia um objeto de bala na posição do ponto de disparo.
        // Obtém o script da bala e define o alvo.
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
    }
    private bool CheckTargetIsInRange()    // Verifica se o alvo está dentro do alcance da torre.

    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }
    private void FindTarget()    // Procura por um alvo inimigo dentro do alcance usando um CircleCast.

    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);
        // Se houver inimigos detectados, define o primeiro como alvo.
        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
}
