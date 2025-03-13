using UnityEngine;

namespace BGS.Inventory
{
    /// <summary>
    /// Base class for all item settings
    /// </summary>
    [CreateAssetMenu(fileName = "BaseItemSettings", menuName = "ScriptableObjects/BaseItemSettings")]
    public class BaseItemSettings : ScriptableObject
    {
        public string Type;
        public string Name;
        public string Description;
        public string Quote;
        
        public Sprite ImagePV;
        public Sprite ImageHD;
        
        public bool IsSellable;
        public int Price;
    }
}