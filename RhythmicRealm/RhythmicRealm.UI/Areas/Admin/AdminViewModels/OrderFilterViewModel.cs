using Microsoft.AspNetCore.Mvc.Rendering;
using RhythmicRealm.Shared.ViewModels.OrderViewModels;

namespace RhythmicRealm.UI.Areas.Admin.AdminViewModels
{
    public class OrderFilterViewModel
    {
        public List<OrderListViewModel>  Orders { get; set; }
        public List<SelectListItem> Products { get; set; }
    }
}
