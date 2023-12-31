USE PropertyManagementDB
GO

CREATE PROCEDURE spUserGetById
@Id INT
AS
BEGIN
	SELECT * FROM Users
	WHERE Id = @Id AND IsDeleted = 0
END
GO

CREATE PROCEDURE spUserGetByUsername
@Username NVARCHAR(35)
AS
BEGIN
	SELECT * FROM Users
	WHERE Username = @Username AND IsDeleted = 0
END
GO

CREATE PROCEDURE spUserGetByEmail
@Email NVARCHAR(75)
AS
BEGIN
	SELECT * FROM Users
	WHERE Email = @Email AND IsDeleted = 0
END
GO

CREATE PROCEDURE spUsersGetAll
AS
BEGIN
	SELECT * FROM Users
	WHERE IsDeleted = 0
END
GO

CREATE PROCEDURE spUserCreate
	@FirstName NVARCHAR(35),
	@LastName NVARCHAR(35),
	@Username NVARCHAR(35),
	@Email NVARCHAR(75),
	@PhoneNumber NVARCHAR(14),
	@UserPassword NVARCHAR(35)
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO Users (FirstName, LastName, Username, Email, PhoneNumber, UserPassword)
	VALUES (@FirstName, @LastName, @UserName, @Email, @PhoneNumber, @UserPassword)
END
GO

CREATE PROCEDURE spUserUpdate
	@Id INT,
	@FirstName NVARCHAR(35) = NULL,
	@LastName NVARCHAR(35) = NULL,
	@Username NVARCHAR(35) = NULL,
	@Email NVARCHAR(75) = NULL,
	@PhoneNumber NVARCHAR(14) = NULL,
	@UserPassword NVARCHAR(35) = NULL,
	@IsActive BIT = NULL,
	@IsAdmin BIT  = NULL,
	@IsDeleted BIT = NULL,
	@UserPhoto VARBINARY(MAX)  = NULL
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Users
	SET FirstName = ISNULL(@FirstName, FirstName),
		LastName = ISNULL(@LastName, LastName),
		Username = ISNULL(@Username, Username),
		Email = ISNULL(@Email, Email),
		PhoneNumber = ISNULL(@PhoneNumber, PhoneNumber),
		UserPassword = ISNULL(@UserPassword, UserPassword),
		IsActive = ISNULL(@IsActive, IsActive),
		IsAdmin = ISNULL(@IsAdmin, IsAdmin),
		IsDeleted = ISNULL(@IsDeleted, IsDeleted),
		UserPhoto = ISNULL(@UserPhoto, UserPhoto)
		WHERE Id = @Id
END
GO

CREATE PROCEDURE spUserDelete
	@Id INT
AS
BEGIN
	UPDATE Users
	SET IsDeleted = 1
	WHERE Id = @Id
END
GO

CREATE PROCEDURE spPropertyGetById
	@Id INT
AS
BEGIN
	SELECT * FROM Properties
	WHERE Id = @Id AND IsDeleted = 0 AND IsArchived = 0
END
GO

CREATE PROCEDURE spPropertyGetByLandlordId
	@LandlordId INT
AS
BEGIN
	SELECT * FROM Properties
	WHERE LandlordId = @LandlordId
END
GO

CREATE PROCEDURE spPropertiesGetAll
AS
BEGIN
	SELECT * FROM Properties
	WHERE IsDeleted = 0 AND IsArchived = 0
END
GO

CREATE PROCEDURE spPropertyCreate
	@LandlordId INT,
	@TownId INT,
	@PropertyType INT,
	@Area INT,
	@NumOfRooms INT,
	@NumOfFloors INT,
	@NumOfBedrooms INT,
	@NumOfBathrooms INT,
	@PetsAllowed BIT,
	@YardArea INT,
	@Price DECIMAL(10,2)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Properties(LandlordId, TownId, PropertyType, Area, NumOfRooms, NumOfFloors, NumOfBedrooms, NumOfBathrooms, PetsAllowed, YardArea, Price)
	VALUES(@LandlordId, @TownId, @PropertyType, @Area, @NumOfRooms, @NumOfFloors, @NumOfBedrooms, @NumOfBathrooms, @PetsAllowed, @YardArea, @Price)
END
GO

CREATE PROCEDURE spPropertyUpdate
	@Id INT,
	@PetsAllowed BIT,
	@Price DECIMAL(10,2)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Property
	SET PetsAllowed = ISNULL(@PetsAllowed, PetsAllowed),
		Price = ISNULL(@Price, Price)
		WHERE Id = @Id AND IsDeleted = 0 AND IsArchived = 0
