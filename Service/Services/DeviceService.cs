using Service.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using AutoMapper;
using Service.DTOs;

namespace Service.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly IStatusTypeRepository _statusTypeRepository;
        private readonly IMapper _mapper;

        public DeviceService(IDeviceRepository deviceRepository, IStatusRepository statusRepository, IStatusTypeRepository statusTypeRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _statusRepository = statusRepository;
            _statusTypeRepository = statusTypeRepository;
            _mapper = mapper;
        }

        public IEnumerable<DeviceDto> GetAllDevices()
        {
            var devices = _deviceRepository.GetAllDevices();
            return _mapper.Map<IEnumerable<DeviceDto>>(devices);
        }

        public DeviceDto GetDeviceById(int deviceId)
        {
            var device = _deviceRepository.GetDeviceById(deviceId);
            return _mapper.Map<DeviceDto>(device);
        }

        public DeviceDto CreateDevice(DeviceDto deviceDto)
        {
            var device = _mapper.Map<Device>(deviceDto);
            _deviceRepository.InsertDevice(device);

            var entryStatusType = _statusTypeRepository.GetByName("נכנס");
            if (entryStatusType == null)
            {
                throw new Exception("Status type 'נכנס' not found in the system.");
            }

            var status = new Status
            {
                DeviceId = device.Id, // משתמש ב-Id של המכשיר שנוצר זה עתה
                StatusId = entryStatusType.Id, // סטטוס ברירת המחדל "נכנס"
                StatusChangeDate = DateTime.Now
            };

            _statusRepository.InsertStatus(status);

            return _mapper.Map<DeviceDto>(device);
        }


        public void UpdateDevice(DeviceDto deviceDto)
        {
            var device = _mapper.Map<Device>(deviceDto);
            _deviceRepository.UpdateDevice(device);
        }

        public void DeleteDevice(int deviceId)
        {
            _deviceRepository.DeleteDevice(deviceId);
        }
    }
}
