GO
USE master

GO 
IF EXISTS(SELECT name FROM sys.databases WHERE name = 'CommandDB')
BEGIN
	DECLARE @kill varchar(8000) = '';  
	SELECT @kill = @kill + 'kill ' + CONVERT(VARCHAR(5), session_id) + ';'  
	FROM sys.dm_exec_sessions
	WHERE database_id  = db_id('CommandDB')
	EXEC(@kill);
	DROP DATABASE CommandDB
END

GO
CREATE DATABASE CommandDB

GO
USE CommandDB

GO
CREATE TABLE LogOrdenesRealizadas(

Id uniqueidentifier NOT NULL PRIMARY KEY default(newid()),
Orden varchar(100),
Valor varchar(100)

)