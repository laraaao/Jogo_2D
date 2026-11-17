using UnityEngine;

public class CAMERA : MonoBehaviour
{
    public Transform alvo;
    public Vector3 distancia = new Vector3(0f, 0f, -10f);
    public bool movimentoSuave = true;
    public float velocidade = 5f;

    void LateUpdate()
    {
        Vector3 PosicaoDesejada = alvo.position + distancia;

        if (movimentoSuave)
        {
            transform.position = Vector3.Lerp(transform.position, PosicaoDesejada, velocidade * Time.deltaTime);
        }
        else
        {
            transform.position = PosicaoDesejada;
        }

}   }
