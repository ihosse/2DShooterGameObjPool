using System.Collections;
using UnityEngine;

public class AIControlInput : InputHandler
{
    private float horizontalAxis;

    private void Start()
    {
        StartCoroutine(Move());
    }
    private IEnumerator Move() 
    {
        while (true)
        {
            horizontalAxis = -.5f;
            yield return new WaitForSeconds(2);
            horizontalAxis = .5f;
            yield return new WaitForSeconds(2);
        }
    }

    public override float GetHorizontalAxis()
    {
        return horizontalAxis;
    }

    public override float GetVerticalAxis()
    {
        return 0;
    }

    public override bool GetFire1Button()
    {
        return true;
    }
}
