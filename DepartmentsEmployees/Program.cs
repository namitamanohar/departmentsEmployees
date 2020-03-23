using DepartmentsEmployees.Data;
using DepartmentsEmployees.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DepartmentsEmployees
{
    class Program
    {
        static void Main(string[] args)
        {
           var departmentRepo = new DepartmentRepository();

            //Console.WriteLine("Getting All Departments:");
            //Console.WriteLine();

            List<Department> allDepartments = departmentRepo.GetAllDepartments();

            //foreach (Department dept in allDepartments)
            //{
            //    Console.WriteLine($"{dept.Id} {dept.DeptName}");
            //}


            //Console.WriteLine("----------------------------");
            //Console.WriteLine("Getting Department with Id 1");

            //Department singleDepartment = departmentRepo.GetDepartmentById(1);

            //Console.WriteLine($"{singleDepartment.Id} {singleDepartment.DeptName}");

            //Department legalDept = new Department
            //{
            //    DeptName = "Legal"
            //};

            //departmentRepo.AddDepartment(legalDept);

            //Console.WriteLine("-------------------------------");
            //Console.WriteLine("Added the new Legal Department!");

            var employeeRepo = new EmployeeRepository();
            var employees = employeeRepo.GetAllEmployees();

            //foreach(var employee in employees)
            //{
            //    Console.WriteLine($"{employee.FirstName} {employee.LastName} is in {employee.Department.DeptName}");  
            //}                

            while (true)
            {

            Console.WriteLine("Select an option ");
            Console.WriteLine("1. Add A Department");
            Console.WriteLine("2. Add An Employee");
            Console.WriteLine("3. Update A Department");
            Console.WriteLine("4. Update An Employee");
            Console.WriteLine("5. Delete A Department");
            Console.WriteLine("6. Delete A Employee");



            switch (int.Parse(Console.ReadLine()))
            {
                case 1:

                    Console.WriteLine("Enter your department name");
                    var departmentNameEntered = Console.ReadLine();
                    Department newDept = new Department
                    {
                        DeptName = departmentNameEntered
                    };
                    departmentRepo.AddDepartment(newDept);
                    Console.WriteLine("You have added your department!");
                    break;
                case 2:
                    Console.WriteLine("Enter the employees first name");
                    var firstNameEntered = Console.ReadLine();
                    Console.WriteLine("Enter the employees last name");
                    var lastNameEntered = Console.ReadLine();
                    Console.WriteLine("Select the department id");
                    foreach (var department in allDepartments)
                    {
                        Console.WriteLine($" {department.Id} {department.DeptName}");
                    }
                    var deptIdEntered = int.Parse(Console.ReadLine());
                    Employee newEmployee = new Employee
                    {
                        FirstName = firstNameEntered,
                        LastName = lastNameEntered,
                        DepartmentId = deptIdEntered
                    };
                    employeeRepo.CreateNewEmployee(newEmployee);
                    Console.WriteLine("You have added an employee");
                    break;
                case 3:
                    Console.WriteLine("Enter the department id you want to update");
                    foreach (var department in allDepartments)
                    {
                        Console.WriteLine($" {department.Id} {department.DeptName}");
                    }
                    var DeptId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the updated department name");
                    var updatedDeptName = Console.ReadLine();
                    var updatedDept = new Department
                    {
                        Id = DeptId,
                        DeptName = updatedDeptName
                    };
                    departmentRepo.UpdateDepartment(DeptId, updatedDept);

                    break;
                case 4:
                    Console.WriteLine("Enter the id of the employee you want to update");
                    foreach (var employee in employees)
                    {
                        Console.WriteLine($" {employee.Id} {employee.FirstName} {employee.LastName}");
                    }
                    var updatedEmpId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter updated first name:");
                    var updatedFirst = Console.ReadLine();
                    Console.WriteLine("Enter updated last name");
                    var updatedLast = Console.ReadLine();
                    Console.WriteLine("Enter the updated department");
                    foreach (var department in allDepartments)
                    {
                        Console.WriteLine($" {department.Id} {department.DeptName}");
                    }
                    var updatedDeptId = int.Parse(Console.ReadLine());

                    var updatedEmployee = new Employee
                    {
                        FirstName = updatedFirst,
                        LastName = updatedLast,
                        DepartmentId = updatedDeptId
                    };
                    employeeRepo.UpdateEmployee(updatedEmpId, updatedEmployee);
                    break;

                case 5:
                    Console.WriteLine("Select the department you want to delete");
                    foreach (var department in allDepartments)
                    {
                            Console.Write($"{department.Id} {department.DeptName} ");
                            var relatedEmp = employees.Where(emp => emp.DepartmentId == department.Id).ToList();
                            foreach(var emp in relatedEmp)
                            {
                                Console.Write($" {emp.Id} {emp.FirstName} {emp.LastName}"); 
                            }
                            Console.WriteLine();
                    }
                    var selectedDept = int.Parse(Console.ReadLine());
                        foreach (var emp in employees)
                        {
                            try
                            {
                                if(emp.Department.Id != selectedDept)
                                {
                                    
                                departmentRepo.DeleteDepartment(selectedDept);
                                    break; 
                                }

                            }
                            catch
                            {
                                Console.WriteLine("Delete the employees in that department first");
                                break; 
                            }
                        
                        }
                    break;
                case 6:
                    Console.WriteLine("Select the employee you would like to fire");
                    foreach (var emp in employees)
                    {
                        Console.WriteLine($"{emp.Id} {emp.FirstName} {emp.LastName} {emp.Department.DeptName}");
                    }
                    var empId = int.Parse(Console.ReadLine());
                    employeeRepo.DeleteEmployee(empId);
                    break;
                default:
                    break; 
            }


            }
        }
    }
}
