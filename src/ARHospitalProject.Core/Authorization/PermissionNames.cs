namespace ARHospitalProject.Authorization
{
    public static class PermissionNames
    {
        public const string Pages_Tenants = "Pages.Tenants";

        //CRUD Doctor
        public const string Pages_Create_Doctor = "Pages.CreateDoctor";  
        public const string Pages_See_Doctor_By_Id = "Pages.SeeDoctorById";
        public const string Pages_Update_Doctor = "Pages.UpdateDoctor";
        public const string Pages_See_Doctor = "Pages.SeeDoctor";
        public const string Pages_Delete_Doctor = "Pages.DeleteDoctor";

        //CRUD Patient
        public const string Pages_Create_Patient = "Pages.CreatePatient";  //Receptionist
        public const string Pages_Update_Patient = "Pages.UpdatePatient";  //Receptionist
        public const string Pages_See_Patient = "Pages.SeePatient";  //Receptionist  //Doctor
        public const string Pages_See_Patient_By_Id =    "Pages.SeePatientById";  //Receptionist  //Doctor
        public const string Pages_Delete_Patient = "Pages.DeletePatient";  //Receptionist

        //CRUD Receptionist
        public const string Pages_See_Receptionist = "Pages.SeeReceptionist"; //Patient
        public const string Pages_See_Receptionist_By_Id = "Pages.SeeReceptionistById";  //Patient
        public const string Pages_Update_Receptionist = "Pages.UpdateReceptionist";
        public const string Pages_Create_Receptionist = "Pages.CreateReceptionist";
        public const string Pages_Delete_Receptionist = "Pages.DeleteReceptionist";

        //CRUD Hospital
        public const string Pages_See_Hospital = "Pages.SeeHospital"; //Receptionist  // Doctor //Patient
        public const string Pages_See_Hospital_By_Id = "Pages.SeeHospitalById"; //Receptionist  //Doctor //Patient
        public const string Pages_Create_Hospital = "Pages.CreateHospital";
        public const string Pages_Update_Hospital = "Pages.UpdateHospital";
        public const string Pages_Delete_Hospital = "Pages.DeleteHospital";

        //CRUD DoctorAvailability
        public const string Pages_See_DoctorAvailability = "Pages.SeeDoctorAvailability"; //Receptionist // Doctor  //Patient
        public const string Pages_See_DoctorAvailability_By_Id = "Pages.SeeDoctorAvailabilityById"; //Receptionist //Doctor  //Patient
        public const string Pages_Create_DoctorAvailability = "Pages.CreateDoctorAvailability"; //Receptionist  //Doctor
        public const string Pages_Update_DoctorAvailability = "Pages.UpdateDoctorAvailability"; //Receptionist  //Doctor
        public const string Pages_Delete_DoctorAvailability = "Pages.DeleteDoctorAvailability"; //Receptionist  //Doctor

        //CRUD DoctorActivity
        public const string Pages_See_DoctorActivity = "Pages.SeeDoctorActivity";  //Receptionist  //Doc
        public const string Pages_See_DoctorActivity_By_Id = "Pages.SeeDoctorActivityById"; //Receptionist   //Doc
        public const string Pages_Update_DoctorActivity = "Pages.UpdateDoctorActivity";  
        public const string Pages_Delete_DoctorActivity = "Pages.DeleteDoctorActivity";
        public const string Pages_Create_DoctorActivity = "Pages.CreateDoctorActivity";  //Doc


        //CRUD Appointment
        public const string Pages_See_Appointment = "Pages.SeeAppointment"; //Receptionist  // Doc  
        public const string Pages_See_Appointment_By_Id = "Pages.SeeAppointmentById"; //Receptionist  //Doc  //Patient
        public const string Pages_Create_Appointment = "Pages.CreateAppointment"; //Receptionist  //Doc  //Patient
        public const string Pages_Update_Appointment = "Pages.UpdateAppointment";//Has an enum so we can delete but update the status //Receptionist  //Doc
        public const string Pages_Delete_Appointment = "Pages.DeleteAppointment"; 


        //CRUD MedicalRecord
        public const string Pages_See_MedicalRecord= "Pages.SeeMedicalRecord";  //Doc
        public const string Pages_See_MedicalRecord_By_Id = "Pages.SeeMedicalRecordById";  //Doc
        public const string Pages_Create_MedicalRecord = "Pages.CreateMedicalRecord";  //Doc
        public const string Pages_Update_MedicalRecord = "Pages.UpdateMedicalRecord";  //Doc
        public const string Pages_Delete_MedicalRecord = "Pages.DeleteMedicalRecord";

        /// <summary
        /// </summary>



        public const string Pages_Users = "Pages.Users";
        public const string Pages_Users_Activation = "Pages.Users.Activation";
        public const string Pages_Roles = "Pages.Roles";
        public const string Pages_CreatePrescribedMedication = "Pages.CreatePrescribedMedication";
    }
}
