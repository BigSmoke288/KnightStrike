using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; // Vida máxima do jogador
    public int score = 0; // Pontuação do jogador
    public TextMeshProUGUI scoreText; // Referência ao texto de pontuação
    public Image[] healthImages; // Array de imagens para representar a vida
    public Sprite fullHeartSprite; // Sprite para vida cheia
    public Sprite emptyHeartSprite; // Sprite para vida vazia
    public GameObject PainelGameOver; // Painel de Game Over
    public Animator animator;

    public GameOverPanel gameOverPanel;

    private int currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth; // Inicializa a vida 
        UpdateHealthUI(); // Atualiza as imagens da vida
        UpdateScoreUI(); // Atualiza a pontuação na UI

        animator = GetComponent<Animator>();

    }
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString(); 
        }
    }
    public void AumentaScore(int total)
    {
        score += total;
        UpdateScoreUI();
        Debug.Log("Pontuação: " + score);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Vida do jogador: " + currentHealth);

        if (currentHealth <= 0 )
        {
            Die();
        }
        animator.SetTrigger("Hit");
        UpdateHealthUI();

        if (gameOverPanel != null)
        {
            StartCoroutine(gameOverPanel.ShowGameOverPanel());
        }
    }

    private void Die()
    {
        Debug.Log("O jogador morreu!");
        // Pausa o jogo
        Time.timeScale = 0;
        // Ativa o painel de Game Over
        if (PainelGameOver != null)
        {
            PainelGameOver.SetActive(true);
        }

    }
    
    private void UpdateHealthUI()
    {
        for (int i = 0; i < healthImages.Length; i++)
        {
            if (i < currentHealth)
            {
                healthImages[i].sprite = fullHeartSprite; // Mostra vida cheia
            }
            else
            {
                healthImages[i].sprite = emptyHeartSprite; // Mostra vida vazia
            }
        }
    }
}
