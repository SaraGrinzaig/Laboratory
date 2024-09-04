using Service.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using AutoMapper;
using Service.DTOs;

namespace Service.Implementations
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        public DeviceService(IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
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
            _deviceRepository.Save();
            return _mapper.Map<DeviceDto>(device);

        }

        public void UpdateDevice(DeviceDto deviceDto)
        {
            var device = _mapper.Map<Device>(deviceDto);
            _deviceRepository.UpdateDevice(device);
            _deviceRepository.Save();
        }

        public void DeleteDevice(int deviceId)
        {
            _deviceRepository.DeleteDevice(deviceId);
            _deviceRepository.Save();
        }
    }
}

