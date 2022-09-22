using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace ARHospitalProject.Authorization
{
    public class ARHospitalProjectAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_CreatePrescribedMedication, L("CreatePrescribedMedication"));

            //Doctor
            context.CreatePermission(PermissionNames.Pages_Create_Doctor, L("CreateDoctor"));
            context.CreatePermission(PermissionNames.Pages_See_Doctor_By_Id, L("SeeDoctorById"));
            context.CreatePermission(PermissionNames.Pages_Update_Doctor, L("UpdateDoctor"));
            context.CreatePermission(PermissionNames.Pages_See_Doctor, L("SeeDoctor"));
            context.CreatePermission(PermissionNames.Pages_Delete_Doctor, L("DeleteDoctor"));
            
            //Patient
            context.CreatePermission(PermissionNames.Pages_Create_Patient, L("CreatePatient"));
            context.CreatePermission(PermissionNames.Pages_Update_Patient, L("UpdatePatient"));
            context.CreatePermission(PermissionNames.Pages_See_Patient, L("SeePatient"));
            context.CreatePermission(PermissionNames.Pages_See_Patient_By_Id, L("SeePatientById"));
            context.CreatePermission(PermissionNames.Pages_Delete_Patient, L("DeletePatient"));

            //Receptionist
            context.CreatePermission(PermissionNames.Pages_Create_Receptionist, L("CreateReceptionist"));
            context.CreatePermission(PermissionNames.Pages_Update_Receptionist, L("UpdateReceptionist"));
            context.CreatePermission(PermissionNames.Pages_See_Receptionist, L("SeeReceptionist"));
            context.CreatePermission(PermissionNames.Pages_See_Receptionist_By_Id, L("SeeReceptionistById"));
            context.CreatePermission(PermissionNames.Pages_Delete_Receptionist, L("DeleteReceptionist"));

            //Hospital
            context.CreatePermission(PermissionNames.Pages_Create_Hospital, L("CreateHospital"));
            context.CreatePermission(PermissionNames.Pages_Update_Hospital, L("UpdateHospital"));
            context.CreatePermission(PermissionNames.Pages_See_Hospital, L("SeeHospital"));
            context.CreatePermission(PermissionNames.Pages_See_Hospital_By_Id, L("SeeHospitalById"));
            context.CreatePermission(PermissionNames.Pages_Delete_Hospital, L("DeleteHospital"));


            // DoctorAvailability
            context.CreatePermission(PermissionNames.Pages_Create_DoctorAvailability, L("CreateDoctorAvailability"));
            context.CreatePermission(PermissionNames.Pages_Update_DoctorAvailability, L("UpdateDoctorAvailability"));
            context.CreatePermission(PermissionNames.Pages_See_DoctorAvailability, L("SeeDoctorAvailability"));
            context.CreatePermission(PermissionNames.Pages_See_DoctorAvailability_By_Id, L("SeeDoctorAvailabilityById"));
            context.CreatePermission(PermissionNames.Pages_Delete_DoctorAvailability, L("DeleteDoctorAvailability"));

            // DoctorActivity
            context.CreatePermission(PermissionNames.Pages_Create_DoctorActivity, L("CreateDoctorActivity"));
            context.CreatePermission(PermissionNames.Pages_Update_DoctorActivity, L("UpdateDoctorActivity"));
            context.CreatePermission(PermissionNames.Pages_See_DoctorActivity, L("SeeDoctorActivity"));
            context.CreatePermission(PermissionNames.Pages_See_DoctorActivity_By_Id, L("SeeDoctorActivityById"));
            context.CreatePermission(PermissionNames.Pages_Delete_DoctorActivity, L("DeleteDoctorActivity"));


            // Appointment
            context.CreatePermission(PermissionNames.Pages_Create_Appointment, L("CreateAppointment"));
            context.CreatePermission(PermissionNames.Pages_Update_Appointment, L("UpdateAppointment"));
            context.CreatePermission(PermissionNames.Pages_See_Appointment, L("SeeAppointment"));
            context.CreatePermission(PermissionNames.Pages_See_Appointment_By_Id, L("SeeAppointmentById"));
            context.CreatePermission(PermissionNames.Pages_Delete_Appointment, L("DeleteAppointment"));

            // Medical Record 
            context.CreatePermission(PermissionNames.Pages_Create_MedicalRecord, L("CreateMedicalRecord"));
            context.CreatePermission(PermissionNames.Pages_Update_MedicalRecord, L("UpdateMedicalRecord"));
            context.CreatePermission(PermissionNames.Pages_See_MedicalRecord, L("SeeMedicalRecord"));
            context.CreatePermission(PermissionNames.Pages_See_MedicalRecord_By_Id, L("SeeMedicalRecordById"));
            context.CreatePermission(PermissionNames.Pages_Delete_MedicalRecord, L("DeleteMedicalRecord"));

            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ARHospitalProjectConsts.LocalizationSourceName);
        }
    }
}


