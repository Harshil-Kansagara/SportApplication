#pragma checksum "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\AthleteByTest\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8c18547604de10c68bb1d089fb2d730490c0c4d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AthleteByTest_Index), @"mvc.1.0.view", @"/Views/AthleteByTest/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/AthleteByTest/Index.cshtml", typeof(AspNetCore.Views_AthleteByTest_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\_ViewImports.cshtml"
using SportsApplication;

#line default
#line hidden
#line 2 "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\_ViewImports.cshtml"
using SportsApplication.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c18547604de10c68bb1d089fb2d730490c0c4d8", @"/Views/AthleteByTest/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e1776ef53efd5b002859436d3ba923f1a376d91", @"/Views/_ViewImports.cshtml")]
    public class Views_AthleteByTest_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SportsApplication.Data.Entity.GetAthleteDataModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-top:10px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "TestLists", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\AthleteByTest\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(146, 47, true);
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h3>\r\n        ");
            EndContext();
            BeginContext(194, 15, false);
#line 9 "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\AthleteByTest\Index.cshtml"
   Write(Model.test_type);

#line default
#line hidden
            EndContext();
            BeginContext(209, 4, true);
            WriteLiteral(" D. ");
            EndContext();
            BeginContext(214, 33, false);
#line 9 "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\AthleteByTest\Index.cshtml"
                       Write(Model.date.ToString("dd/MM/yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(247, 261, true);
            WriteLiteral(@"
    </h3>
    <hr/>
    <div class=""row"" style=""margin-top:30px"">
        <div class=""col""><b>Ranking</b></div>
        <div class=""col""><b>Distance(meter)</b></div>
        <div class=""col""><b>Fitness Rating</b></div>
    </div>
    <hr />
    <ol>
");
            EndContext();
#line 19 "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\AthleteByTest\Index.cshtml"
         foreach (var item in Model.AthleteList)
        {

#line default
#line hidden
            BeginContext(569, 53, true);
            WriteLiteral("            <li>\r\n                <div class=\"row\">\r\n");
            EndContext();
#line 23 "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\AthleteByTest\Index.cshtml"
                     foreach (var item1 in Model.allAthleteLists)
                    {
                        

#line default
#line hidden
#line 25 "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\AthleteByTest\Index.cshtml"
                         if (item.athlete_id == item1.id)
                        {

#line default
#line hidden
            BeginContext(798, 79, true);
            WriteLiteral("                            <div class=\"col\">\r\n                                ");
            EndContext();
            BeginContext(877, 161, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8c18547604de10c68bb1d089fb2d730490c0c4d88433", async() => {
                BeginContext(986, 48, false);
#line 28 "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\AthleteByTest\Index.cshtml"
                                                                                                                                       Write(Html.DisplayFor(modelItem => item1.athlete_name));

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-athleteId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 28 "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\AthleteByTest\Index.cshtml"
                                                                             WriteLiteral(item.athlete_id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["athleteId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-athleteId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["athleteId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 28 "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\AthleteByTest\Index.cshtml"
                                                                                                                 WriteLiteral(Model.TestId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["testId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-testId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["testId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1038, 38, true);
            WriteLiteral("\r\n                            </div>\r\n");
            EndContext();
#line 30 "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\AthleteByTest\Index.cshtml"
                        }

#line default
#line hidden
#line 30 "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\AthleteByTest\Index.cshtml"
                         
                    }

#line default
#line hidden
            BeginContext(1126, 65, true);
            WriteLiteral("\r\n                    <div class=\"col\">\r\n                        ");
            EndContext();
            BeginContext(1192, 51, false);
#line 34 "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\AthleteByTest\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.athlete_distance));

#line default
#line hidden
            EndContext();
            BeginContext(1243, 30, true);
            WriteLiteral("\r\n                    </div>\r\n");
            EndContext();
#line 36 "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\AthleteByTest\Index.cshtml"
                     if (item.athlete_distance > 3500)
                    {

#line default
#line hidden
            BeginContext(1352, 114, true);
            WriteLiteral("                        <div class=\"col\">\r\n                            Very Good\r\n                        </div>\r\n");
            EndContext();
#line 41 "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\AthleteByTest\Index.cshtml"
                    }
                    else if (item.athlete_distance > 2000 && item.athlete_distance <= 3500)
                    {

#line default
#line hidden
            BeginContext(1605, 109, true);
            WriteLiteral("                        <div class=\"col\">\r\n                            Good\r\n                        </div>\r\n");
            EndContext();
#line 47 "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\AthleteByTest\Index.cshtml"
                    }
                    else if (item.athlete_distance > 1000 && item.athlete_distance <= 2000)
                    {

#line default
#line hidden
            BeginContext(1853, 112, true);
            WriteLiteral("                        <div class=\"col\">\r\n                            Average\r\n                        </div>\r\n");
            EndContext();
#line 53 "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\AthleteByTest\Index.cshtml"
                    }
                    else if (item.athlete_distance <= 1000)
                    {

#line default
#line hidden
            BeginContext(2072, 118, true);
            WriteLiteral("                        <div class=\"col\">\r\n                            Below Average\r\n                        </div>\r\n");
            EndContext();
#line 59 "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\AthleteByTest\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(2213, 69, true);
            WriteLiteral("\r\n                </div>\r\n                <hr />\r\n            </li>\r\n");
            EndContext();
#line 64 "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\AthleteByTest\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(2293, 32, true);
            WriteLiteral("\r\n    </ol>\r\n    <div>\r\n        ");
            EndContext();
            BeginContext(2325, 142, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8c18547604de10c68bb1d089fb2d730490c0c4d815886", async() => {
                BeginContext(2440, 23, true);
                WriteLiteral("Add new athlete to test");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 68 "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\AthleteByTest\Index.cshtml"
                                                         WriteLiteral(Model.TestId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2467, 33, true);
            WriteLiteral("\r\n    </div>\r\n    <div>\r\n        ");
            EndContext();
            BeginContext(2500, 157, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8c18547604de10c68bb1d089fb2d730490c0c4d818588", async() => {
                BeginContext(2642, 11, true);
                WriteLiteral("Delete Test");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 71 "C:\Users\harshilkansagara\source\repos\SportsApplication\SportsApplication\SportsApplication\Views\AthleteByTest\Index.cshtml"
                                                                                    WriteLiteral(Model.TestId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2657, 33, true);
            WriteLiteral("\r\n    </div>\r\n    <div>\r\n        ");
            EndContext();
            BeginContext(2690, 70, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8c18547604de10c68bb1d089fb2d730490c0c4d821510", async() => {
                BeginContext(2739, 17, true);
                WriteLiteral("Back to Test List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2760, 22, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SportsApplication.Data.Entity.GetAthleteDataModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
