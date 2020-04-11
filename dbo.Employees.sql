CREATE TABLE [dbo].[Employees] (
    [EmployeeId]   INT            IDENTITY (1, 1) NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [Surname]      NVARCHAR (MAX) NULL,
    [PaymentNum]   NVARCHAR (MAX) NULL,
    [Experience]   INT            NULL,
    [DepartmentId] INT            NULL,
    [PositionId]   INT            NULL,
    CONSTRAINT [PK_dbo.Employees] PRIMARY KEY CLUSTERED ([EmployeeId] ASC)
);

