using UnityEngine;

public class PlayerMovingState : LakituState
{
    private Animator animator;
    private float followSpeed = 5.0f;
    private float heightOffset = 2.0f;
    private float distanceInFront = 4.0f;
    private float tiltAngle = 10.0f;
    private float tiltSpeed = 2.0f;

    public PlayerMovingState(GameObject lakitu, Transform player) : base(lakitu, player)
    {
        animator = lakitu.GetComponent<Animator>();
    }

    public override void Enter()
    {
        animator.SetTrigger("Move");
    }

    public override void Update()
    {
        Vector3 targetPosition = player.position + player.forward * distanceInFront + Vector3.up * heightOffset;

        lakitu.transform.position = Vector3.Lerp(
            lakitu.transform.position,
            targetPosition,
            Time.deltaTime * followSpeed);

        Vector3 lookDirection = player.position - lakitu.transform.position;
        lookDirection.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection);

        targetRotation *= Quaternion.Euler(tiltAngle, 0, 0);

        lakitu.transform.rotation = Quaternion.Slerp(
            lakitu.transform.rotation,
            targetRotation,
            Time.deltaTime * tiltSpeed);
    }

    public override void Exit()
    {

    }
}
