using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ARHospitalProject.Authorization.Roles;
using ARHospitalProject.Authorization.Users;
using ARHospitalProject.MultiTenancy;
using ARHospitalProject.Domain;

namespace ARHospitalProject.EntityFrameworkCore
{
    public class ARHospitalProjectDbContext : AbpZeroDbContext<Tenant, Role, User, ARHospitalProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Person> People { get; set; }     
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientReport> PatientReports { get; set; }
        public DbSet<DoctorAvailability> DoctorAvailabilities { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public ARHospitalProjectDbContext(DbContextOptions<ARHospitalProjectDbContext> options)
            : base(options)
        {
        }
    }
}
