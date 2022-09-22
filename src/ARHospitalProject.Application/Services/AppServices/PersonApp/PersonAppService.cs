using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ARHospitalProject.Domain;
using ARHospitalProject.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.AppServices.PersonApp
{
    public class PersonAppService: ApplicationService, IPersonAppService
    {
        private readonly IRepository<Person, Guid> _personRepository;
        public PersonAppService(IRepository<Person, Guid> personRepository)
        
        {
            _personRepository = personRepository;
        }

        public async Task<PersonDto> CreateAsync(PersonDto input)
        {
            var person = ObjectMapper.Map<Person>(input);
            await _personRepository.InsertAsync(person);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<PersonDto>(person);
        }

        public async Task DeleteAsync(Guid id)
        {
            var person = await _personRepository.GetAsync((Guid)id);
            await _personRepository.DeleteAsync(person);
        }

        public async Task<PagedResultDto<PersonDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
      
                var query = _personRepository.GetAllIncluding();
                var result = new PagedResultDto<PersonDto>();  
                result.TotalCount = query.Count(); 
                result.Items = ObjectMapper.Map<IReadOnlyList<PersonDto>>(query);  
                return await Task.FromResult(result); 

           
        }

        public async Task<PagedResultDto<PersonDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id)
        {
          
                var query = _personRepository.GetAllIncluding();
                var IdResult = query.Where(data => data.Id == id);
                var result = new PagedResultDto<PersonDto>();
                result.Items = ObjectMapper.Map<IReadOnlyList<PersonDto>>(IdResult);
                return await Task.FromResult(result);
       
        }

        public async Task<PersonDto> UpdateAsync( PersonDto input)
        {
            var person = await _personRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, person);
            await _personRepository.UpdateAsync(person);
            return ObjectMapper.Map<PersonDto>(person);
        }
    }
}
