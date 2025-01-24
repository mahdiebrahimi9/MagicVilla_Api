namespace MagicVilla_Api.Models.SeedData
{
    public static class VillaList
    {
        public static IEnumerable<Villa> VillaLists = new List<Villa>()
        {
            new Villa()
            {
                VillaId = 1,
                VillaName = "beach",
            },
            new Villa()
            {
                VillaId = 2,
                VillaName = "Suni",
            },
        };
    }
}
