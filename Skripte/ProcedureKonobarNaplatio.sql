ALTER PROCEDURE ProcedureKonobarNaplatio
(@KonobarJmbg VARCHAR(13),
@UkupnoNaplatio INT OUT,
@ImeKonobara varchar(20) out)
AS

BEGIN TRY
	SELECT @UkupnoNaplatio = SUM(Proizvodi.Cena), @ImeKonobara = Radnici.Ime
	FROM Kupovine
	INNER JOIN Proizvodi ON Kupovine.NudiProizvodNaziv = Proizvodi.Naziv
	INNER JOIN Radnici ON Kupovine.KonobarJmbg = Radnici.Jmbg
	where Kupovine.KonobarJmbg = @KonobarJmbg
	group by Kupovine.KonobarJmbg
END TRY

BEGIN CATCH
	SELECT
		ERROR_MESSAGE() AS ErrorNumber,
		ERROR_MESSAGE() AS ErrorMessage;
END CATCH;
