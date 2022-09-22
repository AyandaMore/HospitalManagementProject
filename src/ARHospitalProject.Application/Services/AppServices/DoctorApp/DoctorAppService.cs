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
using ARHospitalProject.Services.AppServices.PersonApp;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.AppServices.DoctorApp
{
 
   public class DoctorAppService: ApplicationService, IDoctorAppService
    {
        private readonly IRepository<Doctor ,Guid> _doctorRepository;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;

        public DoctorAppService(IRepository<Doctor, Guid> doctorRepository, UserManager userManager, RoleManager roleManager)
        {
            _doctorRepository = doctorRepository;
            _userManager = userManager;
            _roleManager = roleManager;
        }

     
        //1. Create
        [AbpAuthorize(PermissionNames.Pages_Create_Doctor)]
        public async Task<DoctorDto> CreateAsync(DoctorDto input)
        {
            var idNum = input.IdentificationNumber;
            var passportNum = input.PassportNumber;

            if (idNum.Length < 13)
            {
                throw new UserFriendlyException("The IdentificationNumber must be 13 characters long.");
            }

            if (passportNum.Length < 9 && passportNum.Length > 9)
            {
                throw new UserFriendlyException("The PassportNumber must be 9 characters long. Please enter valid Passport Number");
            }

            //Gendercheck
            string genderPart = idNum.Substring(6, 4);
            int genderNum = Convert.ToInt32(genderPart);

            //citizenship check
            string citizenshipPart = idNum.Substring(10, 1);
            int citizenShipNum = Convert.ToInt32(citizenshipPart);

            //input genderValue
            var genderValue = input.Gender;
            int genderValueNum = Convert.ToInt32(genderValue);

            if ((genderNum > 0 && genderNum < 4999) && (citizenShipNum == 0 || citizenShipNum == 1) && (genderValueNum == 1 && genderValueNum != 2))
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

                var doctor = ObjectMapper.Map<Doctor>(input);
                doctor.FirstName = char.ToUpper(input.FirstName[0]) + input.FirstName.Substring(1);
                doctor.LastName = char.ToUpper(input.LastName[0]) + input.LastName.Substring(1);

                doctor.User = user;
                await _doctorRepository.InsertAsync(doctor);
                CurrentUnitOfWork.SaveChanges();
                return ObjectMapper.Map<DoctorDto>(doctor);
            }
            else if ((genderNum > 4999 && genderNum < 9999) && (citizenShipNum == 0 || citizenShipNum == 1) && (genderValueNum == 2 && genderValueNum != 1))
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

                var doctor = ObjectMapper.Map<Doctor>(input);
                doctor.FirstName = char.ToUpper(input.FirstName[0]) + input.FirstName.Substring(1);
                doctor.LastName = char.ToUpper(input.LastName[0]) + input.LastName.Substring(1);

                doctor.User = user;
                await _doctorRepository.InsertAsync(doctor);
                CurrentUnitOfWork.SaveChanges();
                return ObjectMapper.Map<DoctorDto>(doctor);
            }
            else
            {
                throw new UserFriendlyException("Invalid ID Number, please enter valid RSA ID Number");
            }
        }


        //2.1. Read All
        [AbpAuthorize(PermissionNames.Pages_See_Doctor)]
        public async Task<PagedResultDto<DoctorDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
           
            var query = _doctorRepository.GetAllIncluding();
            var result = new PagedResultDto<DoctorDto>(); 
            result.TotalCount = query.Count();  
            result.Items = ObjectMapper.Map<IReadOnlyList<DoctorDto>>(query);  
            return await Task.FromResult(result); 
        }
       
        //2.2. Read by Id
        [AbpAuthorize(PermissionNames.Pages_See_Doctor_By_Id)]

        public async Task<PagedResultDto<DoctorDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id)
        {
            var query = _doctorRepository.GetAllIncluding();
            var IdResult = query.Where(data => data.Id == id); 
            var result = new PagedResultDto<DoctorDto>();
            result.Items = ObjectMapper.Map<IReadOnlyList<DoctorDto>>(IdResult);
            return await Task.FromResult(result);
        }

        //3. Update
        [AbpAuthorize(PermissionNames.Pages_Update_Doctor)]
 
        public async Task<DoctorDto> UpdateAsync(DoctorDto input)
        {
            var doctor = await _doctorRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, doctor);
            await _doctorRepository.UpdateAsync(doctor);
            return ObjectMapper.Map<DoctorDto>(doctor);
        }

        //4. Delete
        [AbpAuthorize(PermissionNames.Pages_Delete_Doctor)]

        public async Task DeleteAsync(Guid id)
        {
            var doctor = await _doctorRepository.GetAsync((Guid)id);
            await _doctorRepository.DeleteAsync(doctor);
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

    }
}


//User Manager
//creating a user

//Role Mansger
//creating a role 

