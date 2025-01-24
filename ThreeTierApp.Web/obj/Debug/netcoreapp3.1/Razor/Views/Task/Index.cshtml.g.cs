#pragma checksum "E:\Trusha\Training\ThreeTierApp\ThreeTierApp.Web\Views\Task\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "063aa5e193ad13db937155eb55ec33aeae9f82539db7c3bc761fdaac47dd7c15"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCoreGeneratedDocument.Views_Task_Index), @"mvc.1.0.view", @"/Views/Task/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"063aa5e193ad13db937155eb55ec33aeae9f82539db7c3bc761fdaac47dd7c15", @"/Views/Task/Index.cshtml")]
    #nullable restore
    internal sealed class Views_Task_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("ng-controller", new global::Microsoft.AspNetCore.Html.HtmlString("TaskController"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 1 "E:\Trusha\Training\ThreeTierApp\ThreeTierApp.Web\Views\Task\Index.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n<!-- Task Management Page -->\r\n<!DOCTYPE html>\r\n<html lang=\"en\" ng-app=\"taskApp\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "063aa5e193ad13db937155eb55ec33aeae9f82539db7c3bc761fdaac47dd7c153547", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Task Management</title>

    <!-- Bootstrap CSS -->
    <link href=""https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"" rel=""stylesheet"">

    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src=""https://code.jquery.com/jquery-3.5.1.min.js""></script>

    <!-- Popper.js (necessary for Bootstrap) -->
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.1/umd/popper.min.js""></script>

    <!-- Bootstrap JavaScript -->
    <script src=""https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js""></script>

    <!-- Select2 CSS -->
    <link href=""https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.13/css/select2.min.css"" rel=""stylesheet"" />

    <!-- Select2 JS -->
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.13/js/select2.min.js""></script>

    <!-- AngularJS -->
    <script sr");
                WriteLiteral(@"c=""https://ajax.googleapis.com/ajax/libs/angularjs/1.8.2/angular.min.js""></script>

    <!-- Bootstrap JS (with Popper) -->
    <script src=""https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js""></script>


    <style>
        /* Ensure the select input is full width */
        .custom-select-width {
            width: 100% !important; /* Ensure it takes full width of the parent */
            height: calc(2.25rem + 2px) !important; /* Match the height with other inputs */
            padding: 0.375rem 0.75rem; /* Match padding with other inputs */
        }

        /* Select2 Dropdown styling */
        .select2-container {
            width: 100% !important; /* Ensure the dropdown width is 100% */
        }

        .select2-selection {
            height: calc(2.25rem + 2px) !important; /* Match the height of the dropdown */
            padding: 0.375rem 0.75rem !important; /* Match the padding with other inputs */
        }

        /* Add some margin to th");
                WriteLiteral(@"e dropdown to align with other form controls */
        .select2-selection__rendered {
            padding-left: 10px; /* Optional: Adjust padding to make it look neat */
        }

        .alert .close {
            position: absolute;
            top: 50%;
            right: 15px;
            transform: translateY(-50%);
            font-size: 1.25rem;
            color: #000; /* Adjust color if needed */
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "063aa5e193ad13db937155eb55ec33aeae9f82539db7c3bc761fdaac47dd7c157133", async() => {
                WriteLiteral(@"
    <div class=""container mt-5"">
        <div class=""row"">
            <div class=""col-12"">
                <h2 class=""text-center"">Task Management</h2>
                <button ng-click=""openTaskModal()"" class=""btn btn-primary mb-3"">Add Task</button>
            </div>
        </div>

        <div class=""alert alert-success alert-dismissible fade show"" ng-if=""notification.message"" role=""alert"">
            {{notification.message}}
            <button type=""button"" class=""close"" aria-label=""Close"" ng-click=""closeNotification()"">
                <span aria-hidden=""true"">&times;</span>
            </button>
        </div>


        <div class=""row"">
            <div class=""col-12"">
                <table class=""table table-striped table-bordered"" id=""tasksTable"">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Task Name</th>
                            <th>Description</th>
                            <th>Dea");
                WriteLiteral(@"dline</th>
                            <th>Is Completed</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr ng-repeat=""task in tasks"">
                            <td>{{$index + 1}}</td>
                            <td>{{task.title}}</td>
                            <td>{{task.description}}</td>
                            <td>{{task.dueDate | date:'yyyy-MM-dd'}}</td>
                            <td>
                                <!-- Toggle Button for Task Status -->
                                <div class=""form-check form-switch"">
                                    <input type=""checkbox"" class=""form-check-input"" ng-model=""task.isCompleted"" ng-change=""toggleTaskStatus(task)"" />
                                    <label class=""form-check-label"">{{task.isCompleted ? 'Completed' : 'Pending'}}</label>
                                </div>
                            </td>
   ");
                WriteLiteral(@"                         <td>
                                <button ng-click=""viewAssignedEmployees(task)"" class=""btn btn-sm btn-info"">View Employees</button>
                                <button ng-click=""openTaskModal(task)"" class=""btn btn-sm btn-warning"">Edit</button>
                                <button ng-click=""deleteTask(task.id)"" class=""btn btn-sm btn-danger"">Delete</button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <!-- Task Modal -->
    <div id=""taskModal"" class=""modal"" tabindex=""-1"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"">{{task.id ? 'Edit Task' : 'Add Task'}}</h5>
                    <button type=""button"" class=""close"" ng-click=""closeTaskModal()"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</sp");
                WriteLiteral(@"an>
                    </button>
                </div>
                <div class=""modal-body"">
                    <form name=""taskForm"">
                        <input type=""hidden"" ng-model=""task.id"" />
                        <div class=""mb-3"">
                            <label for=""taskName"" class=""form-label"">Task Name</label>
                            <input type=""text"" class=""form-control"" ng-model=""task.title"" required />
                        </div>
                        <div class=""mb-3"">
                            <label for=""description"" class=""form-label"">Description</label>
                            <textarea class=""form-control"" ng-model=""task.description"" rows=""3"" required></textarea>
                        </div>

                        <div class=""mb-3"">
                            <label for=""assignedTo"" class=""form-label"">Assigned To</label>
                            <select id=""assignedEmployees"" class=""form-control custom-select-width"" ng-model=""task.ass");
                WriteLiteral(@"ignedEmployeeIds"" ng-options=""employee.id as employee.name for employee in employees"" multiple>
                            </select>
                        </div>


                        <div class=""mb-3"">
                            <label for=""deadline"" class=""form-label"">Deadline</label>
                            <input type=""date"" class=""form-control"" ng-model=""task.dueDate"" required />
                        </div>

                        <div class=""mb-3"">
                            <label for=""status"" class=""form-label"">Status</label>
                            <div class=""form-check form-switch"">
                                <input type=""checkbox"" class=""form-check-input"" ng-model=""task.isCompleted"" ng-change=""toggleTaskStatus(task)"" />
                                <label class=""form-check-label"" for=""status"">{{task.isCompleted ? 'Completed' : 'Pending'}}</label>
                            </div>
                        </div>
                    </form>
            ");
                WriteLiteral(@"    </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" ng-click=""closeTaskModal()"">Close</button>
                    <button type=""button"" class=""btn btn-primary"" ng-click=""saveTask()"">Save</button>
                </div>
            </div>
        </div>
    </div>

    <div id=""employeeModal"" class=""modal"" tabindex=""-1"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"">Assigned Employees</h5>
                    <!-- Use 'close' for Bootstrap 4 -->
                    <button type=""button"" class=""close"" ng-click=""closeEmployeeModal()"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <ul>
                        <li ng-repeat=""employee in employeeList"">{{employee.");
                WriteLiteral(@"name}}</li>
                    </ul>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" ng-click=""closeEmployeeModal()"">Close</button>
                </div>
            </div>
        </div>
    </div>


    <script>
        angular.module('taskApp', [])
            .controller('TaskController', function ($scope, $http, $timeout) {
                // Initialize task and notification models
                $scope.tasks = [];
                $scope.employees = [];
                $scope.notification = { message: '' };

                // Function to initialize or reinitialize DataTable
                $scope.initializeDataTable = function () {
                    $timeout(function () {
                        if ($.fn.DataTable.isDataTable('#tasksTable')) {
                            $('#tasksTable').DataTable().destroy(); // Destroy existing DataTable instance
                        }
               ");
                WriteLiteral(@"         $('#tasksTable').DataTable(); // Reinitialize DataTable
                    }, 0);
                };

                // Function to load all tasks
                $scope.loadTasks = function () {
                    $http.get('/tasks')  // Adjusted URL
                        .then(function (response) {
                            if (response.data.data) {
                                $scope.tasks = response.data.data;
                                $scope.initializeDataTable(); // Reinitialize DataTable after loading tasks
                            }
                        });
                };

                // Update task status when checkbox is toggled
                $scope.toggleTaskStatus = function (task) {
                // Prepare the payload with all required properties
                const updateData = {
                    Id: task.id,
                    Title: task.title,
                    Description: task.description,
                    Assigned");
                WriteLiteral(@"EmployeeIds: task.assignedEmployeeIds,
                    DueDate: task.dueDate,
                    IsCompleted: task.isCompleted,
                };

                    $http.put(`/tasks/${task.id}`, updateData) // Ensure the endpoint matches the backend API
                        .then(function (response) {
                            $scope.showNotification('Task status updated successfully!');
                            $scope.loadTasks(); // Reload tasks to reflect the latest data
                        })
                        .catch(function (error) {
                            console.error('Error updating task status:', error);
                            $scope.showNotification('Failed to update task status.');
                        });
                };



                // Function to load employees
                $scope.loadEmployees = function () {
                    $http.get('https://localhost:65391/employees') // Ensure this is the correct URL for employees");
                WriteLiteral(@"
                        .then(function (response) {
                            $scope.employees = response.data;
                        });
                };

                // Show notifications
                $scope.showNotification = function (message) {
                    $scope.notification.message = message;
                    $timeout($scope.closeNotification, 5000);
                };

                // Close notifications
                $scope.closeNotification = function () {
                    $scope.notification.message = '';
                };

                 $scope.viewAssignedEmployees = function (task) {
                    $scope.employeeList = []; // Reset the employee list
                    task.assignedEmployeeIds.forEach(function (employeeId) {
                        $http.get('https://localhost:65391/employees/' + employeeId)  // Fetch employee by ID
                            .then(function (response) {
                                $scope.employe");
                WriteLiteral(@"eList.push(response.data); // Add the employee to the list
                            });
                    });

                    // Open the modal to show employee names
                    $timeout(function () {
                        $('#employeeModal').modal('show');
                    }, 0);
                };


                $scope.openTaskModal = function (task) {
                    if (task) {
                        $scope.task = angular.copy(task);

                        // Ensure that assigned employees are properly populated
                        $scope.task.assignedEmployeeNames = [];
                        $scope.task.assignedEmployeeIds.forEach(function (employeeId) {
                            $http.get('https://localhost:65391/employees/' + employeeId)  // Fetch employee by ID
                                .then(function (response) {
                                    $scope.task.assignedEmployeeNames.push(response.data.name); // Store the employee name");
                WriteLiteral(@"
                                });
                        });

                        // Format the due date correctly if needed (in case it was a string in the server)
                        if ($scope.task.dueDate) {
                            $scope.task.dueDate = new Date($scope.task.dueDate).toISOString().split('T')[0];
                        }

                    } else {
                        // New task for adding
                        $scope.task = { assignedEmployeeIds: [], assignedEmployeeNames: [] };
                    }

                    // Wait until the task data is fully set before initializing Select2
                    $timeout(function () {
                        $('#assignedEmployees').select2({
                            placeholder: 'Select employees',
                            allowClear: true
                        });

                        // Set selected values in Select2 based on task data
                        $('#assignedEmployees')");
                WriteLiteral(@".val($scope.task.assignedEmployeeIds).trigger('change');
                    }, 0);

                    // Open modal
                    $timeout(function () {
                        $('#taskModal').modal('show');
                    }, 0);
                };

                // Close the modal
                $scope.closeTaskModal = function () {
                    $('#taskModal').modal('hide');
                };

            $scope.saveTask = function () {
            // Create task data, omit Id for POST request
            const taskData = {
                Title: $scope.task.title,
                Description: $scope.task.description,
                AssignedEmployeeIds: $scope.task.assignedEmployeeIds,
                DueDate: $scope.task.dueDate,
                IsCompleted: $scope.task.isCompleted
            };

            // Set method and URL based on whether task ID exists
            const method = $scope.task.id ? 'PUT' : 'POST';
            const url = $scope.tas");
                WriteLiteral(@"k.id ? '/tasks/' + $scope.task.id : '/tasks';

            // If it's a PUT request, include the ID in the payload
            if ($scope.task.id) {
                taskData.Id = $scope.task.id;
            }

            $http({
                method: method,
                url: url,
                data: taskData,
            }).then(function () {
                $scope.showNotification('Task saved successfully!');
                $scope.loadTasks();
                $scope.closeTaskModal();
            }).catch(function (error) {
                console.error('Error saving task:', error);
                $scope.showNotification('Failed to save task.');
            });
        };

                $scope.deleteTask = function (taskId) {
            // Confirm deletion
            if (confirm('Are you sure you want to delete this task?')) {
                $http.delete('/tasks/' + taskId)  // Use the appropriate delete API endpoint
                    .then(function (response) {
   ");
                WriteLiteral(@"                     $scope.showNotification('Task deleted successfully!');
                        $scope.loadTasks();  // Reload tasks after deletion
                    })
                    .catch(function (error) {
                        console.error('Error deleting task:', error);
                        $scope.showNotification('Failed to delete task.');
                    });
            }
        };


                $scope.closeEmployeeModal = function () {
                    $('#employeeModal').modal('hide');
                };

                $scope.loadTasks();
                $scope.loadEmployees();
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
