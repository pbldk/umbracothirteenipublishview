

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using UmbracoThirteenIPView.Models;



namespace UmbracoThirteenIPView.Controllers
{



 public class ClubsPageController : RenderController
 {
  private IUmbracoContextAccessor _umbracoContextAccessor;
  private readonly IVariationContextAccessor _variationContextAccessor;
  private readonly ServiceContext _serviceContext;
  public ClubsPageController(ILogger<ClubsPageController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor, IVariationContextAccessor variationContextAccessor, ServiceContext context)
      : base(logger, compositeViewEngine, umbracoContextAccessor)
  {
   _variationContextAccessor = variationContextAccessor;
   _serviceContext = context;
   _umbracoContextAccessor = umbracoContextAccessor;
  }

  public override IActionResult Index()
  {

   var cache = _umbracoContextAccessor.GetRequiredUmbracoContext();
   var ctx = cache.Content!.GetById(1061);

   IEnumerable<IPublishedContent> content = ctx!.Children;
   // you are in control here!
   // create our ViewModel based on the PublishedContent of the current request:
   // set our custom properties
   IList<ClubsViewModel> resultList = new List<ClubsViewModel>(); // Initialize the list

   foreach (var item in content)
   {
    var _clubViewModel = new ClubsViewModel(CurrentPage, new PublishedValueFallback(_serviceContext, _variationContextAccessor))
    {
     ClubID = item.GetProperty("clubID")?.GetValue()?.ToString(),
     ClubName = item.GetProperty("clubName")?.GetValue()?.ToString()
    };
    resultList.Add(_clubViewModel);
   }

   // return our custom ViewModel
   return CurrentTemplate(resultList);


  }
 }
}