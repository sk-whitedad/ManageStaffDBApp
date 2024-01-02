using ManageStaffDBApp.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStaffDBApp.Model
{
    public static class DataWorker
    {
        //получить все отделы
        public static List<Department> GetAllDepartments()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Departments.ToList();
            }
        }
        //получить все позиции
        public static List<Position> GetAllPositions()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Positions.ToList();
            }
        }
        //получить всех пользователей
        public static List<User> GetAllUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Users.ToList();
            }
        }
        //создать отдел
        public static string CreateDepartment(string name)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем существует ли отдел
                bool checkIsExist = db.Departments.Any(el => el.Name == name);
                if (!checkIsExist)
                {
                    Department newDepartment = new Department();
                    newDepartment.Name = name;
                    db.Departments.Add(newDepartment);
                    db.SaveChanges();
                    result = "Сделано";
                }
                return result;
            }
        }
        //создать позицию
        static string CreatePosition(string name, decimal salary, int maxNumber, Department department)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем существует ли позиция
                bool checkIsExist = db.Positions.Any(el => el.Name == name && el.Salary == salary);
                if (!checkIsExist)
                {
                    Position newPosition = new Position 
                    { 
                        Name = name, 
                        Salary = salary, 
                        MaxNumber = maxNumber, 
                        DepartmentId = department.Id };
                    db.Positions.Add(newPosition);
                    db.SaveChanges();
                    result = "Сделано";
                }
                return result;
            }
        }
        //создать сотрудника
        static string CreateUser(string name, string surName, string phone, Position position)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем существует ли позиция
                bool checkIsExist = db.Users.Any(el => el.Phone == phone);
                if (!checkIsExist)
                {
                    User newUser = new User
                    {
                        Name = name,
                        SurName = surName,
                        Phone = phone,
                        PositionId = position.Id
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    result = "Сделано";
                }
                return result;
            }
        }
        //удалить отдел
        public static string DeleteDepartment(Department department)
        {
            string result = "Тагого отдела не существует";
            using(ApplicationContext db = new ApplicationContext())
            {
                db.Departments.Remove(department);
                db.SaveChanges();
                result = $"Сделано! Отдел {department.Name} удален.";
            }
            return result;
        }
        //удалить позицию
        public static string DeletePosition(Position position)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Positions.Remove(position);
                db.SaveChanges();
                result = $"Сделано! Позиция {position.Name} удалена.";
            }
            return result;
        }

        //удалить сотрудника
        public static string DeleteUser(User user)
        {
            string result = "Такого пользователя не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Remove(user);
                db.SaveChanges();
                result = $"Сделано! Пользователь {user.Name} удален.";
            }
            return result;
        }
        //редактирование отдел
        public static string EditDepartment(Department oldDepartment, string newName)
        {
            string result = "Тагого отдела не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Department department = db.Departments.FirstOrDefault(x => x.Id == oldDepartment.Id);
                department.Name = newName;
                db.SaveChanges();
                result = $"Сделано! Отдел {department.Name} изменен.";
            }
            return result;
        }
        //редактирование позицию
        public static string EditPosition(Position oldPosition, string newName, decimal newSalary, int newMaxNumber, Department newDepartment)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Position position = db.Positions.FirstOrDefault(x => x.Id == oldPosition.Id);
                position.Name = newName;
                position.Salary = newSalary;
                position.MaxNumber = newMaxNumber;
                position.DepartmentId = newDepartment.Id;
                db.SaveChanges();
                result = $"Сделано! Позиция {position.Name} изменена.";
            }
            return result;
        }
        //редактирование сотрудника
        public static string EditUser(User oldUser, string newName, string newSurName, string newPhone, Position newPosition)
        {
            string result = "Такого пользователя не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.FirstOrDefault(x => x.Id == oldUser.Id);
                user.Name = newName;
                user.SurName = newSurName;
                user.Phone = newPhone;
                user.PositionId = newPosition.Id;
                db.SaveChanges();
                result = $"Сделано! Пользователь {user.Name} изменен.";
            }
            return result;
        }
    }
}
