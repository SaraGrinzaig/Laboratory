using Service.DTOs;

namespace Service.Interfaces
{
    public interface IStatusService
    {
        IEnumerable<StatusDto> GetAllStatuses();
        StatusDto GetStatusById(int statusId);
        void CreateStatus(StatusDto status);
        void UpdateStatus(StatusDto status);
        void DeleteStatus(int statusId);
    }
}

