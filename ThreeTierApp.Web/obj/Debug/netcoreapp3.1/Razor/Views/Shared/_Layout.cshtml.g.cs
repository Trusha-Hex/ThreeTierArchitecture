#pragma checksum "E:\Trusha\Training\ThreeTierApp\ThreeTierApp.Web\Views\Shared\_Layout.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "65f4e2e4a1898fa4cd33f620f25fc66d203d86820edbcb500957ae0b976da6a4"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"65f4e2e4a1898fa4cd33f620f25fc66d203d86820edbcb500957ae0b976da6a4", @"/Views/Shared/_Layout.cshtml")]
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "65f4e2e4a1898fa4cd33f620f25fc66d203d86820edbcb500957ae0b976da6a43347", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Employee Management</title>

    <style>
        :root {
            --primary-bg-color: #BFECFF;
            --menu-bg-color: #CDC1FF;
            --content-bg-color: #FFF6E3;
            --menu-font-color: black;
            --menu-border-color: #ccc; 
        }

        .side-panel {
            position: fixed;
            top: 0;
            left: 0;
            width: 250px;
            height: 100%;
            background-color: var(--primary-bg-color);
            color: white;
            transform: translateX(0); 
            transition: transform 0.3s ease;
            z-index: 9999;
            box-shadow: 2px 0px 5px rgba(0, 0, 0, 0.5);
        }

            .side-panel ul {
                list-style: none;
                padding: 0;
                margin-top: 50px; 
            }

            .side-panel li {
                padding: 15px;
    ");
                WriteLiteral(@"            background-color: var(--menu-bg-color);
                border-bottom: 1px solid var(--menu-border-color);
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
            display: none;
        }

        .side-panel.closed {
            transform: translateX(-100%); 
        }

        #contentArea {
            transition: margin-left 0.3s ease;
        }

            #contentArea.open {
                margin-left: 250px;
            }

        #hamburgerIcon {
            font-size: 30px;
            color: var(--menu-font-color);
            cursor: pointer;
         ");
                WriteLiteral(@"   display: none;
        }

        .side-panel.closed + #hamburgerIcon {
            display: block;
        }

        #alert-box {
            position: fixed;
            top: 20px; 
            right: 20px; 
            z-index: 1050; 
            max-width: 300px; 
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); 
        }

        .alert {
            border-radius: 4px; 
            padding: 10px 15px; 
        }

        .btn-close {
            float: right;
        }
    </style>

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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "65f4e2e4a1898fa4cd33f620f25fc66d203d86820edbcb500957ae0b976da6a47065", async() => {
                WriteLiteral("\r\n");
                WriteLiteral(@"

    <!-- Side Panel -->
    <div id=""sidePanel"" class=""side-panel"">
        <ul>
            <li><a href=""/Employee/Index"">Employee Management</a></li>
            <li><a href=""#"">Task Management</a></li>
            <li style=""display: flex; justify-content: center; align-items: center;"">
                <button id=""logoutButton"" style=""background-color: red; color: white; padding: 10px 20px; border: none; cursor: pointer; border-radius: 5px; text-align: center;"">
                    Logout
                </button>
            </li>
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
#line 129 "E:\Trusha\Training\ThreeTierApp\ThreeTierApp.Web\Views\Shared\_Layout.cshtml"
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

               $('#logoutButton').on('click', function () {
            // Show confirmation prompt
            const userConfirmed = confirm('Are you sure you want to logout?');

            if (userConfirmed) {
                // Proceed with logout if confirmed
  ");
                WriteLiteral(@"              $.post('/logout')
                    .done(function (response) {
                        showAlert('success', response.message); // Trigger success alert
                        window.location.href = response.redirectUrl; // Redirect to login page
                    })
                    .fail(function (error) {
                        const errorMessage = error.responseJSON?.message || 'Logout failed.';
                        showAlert('danger', errorMessage); // Trigger error alert
                    });
            } else {
                // Show an alert if the user cancels logout
                showAlert('info', 'Logout cancelled.');
            }
        });


            function showAlert(type, message) {
            const alertBox = $('#alert-box');
            alertBox.removeClass(); // Clear all existing classes
            alertBox.addClass(`alert alert-${type} alert-dismissible fade show`); // Set proper classes
            alertBox.html(`
              ");
                WriteLiteral(@"  <strong>${type === 'success' ? 'Success!' : type === 'danger' ? 'Error!' : 'Info!'}</strong> ${message}
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
            `);

            console.log(`Showing ${type} alert:`, message); // Debugging log

            alertBox.fadeIn(); // Show the alert

            // Automatically fade out after 3 seconds
            setTimeout(() => alertBox.fadeOut(), 3000);
        }
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
