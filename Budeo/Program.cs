using System;

namespace Budeo
{
    public class Program
    {
        static void Main(string[] args)
        {

            MenuActionService menuActionService = new MenuActionService();
            menuActionService =  Initialize(menuActionService);
            ItemService itemService = new ItemService();

            Console.WriteLine("Welcome to Budeo!");
            Console.WriteLine("Budeo is a place where you can sell or buy construction materials left over from building the house.");
            while (true)
            {
                Console.WriteLine("\nChoose your next step:");

                var mainMenu = menuActionService.GetMenuActionsByMenuName("Main");

                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }

                var step = Console.ReadKey();
             
                switch (step.KeyChar)
                {
                    case '1':
                        var keyInfo = itemService.AddNewItemView(menuActionService);
                        var id = itemService.AddNewItem(keyInfo.KeyChar);
                        break;
                    case '2':
                        var removeId = itemService.RemoveItemView();
                        itemService.RemoveItem(removeId);
                        break;
                    case '3':
                        var detailId = itemService.ItemDetailSelectionView();
                        itemService.ItemDetailView(detailId);
                        break;
                    case '4':
                        itemService.ItemDisplayAll();
                        break;
                    case '5':
                        var categoryId = itemService.ItemCategorySelectionView();
                        itemService.ItemDisplayOfCategory(categoryId);
                        break;
                    case '6':
                        var town = itemService.ItemTownSelectionView();
                        itemService.ItemDisplayOfTown(town);
                        break;
                    default:
                        Console.WriteLine("\nWrong choice. Try again!");
                        break;
                }
            }
        }

        private static MenuActionService Initialize(MenuActionService menuActionService)
        {
            menuActionService.AddNewAction(1, "Add item", "Main");
            menuActionService.AddNewAction(2, "Remove item", "Main");
            menuActionService.AddNewAction(3, "Show details", "Main");
            menuActionService.AddNewAction(4, "List all items", "Main");
            menuActionService.AddNewAction(5, "List items of chosen category", "Main");
            menuActionService.AddNewAction(6, "List items from the same town", "Main");

            menuActionService.AddNewAction(1, "Masonry Elements", "AddNewItemMenu");
            menuActionService.AddNewAction(2, "Concrete Elements", "AddNewItemMenu");
            menuActionService.AddNewAction(3, "Loose Materials", "AddNewItemMenu");
            menuActionService.AddNewAction(4, "Insulating Materials", "AddNewItemMenu");
            return menuActionService;
        }
    }
}
