#pragma checksum "E:\Trusha\Training\ThreeTierApp\ThreeTierApp.Web\wwwroot\index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "ea7b5bf7460a31e3ae89dee5138e918f80689bfd1bf8345fa04f8d07d79ff391"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCoreGeneratedDocument.wwwroot_index), @"mvc.1.0.view", @"/wwwroot/index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"ea7b5bf7460a31e3ae89dee5138e918f80689bfd1bf8345fa04f8d07d79ff391", @"/wwwroot/index.cshtml")]
    #nullable restore
    internal sealed class wwwroot_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea7b5bf7460a31e3ae89dee5138e918f80689bfd1bf8345fa04f8d07d79ff3912930", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Employee Management</title>
    <script src=""https://code.jquery.com/jquery-3.6.4.min.js""></script>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }
        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        table, th, td {
            border: 1px solid #ddd;
        }
        th, td {
            padding: 10px;
            text-align: left;
        }
        th {
            background-color: #f4f4f4;
        }
        .form-control {
            margin-bottom: 10px;
        }
    </style>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea7b5bf7460a31e3ae89dee5138e918f80689bfd1bf8345fa04f8d07d79ff3914691", async() => {
                WriteLiteral(@"
    <h1>Employee Management</h1>
    <div>
        <h3>Add / Update Employee</h3>
        <input type=""hidden"" id=""employee-id"">
        <div class=""form-control"">
            <label>Name:</label>
            <input type=""text"" id=""employee-name"">
        </div>
        <div class=""form-control"">
            <label>Department:</label>
            <input type=""text"" id=""employee-department"">
        </div>
        <div class=""form-control"">
            <label>Salary:</label>
            <input type=""number"" id=""employee-salary"">
        </div>
        <button id=""add-btn"">Add Employee</button>
        <button id=""update-btn"" style=""display: none;"">Update Employee</button>
    </div>

    <h3>All Employees</h3>
    <table id=""employees-table"">
        <thead>
            <tr>
                <th>ID</th>
                <th>Name</th>
                <th>Department</th>
                <th>Salary</th>
                <th>Actions</th>
            </tr>
        </thead>
        <tbo");
                WriteLiteral(@"dy>
            <!-- Rows will be added dynamically -->
        </tbody>
    </table>

    <script>
        const apiBaseUrl = ""https://localhost:65391/api/employees"";

        // Function to load all employees
        function loadEmployees() {
            $.get(apiBaseUrl, function(data) {
                const tbody = $(""#employees-table tbody"");
                tbody.empty(); // Clear previous rows

                data.forEach(employee => {
                    tbody.append(`
                        <tr>
                            <td>${employee.id}</td>
                            <td>${employee.name}</td>
                            <td>${employee.department}</td>
                            <td>${employee.salary}</td>
                            <td>
                                <button onclick=""editEmployee(${employee.id})"">Edit</button>
                                <button onclick=""deleteEmployee(${employee.id})"">Delete</button>
                            </td>
      ");
                WriteLiteral(@"                  </tr>
                    `);
                });
            });
        }

        // Add a new employee
        $(""#add-btn"").click(function() {
            const employee = {
                name: $(""#employee-name"").val(),
                department: $(""#employee-department"").val(),
                salary: $(""#employee-salary"").val()
            };

            $.post(apiBaseUrl, JSON.stringify(employee), function() {
                loadEmployees();
                clearForm();
                alert(""Employee added successfully!"");
            }).fail(function() {
                alert(""Failed to add employee."");
            });
        });

        // Edit an existing employee
        function editEmployee(id) {
            $.get(`${apiBaseUrl}/${id}`, function(employee) {
                $(""#employee-id"").val(employee.id);
                $(""#employee-name"").val(employee.name);
                $(""#employee-department"").val(employee.department);
          ");
                WriteLiteral(@"      $(""#employee-salary"").val(employee.salary);

                $(""#add-btn"").hide();
                $(""#update-btn"").show();
            });
        }

        // Update an existing employee
        $(""#update-btn"").click(function() {
            const id = $(""#employee-id"").val();
            const employee = {
                id: id,
                name: $(""#employee-name"").val(),
                department: $(""#employee-department"").val(),
                salary: $(""#employee-salary"").val()
            };

            $.ajax({
                url: `${apiBaseUrl}/${id}`,
                type: ""PUT"",
                data: JSON.stringify(employee),
                contentType: ""application/json"",
                success: function() {
                    loadEmployees();
                    clearForm();
                    $(""#add-btn"").show();
                    $(""#update-btn"").hide();
                    alert(""Employee updated successfully!"");
                },
        ");
                WriteLiteral(@"        error: function() {
                    alert(""Failed to update employee."");
                }
            });
        });

        // Delete an employee
        function deleteEmployee(id) {
            if (confirm(""Are you sure you want to delete this employee?"")) {
                $.ajax({
                    url: `${apiBaseUrl}/${id}`,
                    type: ""DELETE"",
                    success: function() {
                        loadEmployees();
                        alert(""Employee deleted successfully!"");
                    },
                    error: function() {
                        alert(""Failed to delete employee."");
                    }
                });
            }
        }

        // Clear form inputs
        function clearForm() {
            $(""#employee-id"").val("""");
            $(""#employee-name"").val("""");
            $(""#employee-department"").val("""");
            $(""#employee-salary"").val("""");
        }

        // Load employees o");
                WriteLiteral("n page load\r\n        $(document).ready(function() {\r\n            loadEmployees();\r\n        });\r\n    </script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
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