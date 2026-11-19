using UnityEngine;
using UnityEngine.SceneManagement; // Permite controlar as cenas do jogo
public class MenuScene : MonoBehaviour
{
    public GameObject painelPause;   // Referência ao painel de pause
    public GameObject painelGameOver;     // Referência ao painel de game over

    bool pausado = false; // Variável que verifica se o jogo está pausado
    bool jogoAcabou = false; // verifica se o jogo terminou.


    void Start()
    {
        painelPause.SetActive(false);
        painelGameOver.SetActive(false); //painel esta desativado
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Verifica se o jogador pressionou a tecla ESC
        {
            if (pausado)
            {
                Continuar(); // se estiver pausado, chama função de continuar
            }
            else
            {
                Pausar();  // se estiver nao esticer, chama funçao de pausar
            }
        }
    }

    public void Pausar()
    {
        if (jogoAcabou == false)   // Só permite pausar se o jogo ainda não tiver acabado
        {
            pausado = true;  //indica que esta pausado
            painelPause.SetActive(true); //tela de pause aparece
            Time.timeScale = 0f; //congela o tempo do jogo, pausando sua execução
        }
    }

    public void Continuar() //permite continuar o jogo
    {
        pausado = false; //pause esta desativado
        painelPause.SetActive(false); //painel de pause é desativado
        Time.timeScale = 1f; //continua o jogo
    }

    public void MostrarGameOver() // mostra a tela de game over quando encosta no inimigo ou obstaculo
    {
        jogoAcabou = true; //indica que o jogo acabou 
        painelGameOver.SetActive(true); //painel de gameover aparece 
        Time.timeScale = 0f; //conegela o jogo
    }

    public void Reiniciar() //pemite reiniciar o jogo 
    {
        Time.timeScale = 1f; // Restaura o tempo antes de carregar a cena.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarrega a cena atual, reiniciando a fase
    }

    public void VoltarMenu() //responsável por voltar ao menu
    {
        Time.timeScale = 1f; // Restaura o tempo normal do jogo
        SceneManager.LoadScene(0);  // Carrega a cena de menu
    }

    
}
