using UnityEngine;

public class ITEM : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            // Adiciona ao jogador
            other.GetComponent<PLAYER>().AdicionarItem();

            // Remove o item da cena
            Destroy(gameObject);
        }
    }

}