END
GO

CREATE PROCEDURE spPropertyDelete
	@Id INT
AS
BEGIN
	UPDATE Properties
	SET IsDeleted = 1
	WHERE Id = @Id AND IsDeleted = 0 AND IsArchived = 0
END
GO

CREATE PROCEDURE spPropertyArchive
	@Id INT
AS
BEGIN
	UPDATE Properties
	SET IsArchived = 1
	WHERE Id = @Id AND IsDeleted = 0 AND IsArchived = 0
END
GO

CREATE PROCEDURE spFeedbackCreate
	@RequestId INT,
	@Content NVARCHAR(150),
	@AuthorId INT,
	@CommentedUserId INT,
	@IsAuthorLandlord BIT,
	@Rating INT
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Feedbacks(RequestId, Content, AuthorId, CommentedUserId, IsAuthorLandlord, Rating)
	VALUES(@RequestId, @Content, @AuthorId, @CommentedUserId, @IsAuthorLandlord, @Rating)
END
GO

CREATE PROCEDURE spFeedbackUpdate
	@Id INT,
	@Content NVARCHAR(150),
	@Rating INT
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Feedbacks
	SET Content = ISNULL(@Content, Content),
		Rating = ISNULL(@Rating, Rating)
		WHERE Id = @Id
END
GO

CREATE PROCEDURE spFeedbackGetAll
AS
BEGIN
	SELECT * FROM Feedbacks
END
GO

CREATE PROCEDURE spFeedbackGetAllAsLandlord
	@UserId INT
AS
BEGIN
	SELECT * FROM Feedbacks
	WHERE CommentedUserId = @UserId AND IsAuthorLandlord = 0
END
GO

CREATE PROCEDURE spFeedbackGetAllAsTenand
	@UserId INT
AS
BEGIN
	SELECT * FROM Feedbacks
	WHERE CommentedUserId = @UserId AND IsAuthorLandlord = 1
END
GO

CREATE PROCEDURE spFeedbackGetById
	@Id INT
AS
BEGIN
	SELECT * FROM Feedbacks
	WHERE Id = @Id
END
GO

CREATE PROCEDURE spFeedbackGetAllByUserId
	@UserId INT
AS
BEGIN
	SELECT * FROM Feedbacks
	WHERE CommentedUserId = @UserId
END
GO

CREATE PROCEDURE spFeedbackGetAvgRatingAsLandlord
	@UserId INT
AS
BEGIN

	SELECT CONVERT(DECIMAL(2,1), AVG(CAST(Rating AS DECIMAL))) FROM Feedbacks
	WHERE CommentedUserId = @UserId AND IsAuthorLandlord = 0
END
GO

CREATE PROCEDURE spFeedbackGetAvgRatingAsTenand
	@UserId INT
AS
BEGIN

	SELECT CONVERT(DECIMAL(2,1), AVG(CAST(Rating AS DECIMAL))) FROM Feedbacks
	WHERE CommentedUserId = @UserId AND IsAuthorLandlord = 1
END
GO

CREATE PROCEDURE spRequestCreate
	@TenandId INT,
	@PropertyId INT,
	@MoveIn DATETiME,
	@MoveOut DATETIME
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Requests (TenandId, PropertyId, MoveIn, MoveOut)
	VALUES (@TenandId, @PropertyId, @MoveIn, @MoveOut)
END
GO

CREATE PROCEDURE spRequestDelete
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Requests
	SET IsDeleted = 1
	WHERE Id = @Id AND IsDeleted = 0
END
GO

CREATE PROCEDURE spRequestGetById
	@Id INT
AS
BEGIN
	SELECT * FROM Requests
	WHERE Id = @Id AND IsDeleted = 0
END
GO

CREATE PROCEDURE spRequestGetByTenandId
	@TenandId INT
AS
BEGIN
	SELECT * FROM Requests
	WHERE TenandId = @TenandId AND IsDeleted = 0
END
GO

CREATE PROCEDURE spRequestGetByPropertyId
	@PropertyId INT
AS
BEGIN
	SELECT * FROM Requests
	WHERE PropertyId = @PropertyId AND IsDeleted = 0
END
GO

CREATE PROCEDURE spRequestAccept
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Requests
	SET IsAccepted = 1
	WHERE Id = @Id AND IsDeleted = 0
END
GO

CREATE PROCEDURE spRequestDecline
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Requests
	SET IsAccepted = 2
	WHERE Id = @Id AND IsDeleted = 0 
END
GO