CREATE FUNCTION [dbo].[FunkcijaIzracunajRadnike]()
RETURNS INT
AS 
BEGIN
    DECLARE @Radnik INT
    SET @Radnik = 0

    WHILE @Radnik < (SELECT COUNT(*) FROM Radnici)
    BEGIN
        SET @Radnik = @Radnik + 1
    END
    RETURN @Radnik
END