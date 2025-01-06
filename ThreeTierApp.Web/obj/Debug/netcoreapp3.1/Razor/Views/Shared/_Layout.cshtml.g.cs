#pragma checksum "E:\Trusha\Training\ThreeTierApp\ThreeTierApp.Web\Views\Shared\_Layout.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "bb060c19a5d0a654d73adcd6753fc9813bb713c63b81afe548affbe4da121658"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCoreGeneratedDocument.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
namespace AspNetCoreGeneratedDocument
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
    #line default
    #line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"bb060c19a5d0a654d73adcd6753fc9813bb713c63b81afe548affbe4da121658", @"/Views/Shared/_Layout.cshtml")]
    #nullable restore
    internal sealed class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color: var(--content-bg-color);"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb060c19a5d0a654d73adcd6753fc9813bb713c63b81afe548affbe4da1216583347", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Employee Management</title>

    <!-- Inline CSS for the side panel -->
    <style>
        /* Color theme */
        :root {
            --primary-bg-color: #BFECFF;
            --menu-bg-color: #CDC1FF;
            --content-bg-color: #FFF6E3;
            --menu-font-color: black;
            --menu-border-color: #ccc; /* Light grey border color */
        }

        /* Side Panel Styles */
        .side-panel {
            position: fixed;
            top: 0;
            left: 0;
            width: 250px;
            height: 100%;
            background-color: var(--primary-bg-color);
            color: white;
            transform: translateX(0); /* Initially visible */
            transition: transform 0.3s ease;
            z-index: 9999;
            box-shadow: 2px 0px 5px rgba(0, 0, 0, 0.5);
        }

            .side-panel ul {
                list-style:");
                WriteLiteral(@" none;
                padding: 0;
                margin-top: 50px; /* Some space from the top */
            }

            .side-panel li {
                padding: 15px;
                background-color: var(--menu-bg-color);
                border-bottom: 1px solid var(--menu-border-color); /* Grey border */
            }

                .side-panel li a {
                    color: var(--menu-font-color);
                    text-decoration: none;
                    font-size: 18px;
                }

        .close-panel-btn {
            position: absolute;
            top: 10px;
            right: 10px;
            background: none;
            border: none;
            color: white;
            font-size: 20px;
            cursor: pointer;
            display: none; /* Hidden by default */
        }

        /* Side Panel Closed */
        .side-panel.closed {
            transform: translateX(-100%); /* Move off the screen */
        }

        /* Content Area */");
                WriteLiteral(@"
        #contentArea {
            transition: margin-left 0.3s ease;
        }

            /* Open content area when side panel is closed */
            #contentArea.open {
                margin-left: 250px; /* Adjust for the width of the side panel */
            }

        /* Hamburger Icon */
        #hamburgerIcon {
            font-size: 30px;
            color: var(--menu-font-color);
            cursor: pointer;
            display: none; /* Hidden by default, shown when the panel is closed */
        }

        /* Make the hamburger icon visible when the panel is closed */
        .side-panel.closed + #hamburgerIcon {
            display: block;
        }
    </style>

    <!-- Include jQuery -->
    <script src=""https://code.jquery.com/jquery-3.6.0.min.js""></script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb060c19a5d0a654d73adcd6753fc9813bb713c63b81afe548affbe4da1216587278", async() => {
                WriteLiteral(@"

    <!-- Side Panel -->
    <div id=""sidePanel"" class=""side-panel"">
        <ul>
            <li><a href=""/Employee/Index"">Employee Management</a></li>
            <li><a href=""#"">Task Management</a></li>
        </ul>
    </div>

    <!-- Hamburger Icon (appears when the side panel is closed) -->
    <div id=""hamburgerIcon"" class=""hamburger-icon"">
        &#9776; <!-- Unicode for hamburger icon -->
    </div>

    <!-- Main Content Area -->
    <div id=""contentArea"">
        ");
                Write(
#nullable restore
#line 113 "E:\Trusha\Training\ThreeTierApp\ThreeTierApp.Web\Views\Shared\_Layout.cshtml"
         RenderBody()

#line default
#line hidden
#nullable disable
                );
                WriteLiteral(@"  <!-- This will render the content of your views -->
    </div>

    <!-- Inline JS for the side panel logic -->
    <script>
        $(document).ready(function () {
            var $sidePanel = $('#sidePanel');
            var $contentArea = $('#contentArea');
            var $hamburgerIcon = $('#hamburgerIcon');

            // Close the side panel when anywhere outside of it is clicked
            $(document).on('click', function (event) {
                if (!$(event.target).closest('#sidePanel, #hamburgerIcon').length) {
                    $sidePanel.addClass('closed'); // Hide the panel
                    $contentArea.removeClass('open'); // Adjust content area width
                    $hamburgerIcon.show(); // Show hamburger icon
                }
            });

            // Open the side panel when cursor is near the left edge of the screen
            $(document).on('mousemove', function (event) {
                var mouseX = event.pageX;

                // If the mous");
                WriteLiteral(@"e is near the left edge and the panel is closed, open it
                if (mouseX < 50 && $sidePanel.hasClass('closed')) {
                    $sidePanel.removeClass('closed'); // Open the side panel
                    $contentArea.addClass('open'); // Adjust content area width
                    $hamburgerIcon.hide(); // Hide hamburger icon
                }
            });

            // Open the side panel when hamburger icon is clicked
            $hamburgerIcon.on('click', function () {
                $sidePanel.removeClass('closed'); // Open the side panel
                $contentArea.addClass('open'); // Adjust content area width
                $(this).hide(); // Hide hamburger icon
            });
        });
    </script>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
