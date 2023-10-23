using UnityEngine;

public class DefaultSystemInput : InputHandler
{
    [SerializeField]
    private string horizontalAxisName = "Horizontal";

    [SerializeField]
    private string verticalAxisName = "Vertical";
    
    [SerializeField]
    private string fire1ButtonName = "Fire1";

    public override float GetHorizontalAxis()
    {
        return Input.GetAxis(horizontalAxisName);
    }

    public override float GetVerticalAxis()
    {
        return Input.GetAxis(verticalAxisName);
    }

    public override bool GetFire1Button()
    {
        return Input.GetButton(fire1ButtonName);
    }
}
