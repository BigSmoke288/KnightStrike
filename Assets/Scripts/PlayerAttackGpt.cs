using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject LeftTransform;
    public GameObject RightTransform;
    public GameObject armLeft;              // Referência para o braço esquerdo
    public GameObject armRight;             // Referência para o braço direito
    public float leftAttackDistance = 0.1f; // Distância de ataque do braço esquerdo
    public float rightAttackDistance = 0.7f; // Distância de ataque do braço direito
    public float attackDuration = 0.5f;     // Tempo que o ataque dura
    public float delayBetweenArms = 0.1f;   // Tempo entre o ataque do braço esquerdo e o direito

    private Transform LeftArmTransform;
    private Transform RightArmTransform;
    private Vector3 initialPositionLeft;
    private Vector3 initialPositionRight;
    private Collider2D armLeftCollider;
    private Collider2D armRightCollider;
    private bool isAttacking;

    void Start()
    {
        // Salva as posições iniciais dos braços
        initialPositionLeft = armLeft.transform.localPosition;
        initialPositionRight = armRight.transform.localPosition;

        // Obtém os colliders dos braços e desativa-os inicialmente
        LeftArmTransform = LeftTransform.GetComponent<Transform>();
        RightArmTransform = RightTransform.GetComponent<Transform>();
        armLeftCollider = armLeft.GetComponent<Collider2D>();
        armRightCollider = armRight.GetComponent<Collider2D>();
        armLeftCollider.enabled = false;
        armRightCollider.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && !isAttacking)  // Assume que o ataque é ativado com a barra de espaço
        {
            StartCoroutine(AttackSequence());
        }
    }

    public void AttackButton()
    {
        if (!isAttacking)  // Assume que o ataque é ativado com a barra de espaço
        {
            StartCoroutine(AttackSequence());
        }
    }

    private IEnumerator AttackSequence()
    {
        isAttacking = true;

        // Ataca com o braço esquerdo com a distância especificada
        yield return StartCoroutine(AttackArmLeft(armLeft, armLeftCollider, initialPositionLeft, LeftArmTransform, leftAttackDistance));

        // Espera um pouco antes de atacar com o braço direito
        yield return new WaitForSeconds(delayBetweenArms);

        yield return StartCoroutine(AttackArmLeft(armLeft, armLeftCollider, initialPositionLeft,LeftArmTransform, leftAttackDistance));

        yield return new WaitForSeconds(delayBetweenArms);

        // Ataca com o braço direito com a distância especificada
        yield return StartCoroutine(AttackArmRight(armRight, armRightCollider, initialPositionRight,RightArmTransform, rightAttackDistance));

        isAttacking = false;
    }

    private IEnumerator AttackArmLeft(GameObject arm, Collider2D armCollider, Vector3 initialPosition, Transform initialScale, float attackDistance)
    {

        LeftArmTransform.localScale = new Vector3(1.5f, -1.5f, 1);
        // Ativa o colisor
        armCollider.enabled = true;

        // Move o braço para frente pela distância especificada
        arm.transform.localPosition += Vector3.right * attackDistance;

        // Espera o tempo de ataque
        yield return new WaitForSeconds(attackDuration);

        // Retorna o braço à posição inicial
        arm.transform.localPosition = initialPosition;

        // Desativa o colisor
        armCollider.enabled = false;

        LeftArmTransform.localScale = new Vector3(1.5f, 1.5f, 1);

    }
    private IEnumerator AttackArmRight(GameObject arm, Collider2D armCollider, Vector3 initialPosition, Transform initialScale, float attackDistance)
    {

        RightArmTransform.localScale = new Vector3(-1.5f, -1.5f, 1);
        // Ativa o colisor
        armCollider.enabled = true;

        // Move o braço para frente pela distância especificada
        arm.transform.localPosition += Vector3.right * attackDistance;

        // Espera o tempo de ataque
        yield return new WaitForSeconds(attackDuration);

        // Retorna o braço à posição inicial
        arm.transform.localPosition = initialPosition;

        // Desativa o colisor
        armCollider.enabled = false;

        RightArmTransform.localScale = new Vector3(1.5f, 1.5f, 1);

    }
}
