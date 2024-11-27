using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour // Classe que controla o menu do jogo, incluindo a exibi��o de informa��es como o valor atual de moedas.
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI; // Refer�ncia ao componente TextMeshProUGUI para mostrar o valor da moeda.
    [SerializeField] Animator animator; // Refer�ncia ao componente Animator para controlar as anima��es do menu.

    private bool ismenuOpen = true; // Vari�vel booleana que indica se o menu est� aberto ou fechado.

    public void ToggleMenu() // M�todo para alternar o estado do menu (aberto/fechado).
    {
        ismenuOpen = !ismenuOpen; // Inverte o estado atual do menu.
        animator.SetBool("MenuOpen", ismenuOpen); // Define a vari�vel "MenuOpen" do Animator de acordo com o novo estado.
    }

    private void OnGUI() // M�todo chamado para atualizar a interface gr�fica do usu�rio.
    {
        currencyUI.text = LevelManager.main.currency.ToString(); // Atualiza o texto da UI com o valor atual de moedas do LevelManager.
    }

    public void SetTower() // M�todo reservado para definir uma torre (implementa��o futura).
    {
        // M�todo a ser implementado.
    }
}