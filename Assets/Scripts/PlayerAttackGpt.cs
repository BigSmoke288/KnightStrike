using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject LeftTransform;
    public GameObject RightTransform;
    public GameObject armLeft;              // Refer�ncia para o bra�o esquerdo
    public GameObject armRight;             // Refer�ncia para o bra�o direito
    public float leftAttackDistance = 0.1f; // Dist�ncia de ataque do bra�o esquerdo
    public float rightAttackDistance = 0.7f; // Dist�ncia de ataque do bra�o direito
    public float attackDuration = 0.5f;     // Tempo que o ataque dura
    public float delayBetweenArms = 0.1f;   // Tempo entre o ataque do bra�o esquerdo e o direito

    private Transform LeftArmTransform;
    private Transform RightArmTransform;
    private Vector3 initialPositionLeft;
    private Vector3 initialPositionRight;
    private Collider2D armLeftCollider;
    private Collider2D armRightCollider;
    private bool isAttacking;

    void Start()
    {
        // Salva as posi��es iniciais dos bra�os
        initialPositionLeft = armLeft.transform.localPosition;
        initialPositionRight = armRight.transform.localPosition;

        // Obt�m os colliders dos bra�os e desativa-os inicialmente
        LeftArmTransform = LeftTransform.GetComponent<Transform>();
        RightArmTransform = RightTransform.GetComponent<Transform>();
        armLeftCollider = armLeft.GetComponent<Collider2D>();
        armRightCollider = armRight.GetComponent<Collider2D>();
        armLeftCollider.enabled = false;
        armRightCollider.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && !isAttacking)  // Assume que o ataque � ativado com a barra de espa�o
        {
            StartCoroutine(AttackSequence());
        }
    }

    public void AttackButton()
    {
        if (!isAttacking)  // Assume que o ataque � ativado com a barra de espa�o
        {
            StartCoroutine(AttackSequence());
        }
    }

    private IEnumerator AttackSequence()
    {
        isAttacking = true;

        // Ataca com o bra�o esquerdo com a dist�ncia especificada
        yield return StartCoroutine(AttackArmLeft(armLeft, armLeftCollider, initialPositionLeft, LeftArmTransform, leftAttackDistance));

        // Espera um pouco antes de atacar com o bra�o direito
        yield return new WaitForSeconds(delayBetweenArms);

        yield return StartCoroutine(AttackArmLeft(armLeft, armLeftCollider, initialPositionLeft,LeftArmTransform, leftAttackDistance));

        yield return new WaitForSeconds(delayBetweenArms);

        // Ataca com o bra�o direito com a dist�ncia especificada
        yield return StartCoroutine(AttackArmRight(armRight, armRightCollider, initialPositionRight,RightArmTransform, rightAttackDistance));

        isAttacking = false;
    }

    private IEnumerator AttackArmLeft(GameObject arm, Collider2D armCollider, Vector3 initialPosition, Transform initialScale, float attackDistance)
    {

        LeftArmTransform.localScale = new Vector3(1.5f, -1.5f, 1);
        // Ativa o colisor
        armCollider.enabled = true;

        // Move o bra�o para frente pela dist�ncia especificada
        arm.transform.localPosition += Vector3.right * attackDistance;

        // Espera o tempo de ataque
        yield return new WaitForSeconds(attackDuration);

        // Retorna o bra�o � posi��o inicial
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

        // Move o bra�o para frente pela dist�ncia especificada
        arm.transform.localPosition += Vector3.right * attackDistance;

        // Espera o tempo de ataque
        yield return new WaitForSeconds(attackDuration);

        // Retorna o bra�o � posi��o inicial
        arm.transform.localPosition = initialPosition;

        // Desativa o colisor
        armCollider.enabled = false;

        RightArmTransform.localScale = new Vector3(1.5f, 1.5f, 1);

    }
}
