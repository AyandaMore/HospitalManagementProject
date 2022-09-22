using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.UI;
using ARHospitalProject.Authorization;
using ARHospitalProject.Authorization.Roles;
using ARHospitalProject.Authorization.Users;
using ARHospitalProject.Domain;
using ARHospitalProject.Services.Dto;
using ARHospitalProject.Services.Notifications;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ARHospitalProject.Domain.Patient;

namespace ARHospitalProject.Services.AppServices.PatientApp
{
    public class PatientAppService : ApplicationService, IPatientAppService
    {
        private readonly IRepository<Patient, Guid> _patientRepository;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;

        public PatientAppService(IRepository<Patient, Guid> patientRepository,  UserManager userManager, RoleManager roleManager)
        {
            _patientRepository = patientRepository;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        [AbpAuthorize(PermissionNames.Pages_Create_Patient)]
        public async Task<PatientDto> CreateAsync(PatientDto input)
        {
            var idNum = input.IdentificationNumber;
            var passportNum = input.PassportNumber;
           
            if (idNum.Length < 13)
            {
                throw new UserFriendlyException("The IdentificationNumber must be 13 characters long.");
            }

            if(passportNum.Length <9 && passportNum.Length > 9)
            {
                throw new UserFriendlyException("The PassportNumber must be 9 characters long. Please enter valid Passport Number");
            }

            //Gender Check
            string genderPart = idNum.Substring(6, 4); 
            int genderNum = Convert.ToInt32(genderPart);  
            
            //citizenship Check
            string citizenshipPart = idNum.Substring(10, 1);
            int citizenShipNum = Convert.ToInt32(citizenshipPart);

            //input genderValue
            var genderValue = input.Gender;
            int genderValueNum = Convert.ToInt32(genderValue);


            if ( (genderNum > 0 && genderNum < 4999) && (citizenShipNum ==0 || citizenShipNum == 1) && (genderValueNum == 1 && genderValueNum != 2))
            {
                var user = new User();
                user.Id = (long)input.UserId;
                user.TenantId = AbpSession.TenantId;
                user.EmailAddress = input.Email;
                user.PhoneNumber = input.CellPhoneNumber;
                user.IsEmailConfirmed = true;
                user.UserName = input.UserName;
                user.Name = input.FirstName;
                user.Surname = input.LastName;

                user.SetNormalizedNames();
                var password = input.Password;
                await _userManager.InitializeOptionsAsync(AbpSession.TenantId);
                CheckErrors(await _userManager.CreateAsync(user, password));
                CheckErrors(await _userManager.SetRolesAsync(user, input.RoleNames));


                var patient = ObjectMapper.Map<Patient>(input);
                patient.FirstName = char.ToUpper(input.FirstName[0]) + input.FirstName.Substring(1);
                patient.LastName = char.ToUpper(input.LastName[0]) + input.LastName.Substring(1);
                patient.User = user;
                await _patientRepository.InsertAsync(patient);
                CurrentUnitOfWork.SaveChanges();
                return ObjectMapper.Map<PatientDto>(patient);
            }
            else if ( (genderNum > 4999 && genderNum < 9999) && (citizenShipNum == 0 || citizenShipNum == 1) && (genderValueNum == 2 && genderValueNum !=1))
            {
                var user = new User();
                user.Id = (long)input.UserId;
                user.TenantId = AbpSession.TenantId;
                user.EmailAddress = input.Email;
                user.PhoneNumber = input.CellPhoneNumber;
                user.IsEmailConfirmed = true;
                user.UserName = input.UserName;
                user.Name = input.FirstName;
                user.Surname = input.LastName;

                user.SetNormalizedNames();
                var password = input.Password;
                await _userManager.InitializeOptionsAsync(AbpSession.TenantId);
                CheckErrors(await _userManager.CreateAsync(user, password));
                CheckErrors(await _userManager.SetRolesAsync(user, input.RoleNames));


                var patient = ObjectMapper.Map<Patient>(input);
                patient.FirstName = char.ToUpper(input.FirstName[0]) + input.FirstName.Substring(1);
                patient.LastName = char.ToUpper(input.LastName[0]) + input.LastName.Substring(1);
                patient.User = user;
                await _patientRepository.InsertAsync(patient);
                CurrentUnitOfWork.SaveChanges();
                return ObjectMapper.Map<PatientDto>(patient);
            }
            else
            {
                throw new UserFriendlyException("Invalid ID Number, please enter valid RSA ID Number");
            }
            
            
        }


        [AbpAuthorize(PermissionNames.Pages_See_Patient)]
        public async Task<PagedResultDto<PatientDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var query = _patientRepository.GetAllIncluding();
            var result = new PagedResultDto<PatientDto>(); 
            result.TotalCount = query.Count(); 
            result.Items = ObjectMapper.Map<IReadOnlyList<PatientDto>>(query);  
            return await Task.FromResult(result);
        }


        [AbpAuthorize(PermissionNames.Pages_See_Patient_By_Id)]
        public async Task<PagedResultDto<PatientDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id)
        {
            var query = _patientRepository.GetAllIncluding();
            var IdResult = query.Where(data => data.Id == id); 
            var result = new PagedResultDto<PatientDto>();
            result.Items = ObjectMapper.Map<IReadOnlyList<PatientDto>>(IdResult);
            return await Task.FromResult(result);
        }


        [AbpAuthorize(PermissionNames.Pages_Update_Patient)]
        public async Task<PatientDto> UpdateAsync(PatientDto input)
        {
            var patient = await _patientRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, patient);
            await _patientRepository.UpdateAsync(patient);
            return ObjectMapper.Map<PatientDto>(patient);
        }


        [AbpAuthorize(PermissionNames.Pages_Delete_Patient)]
        public async Task DeleteAsync(Guid id)
        {
            var patient = await _patientRepository.GetAsync((Guid)id);
            await _patientRepository.DeleteAsync(patient);
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }


    }
}
