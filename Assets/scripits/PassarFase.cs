using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PassarFase : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Fase2");
        }
    }    
}
