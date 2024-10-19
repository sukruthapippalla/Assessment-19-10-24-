using System.ComponentModel.DataAnnotations;

namespace Que4
{
    interface IBroadbandPlan
    {
        int GetBroadbandPlanAmount();
    }
    class Black : IBroadbandPlan
    {
        private readonly bool _isSubscriptionValid;
        private readonly int _discountPercentge;
        private const int PlanAmount = 3000;
        public Black(bool isSubscriptionValid, int discountPercentge)
        {
            this._isSubscriptionValid = isSubscriptionValid;
            if (discountPercentge < 0 || discountPercentge > 50)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                this._discountPercentge = discountPercentge;
            }
        }
        public int GetBroadbandPlanAmount()
        {
            int disPrice = 0;
            if (_isSubscriptionValid)
            {
                disPrice = PlanAmount - PlanAmount * _discountPercentge / 100;
                return disPrice;
            }
            else
            {
                disPrice = PlanAmount;
                return disPrice;
            }
        }
    }
    class Gold : IBroadbandPlan
    {
        private readonly bool _isSubscriptionValid;
        private readonly int _discountPercentge;
        private const int PlanAmount = 1500;
        public Gold(bool isSubscriptionValid, int discountPercentge)
        {
            this._isSubscriptionValid = isSubscriptionValid;
            if (discountPercentge < 0 || discountPercentge > 50)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                this._discountPercentge = discountPercentge;
            }
        }
        public int GetBroadbandPlanAmount()
        {
            int disPrice = 0;
            if (_isSubscriptionValid)
            {
                disPrice = PlanAmount - PlanAmount * _discountPercentge / 100;
                return disPrice;
            }
            else
            {
                disPrice = PlanAmount;
                return disPrice;
            }
        }
    }

    class SubscriptionPlan
    {
        private readonly IList<IBroadbandPlan> _broadbandPlans;
        public SubscriptionPlan(IList<IBroadbandPlan> broadbandPlans)
        {
            if(broadbandPlans != null)
            {
                this._broadbandPlans = broadbandPlans;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        public IList<Tuple<string,int>> GetSubscriptionPlan()
        {
            IList<Tuple<string, int>> list = new List<Tuple<string, int>>();
            foreach(var i in _broadbandPlans)
            {
                string planType = i.GetType().Name;
                int amount = i.GetBroadbandPlanAmount();
                list.Add(new Tuple<string, int>(planType, amount));
            }

            if(_broadbandPlans == null)
            {
                throw new ArgumentNullException();
            }
            return list;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var plans = new List<IBroadbandPlan>
            {
                new Black(true,50),
                new Black(false,10),
                new Gold(true,30),
                new Black(true,20),
                new Gold(false,20)
            };
            var subscriptionPlans = new SubscriptionPlan(plans);
            var result = subscriptionPlans.GetSubscriptionPlan();
            foreach (var plan in result) 
            {
                Console.WriteLine($"{plan.Item1},{plan.Item2}");
            }
        }
    }
}
