using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;            // O objeto que a c�mera seguir� (geralmente o jogador)
    public float smoothSpeed = 0.125f;  // Velocidade de suaviza��o do movimento da c�mera
    public Vector3 offset;              // Offset entre o jogador e a c�mera

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
        if (target == null) return;  // Verifica se o alvo foi atribu�do

        // Calcula a posi��o desejada da c�mera com base na posi��o do jogador e no offset
        Vector3 desiredPosition = target.position + offset;

        // Suaviza a transi��o entre a posi��o atual e a desejada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
