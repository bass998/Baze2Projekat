USE [RestoranDataBase]
GO
/****** Object:  StoredProcedure [dbo].[ProcedureKupacPotrosnja]    Script Date: 6/2/2021 8:21:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ProcedureKupacPotrosnja]
(@KupacJmbg VARCHAR(13),
@ImeKupca VARCHAR(50) OUT,
@UkupnaPotrosnja INT OUT)
AS

BEGIN TRY
	SELECT @UkupnaPotrosnja = SUM(Proizvodi.Cena), @ImeKupca = Kupci.Ime
	FROM Kupovine
	INNER JOIN Proizvodi ON Kupovine.NudiProizvodNaziv = Proizvodi.Naziv
	INNER JOIN Kupci on Kupovine.KupacJmbg = Kupci.Jmbg
	where Kupovine.KupacJmbg = @KupacJmbg
	group by Kupci.Ime
END TRY

BEGIN CATCH
	SELECT
		ERROR_MESSAGE() AS ErrorNumber,
		ERROR_MESSAGE() AS ErrorMessage;
END CATCH;

declare @ret1 int
declare @ret2 varchar(20)
exec ProcedureKupacPotrosnja '1122334455661', @ImeKupca = @ret2 OUT, @UkupnaPotrosnja = @ret1 OUT
SELECT @ret1, @ret2