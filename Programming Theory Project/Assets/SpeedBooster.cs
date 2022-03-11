using UnityEngine;

public class SpeedBooster : ItemBase
{
    [SerializeField] private float speedBoost;
    [SerializeField] private float speedDuration;

    // INHERITANCE - there are two items that both inherit from ItemBase class // 
    public override void Triggered()
    {
        StartCoroutine(PlayerMover.Instance.BoostSpeed(speedBoost, speedDuration));
        base.Triggered();
    }
}