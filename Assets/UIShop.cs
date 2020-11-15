using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShop : MonoBehaviour
{
    public void UpgradeDamage(int _cost)
    {
        if (CallbackHandler.instance.CheckMoney(_cost))
        {
            CallbackHandler.instance.SpendMoney(_cost);
            CallbackHandler.instance.UpgradeSkill(0, UpgradeType.Damage);
            MapController.instance.ToggleShop(false);
        }
    }
    public void UpgradeFireSpeed(int _cost)
    {
        if (CallbackHandler.instance.CheckMoney(_cost))
        {
            CallbackHandler.instance.SpendMoney(_cost);
            //temp
            CallbackHandler.instance.UpgradeSkill(0, UpgradeType.Cooldown);
            MapController.instance.ToggleShop(false);
        }
    }
    public void UpgradeProjectiles(int _cost)
    {
        if (CallbackHandler.instance.CheckMoney(_cost))
        {
            CallbackHandler.instance.SpendMoney(_cost);
            CallbackHandler.instance.UpgradeSkill(0, UpgradeType.NumProj);
            MapController.instance.ToggleShop(false);
        }
    }
}
