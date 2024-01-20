A project using: PublishedContentWrapped

public class MyProductViewModel : PublishedContentWrapped
{
    // The PublishedContentWrapped accepts an IPublishedContent item as a constructor
    public MyProductViewModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
    {
    }

    // Custom properties here...
    public int StockLevel { get; set; }
    public IEnumerable<Distributor> ProductDistributors { get; set; }
}



And MVC view

@inherits Umbraco.Cms.Web.Common.Views.UmbracoViewPage<MyProductViewModel>
@{
Layout = "Master";
}
<h1>@Model.Name</h1>

@(Model.Value<IHtmlString>("productDescription"))
// or using Modelsbuilder
@Model.ProductDescription

<dl>
<dt>Stock Level</dt>
<dd>@Model.StockLevel</dd>
<dt>Distributors</dt>
@foreach (var distributor in Model.Distributors){
<dd>@distributor.Name</dd>
}
