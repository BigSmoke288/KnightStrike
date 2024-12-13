using System.Collections;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public GameObject gameOverPanel; // Painel de Game Over
    public CanvasGroup gameOverCanvasGroup; // Canvas Group do Painel de Game Over
    public Animator characterAnimator; // Animador do personagem
    private bool isGameOver = false;
    void Start()
    {
        // Certifique-se de que o painel de Game Over esteja desativado inicialmente
        gameOverPanel.SetActive(false);
        gameOverCanvasGroup.alpha = 0;
    }
    public void CoroutineCaller()
    {
        StartCoroutine(ShowGameOverPanel());
    }
    public IEnumerator ShowGameOverPanel()
    {
        yield return new WaitForSeconds(2); // Aguarda o término da animação (ajuste conforme necessário)
        gameOverPanel.SetActive(true);

        // Gradualmente aumenta o alpha do Canvas Group para 1
        while (gameOverCanvasGroup.alpha < 1)
        {
            gameOverCanvasGroup.alpha += Time.deltaTime; // Ajuste a velocidade do fade
            yield return null;
        }
    }
}
