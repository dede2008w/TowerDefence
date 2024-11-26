using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour // Classe respons�vel por gerenciar o n�vel do jogo, controlando vari�veis globais como moeda e caminhos.
{
    public static LevelManager instance;    // Inst�ncia �nica do LevelManager para acesso global.

    public Transform startPoint;    // Ponto inicial onde o jogador ou objeto come�a no n�vel.

    public Transform[] path;    // Array contendo os pontos do caminho que o jogador ou objeto pode seguir.
    [SerializeField] public int currency;    // Quantidade de moeda ou pontos que o jogador possui.

    private void Awake()    // M�todo chamado antes do Start, para inicializar a inst�ncia global.
    {
        instance = this; // Define esta inst�ncia como a inst�ncia global da classe.
    }

    private void Start() // M�todo inicial que configura o estado do jogo quando ele come�a.
    {
        currency = 500; // Define o valor inicial da moeda para o jogador em 100.
    }

    public void IncreaseCurrency(int amount) // M�todo que aumenta o valor da moeda.
    {
        amount = 50; // Define o valor da moeda a ser adicionado como 50.
        currency += amount; // Adiciona a quantidade definida de moeda ao total atual.
    }

    public bool SpendCurrency(int amount) // M�todo que tenta reduzir a moeda se houver quantidade suficiente.
    {
        if (amount <= currency) // Verifica se o jogador tem moeda suficiente para gastar.
        {
            currency -= amount; // Subtrai a quantidade de moeda do total atual.
            return true; // Retorna verdadeiro se a transa��o foi realizada com sucesso.
        }
        else
        {
            Debug.Log("You do not have enough to purchase this item"); // Mensagem de aviso caso o jogador n�o tenha moeda suficiente.
            return false; // Retorna falso se a transa��o falhou.
        }
    }
}