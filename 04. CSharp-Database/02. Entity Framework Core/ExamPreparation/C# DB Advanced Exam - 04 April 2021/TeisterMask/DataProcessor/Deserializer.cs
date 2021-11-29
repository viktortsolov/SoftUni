namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder stringBuilder = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Projects");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectDTO[]), xmlRoot);

            using StringReader stringReader = new StringReader(xmlString);

            ImportProjectDTO[] projectDtos = (ImportProjectDTO[])xmlSerializer.Deserialize(stringReader);

            HashSet<Project> projects = new HashSet<Project>();
            foreach (var projectDto in projectDtos)
            {
                if (!IsValid(projectDto))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                bool isOpenDateValid = DateTime.TryParseExact
                    (projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime openDate);

                if (!isOpenDateValid)
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? dueDate = null;
                if (!String.IsNullOrWhiteSpace(projectDto.DueDate))
                {
                    bool isDueDateValid = DateTime.TryParseExact
                        (projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDateValue);

                    if (!isDueDateValid)
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    dueDate = dueDateValue;
                }

                Project project = new Project()
                {
                    Name = projectDto.Name,
                    OpenDate = openDate,
                    DueDate = dueDate
                };

                HashSet<Task> projectTasks = new HashSet<Task>();
                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isTaskOpenDateValid = DateTime.TryParseExact
                        (taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskOpenDate);

                    if (!isTaskOpenDateValid)
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isTaskDueDateValid = DateTime.TryParseExact
                       (taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskDueDate);

                    if (!isTaskDueDateValid)
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < project.OpenDate)
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (project.DueDate.HasValue && taskDueDate > project.DueDate)
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task task = new Task()
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType
                    };

                    projectTasks.Add(task);
                }

                project.Tasks = projectTasks;

                stringBuilder.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, projectTasks.Count));

                projects.Add(project);
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return stringBuilder.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder stringBuilder = new StringBuilder();

            ImportEmployeeDTO[] employeeDtos = 
                JsonConvert.DeserializeObject<ImportEmployeeDTO[]>(jsonString);

            HashSet<Employee> validEmployees = new HashSet<Employee>();
            foreach (var employeeDto in employeeDtos)
            {
                if (!IsValid(employeeDto))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                Employee employee = new Employee()
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                HashSet<EmployeeTask> employeeTasks = new HashSet<EmployeeTask>();
                foreach (var taskId in employeeDto.Tasks.Distinct())
                {
                    Task task = context
                        .Tasks
                        .Find(taskId);

                    if (task == null)
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    EmployeeTask employeeTask = new EmployeeTask()
                    {
                        Employee = employee,
                        TaskId = taskId
                    };
                    employeeTasks.Add(employeeTask);
                }

                employee.EmployeesTasks = employeeTasks;

                validEmployees.Add(employee);

                stringBuilder.AppendLine(String.Format(SuccessfullyImportedEmployee, employee.Username, employeeTasks.Count));
            }

            context.Employees.AddRange(validEmployees);
            context.SaveChanges();

            return stringBuilder.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}