namespace ListPatternMatching
{
    public class StoreProcessor
    {
        public static void RunTotals()
        {
            // Pretend we're actually loading a variety of inconsistently formatted CSV files,
            // which may have been exported from some third-party system
            var inconsistentCSVFileRecords = new[]
            {
                "Willy Wonka's Chocolate Factory, true, false, 400000.00",
                "The Shop Around The Corner, true, false, maybe, 12, 1200, M-F, 15000.00",
                "Zonko's Joke Shop, 13000.00",
            };

            var stores = new List<string>();
            var totalSales = 0m;

            foreach (var record in inconsistentCSVFileRecords)
            {
                if (record.Split(',') is [string name, .., string sales])
                {
                    stores.Add(name);
                    totalSales += decimal.Parse(sales);
                }
            }

            Console.WriteLine($"The following stores had combined sales of ${totalSales}:");
            Console.WriteLine(string.Join(", ", stores));
        }
    }
}
