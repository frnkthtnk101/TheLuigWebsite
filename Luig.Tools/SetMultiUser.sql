use master
go
DECLARE @KILL VARCHAR(8000) = '';
SELECT @KILL=@KILL+'KILL '+CONVERT(VARCHAR(5),SPID)+';'
FROM MASTER..SYSPROCESSES
WHERE DBID=DB_ID('DataLuig');
EXEC (@KILL);
GO
ALTER DATABASE DataLuig SET MULTI_USER

--https://stackoverflow.com/a/58329203/4803536