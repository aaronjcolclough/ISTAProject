#pragma checksum "D:\ISTA\ISTAProject\StudyGuide\StudyGuide\Views\QaDetails\Filter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f998e0bb0fd26def3b4dcfc62cb8a98dd1bb4608"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_QaDetails_Filter), @"mvc.1.0.view", @"/Views/QaDetails/Filter.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/QaDetails/Filter.cshtml", typeof(AspNetCore.Views_QaDetails_Filter))]
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
#line 1 "D:\ISTA\ISTAProject\StudyGuide\StudyGuide\Views\_ViewImports.cshtml"
using StudyGuide;

#line default
#line hidden
#line 2 "D:\ISTA\ISTAProject\StudyGuide\StudyGuide\Views\_ViewImports.cshtml"
using StudyGuide.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f998e0bb0fd26def3b4dcfc62cb8a98dd1bb4608", @"/Views/QaDetails/Filter.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa398c00332a717e4f25225f6d946309b3793140", @"/Views/_ViewImports.cshtml")]
    public class Views_QaDetails_Filter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<StudyGuide.Models.QaDetails>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(49, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\ISTA\ISTAProject\StudyGuide\StudyGuide\Views\QaDetails\Filter.cshtml"
  
    ViewData["Title"] = "Questions";

#line default
#line hidden
            BeginContext(96, 6, true);
            WriteLiteral("\r\n<h2>");
            EndContext();
            BeginContext(103, 34, false);
#line 7 "D:\ISTA\ISTAProject\StudyGuide\StudyGuide\Views\QaDetails\Filter.cshtml"
Write(Model.FirstOrDefault().Sub.SubName);

#line default
#line hidden
            EndContext();
            BeginContext(137, 246, true);
            WriteLiteral("</h2>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                Question\r\n            </th>            \r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n        \r\n            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(384, 31, false);
#line 21 "D:\ISTA\ISTAProject\StudyGuide\StudyGuide\Views\QaDetails\Filter.cshtml"
               Write(Model.FirstOrDefault().Question);

#line default
#line hidden
            EndContext();
            BeginContext(415, 176, true);
            WriteLiteral("\r\n                </td>                \r\n            </tr>\r\n            <tr>\r\n                \r\n                <td>\r\n                    <div id=\"toggle\" style=\"display:none\">");
            EndContext();
            BeginContext(592, 29, false);
#line 27 "D:\ISTA\ISTAProject\StudyGuide\StudyGuide\Views\QaDetails\Filter.cshtml"
                                                     Write(Model.FirstOrDefault().Answer);

#line default
#line hidden
            EndContext();
            BeginContext(621, 1204, true);
            WriteLiteral(@"</div>
                        <script type=""text/javascript"">
                            function showDiv(toggle) {
                                document.getElementById(toggle).style.display = 'block';
                            }
                        </script>
                    <input type=""button"" id=""ans_button"" name=""answer"" value=""Answer"" onclick=""showDiv('toggle'); hideshow()"" />
                    <script type=""text/javascript"">
                        var button = document.getElementById('ans_button')
                        button.addEventListener('click', hideshow, false);

                        function hideshow() {
                            document.getElementById('ans_button').style.display = 'none';
                            
                            document.getElementById('next_button').style.display = 'initial';
                             
                        }
                    </script>
                </td>
            </tr>
            <tr>");
            WriteLiteral("\r\n                <input type=\"button\" id=\"next_button\" name=\"next\" style=\"display:none\" value=\"Next Question\" \r\n                       asp-controller=\"QaDetails\" asp-action=\"Next\"");
            EndContext();
            BeginWriteAttribute("asp-route-qaId", " \r\n                       asp-route-qaId=\"", 1825, "\"", 1895, 1);
#line 50 "D:\ISTA\ISTAProject\StudyGuide\StudyGuide\Views\QaDetails\Filter.cshtml"
WriteAttributeValue("", 1867, Model.FirstOrDefault().QaId, 1867, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("asp-route-subId", " asp-route-subId=\"", 1896, "\"", 1943, 1);
#line 50 "D:\ISTA\ISTAProject\StudyGuide\StudyGuide\Views\QaDetails\Filter.cshtml"
WriteAttributeValue("", 1914, Model.FirstOrDefault().SubId, 1914, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1944, 58, true);
            WriteLiteral(" />\r\n            </tr>\r\n        \r\n    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<StudyGuide.Models.QaDetails>> Html { get; private set; }
    }
}
#pragma warning restore 1591
