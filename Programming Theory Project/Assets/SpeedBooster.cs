using UnityEngine;

public class SpeedBooster : ItemBase
{
    [SerializeField] private float speedBoost;
    [SerializeField] private float speedDuration;

    public override void Triggered()
    {
        StartCoroutine(PlayerMover.Instance.BoostSpeed(speedBoost, speedDuration));
        base.Triggered();
    }
}