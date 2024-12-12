using UnityEngine;

public class LakituStateMachine : MonoBehaviour
{
    private LakituState currentState;
    public GameObject lakitu;
    public Transform player; 

    private Vector3 lastPlayerPosition;
    private float playerSpeedThreshold = 0.1f;

    void Start()
    {
        lastPlayerPosition = player.position;
        currentState = new PlayerStoppedState(lakitu, player);
        currentState.Enter();
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
}
