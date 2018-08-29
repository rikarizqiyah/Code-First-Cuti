namespace Cuti.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class ModelCuti : DbContext
    {
        // Your context has been configured to use a 'ModelCuti' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CodeFirst.Models.ModelCuti' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ModelCuti' 
        // connection string in the application configuration file.
        public ModelCuti()
            : base("name=ModelCuti")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<SpecialLeave> SpecialLeaves { get; set; }
        public DbSet<ApprovalHistory> ApprovalHistories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

    public class LeaveRequest
    {
        [Key]
        public string id { get; set; }
        public string SpecialLeaveId { get; set; }
        public virtual SpecialLeave Special_Leave_Id { get; set; }
        public string UserId { get; set; }
        public virtual User User_Id { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public int Total_Date { get; set; }
        public int Holiday { get; set; }
        public DateTime Start_Date_Special { get; set; }
        public DateTime End_Date_Special { get; set; }
        public string Attachment { get; set; }
        public ICollection<ApprovalHistory> ApprovalHistoryCollection { get; set; }
    }

    public class SpecialLeave
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Qty_Leave { get; set; }
        public ICollection<LeaveRequest> LeaveRequestCollection { get; set; }
    }

    public class ApprovalHistory
    {
        [Key]
        public string Id { get; set; }
        public string LeaveRequestId { get; set; }
        public virtual LeaveRequest Leave_Request_Id { get; set; }
        public DateTime Date_Action { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }

    }

    public class User
    {
        [Key]
        public string Id { get; set; }
        public string RoleId { get; set; }
        public virtual Role Role_Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string Job_Title { get; set; }
        public string Jenis_Kelamin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Tanggal_Lahir { get; set; }
        public int This_Year_Balance { get; set; }
        public int Last_Year_Balance { get; set; }
        public ICollection<LeaveRequest> LeaveRequests { get; set; }
    }

    [Table("role")]
    public class Role
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }

    }

    public class Parameter
    {
        [Key]
        public int Id { get; set; }
        public int Max_Leave_Req { get; set; }
        public string Max_Leave_Year { get; set; }
    }
}