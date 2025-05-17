using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Istate currentState;

    void Start()
    {
        ChangeState(new IdleState());
    }

    // Update is called once per frame
    void Update()
    {
        currentState?.Update(this);
    }

    public void ChangeState(Istate newState)
    {
        currentState?.Exit(this);
        currentState = newState;
        currentState?.Enter(this);
    }


}
