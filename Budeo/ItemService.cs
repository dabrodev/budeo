using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budeo
{
    public class ItemService
    {
        private List<Item> Items;

        public ItemService()
        {
            Items = new List<Item>();
        }

        public ConsoleKeyInfo AddNewItemView(MenuActionService menuActionService)
        {
            var addNewItemMenu = menuActionService.GetMenuActionsByMenuName("AddNewItemMenu");
            Console.WriteLine("\nPlease select item category:");
            for (int i = 0; i < addNewItemMenu.Count; i++)
            {
                Console.WriteLine($"{addNewItemMenu[i].Id}. {addNewItemMenu[i].Name}");
            }

            var category = Console.ReadKey();
            return category;
        }

        public int AddNewItem(char itemCategory)
        {
            int categoryId;
            Int32.TryParse(itemCategory.ToString(), out categoryId);
           
            Item item = new Item();
            Location location = new Location();
           

            item.CategoryId = categoryId;
            Console.WriteLine("\nPlease enter id for new product:");
            var id = Console.ReadKey();
            int itemId;
            Int32.TryParse(id.KeyChar.ToString(), out itemId);
            Console.WriteLine("\nPlease enter name for new product:");
            var name = Console.ReadLine();
            Console.WriteLine("Please enter location(Town) of the product:");
            var town = Console.ReadLine();

            Console.WriteLine("Please enter location(Street) of the product:");
            var street = Console.ReadLine();

            item.Id = itemId;
            item.Name = name;

            item.Location = location;
            location.Town = town;
            location.Street = street;

            Items.Add(item);
            return itemId;
        }
        public int RemoveItemView()
        {
            Console.WriteLine("\nPlease enter id for product you want to  remove:");
            var itemId = Console.ReadKey();

            int id;
            Int32.TryParse(itemId.KeyChar.ToString(), out id);

            return id;
        }

        public void RemoveItem(int removeId)
        {
            Item productToRemove = new Item();
           foreach(var item in Items)
            {
                if(item.Id == removeId)
                {
                    productToRemove = item;
                    break;
                }
            }
           Items.Remove(productToRemove);
        }

        public int ItemDetailSelectionView()
        {
            Console.WriteLine("\nPlease enter id for product you want to view");
            var itemId = Console.ReadKey();

            int id;
            Int32.TryParse(itemId.KeyChar.ToString(), out id);

            return id;
        }

        public void ItemDetailView(int detailId)
        {
            Item productToDisplay = new Item();
            foreach(var item in Items)
            {
                if(item.Id == detailId)
                {
                    productToDisplay = item;
                    break;
                }
            }
            Console.WriteLine($"{productToDisplay.Id} - {productToDisplay.Name} - {productToDisplay.CategoryId} - {productToDisplay.Location.Town}");
        }

        public void ItemDisplayAll()
        {
            foreach(var item in Items)
            {
                Console.WriteLine($"{item.Id} - {item.Name} - {item.CategoryId} - {item.Location.Town}");
            }
        }

        public int ItemCategorySelectionView()
        {
            Console.WriteLine("\nPlease enter category id of products you want to see:");
            var categoryId = Console.ReadKey();

            int id;
            Int32.TryParse(categoryId.KeyChar.ToString(), out id);

            return id;
        }

        public void ItemDisplayOfCategory(int categoryId)
        {
            foreach (var item in Items)
            {
                if (categoryId == item.CategoryId)
                {
                    Console.WriteLine($"{item.Id} - {item.Name} - {item.CategoryId} - {item.Location.Town} ");
                }
                else
                {
                    Console.WriteLine("\nNo products of this category!");
                }
            }
        }

        public string ItemTownSelectionView()
        {
            Console.WriteLine("\nPlease enter town location of products you want to see:");
            var town = Console.ReadLine();

            return town;
        }

        public void ItemDisplayOfTown(string town)
        {
            foreach (var item in Items)
            {
                if (town == item.Location.Town)
                {
                    Console.WriteLine($"{item.Id} - {item.Name} - {item.CategoryId} - {item.Location.Town} ");
                }
            }
        }

    }
}
