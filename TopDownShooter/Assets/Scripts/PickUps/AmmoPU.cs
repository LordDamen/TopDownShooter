using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPU : PickUp {
   

    public int ammoAmount;
    public void Awake()
    {

    }
    public override void OnPickup(GameObject target)
    {
        Pawn pawn = target.GetComponent<Pawn>();
        if (pawn != null)
        {
            pawn.weaponScript.ammoCount += ammoAmount;
            pawn.weaponScript.UpdateAmmoText();
        }
        else
        {
            Debug.Log("Null pawn");
            return;
        }

        base.OnPickup(target);
    }
 
}
