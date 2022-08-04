CREATE TABLE [dbo].[UseCaseLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UseCaseName] [nvarchar](30) NOT NULL,
	[Username] [nvarchar](30) NOT NULL,
	[UserId] [int] NOT NULL,
	[ExecutionTime] [datetime] NOT NULL,
	[Data] [nvarchar](max) NOT NULL,
	[IsAuthorized] [bit] NOT NULL,
 CONSTRAINT [PK_UseCaseLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

  create procedure [dbo].[GetUseCaseLogs]
  @dateFrom datetime,@dateTo datetime, @useCaseName nvarchar(30),@user nvarchar(30)
  as begin
  select UseCaseName, Username as [User], UserId, 
         ExecutionTime as ExecutionDateTime, IsAuthorized,
		 Data
  from UseCaseLogs 
  where ExecutionTime between @dateFrom and @dateTo AND
        (@useCaseName is null OR UseCaseName like '%' + @useCaseName + '%') AND
		(@user is null OR Username like '%' + @user + '%')

end
GO

create procedure [dbo].[AddNewLogRecord]
@useCaseName nvarchar(30),
@username nvarchar(30),
@userId int,
@executionTime datetime,
@data nvarchar(max),
@isAuthorized bit
as 
begin

insert into UseCaseLogs(UseCaseName,Username, UserId, ExecutionTime, Data,IsAuthorized)
values (@useCaseName, @username, @userId, @executionTime, @data, @isAuthorized)

end
GO