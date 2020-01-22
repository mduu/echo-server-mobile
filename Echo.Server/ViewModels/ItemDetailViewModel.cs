using System;

using Echo.Server.Models;

namespace Echo.Server.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item
        {
            get; set;
        }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
