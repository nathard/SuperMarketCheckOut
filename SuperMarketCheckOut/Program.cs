using System;


namespace Project2
{

    public abstract class Purchase
    {
        // Attributes
        private string _Name;
        private decimal _Price;

        // Properties
        public string Name
        {
            get { return _Name; }
        }
        public decimal Price
        {
            get { return _Price; }
        }

        // Constructor
        public Purchase(string name, decimal price)
        {
            _Name = name;
            _Price = price;
        }

        public abstract decimal Calculate();

        public override string ToString()
        {
            return string.Format("{0,-25}{1,6:c}", _Name, _Price);
        }
    }
    public class Item : Purchase
    {
        // Attrbutes
        private ushort _Qty;

        // Properties
        public ushort Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }

        // Constructor
        public Item(string name, ushort qty, decimal price)
            : base(name, price)
        {
            _Qty = qty;
        }

        public override decimal Calculate()
        {
            return ((decimal)_Qty * base.Price);
        }

        public override string ToString()
        {
            return string.Format("{0}{1,46}{2,16:c}", _Qty, base.ToString(), Calculate());
        }
    }
    public class Weight : Purchase
    {
        // Attributes
        private float _Unit;

        // Properties
        public float Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }

        // Constructor
        public Weight(string name, float unit, decimal price)
            : base(name, price)
        {
            _Unit = unit;
        }


        public override decimal Calculate()
        {
            return ((decimal)_Unit * base.Price);
        }

        public override string ToString()
        {
            return string.Format("{0,9}{1,38}{2,16:c}", _Unit, base.ToString(), Calculate());
        }
    }


    public class Grocery : Item
    {

        public Grocery(string name, ushort qty, decimal price)
            : base(name, qty, price) { }

        public override string ToString()
        {
            return string.Format("{0,16:c}", base.ToString());
        }
    }

    public class MeatWeight : Weight
    {
        // Constructor
        public MeatWeight(string name, float unit, decimal price)
            : base(name, unit, price) { }

        public override string ToString()
        {
            return string.Format("{0,16:c}", base.ToString());
        }
    }
    public class MeatItem : Item
    {
        // Constructor
        public MeatItem(string name, ushort qty, decimal price)
            : base(name, qty, price) { }

        public override string ToString()
        {
            return string.Format("{0,16:c}", base.ToString());
        }
    }

    public class ProduceWeight : Weight
    {
        // Constructor
        public ProduceWeight(string name, float unit, decimal price)
            : base(name, unit, price) { }

        public override string ToString()
        {
            return string.Format("{0,16:c}", base.ToString());
        }
    }


    public class ProduceItem : Item
    {
        // Constructor
        public ProduceItem(string name, ushort qty, decimal price)
            : base(name, qty, price) { }

        public override string ToString()
        {
            return string.Format("{0,16:c}", base.ToString());
        }
    }


    class Receipt
    {
        static void Main(string[] args)
        {
            // Arrays
            Item[] itemlist = new Item[]
            {     
                new Grocery("Loaf of bread", 3, 3.50m),
                new MeatItem("Kabana twin pack", 2, 4.95m),
                new ProduceItem("Iceberg Lettuce", 1, 1.25m),

            };

            Weight[] weightlist = new Weight[]
            {
                new ProduceWeight("Tomatoes",0.72f, 4.35m),
                new MeatWeight("Rump Steak",1.22f, 18.75m)
            };

            // Calculations and Output
            Console.WriteLine("{0}  {1}{2,5}{3,-28}{4}{5,10} {6}", "Qty", "Weight", "", "Decscription", "Net", "", "Gross");
            Console.WriteLine("{0}", new string('=', 63));

            decimal total = 0m;
            foreach (Purchase item in itemlist)
            {
                Console.WriteLine(item);
                total += item.Calculate();
            }
            foreach (Purchase item in weightlist)
            {
                Console.WriteLine(item);
                total += item.Calculate();
            }
            Console.WriteLine("{0}", new string('=', 63));
            Console.WriteLine("{0,63:c}", total);
        }
    }
}


