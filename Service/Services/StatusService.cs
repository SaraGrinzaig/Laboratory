using Service.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using AutoMapper;
using Service.DTOs;

namespace Service.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;

        public StatusService(IStatusRepository statusRepository, IMapper mapper)
        {
            _statusRepository = statusRepository;
            _mapper = mapper;
        }

        public IEnumerable<StatusDto> GetAllStatuses()
        {
            var statuses = _statusRepository.GetAllStatuses();
            return _mapper.Map<IEnumerable<StatusDto>>(statuses);
        }

        public StatusDto GetStatusById(int statusId)
        {
            var status = _statusRepository.GetStatusById(statusId);
            return _mapper.Map<StatusDto>(status);
        }

        public StatusDto CreateStatus(StatusDto statusDto)
        {
            var status = _mapper.Map<Status>(statusDto);
            _statusRepository.InsertStatus(status);
            return _mapper.Map<StatusDto>(status);
        }

        public void UpdateStatus(StatusDto statusDto)
        {
            var status = _mapper.Map<Status>(statusDto);
            _statusRepository.UpdateStatus(status);
        }

        public void DeleteStatus(int statusId)
        {
            _statusRepository.DeleteStatus(statusId);
        }

        public StatusDto GetCurrentStatusForDevice(int deviceId)
        {
            var status = _statusRepository.GetCurrentStatusForDevice(deviceId);
            return _mapper.Map<StatusDto>(status);
        }
    }
}
