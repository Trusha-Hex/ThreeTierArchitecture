#pragma checksum "E:\Trusha\Training\ThreeTierApp\ThreeTierApp.Web\Views\Home\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "799612bbc402fa4a6c7106134ac7c891966bdc10ad65c80bd42ff4d66b0f8b4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCoreGeneratedDocument.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"799612bbc402fa4a6c7106134ac7c891966bdc10ad65c80bd42ff4d66b0f8b4d", @"/Views/Home/Index.cshtml")]
    #nullable restore
    internal sealed class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "799612bbc402fa4a6c7106134ac7c891966bdc10ad65c80bd42ff4d66b0f8b4d2873", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Employee Management</title>
    <script src=""https://code.jquery.com/jquery-3.6.4.min.js""></script>
    <link rel=""stylesheet"" href=""https://cdn.datatables.net/1.13.4/css/jquery.dataTables.min.css"">
    <script src=""https://cdn.datatables.net/1.13.4/js/jquery.dataTables.min.js""></script>
    <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css"" rel=""stylesheet"">
    <script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js""></script>
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css"" />
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 40px;
            background-color: #ffffff;
        }

        h1 {
            color: #CDC1FF;
            margin-bottom: 10px; /* Increase margin below title */
            font-");
                WriteLiteral(@"size: 36px; /* Increased font size for the title */
            font-weight: bold;
        }

        h3 {
            color: #CDC1FF;
            margin-bottom: 20px; /* Increased space between subtitle and table */
            font-size: 26px; /* Increased font size for subtitle */
            font-weight: bold;
        }

        /* Add space between the button and subtitle */
        button.btn-primary {
            margin-top: 40px; /* Add some space between the ""Add Employee"" button and subtitle */
        }


        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 50px;
        }

        table, th, td {
            border: 1px solid #ddd;
        }

        th, td {
            padding: 8px 12px; /* Reduced padding to shorten row length */
            text-align: left;
        }

        th {
            background-color: #f1f1f1;
            color: #333;
            font-weight: bold;
            font-size: 16px;
   ");
                WriteLiteral(@"     }

        td {
            font-size: 15px;
            color: #333;
        }

            /* Adjust column widths */
            td:nth-child(2), th:nth-child(2) {
                width: 25%;
            }

            td:nth-child(3), th:nth-child(3) {
                width: 25%;
            }

            td:nth-child(4), th:nth-child(4) {
                width: 25%;
            }

            td:nth-child(5), th:nth-child(5) {
                width: 15%;
            }

        tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        tr:hover {
            background-color: #FFCCEA;
        }

        .modal-content {
            background-color: #FFF6E3;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
            border: none; /* Remove unnecessary borders */
        }

        .modal-header {
            background-color: #CDC1FF;
            color: #FFF6E3;
        ");
                WriteLiteral(@"    padding: 20px;
            border-bottom: none; /* Remove internal border */
            border-radius: 10px 10px 0 0;
        }

        .modal-footer {
            padding: 15px;
            display: flex;
            justify-content: space-between;
            border-radius: 0 0 10px 10px;
            border-top: none; /* Remove internal border */
        }

        .modal-title {
            font-size: 22px;
        }

        .form-control {
            border-radius: 8px;
            padding: 12px;
            border: 1px solid #ddd;
            margin-bottom: 15px;
            font-size: 16px;
        }

            .form-control:focus {
                border-color: #CDC1FF;
                box-shadow: 0 0 5px rgba(205, 193, 255, 0.5);
            }

        .btn {
            min-width: 40px;
            padding: 10px;
            font-size: 14px;
            border-radius: 5px;
        }

        .btn-light {
            background-color: #FFF6E3;
         ");
                WriteLiteral(@"   border-color: #FFCCEA;
        }

            .btn-light:hover {
                background-color: #FFCCEA;
                border-color: #CDC1FF;
            }

        .btn-primary {
            background-color: #CDC1FF;
            border-color: #CDC1FF;
            margin-bottom: 30px;
        }

            .btn-primary:hover {
                background-color: #B8A4FF;
                border-color: #B8A4FF;
            }

        /* Edit and Delete Buttons */
        .btn-square {
            width: 40px;
            height: 40px;
            padding: 0;
            font-size: 20px;
            text-align: center;
            line-height: 20px;
        }

        .btn-warning, .btn-danger {
            padding: 5px 10px;
            font-size: 16px;
        }

            .btn-warning i,
            .btn-danger i {
                font-size: 18px;
            }

        .modal-dialog {
            max-width: 500px;
            margin: 30px auto;
        }
");
                WriteLiteral(@"
        .modal-footer .btn {
            width: 45%;
            margin: 0 5px;
        }

        /* Alert Styles */
        .alert {
            margin-top: 20px;
        }

        .modal-footer .btn:hover {
            box-shadow: 0 0 8px rgba(0, 0, 0, 0.1);
        }

        /* Adjust Add/Update Employee buttons in modal */
        .modal-footer .btn-primary,
        .modal-footer .btn-warning {
            width: auto; /* Remove fixed width */
            height: auto; /* Remove fixed height */
            padding: 10px 20px; /* Add more padding for a rectangular shape */
            font-size: 16px; /* Adjust font size */
            border-radius: 5px; /* Optional: rounded corners */
        }


        /* Center the action buttons in the last column */
        td:last-child {
            text-align: center;
            vertical-align: middle; /* Ensures buttons are vertically centered */
        }

            /* Center the buttons inside the container */
           ");
                WriteLiteral(" td:last-child .action-buttons {\r\n                display: flex;\r\n                justify-content: center;\r\n                gap: 10px; /* Adds space between buttons */\r\n            }\r\n\r\n\r\n    </style>\r\n");
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
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "799612bbc402fa4a6c7106134ac7c891966bdc10ad65c80bd42ff4d66b0f8b4d10467", async() => {
                WriteLiteral(@"
    <h1>Employee Management</h1>

    <button type=""button"" class=""btn btn-primary"" data-bs-toggle=""modal"" data-bs-target=""#employeeModal"">
        Add New Employee
    </button>

    <h3>All Employees</h3>
    <table id=""employees-table"" class=""table table-striped"">
        <thead>
            <tr>
                <th>ID</th>
                <th>Name</th>
                <th>Department</th>
                <th>Salary</th>
                <th>Actions</th>
            </tr>
        </thead>
        <tbody>
            <!-- Dynamic employee rows will be added here -->
            <tr>
                <td>${employee.id}</td>
                <td>${employee.name}</td>
                <td>${employee.department}</td>
                <td>${employee.salary}</td>
                <td>
                    <div class=""action-buttons"">
                        <button class=""btn btn-warning"" onclick=""editEmployee(${employee.id})"">
                            <i class=""fas fa-edit""></i>
        ");
                WriteLiteral(@"                </button>
                        <button class=""btn btn-danger"" onclick=""deleteEmployee(${employee.id})"">
                            <i class=""fas fa-trash""></i>
                        </button>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>

    <div class=""modal fade"" id=""employeeModal"" tabindex=""-1"" aria-labelledby=""employeeModalLabel"" aria-hidden=""true"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""employeeModalLabel"">Add / Update Employee</h5>
                    <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
                </div>
                <div class=""modal-body"">
                    <input type=""hidden"" id=""employee-id"">
                    <div class=""form-group"">
                        <label for=""employee-name"">Name:</label>
              ");
                WriteLiteral(@"          <input type=""text"" id=""employee-name"" class=""form-control"">
                    </div>
                    <div class=""form-group"">
                        <label for=""employee-department"">Department:</label>
                        <input type=""text"" id=""employee-department"" class=""form-control"">
                    </div>
                    <div class=""form-group"">
                        <label for=""employee-salary"">Salary:</label>
                        <input type=""number"" id=""employee-salary"" class=""form-control"">
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-bs-dismiss=""modal"">Close</button>
                    <div class=""ml-auto"">
                        <button type=""button"" id=""add-btn"" class=""btn btn-primary"">Add Employee</button>
                        <button type=""button"" id=""update-btn"" class=""btn btn-warning"" style=""display: none;"">Update Employee");
                WriteLiteral(@"</button>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <script>
        const apiBaseUrl = ""https://localhost:65391/employees"";

        // Load Employees from API
        function loadEmployees() {
            $.get(apiBaseUrl, function(data) {
                const tbody = $(""#employees-table tbody"");
                tbody.empty();

                data.forEach(employee => {
                    tbody.append(`
                        <tr>
                            <td>${employee.id}</td>
                            <td>${employee.name}</td>
                            <td>${employee.department}</td>
                            <td>${employee.salary}</td>
                            <td>
                                <button class=""btn btn-warning"" onclick=""editEmployee(${employee.id})"">
                                    <i class=""fas fa-edit""></i>
                                </button>
                             ");
                WriteLiteral(@"   <button class=""btn btn-danger"" onclick=""deleteEmployee(${employee.id})"">
                                    <i class=""fas fa-trash""></i>
                                </button>
                            </td>
                        </tr>
                    `);
                });

                $('#employees-table').DataTable();
            });
        }

        // Add Employee
        $(""#add-btn"").click(function() {
            const employee = {
                name: $(""#employee-name"").val(),
                department: $(""#employee-department"").val(),
                salary: parseFloat($(""#employee-salary"").val())
            };

            $.ajax({
                url: apiBaseUrl,
                type: ""POST"",
                data: JSON.stringify(employee),
                contentType: ""application/json"",
                success: function() {
                    loadEmployees();
                    clearForm();
                    $('#employeeModal').modal('hide");
                WriteLiteral(@"');
                    showAlert(""Employee added successfully!"", ""success"");
                },
                error: function() {
                    showAlert(""Failed to add employee."", ""danger"");
                }
            });
        });

        // Edit Employee
        function editEmployee(id) {
            $.get(`${apiBaseUrl}/${id}`, function(employee) {
                $(""#employee-id"").val(employee.id);
                $(""#employee-name"").val(employee.name);
                $(""#employee-department"").val(employee.department);
                $(""#employee-salary"").val(employee.salary);

                $(""#add-btn"").hide();
                $(""#update-btn"").show();
                $('#employeeModal').modal('show');
            });
        }

        // Update Employee
        $(""#update-btn"").click(function() {
            const employee = {
                id: $(""#employee-id"").val(),
                name: $(""#employee-name"").val(),
                department: $(""#emp");
                WriteLiteral(@"loyee-department"").val(),
                salary: parseFloat($(""#employee-salary"").val())
            };

            $.ajax({
                url: `${apiBaseUrl}/${employee.id}`,
                type: ""PUT"",
                data: JSON.stringify(employee),
                contentType: ""application/json"",
                success: function() {
                    loadEmployees();
                    clearForm();
                    $(""#add-btn"").show();
                    $(""#update-btn"").hide();
                    $('#employeeModal').modal('hide');
                    showAlert(""Employee updated successfully!"", ""success"");
                },
                error: function() {
                    showAlert(""Failed to update employee."", ""danger"");
                }
            });
        });

        // Delete Employee
        function deleteEmployee(id) {
            if (confirm(""Are you sure you want to delete this employee?"")) {
                $.ajax({
                    url: ");
                WriteLiteral(@"`${apiBaseUrl}/${id}`,
                    type: ""DELETE"",
                    success: function() {
                        loadEmployees();
                        showAlert(""Employee deleted successfully!"", ""success"");
                    },
                    error: function() {
                        showAlert(""Failed to delete employee."", ""danger"");
                    }
                });
            }
        }

        // Clear form fields
        function clearForm() {
            $(""#employee-id"").val("""");
            $(""#employee-name"").val("""");
            $(""#employee-department"").val("""");
            $(""#employee-salary"").val("""");
        }

        // Show alerts
        function showAlert(message, type) {
            const alertContainer = $(""#alert-container"");
            alertContainer.html(`<div class=""alert alert-${type}"">${message}</div>`);
        }

        $(document).ready(function() {
            loadEmployees();
        });
    </script>
");
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
            WriteLiteral("\r\n");
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
