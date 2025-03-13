using UnityEngine;

namespace BGS.Inventory
{
    public class Item
    {
        protected string _type;
        protected string _name;
        protected string _description;
        protected string _quote;
        
        protected Sprite _imagePV;
        protected Sprite _imageHD;
        
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

        public Sprite ImagePV { get => _imagePV; protected set => _imagePV = value; }
        public Sprite ImageHD { get => _imageHD; protected set => _imageHD = value; }

        public Item(BaseItemSettings config)
        {
            _type = config.Type;
            _name = config.name;
            _description = config.Description;
            _quote = config.Quote;
            _isSellable = config.IsSellable;
            _price = config.Price;
            //_id;

            _imagePV = config.ImagePV;
            _imageHD = config.ImageHD;
        }
    }
}
