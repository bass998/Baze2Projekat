ALTER TRIGGER TrigerIzracunajCene
ON Proizvodi
AFTER INSERT
AS 
BEGIN
    DECLARE @varchar AS varchar(100);
    DECLARE @Var INT
    SET @Var = [dbo].[FunkcijaIzbrojCene]()
	IF @Var > 10
		BEGIN
			RAISERROR('Ne moze se dodati preko 10 proizvoda sa cenom preko 140 RSD', 16,1)
		END
END