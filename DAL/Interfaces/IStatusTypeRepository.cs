using DAL.Models;

namespace DAL.Interfaces
{
    public interface IStatusTypeRepository
    {
        StatusType GetById(int id);
        StatusType GetByName(string statusName);
        IEnumerable<StatusType> GetAllStatusTypes();
        void InsertStatusType(StatusType statusType);
        void UpdateStatusType(StatusType statusType);
        void DeleteStatusType(int id);
    }
}
