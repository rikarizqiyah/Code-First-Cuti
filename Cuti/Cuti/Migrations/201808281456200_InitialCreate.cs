namespace Cuti.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApprovalHistories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Date_Action = c.DateTime(nullable: false),
                        Action = c.String(),
                        Description = c.String(),
                        Leave_Request_Id_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LeaveRequests", t => t.Leave_Request_Id_id)
                .Index(t => t.Leave_Request_Id_id);
            
            CreateTable(
                "dbo.LeaveRequests",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        Start_Date = c.DateTime(nullable: false),
                        End_Date = c.DateTime(nullable: false),
                        Reason = c.String(),
                        Status = c.String(),
                        Total_Date = c.Int(nullable: false),
                        Holiday = c.Int(nullable: false),
                        Start_Date_Special = c.DateTime(nullable: false),
                        Attachment = c.String(),
                        Special_Leave_Id_Id = c.String(maxLength: 128),
                        User_Id_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.SpecialLeaves", t => t.Special_Leave_Id_Id)
                .ForeignKey("dbo.Users", t => t.User_Id_Id)
                .Index(t => t.Special_Leave_Id_Id)
                .Index(t => t.User_Id_Id);
            
            CreateTable(
                "dbo.SpecialLeaves",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Qty_Leave = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Email = c.String(),
                        Company = c.String(),
                        Department = c.String(),
                        Job_Title = c.String(),
                        Jenis_Kelamin = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Tanggal_Lahir = c.DateTime(nullable: false),
                        This_Year_Balance = c.Int(nullable: false),
                        Last_Year_Balance = c.Int(nullable: false),
                        Role_Id_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.role", t => t.Role_Id_Id)
                .Index(t => t.Role_Id_Id);
            
            CreateTable(
                "dbo.role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Parameters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Max_Leave_Req = c.Int(nullable: false),
                        Max_Leave_Year = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeaveRequests", "User_Id_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Role_Id_Id", "dbo.role");
            DropForeignKey("dbo.LeaveRequests", "Special_Leave_Id_Id", "dbo.SpecialLeaves");
            DropForeignKey("dbo.ApprovalHistories", "Leave_Request_Id_id", "dbo.LeaveRequests");
            DropIndex("dbo.Users", new[] { "Role_Id_Id" });
            DropIndex("dbo.LeaveRequests", new[] { "User_Id_Id" });
            DropIndex("dbo.LeaveRequests", new[] { "Special_Leave_Id_Id" });
            DropIndex("dbo.ApprovalHistories", new[] { "Leave_Request_Id_id" });
            DropTable("dbo.Parameters");
            DropTable("dbo.role");
            DropTable("dbo.Users");
            DropTable("dbo.SpecialLeaves");
            DropTable("dbo.LeaveRequests");
            DropTable("dbo.ApprovalHistories");
        }
    }
}
