using UnityEngine;

public class PlayerStoppedState : LakituState
{
    private Animator animator;

    public PlayerStoppedState(GameObject lakitu, Transform player) : base(lakitu, player)
    {
        animator = lakitu.GetComponent<Animator>();
    }

    public override void Enter()
    {
        animator.SetTrigger("Idle");
    }

    public override void Update()
    {
        Vector3 targetPosition = player.position - player.forward * 4f + Vector3.up * 2f;

        lakitu.transform.position = Vector3.Lerp(
            lakitu.transform.position,
            targetPosition,
            Time.deltaTime * 2);

        lakitu.transform.LookAt(player.position);
    }

    public override void Exit()
    {

    }
}
