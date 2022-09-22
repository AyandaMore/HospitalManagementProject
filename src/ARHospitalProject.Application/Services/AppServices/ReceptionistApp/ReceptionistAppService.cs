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
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.AppServices.ReceptionistApp
{
    public class ReceptionistAppService:ApplicationService , IReceptionistAppService
    {
        private readonly IRepository<Receptionist, Guid> _receptionistRepository;
        private readonly IRepository<Hospital, Guid> _hospitalRepository;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;

        public ReceptionistAppService(IRepository<Receptionist, Guid> receptionistRepository, IRepository<Hospital, Guid> hospitalRepository, UserManager userManager, RoleManager roleManager) 
        {
            _receptionistRepository = receptionistRepository;
            _hospitalRepository = hospitalRepository;
            _userManager = userManager;
            _roleManager = roleManager;
        }

     
        [AbpAuthorize(PermissionNames.Pages_Create_Receptionist)]
        public async Task<ReceptionistDto> CreateAsync(ReceptionistDto input)
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

                var receptionist = ObjectMapper.Map<Receptionist>(input);
                receptionist.Hospital = await _hospitalRepository.GetAsync((Guid)input.HospitalId);
                receptionist.FirstName = char.ToUpper(input.FirstName[0]) + input.FirstName.Substring(1);
                receptionist.LastName = char.ToUpper(input.LastName[0]) + input.LastName.Substring(1);

                receptionist.User = user;
                await _receptionistRepository.InsertAsync(receptionist);
                CurrentUnitOfWork.SaveChanges();
                return ObjectMapper.Map<ReceptionistDto>(receptionist);

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

                var receptionist = ObjectMapper.Map<Receptionist>(input);
                receptionist.Hospital = await _hospitalRepository.GetAsync((Guid)input.HospitalId);
                receptionist.FirstName = char.ToUpper(input.FirstName[0]) + input.FirstName.Substring(1);
                receptionist.LastName = char.ToUpper(input.LastName[0]) + input.LastName.Substring(1);

                receptionist.User = user;
                await _receptionistRepository.InsertAsync(receptionist);
                CurrentUnitOfWork.SaveChanges();
                return ObjectMapper.Map<ReceptionistDto>(receptionist);
            }
            else
            {
                throw new UserFriendlyException("Invalid ID Number, please enter valid RSA ID Number");
            }


        }


        [AbpAuthorize(PermissionNames.Pages_See_Receptionist)]
        public async Task<PagedResultDto<ReceptionistDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var query = _receptionistRepository.GetAllIncluding(h=>h.Hospital);
            var result = new PagedResultDto<ReceptionistDto>();
            result.TotalCount = query.Count();  
            result.Items = ObjectMapper.Map<IReadOnlyList<ReceptionistDto>>(query); 
            return await Task.FromResult(result);
        }


        [AbpAuthorize(PermissionNames.Pages_See_Receptionist_By_Id)]
        public async Task<PagedResultDto<ReceptionistDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id)
        {
            var query = _receptionistRepository.GetAllIncluding(h => h.Hospital);
            var IdResult = query.Where(data => data.Id == id);
            var result = new PagedResultDto<ReceptionistDto>();
            result.Items = ObjectMapper.Map<IReadOnlyList<ReceptionistDto>>(IdResult);
            return await Task.FromResult(result);
        }

        [AbpAuthorize(PermissionNames.Pages_Update_Receptionist)]
        public async Task<ReceptionistDto> UpdateAsync(ReceptionistDto input)
        {
            var receptionist = await _receptionistRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, receptionist);
            await _receptionistRepository.UpdateAsync(receptionist);
            return ObjectMapper.Map<ReceptionistDto>(receptionist);
        }

        [AbpAuthorize(PermissionNames.Pages_Delete_Receptionist)]
        public async Task DeleteAsync(Guid id)
        {
            var receptionist = await _receptionistRepository.GetAsync((Guid)id);
            await _receptionistRepository.DeleteAsync(receptionist);
        }

        private void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

    }
}

