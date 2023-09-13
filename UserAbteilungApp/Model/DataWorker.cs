using System.Collections.Generic;
using System.Linq;
using UserAbteilungApp.Model.Data;

namespace UserAbteilungApp.Model
{
    public static class DataWorker
    {
        public static List<Department> GetAllDepartments()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Departments.ToList();
                return result;
            }
        }

        public static List<Position> GetAllPositions()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Positions.ToList();
                return result;
            }
        }

        public static List<User> GetAllUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Users.ToList();
                return result;
            }
        }


        public static string CreateDepartment(string name)
        {
            string result = "Ist bereits vorhanden";
            using (ApplicationContext db = new ApplicationContext())
            {

                bool checkIsExist = db.Departments.Any(el => el.Name == name);
                if (!checkIsExist)
                {
                    Department newDepartment = new Department { Name = name };
                    db.Departments.Add(newDepartment);
                    db.SaveChanges();
                    result = "Ok, gemacht";
                }
                return result;
            }

        }
        public static string CreatePosition(string name, decimal salary, int maxNumber, Department department)
        {
            string result = "Ist bereits vorhanden";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Positions.Any(el => el.Name == name && el.Salary == salary);
                if (!checkIsExist)
                {
                    Position newPosition = new Position
                    {
                        Name = name,
                        Salary = salary,
                        MaxNumber = maxNumber,
                        DepartmentId = department.Id
                    };
                    db.Positions.Add(newPosition);
                    db.SaveChanges();
                    result = "Ok, gemacht!";
                }
                return result;
            }
        }

        public static string CreateUser(string name, string surName, string phone, Position position)
        {
            string result = "Ist bereits vorhanden";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Users.Any(el => el.Name == name && el.SurName == surName && el.Position == position);
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
                    result = "Ok, gemacht!";
                }
                return result;
            }
        }

        public static string DeleteDepartment(Department department)
        {
            string result = "Diese Abteilung existiert nicht.";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Departments.Remove(department);
                db.SaveChanges();
                result = "Diese Abteilung " + department.Name + " ist gelöscht";
            }
            return result;
        }

        public static string DeletePosition(Position position)
        {
            string result = "Diese Position existiert nicht";
            using (ApplicationContext db = new ApplicationContext())
            {

                db.Positions.Remove(position);
                db.SaveChanges();
                result = "Diese Position " + position.Name + " ist gelöscht";
            }
            return result;
        }

        public static string DeleteUser(User user)
        {
            string result = "User existiert nicht";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Remove(user);
                db.SaveChanges();
                result = "User  " + user.Name + " ist gekündigt";
            }
            return result;
        }

        public static string EditDepartment(Department oldDepartment, string newName)
        {
            string result = "Diese Abteilung existiert nicht.";
            using (ApplicationContext db = new ApplicationContext())
            {
                Department department = db.Departments.FirstOrDefault(d => d.Id == oldDepartment.Id);
                department.Name = newName;
                db.SaveChanges();
                result = "Die Abteilung " + department.Name + " ist geändert";
            }
            return result;
        }

        public static string EditPosition(Position oldPosition, string newName, int newMaxNumber, decimal newSalary, Department newDepartment)
        {
            string result = "Diese Position existiert nicht";
            using (ApplicationContext db = new ApplicationContext())
            {
                Position position = db.Positions.FirstOrDefault(p => p.Id == oldPosition.Id);

                position.Name = newName;
                position.Salary = newSalary;
                position.MaxNumber = newMaxNumber;
                position.DepartmentId = newDepartment.Id;
                db.SaveChanges();
                result = "Die Position " + position.Name + " ist geändert";
            }
            return result;
        }

        public static string EditUser(User oldUser, string newName, string newSurName, string newPhone, Position newPosition)
        {
            string result = "User existiert nicht";
            using (ApplicationContext db = new ApplicationContext())
            {

                User user = db.Users.FirstOrDefault(p => p.Id == oldUser.Id);
                if (user != null)
                {
                    user.Name = newName;
                    user.SurName = newSurName;
                    user.Phone = newPhone;
                    user.PositionId = newPosition.Id;
                    db.SaveChanges();
                    result = " Info über User " + user.Name + " ist geändert! ";
                }
            }
            return result;
        }

        //GetPosition(User) by PositionId (By User + NotMapped Property UserPosition)

        public static Position GetPositionById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Position pos = db.Positions.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }
        //GetDepartment(Position) by DepartmentId (By Position + NotMapped Property PositionDepartment)

        public static Department GetDepartmentById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Department dep = db.Departments.FirstOrDefault(p => p.Id == id);
                return dep;
            }
        }

        //Get AllUsers(in Position)  by PositionId 

        public static List<User> GetAllUsersByPositionId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<User> users = (from user in GetAllUsers() where user.PositionId == id select user).ToList();
                return users;
            }
        }

        //Get Alle Positions by DepartmentId 

        public static List<Position> GetAllPositionsByDepartmentId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Position> positions = (from position in GetAllPositions() where position.DepartmentId == id select position).ToList();
                return positions;
            }
        }
    }
}
