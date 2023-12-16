using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SportsStore.Models.ViewModels;

namespace SportsStore.Infrastructure;

// A custom Tag Helper for generating pagination links based on the provided PagingInfo model.
[HtmlTargetElement("div", Attributes = "page-model")]
public class PageLinkTagHelper : TagHelper
{
    private IUrlHelperFactory _urlHelperFactory;

    // Constructor to inject the IUrlHelperFactory dependency.
    public PageLinkTagHelper(IUrlHelperFactory helperFactory)
    {
        _urlHelperFactory = helperFactory;
    }

    [ViewContext] // Indicates that the property should be set to the ViewContext object for the current request.
    [HtmlAttributeNotBound] // Indicates that the property should not be included in the Tag Helper's output.
    public ViewContext? ViewContext { get; set; }

    public PagingInfo? PageModel { get; set; }

    public string? PageAction { get; set; }

    [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
    public Dictionary<string, object> PageUrlValues { get; set; } = new();

    public bool PageClassesEnabled { get; set; } = false;

    public string PageClass { get; set; } = string.Empty;

    public string PageClassNormal { get; set; } = string.Empty;

    public string PageClassSelected { get; set; } = string.Empty;

    // Process method to generate the HTML for pagination links.
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (ViewContext == null || PageModel == null) return;

        // Get the URL helper.
        var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
        var result = new TagBuilder("div");

        // Generate HTML for each page link.
        for (var i = 1; i <= PageModel.TotalPages; i++)
        {
            var tag = new TagBuilder("a");
            PageUrlValues["productPage"] = i;
            tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

            // Optionally add CSS classes based on configuration.
            if (PageClassesEnabled)
            {
                tag.AddCssClass(PageClass);
                tag.AddCssClass(i == PageModel.CurrentPage
                    ? PageClassSelected
                    : PageClassNormal);
            }

            // Set the link text.
            tag.InnerHtml.Append(i.ToString());
            result.InnerHtml.AppendHtml(tag);
        }

        // Append the generated HTML to the Tag Helper's output.
        output.Content.AppendHtml(result.InnerHtml);
    }
}