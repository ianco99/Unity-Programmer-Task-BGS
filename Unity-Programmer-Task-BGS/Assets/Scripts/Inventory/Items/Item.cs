using UnityEngine.UI;

namespace BGS.Inventory
{
    public abstract class Item
    {
        protected string _type;
        protected string _name;
        protected string _description;
        protected string _quote;
        
        protected Image _imagePV;
        protected Image _imageHD;
        
        protected bool _isSellable;
        protected int _price;

        public string Type { get => _type; private set => _type = value; }
        public string Name { get => _type; private set => _type = value; }
        public string Description { get => _type; private set => _type = value; }
        public string Quote { get => _type; private set => _type = value; }

        public bool IsSellable { get => _isSellable; private set => _isSellable = value; }
        public int Price { get => _price; private set => _price = value; }
    }
}
