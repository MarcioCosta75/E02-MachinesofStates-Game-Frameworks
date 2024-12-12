using UnityEngine;

public class PlayerMovingState : LakituState
{
    private Animator animator;
    private Vector3 velocity;

    public PlayerMovingState(GameObject lakitu, Transform player) : base(lakitu, player)
    {
        animator = lakitu.GetComponent<Animator>();
        velocity = Vector3.zero;
    }

    public override void Enter()
    {
        animator.SetTrigger("Move");
    }

    public override void Update()
    {
        Vector3 targetPosition = player.position - player.forward * 4f + Vector3.up * 2f;

        lakitu.transform.position = Vector3.SmoothDamp(
            lakitu.transform.position,
            targetPosition,
            ref velocity,
            0.6f); 

        lakitu.transform.LookAt(player.position);
    }

    public override void Exit()
    {

    }
}
