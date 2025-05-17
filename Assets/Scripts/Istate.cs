using UnityEngine;

public interface Istate
{
    public void Enter(PlayerController player) { }
    public void Update(PlayerController player) { }
    public void Exit(PlayerController player) { }
}