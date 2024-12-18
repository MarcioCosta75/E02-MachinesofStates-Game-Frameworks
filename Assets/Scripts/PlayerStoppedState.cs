using UnityEngine;

public class PlayerStoppedState : LakituState
{
    private Animator animator;
    private float hoverSpeed = 2f;
    private float hoverHeight = 0.5f;
    private float baseY;

    public PlayerStoppedState(GameObject lakitu, Transform player) : base(lakitu, player)
    {
        animator = lakitu.GetComponent<Animator>();
    }

    public override void Enter()
    {
        animator.SetTrigger("Idle");
        baseY = player.position.y + 3.0f;
    }

    public override void Update()
    {
        Vector3 targetPosition = player.position + player.forward * 3f + Vector3.up * 3f;

        targetPosition.y = baseY + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;

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
