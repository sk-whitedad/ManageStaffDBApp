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

        //создать сотрудника

        //удалить отдел

        //удалить позицию

        //удалить сотрудника

        //редактирование отдел

        //редактирование позицию

        //редактирование сотрудника
    }
}
