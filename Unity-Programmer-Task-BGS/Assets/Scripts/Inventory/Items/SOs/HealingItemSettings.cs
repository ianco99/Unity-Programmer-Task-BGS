using UnityEngine;

namespace BGS.Inventory
{
    [CreateAssetMenu(fileName = "HealingItemSettings", menuName = "ScriptableObjects/HealingItemSettings")]
    public class HealingItemSettings : BaseItemSettings
    {
        public int HealAmount;
    }
}
