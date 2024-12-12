using UnityEngine;

public abstract class LakituState
{
    protected GameObject lakitu;
    protected Transform player;

    public LakituState(GameObject lakitu, Transform player)
    {
        this.lakitu = lakitu;
        this.player = player;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}