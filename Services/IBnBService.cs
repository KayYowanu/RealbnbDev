using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealbnbDev.Data;
using RealbnbDev.Models;

namespace RealbnbDev.Services
{
    public interface IBnBService
    {
        /*************************************************************************************************/
        /*FOR TODO-LIST DEVELOPER*/
        Task<IEnumerable<bnbProperties>> GetProperties();
        Task<bool> CreateProperty(bnbProperties bnb);
        Task<bool> UpdateProperty(int Id, bnbProperties bnb);
        Task<bnbProperties> SingleProperty(int id);
        Task<bool> DeleteProperty(int Id);
        /*************************************************************************************************/
        /*FOR TODO-LIST DEVELOPER SUB-TASKS*/
        /*Task<IEnumerable<SubTasks>> GetTodoSub(int Id);
        Task<bool> CreateTodoSub(SubTasks tod, int Id);
        Task<bool> DeleteTodoSub(int Id);
        Task<bool> IsDoneSub(int id, Boolean chechboxvalue);
        Task<SubTasks> GetSubTaskByTaskId(int Id);*/
        /*************************************************************************************************/
        /*FOR TODO-LIST DEVELOPER SMART TASK*/
        
        /*Task<IEnumerable<Todo>> GetCompletedTasks();
        Task<IEnumerable<Todo>> GetIncompletedTasks();
        Task<bool> IsDoneSmart(int id, Boolean chechboxvalue);
        Task<bool> CreateSmartTask(SmartTask tod);*/
        /*************************************************************************************************/
    }
}
