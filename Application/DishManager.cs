using Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class DishManager : IDishManager
    {
        /// <summary>
        /// Takes an Order object, sorts the orders and builds a list of dishes to be returned. 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public List<Dish> GetDishes(Order order)
        {
            var returnValue = new List<Dish>();
            order.Dishes.Sort();
            foreach (var dishType in order.Dishes)
            {
                AddOrderToList(order.MenuType, dishType, returnValue);
            }
            return returnValue;
        }

        /// <summary>
        /// Takes an int, representing an order type, tries to find it in the list.
        /// If the dish type does not exist, add it and set count to 1
        /// If the type exists, check if multiples are allowed and increment that instances count by one
        /// else throw error
        /// </summary>
        /// <param name="order">int, represents a dishtype</param>
        /// <param name="returnValue">a list of dishes, - get appended to or changed </param>
        private static void AddOrderToList(MenuType menuType, int order, List<Dish> returnValue)
        {
            string orderName = GetOrderName(menuType, order);
            var existingOrder = returnValue.SingleOrDefault(x => x.DishName == orderName);
            if (existingOrder == null)
            {
                returnValue.Add(new Dish
                {
                    DishName = orderName,
                    Count = 1
                });
            } else if (IsMultipleAllowed(menuType, order))
            {
                existingOrder.Count++;
            }
            else
            {
                throw new ApplicationException(string.Format("Multiple {0}(s) not allowed", orderName));
            }
        }

        private static string GetOrderName(MenuType menuType, int order) =>
            (menuType) switch
            {
                MenuType.Morning =>
                    order switch
                    {
                        1 => "egg",
                        2 => "toast",
                        3 => "coffee",
                        _ => throw new ApplicationException($"Order {order} does not exist"),
                    },
                MenuType.Evening =>
                    order switch
                    {
                        1 => "steak",
                        2 => "potato",
                        3 => "wine",
                        4 => "cake",
                        _ => throw new ApplicationException($"Order {order} does not exist"),
                    },
                _ => throw new ApplicationException($"MenuType {menuType} does not exist"),
            };


        private static bool IsMultipleAllowed(MenuType menuType, int order) =>
            menuType switch
            {
                MenuType.Morning => order switch
                {
                    3 => true,
                    _ => false,
                },
                MenuType.Evening => order switch
                {
                    2 => true,
                    _ => false,
                },
                _ => false,
            };
    }
}