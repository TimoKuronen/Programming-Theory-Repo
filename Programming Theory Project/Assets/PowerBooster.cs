using UnityEngine;

public class PowerBooster : ItemBase
{
    [SerializeField] private float powerBoost;
    [SerializeField] private float powerDuration;

    // INHERITANCE - there are two items that both inherit from ItemBase class // 
    public override void Triggered()
    {
        StartCoroutine(PlayerManager.Instance.BoostPower(powerBoost, powerDuration));
        base.Triggered();      
    }
}
