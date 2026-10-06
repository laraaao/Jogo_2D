using UnityEngine;

public class PowerUpPuloDuplo : MonoBehaviour
{
    [Header("Configuração")]
    public float duracao = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Jogador"))
            return;

        PlayerController jogador =
            other.GetComponentInParent<PlayerController>();

        if (jogador != null)
        {
            Debug.Log("PowerUp de pulo duplo coletado!");

            jogador.AtivarPuloDuplo();

            jogador.Invoke(
                "DesativarPuloDuplo",
                duracao
            );

            Destroy(gameObject);
        }
        else
        {
            Debug.LogError(
                "PlayerController não encontrado no jogador!"
            );
        }
    }
}