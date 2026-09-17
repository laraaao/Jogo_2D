using UnityEngine;

public class PLAYER : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");// vai reconhecer o movimento horizontal
        rb.linearVelocity = new Vector2(moveHorizontal * speed, rb.linearVelocity.y);// vai aplicar a velocidade horizontal

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse); // vai gerar o pulo 
        }

    }
}
