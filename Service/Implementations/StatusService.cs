using Service.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using AutoMapper;
using Service.DTOs;

namespace Service.Implementations
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
            _statusRepository.Save();
            return _mapper.Map<StatusDto>(status);
        }

        public void UpdateStatus(StatusDto statusDto)
        {
            var status = _mapper.Map<Status>(statusDto);
            _statusRepository.UpdateStatus(status);
            _statusRepository.Save();
        }

        public void DeleteStatus(int statusId)
        {
            _statusRepository.DeleteStatus(statusId);
            _statusRepository.Save();
        }
    }
}
