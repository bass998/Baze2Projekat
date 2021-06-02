CREATE FUNCTION FunkcijaIzbrojCene()
RETURNS INT
AS 
BEGIN
    DECLARE @Cena INT
    SET @Cena = 0

    WHILE @Cena < (SELECT COUNT(*) FROM Proizvodi WHERE Cena > 140)
    BEGIN
        SET @Cena = @Cena + 1
    END
    RETURN @Cena
END