using UnityEngine;

public class LakituStateMachine : MonoBehaviour
{
    private LakituState currentState;
    public GameObject lakitu;
    public Transform player;

    private Vector3 lastPlayerPosition;
    private float playerSpeedThreshold = 0.1f;

    private Animator animator;

    void Start()
    {
        lastPlayerPosition = player.position;
        currentState = new PlayerStoppedState(lakitu, player);
        currentState.Enter();

        animator = lakitu.GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 playerMovement = player.position - lastPlayerPosition;
        float playerSpeed = playerMovement.magnitude / Time.deltaTime;

        if (playerSpeed > playerSpeedThreshold)
        {
            SwitchState(new PlayerMovingState(lakitu, player));
        }
        else
        {
            SwitchState(new PlayerStoppedState(lakitu, player));
        }

        currentState.Update();
        lastPlayerPosition = player.position;
    }

    private void SwitchState(LakituState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter();
    }

    void OnAnimatorMove()
    {
        if (animator != null)
        {
            Vector3 rootPosition = animator.rootPosition;
            rootPosition.y = lakitu.transform.position.y;
            lakitu.transform.position = Vector3.Lerp(lakitu.transform.position, rootPosition, Time.deltaTime * 2);
        }
    }
}
