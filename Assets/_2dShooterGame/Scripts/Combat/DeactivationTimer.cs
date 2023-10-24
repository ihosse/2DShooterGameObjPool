using System.Collections;
using UnityEngine;

public class DeactivationTimer : MonoBehaviour
{
    [SerializeField]
    private float timeToDeactivate = 1;

    private BasicPool pool;
    public void ScheduleDeactivation(BasicPool pool) 
    {
        this.pool = pool;
        StartCoroutine(Deactivate());
    }

    private IEnumerator Deactivate() 
    {
        yield return new WaitForSeconds(timeToDeactivate);
        pool.Pool.Release(this.gameObject);
    }
}
