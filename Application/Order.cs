using Application.Enums;
using System.Collections.Generic;

namespace Application
{
    public class Order
    {
        public Order()
        {
            Dishes = new List<int>();
        }
        public MenuType MenuType { get; set; }
        public List<int> Dishes { get; set; }
    }
}