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
        protected int _id;

        public string Type { get => _type; protected set => _type = value; }
        public string Name { get => _type; protected set => _type = value; }
        public string Description { get => _type; protected set => _type = value; }
        public string Quote { get => _type; protected set => _type = value; }

        public bool IsSellable { get => _isSellable; protected set => _isSellable = value; }
        public int Price { get => _price; protected set => _price = value; }
        public int ID { get => _id; protected set => _id = value; }

        public Item()
        {
            _type = "Item";
            _name = "Item";
            _description = "Item";
            _quote = "Item";
            _isSellable = false;
            _price = 0;
            _id = 0;
        }
    }
}
