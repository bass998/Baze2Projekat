ALTER PROCEDURE ProcedureImeVlasnika
(@KupacJmbg VARCHAR(13),
 @NazivRestorana VARCHAR(100),
 @ImeVlasnikaRestorana VARCHAR(50) OUT
 @ImeKupca VARCHAR(50) OUT)
AS

BEGIN TRY
	select @ImeVlasnikaRestorana = Vlasnici.Ime
	from Vlasnici
	where Vlasnici.Jmbg in(
		select Vlasnici.Jmbg
		from Kupovine
		inner join Restorani ON Restorani.Naziv = Kupovine.NudiRestoranNaziv
		inner join Vlasnici ON Vlasnici.Jmbg  = Restorani.VlasnikJmbg
		inner join Kupci on Kupci.Jmbg = Kupovine.KupacJmbg
		where Kupovine.KupacJmbg = @KupacJmbg and Kupovine.NudiRestoranNaziv = @NazivRestorana)
	
END TRY

BEGIN CATCH
	SELECT
		ERROR_MESSAGE() AS ErrorNumber,
		ERROR_MESSAGE() AS ErrorMessage;
END CATCH;
