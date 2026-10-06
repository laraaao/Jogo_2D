using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 5f;

    [Header("Pulo")]
    public float forcaDoPulo = 10f;

    [Header("Dash")]
    public float velocidadeDash = 15f;
    public float duracaoDash = 0.2f;
    public float cooldownDash = 1f;

    private Rigidbody2D rb;

    // Pulo duplo
    private bool puloDuploAtivo = false;
    private int pulosRestantes = 0;

    // Dash
    private bool podeDash = true;
    private bool estaDandoDash = false;
    private float direcao = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movimentar();
        Pular();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            TentarDash();
        }
    }

    private void Movimentar()
    {
        float movimento = Input.GetAxisRaw("Horizontal");

        // Guarda a direção
        if (movimento != 0)
        {
            direcao = movimento;
        }

        // Não movimenta normalmente durante o Dash
        if (!estaDandoDash)
        {
            rb.linearVelocity = new Vector2(
                movimento * velocidade,
                rb.linearVelocity.y
            );
        }
    }

    private void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Primeiro pulo
            if (EstaNoChao())
            {
                rb.linearVelocity = new Vector2(
                    rb.linearVelocity.x,
                    forcaDoPulo
                );

                if (puloDuploAtivo)
                {
                    pulosRestantes = 1;
                }
            }

            // Segundo pulo
            else if (puloDuploAtivo && pulosRestantes > 0)
            {
                rb.linearVelocity = new Vector2(
                    rb.linearVelocity.x,
                    forcaDoPulo
                );

                pulosRestantes--;

                Debug.Log("Segundo pulo!");
            }
        }
    }

    private bool EstaNoChao()
    {
        return Mathf.Abs(rb.linearVelocity.y) < 0.01f;
    }

    private void TentarDash()
    {
        if (!podeDash)
            return;

        if (estaDandoDash)
            return;

        StartCoroutine(Dash());
    }

    private System.Collections.IEnumerator Dash()
    {
        podeDash = false;
        estaDandoDash = true;

        float tempo = 0f;

        // Remove o movimento atual
        rb.linearVelocity = Vector2.zero;

        while (tempo < duracaoDash)
        {
            rb.linearVelocity = new Vector2(
                direcao * velocidadeDash,
                0f
            );

            tempo += Time.deltaTime;

            yield return null;
        }

        // Para o jogador depois do Dash
        rb.linearVelocity = Vector2.zero;

        estaDandoDash = false;

        // Espera antes de permitir outro Dash
        yield return new WaitForSeconds(cooldownDash);

        podeDash = true;
    }

    public void AtivarPuloDuplo()
    {
        puloDuploAtivo = true;
        pulosRestantes = 1;
    }

    public void DesativarPuloDuplo()
    {
        puloDuploAtivo = false;
        pulosRestantes = 0;
    }
}
