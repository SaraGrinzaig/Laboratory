using Service.DTOs;

namespace Service.Interfaces
{
    public interface IDeviceService
    {
        IEnumerable<DeviceDto> GetAllDevices();
        DeviceDto GetDeviceById(int deviceId);
        DeviceDto CreateDevice(DeviceDto device);
        void UpdateDevice(DeviceDto device);
        void DeleteDevice(int deviceId);
    }
}


