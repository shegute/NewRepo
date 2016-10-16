using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Patterns.RandomCode
{
    public class PurchaseEntry
    {
        public string entryType;
        public DateTime purchaseDate;
        public DateTime processDate;
        public string storeName;
        public double purchaseAmount;
        public Categories category;
    }

    public class StorePurchases
    {
        public string storeName;
        public List<PurchaseEntry> purchases;
        public double totalAmount;

        public StorePurchases()
        {
            purchases = new List<PurchaseEntry>();
        }

        public double AveragePurchaseAmount()
        {
            return totalAmount / purchases.Count;
        }
    }


    public class PurchasesCategory
    {
        public Categories categoryType;
        public List<PurchaseEntry> purchases;
        public double totalAmount;

        public PurchasesCategory()
        {
            purchases = new List<PurchaseEntry>();
        }

        public double AveragePurchaseAmount()
        {
            return totalAmount / purchases.Count;
        }
    }

    public enum Categories
    {
        Cleaning,
        Clothing,
        DepartmentStore,
        Entertainment,
        Flight,
        Gas,
        Grocery,
        Movies,
        Others,
        Restaurant,
        Unknown
    }


    public class Store
    {
        public string storeName;
        public double minValue;

        public Store(string name, double value)
        {
            this.storeName = name;
            this.minValue = value;
        }

    }

    public interface DataAccessLayer
    {
        List<Store> LoadCategories();
        List<Store> LoadStores();
    }
    public class ReadCSVFile
    {
        public static void Run()
        {
            var reader = new StreamReader(File.OpenRead(@"C:\Users\Nate\Documents\Banking\Chase\201510Activity.CSV"));
            List<PurchaseEntry> purchaseEntries = new List<PurchaseEntry>();
            List<StorePurchases> storePurchases = new List<StorePurchases>();
            List<PurchasesCategory> purchaseCategories = new List<PurchasesCategory>();

            int lineCount = 0;
            while (!reader.EndOfStream)
            {
                if (lineCount++ == 0)
                {
                    var ignoreLine = reader.ReadLine();
                    continue;
                }

                var line = reader.ReadLine();
                var values = line.Split(',');
                DateTime tempPurchaseDate;
                DateTime tempProcessDate;
                double tempPurchaseAmount;
                DateTime.TryParse(values[1], out tempPurchaseDate);
                DateTime.TryParse(values[2], out tempProcessDate);
                double.TryParse(values[4], out tempPurchaseAmount);

                PurchaseEntry entry = new PurchaseEntry
                {
                    entryType = values[0],
                    purchaseDate = tempPurchaseDate,
                    processDate = tempProcessDate,
                    storeName = values[3].Trim('\\', '"'),
                    purchaseAmount = tempPurchaseAmount
                };
                //Determine category

                var store = entry.storeName.ToLowerInvariant();

                List<Store> cleaningStores = new List<Store> { new Store("town and country cleaners", 0), new Store("pro sports ", 20) };
                if (SearchCategoryForStore(entry, cleaningStores))
                { entry.category = Categories.Cleaning; }
                else if (store.Contains("macy's ") || store.Contains("famous footwear ") || store.Contains("nordstrom "))
                { entry.category = Categories.Clothing; }
                else if (store.Contains("sears ") || store.Contains("fred-meyer ") || store.Contains("target "))
                { entry.category = Categories.DepartmentStore; }
                else if (store.Contains("hilton ") || store.Contains("park ") || store.Contains("siriusxm") || store.Contains("uber ") || store.Contains("hulu ") || store.Contains("netflix "))
                { entry.category = Categories.Entertainment; }
                else if (store.Contains("expedia ") || store.Contains("alaska ") || store.Contains("delta ") || store.Contains("us airways "))
                { entry.category = Categories.Flight; }
                else if (store.Contains("shell ") || store.Contains("chevron ") || store.Contains("ampm ") || store.Contains("amco "))
                { entry.category = Categories.Gas; }
                else if (store.Contains("safeway ") || store.Contains("qfc "))
                { entry.category = Categories.Grocery; }
                else if (store.Contains("amc ") || store.Contains("regal "))
                { entry.category = Categories.Movies; }
                else if (store.Contains("usps "))
                { entry.category = Categories.Others; }
                else if (store.Contains("cheesecake ") || store.Contains("cafe ") || store.Contains("chick-fil-a ") || store.Contains("pizza") || store.Contains("starbucks ") || store.Contains("sushi ") || store.Contains("coldstone ") || store.Contains("parlor ") || store.Contains("agelgle ") || store.Contains("panera ") || (store.Contains("pro sports ") && System.Math.Abs(entry.purchaseAmount) < 20))
                { entry.category = Categories.Restaurant; }
                else
                { entry.category = Categories.Unknown; }
                purchaseEntries.Add(entry);

                if (storePurchases.Where(s => s.storeName.Equals(entry.storeName)).ToList().Count != 0)
                {
                    StorePurchases existingStore = storePurchases.Where(s => s.storeName.Equals(entry.storeName)).First();
                    existingStore.purchases.Add(entry);
                    existingStore.totalAmount += entry.purchaseAmount;
                }
                else
                {
                    StorePurchases newStore = new StorePurchases();
                    newStore.storeName = entry.storeName;
                    newStore.purchases.Add(entry);
                    newStore.totalAmount = entry.purchaseAmount;
                    storePurchases.Add(newStore);
                }

                if (purchaseCategories.Where(p => p.categoryType.Equals(entry.category)).ToList().Count != 0)
                {
                    PurchasesCategory existingCategory = purchaseCategories.Where(p => p.categoryType.Equals(entry.category)).First();
                    existingCategory.purchases.Add(entry);
                    existingCategory.totalAmount += entry.purchaseAmount;
                }
                else
                {
                    PurchasesCategory newCategory = new PurchasesCategory();
                    newCategory.categoryType = entry.category;
                    newCategory.purchases.Add(entry);
                    newCategory.totalAmount = entry.purchaseAmount;
                    purchaseCategories.Add(newCategory);
                }
            }

            foreach (StorePurchases s in storePurchases)
            {
                Console.WriteLine("Store Name: " + s.storeName); Console.WriteLine("Store total purchase amount: " + s.totalAmount); Console.WriteLine("Store average purchase amount: " + s.AveragePurchaseAmount());
            }
            foreach (PurchasesCategory p in purchaseCategories)
            {
                Console.WriteLine("Store Name: " + p.categoryType); Console.WriteLine("Category total purchase amount: " + p.totalAmount); Console.WriteLine("Category average purchase amount: " + p.AveragePurchaseAmount());
            }

        }
        private static bool SearchCategoryForStore(PurchaseEntry entry, List<Store> categoryStores)
        {
            foreach (Store s in categoryStores)
            {
                if (entry.storeName.ToLowerInvariant().Contains(s.storeName.ToLowerInvariant()))
                {
                    if (s.minValue != 0)
                    {
                        if (System.Math.Abs(entry.purchaseAmount) >= s.minValue)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
