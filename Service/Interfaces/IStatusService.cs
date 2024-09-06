using Service.DTOs;

namespace Service.Interfaces
{
    public interface IStatusService
    {
        IEnumerable<StatusDto> GetAllStatuses();
        StatusDto GetStatusById(int statusId);
        StatusDto CreateStatus(StatusDto status);
        void UpdateStatus(StatusDto status);
        void DeleteStatus(int statusId);
        StatusDto GetCurrentStatusForDevice(int deviceId);
    }
}

