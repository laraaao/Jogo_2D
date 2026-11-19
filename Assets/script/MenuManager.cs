using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    
    public void StartGame() //inicia o jogo
    {
        SceneManager.LoadScene("Fase1"); //carrega a cena da fase 1 
    }

    
    public void QuitGame() //sai do jogo
    {
        Application.Quit(); 
    }
}
