using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink currentDrink = null;
            if (type == "Water")
            {
                currentDrink = new Water(name,portion,brand);
            }
            else if (type == "Tea")
            {
                currentDrink = new Tea(name, portion, brand);
            }
            if (currentDrink != null)
            {
                this.drinks.Add(currentDrink);
                return $"Added {name} ({brand}) to the drink menu";
            }
            return null;
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood currentFood = null;
            if (type == "Bread")
            {
                currentFood = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                currentFood = new Cake(name, price);
            }
            if (currentFood != null)
            {
                this.bakedFoods.Add(currentFood);
                return $"Added {name} ({type}) to the menu";
            }

            return null;
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber,capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            this.tables.Add(table);
            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            ITable[] tables = this.tables.Where(x => x.IsReserved == false).ToArray();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var table in tables)
            {
                stringBuilder.AppendLine(table.GetFreeTableInfo());
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            decimal tableBill = table.GetBill();
            totalIncome += tableBill;
            table.Clear();
            return $"Table: {tableNumber}" + Environment.NewLine + $"Bill: {tableBill:f2}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            IDrink drink = this.drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            IBakedFood food = this.bakedFoods.FirstOrDefault(x => x.Name == foodName);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);
            return $"Table {tableNumber} ordered {food.Name}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);

            if (table != null)
            {
                table.Reserve(numberOfPeople);
                return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
            }
            else
            {
                return $"No available table for {numberOfPeople} people";
            }
        }
    }
}
