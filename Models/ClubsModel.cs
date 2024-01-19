


using Umbraco.Cms.Core.Models.PublishedContent;

namespace UmbracoThirteenIPView.Models
{
 public class ClubsViewModel : PublishedContentWrapped
 {
  // The PublishedContentWrapped accepts an IPublishedContent item as a constructor
  // The ProductPage model accepts an IPublishedContent item as a constructor
  public ClubsViewModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
  {
  }
  // Custom properties here...
  public string? ClubID { get; set; }
  public string? ClubName { get; set; }
 }
}