using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour // Classe que representa uma �rea onde torres podem ser constru�das no jogo.
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr; // Refer�ncia ao SpriteRenderer para alterar a cor quando o mouse passa sobre o objeto.
    [SerializeField] private Color hoverColor; // Cor a ser exibida quando o mouse est� sobre o objeto.

    private GameObject tower; // Armazena a torre constru�da neste plot.
    private Color startColor; // Armazena a cor original do plot antes da mudan�a ao passar o mouse.

    private void Start() // Inicializa o script.
    {
        startColor = sr.color; // Define a cor inicial com base na cor atual do SpriteRenderer.
    }

    private void OnMouseDown() // M�todo chamado quando o jogador clica no plot.
    {
        if (tower != null) return; // Impede constru��o de uma nova torre se j� houver uma no plot.

        Tower towertobuild = BuildManager.Instance.GetselectedTower(); // Obt�m a torre selecionada para construir.
        if (towertobuild.cost > LevelManager.main.currency) // Verifica se o jogador possui moedas suficientes para construir.
        {
            Debug.Log("you cant afford this"); // Exibe uma mensagem se o jogador n�o tiver moedas suficientes.
            return;
        }

        LevelManager.main.SpendCurrency(towertobuild.cost); // Deduz o custo da torre da moeda do jogador.
        tower = Instantiate(towertobuild.prefab, transform.position, Quaternion.identity); // Instancia a torre no plot.
    }

    private void OnMouseEnter() // M�todo chamado quando o mouse passa sobre o plot.
    {
        sr.color = hoverColor; // Muda a cor do plot para a cor de hover.
    }

    private void OnMouseExit() // M�todo chamado quando o mouse sai de cima do plot.
    {
        sr.color = startColor; // Restaura a cor original do plot.
    }
}