
--Query for making database
CREATE DATABASE Diploma_NET_NAMRA;

--Query for using database
USE Diploma_NET;

-- Query for making table
CREATE TABLE LOC_Country (
    CountryID INT IDENTITY(1,1) PRIMARY KEY, -- Auto-increment primary key starting from 1
    CountryName VARCHAR(100) NOT NULL,       -- CountryName column with VARCHAR data type
    CountryCode VARCHAR(10) NOT NULL         -- CountryCode column with VARCHAR data type
);

INSERT INTO [dbo].[LOC_Country] ([CountryName],[CountryCode]) VALUES ('INDIA' , 91)

SELECT * FROM [dbo].[LOC_Country]



--Procedure for inserting new record in Country Table
CREATE PROCEDURE [dbo].[PR_Country_Insert]
@CountryName varchar(50),
@CountryCode varchar(50)
AS
BEGIN
INSERT INTO [dbo].[LOC_Country]
(
	[dbo].[LOC_Country].[CountryName],
	[dbo].[LOC_Country].[CountryCode]
)	
VALUES
(
	@CountryName,
	@CountryCode
)
END



EXEC [dbo].[PR_Country_Insert] "INDIA" , 91


--Procedure for deleting record from Country table based on CountryID
CREATE PROCEDURE [dbo].[PR_Country_DeleteByPK]
	@CountryID int
AS
BEGIN
	DELETE
	FROM 
		[dbo].[LOC_Country]
	WHERE 
		[dbo].[LOC_Country].[CountryID] = @CountryID
END

--Procedure for updating record of Country table based on CountryID
CREATE PROCEDURE [dbo].[PR_Country_UpdateByPK]
	@CountryID int,
	@CountryName varchar(100),
	@CountryCode varchar(50)
	
AS
BEGIN
	UPDATE 
		[dbo].[LOC_Country]
	SET
		[dbo].[LOC_Country].[CountryName] = @CountryName,
		[dbo].[LOC_Country].[CountryCode] = @CountryCode
		
	WHERE
		[dbo].[LOC_Country].[CountryID] = @CountryID
END


--Procedure for getting all records from LOC_Country Table
Create PROCEDURE [dbo].[PR_Country_SelectAll]
AS
BEGIN
	SELECT
		[dbo].[LOC_Country].[CountryID],
		[dbo].[LOC_Country].[CountryName],
		[dbo].[LOC_Country].[CountryCode]
	
	FROM
		[dbo].[LOC_Country]
End







--Procedure for getting Country record based on CountryID
Create PROCEDURE [dbo].[PR_Country_SelectByCountryID]
 @CountryID int
AS
BEGIN
	SELECT
		[LOC_Country].[CountryID],
		[LOC_Country].[CountryName],
		[LOC_Country].[CountryCode]
		--[LOC_Country].[Created],
		--[LOC_Country].[Modified]
	FROM
		[dbo].[LOC_Country]
	WHERE
		[dbo].[LOC_Country].[CountryID] = @CountryID		
End


