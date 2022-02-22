using UnityEngine;

public class PowerBooster : ItemBase
{
    [SerializeField] private float powerBoost;
    [SerializeField] private float powerDuration;
    public override void Triggered()
    {
        StartCoroutine(PlayerManager.Instance.BoostPower(powerBoost, powerDuration));
        base.Triggered();      
    }
}
