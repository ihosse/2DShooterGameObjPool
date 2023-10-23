using UnityEngine;

public abstract class InputHandler: MonoBehaviour 
{
    public virtual float GetHorizontalAxis() 
    {
        return 0;
    }
    public virtual float GetVerticalAxis()
    {
        return 0;
    }
    public virtual bool GetFire1Button()
    {
        return false;
    }
}
