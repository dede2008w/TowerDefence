using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Inst�ncia est�tica para permitir o acesso a BuildManager de qualquer lugar
    public static BuildManager Instance;

    [Header("References")]
    [SerializeField] private Tower[] towers; // Array de torres dispon�veis para constru��o
    private int selectedTower = 0; // �ndice da torre atualmente selecionada

    private void Awake()
    {
        // Inicializa a inst�ncia singleton para que apenas uma BuildManager exista em toda a cena
        Instance = this;
    }

    // M�todo que retorna a torre que est� atualmente selecionada
    public Tower GetselectedTower()
    {
        // Retorna a torre do array usando o �ndice da torre selecionada
        return towers[selectedTower];
    }

    // M�todo para definir qual torre deve ser a torre selecionada
    public void SetSelectedTower(int _selectedtower)
    {
        // Atribui o �ndice da torre selecionada � vari�vel selectedTower
        selectedTower = _selectedtower;
    }
}