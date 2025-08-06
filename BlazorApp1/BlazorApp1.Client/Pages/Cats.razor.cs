using BlazorApp1.Client.Entities;

namespace BlazorApp1.Client.Pages
{
    public partial class Cats
    {
        private IEnumerable<Cat> CatInfo { get; set; }
        public bool Loading { get; set; } = false;

        private string catName = "persian";

        private async Task GetCats()
        {
            Loading = true;
            CatInfo = await catService.GetCats(catName);
            Loading = false;
        }

    }
}