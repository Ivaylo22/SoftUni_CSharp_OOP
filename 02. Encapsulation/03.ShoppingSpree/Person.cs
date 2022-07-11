using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private const int MinCost = 0;

        private string name;
        private int money;
        private List<string> products;

        public Person()
        {
            this.products = new List<string>();
        }

        public Person(string name, int money)
            : this()
        {
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public int Money
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value < MinCost)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public List<string> Products
        {
            get { return this.products; }

        }

    }
}
