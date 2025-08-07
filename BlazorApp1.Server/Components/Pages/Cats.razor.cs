using BlazorApp1.Server.Entities;

namespace BlazorApp1.Server.Components.Pages
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