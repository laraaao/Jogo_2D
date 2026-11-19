using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VITORIA : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) //Detecta quando outro objeto entra em uma área de colisão 2D configurada como Trigger
    { 
        if (other.CompareTag("Player")) //Verifica se o objeto que entrou na área possui a Tag Player
        {
            SceneManager.LoadScene("Vitoria"); //carrega a cena de vitoria
        }
    }
}
