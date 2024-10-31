using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePotionCollectable : Collectable
{
    public int ammoCount = 3;

    protected override void Collect(Collector collector)
    {
        ProjectileAttacker attacker = collector.GetComponent<ProjectileAttacker>();
        if (attacker != null)
        {
            attacker.GiveAmmo(ammoCount, ProjectileAttacker.AttackType.Ice);

            base.Collect(collector);
        }
    }
}
