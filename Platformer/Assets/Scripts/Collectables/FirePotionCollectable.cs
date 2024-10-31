using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePotionCollectable : Collectable
{
    public int ammoCount = 3;

    protected override void Collect(Collector collector)
    {
        ProjectileAttacker attacker = collector.GetComponent<ProjectileAttacker>();
        if (attacker != null)
        {
            attacker.GiveAmmo(ammoCount, ProjectileAttacker.AttackType.Fire);

            base.Collect(collector);
        }
    }
}
