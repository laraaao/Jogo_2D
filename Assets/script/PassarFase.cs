using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PassarFase : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other) // Detecta quando outro objeto entra no colisor 2D
    {
        if (other.CompareTag("Player"))  // Verifica se o objeto que entrou tem a tag "Player"
        {
            SceneManager.LoadScene("Fase2"); // Carrega a próxima fase
        }
    }    
}
