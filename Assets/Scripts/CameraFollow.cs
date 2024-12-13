using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;            // O objeto que a câmera seguirá (geralmente o jogador)
    public float smoothSpeed = 0.125f;  // Velocidade de suavização do movimento da câmera
    public Vector3 offset;              // Offset entre o jogador e a câmera

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        if (target == null) return;  // Verifica se o alvo foi atribuído

        // Calcula a posição desejada da câmera com base na posição do jogador e no offset
        Vector3 desiredPosition = target.position + offset;

        // Suaviza a transição entre a posição atual e a desejada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
