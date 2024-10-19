namespace Que3
{
    enum CommodityCategory
    {
        Furniture,
        Grocery,
        Service
    }
    class Commodity
    {
        public CommodityCategory Category { get; set; }
        public string CommodityName { get; set; }
        public int CommodityQuantity { get; set; }
        public double CommodityPrice { get; set; }
        public Commodity(CommodityCategory category,string commodityName, int commodityQuantity,double commodityPrice)
        {
            this.Category = category;
            this.CommodityName = commodityName;
            this.CommodityQuantity = commodityQuantity;
            this.CommodityPrice = commodityPrice;
        }
    }
    class PrepareBill
    {
        private readonly IDictionary<CommodityCategory, double> _taxRates;
        public PrepareBill()
        {
            _taxRates = new Dictionary<CommodityCategory, double>();
        }
        public void SetTaxRates(CommodityCategory category,double taxRate)
        {
            bool isNotValid = false;

            foreach(var tr in _taxRates)
            {
                if(category == tr.Key)
                {
                    isNotValid = true; 
                    break;
                }
            }
            if (!isNotValid) 
            {
                _taxRates.Add(category, taxRate);
            }
        }
        public double CalculateBillAmount(IList<Commodity> items)
        {
            double billAmount = 0;
            foreach (var item in items) 
            {
                double tr;
                if (_taxRates.ContainsKey(item.Category))
                {
                    tr = _taxRates[item.Category];
                }
                else
                {
                    throw new ArgumentException();
                }
                double total = item.CommodityQuantity * item.CommodityPrice;
                double tax = total * tr / 100;
                billAmount += total + tax;
            }
            return billAmount;
        }

        public double Sum(double[] tax)
        {
            double res = 0;
            for (int i = 0; i < tax.Length; i++)
            {
                res += tax[i];
            }
            return res;
        }

    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var commodities = new List<Commodity>()
            {
                new Commodity(CommodityCategory.Furniture,"Bed",2,50000),
                new Commodity(CommodityCategory.Grocery,"Flour",5,80),
                new Commodity(CommodityCategory.Service,"Insurance",8,8500),
            };
            var prepareBill = new PrepareBill();
            prepareBill.SetTaxRates(CommodityCategory.Furniture, 18);
            prepareBill.SetTaxRates(CommodityCategory.Grocery, 5);
            prepareBill.SetTaxRates(CommodityCategory.Service, 12);

            var billAmount = prepareBill.CalculateBillAmount(commodities);
            Console.WriteLine(billAmount);
        }
    }
}
