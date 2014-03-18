using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class Organization
    {
        public string Name;
        public List<Departament> Departaments;
        public List<Office> Offices;
        public List<Employee> Employees;
    }
    public class Employee
    {
        public string Name;
        public Position Position;
        public Departament Departament;
        public Office Office;
    }
    public class Position
    {
        public string Name;
        public Departament Departament;
    }
    public class Departament
    {
        public Employee Chief;
        public List<Employee> Employees;
        public List<Office> Offices;
    }
    public class Office
    {
        public string Location;
        public string Departament;
    }
}
