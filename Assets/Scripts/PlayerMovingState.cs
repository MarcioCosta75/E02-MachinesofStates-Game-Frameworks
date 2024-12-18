using UnityEngine;

public class PlayerMovingState : LakituState
{
    private Animator animator;
    private Vector3 targetPosition;
    private float followSpeed = 2.5f;
    private float heightOffset = 2.0f;
    private float distanceBehind = 4.0f;

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
        Vector3 offset = -player.forward * distanceBehind;
        targetPosition = new Vector3(player.position.x + offset.x, player.position.y + heightOffset, player.position.z + offset.z);

        lakitu.transform.position = Vector3.Lerp(
            lakitu.transform.position,
            targetPosition,
            Time.deltaTime * followSpeed);

        Vector3 lookDirection = player.position - lakitu.transform.position;
        lookDirection.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
        lakitu.transform.rotation = Quaternion.Slerp(lakitu.transform.rotation, targetRotation, Time.deltaTime * followSpeed);
    }

    public override void Exit()
    {

    }
}
