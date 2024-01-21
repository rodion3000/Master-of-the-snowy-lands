using UnityEngine;

public abstract class EnemyFundamentState 
{
    public abstract void EnterState(EnemyStateManager enemy);
    public abstract void UpdaterState(EnemyStateManager enemy);
    public abstract void FixUpdaterState(EnemyStateManager enemy);
    

}
