using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLAYER : MonoBehaviour
{
    public float speed = 5f;
   

    private Rigidbody2D rb;

    private bool isGrounded = false;


    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");// vai reconhecer o movimento horizontal
        rb.linearVelocity = new Vector2(moveHorizontal * speed, rb.linearVelocity.y);// vai aplicar a velocidade horizontal

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, 8f), ForceMode2D.Impulse); // vai gerar o pulo 
        }
    }

     void OnCollisionEnter2D (Collision2D collision)
     {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // vai reconhecer quando o jogador estiver encostando no chao
        }

        if (collision.gameObject.CompareTag("dano")) 
        {
            SceneManager.LoadScene(0); // vai fazer o player voltar para o inicio apos tocar o inimigo
        }

     } 


     void OnCollisionExit2D(Collision2D collision)
     {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; //vai reconhecer quando o jogador nao estiver encostando no chao
        }
     }



}
