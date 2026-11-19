using UnityEngine;

public class CAMERA : MonoBehaviour
{
    public Transform alvo; // Define o objeto que será seguido
    public Vector3 distancia = new Vector3(0f, 0f, -10f); // Define a distância entre a câmera e o alvo
    public bool movimentoSuave = true; // Define se o movimento da câmera será suave ou nao
    public float velocidade = 5f; // Define a velocidade com que a câmera se aproxima da posição desejada

    void LateUpdate() 
    {
        Vector3 PosicaoDesejada = alvo.position + distancia; // Calcula a posição em que a câmera deve ficar somando o alvo + a distancia

        if (movimentoSuave) // Move a câmera suavemente da posição atual até a posição desejada
        {
            transform.position = Vector3.Lerp(transform.position, PosicaoDesejada, velocidade * Time.deltaTime);
        }
        else  // Se o movimento suave estiver desativado, a câmera vai diretamente para a posição desejada
        {
            transform.position = PosicaoDesejada;
        }

}   }
