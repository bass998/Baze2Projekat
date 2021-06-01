
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/01/2021 12:28:07
-- Generated from EDMX file: C:\Users\HP\Desktop\baze\ProjectLogic\RestoranDbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RestoranDataBase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_VlasnikRestoran]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Restorani] DROP CONSTRAINT [FK_VlasnikRestoran];
GO
IF OBJECT_ID(N'[dbo].[FK_RestoranRadnik_Restoran]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RestoranRadnik] DROP CONSTRAINT [FK_RestoranRadnik_Restoran];
GO
IF OBJECT_ID(N'[dbo].[FK_RestoranRadnik_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RestoranRadnik] DROP CONSTRAINT [FK_RestoranRadnik_Radnik];
GO
IF OBJECT_ID(N'[dbo].[FK_RestoranNudi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Nudis] DROP CONSTRAINT [FK_RestoranNudi];
GO
IF OBJECT_ID(N'[dbo].[FK_NudiProizvod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Nudis] DROP CONSTRAINT [FK_NudiProizvod];
GO
IF OBJECT_ID(N'[dbo].[FK_KuvarJelo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proizvodi_Jelo] DROP CONSTRAINT [FK_KuvarJelo];
GO
IF OBJECT_ID(N'[dbo].[FK_NudiKupuje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kupovine] DROP CONSTRAINT [FK_NudiKupuje];
GO
IF OBJECT_ID(N'[dbo].[FK_KupujeKupac]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kupovine] DROP CONSTRAINT [FK_KupujeKupac];
GO
IF OBJECT_ID(N'[dbo].[FK_KupujeKonobar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kupovine] DROP CONSTRAINT [FK_KupujeKonobar];
GO
IF OBJECT_ID(N'[dbo].[FK_Kuvar_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radnici_Kuvar] DROP CONSTRAINT [FK_Kuvar_inherits_Radnik];
GO
IF OBJECT_ID(N'[dbo].[FK_Jelo_inherits_Proizvod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proizvodi_Jelo] DROP CONSTRAINT [FK_Jelo_inherits_Proizvod];
GO
IF OBJECT_ID(N'[dbo].[FK_Konobar_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radnici_Konobar] DROP CONSTRAINT [FK_Konobar_inherits_Radnik];
GO
IF OBJECT_ID(N'[dbo].[FK_Pice_inherits_Proizvod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proizvodi_Pice] DROP CONSTRAINT [FK_Pice_inherits_Proizvod];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Vlasnici]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vlasnici];
GO
IF OBJECT_ID(N'[dbo].[Restorani]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Restorani];
GO
IF OBJECT_ID(N'[dbo].[Radnici]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radnici];
GO
IF OBJECT_ID(N'[dbo].[Kupci]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kupci];
GO
IF OBJECT_ID(N'[dbo].[Proizvodi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proizvodi];
GO
IF OBJECT_ID(N'[dbo].[Nudis]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Nudis];
GO
IF OBJECT_ID(N'[dbo].[Kupovine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kupovine];
GO
IF OBJECT_ID(N'[dbo].[Radnici_Kuvar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radnici_Kuvar];
GO
IF OBJECT_ID(N'[dbo].[Proizvodi_Jelo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proizvodi_Jelo];
GO
IF OBJECT_ID(N'[dbo].[Radnici_Konobar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radnici_Konobar];
GO
IF OBJECT_ID(N'[dbo].[Proizvodi_Pice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proizvodi_Pice];
GO
IF OBJECT_ID(N'[dbo].[RestoranRadnik]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RestoranRadnik];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Vlasnici'
CREATE TABLE [dbo].[Vlasnici] (
    [Jmbg] nvarchar(13)  NOT NULL,
    [Ime] nvarchar(50)  NOT NULL,
    [Prezime] nvarchar(50)  NOT NULL,
    [BrojTelefona] nvarchar(10)  NULL
);
GO

-- Creating table 'Restorani'
CREATE TABLE [dbo].[Restorani] (
    [Naziv] nvarchar(100)  NOT NULL,
    [Adresa] nvarchar(50)  NOT NULL,
    [Grad] nvarchar(50)  NOT NULL,
    [BrojTelefona] nvarchar(10)  NOT NULL,
    [VlasnikJmbg] nvarchar(13)  NOT NULL
);
GO

-- Creating table 'Radnici'
CREATE TABLE [dbo].[Radnici] (
    [Jmbg] nvarchar(13)  NOT NULL,
    [Ime] nvarchar(50)  NOT NULL,
    [Prezime] nvarchar(50)  NOT NULL,
    [BrojTelefona] nvarchar(10)  NOT NULL
);
GO

-- Creating table 'Kupci'
CREATE TABLE [dbo].[Kupci] (
    [Jmbg] nvarchar(13)  NOT NULL,
    [Ime] nvarchar(50)  NOT NULL,
    [Prezime] nvarchar(50)  NOT NULL,
    [BrojTelefona] nvarchar(10)  NOT NULL
);
GO

-- Creating table 'Proizvodi'
CREATE TABLE [dbo].[Proizvodi] (
    [Naziv] nvarchar(100)  NOT NULL,
    [Cena] int  NOT NULL
);
GO

-- Creating table 'Nudis'
CREATE TABLE [dbo].[Nudis] (
    [RestoranNaziv] nvarchar(100)  NOT NULL,
    [ProizvodNaziv] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'Kupovine'
CREATE TABLE [dbo].[Kupovine] (
    [NudiRestoranNaziv] nvarchar(100)  NOT NULL,
    [NudiProizvodNaziv] nvarchar(100)  NOT NULL,
    [KupacJmbg] nvarchar(13)  NOT NULL,
    [KonobarJmbg] nvarchar(13)  NOT NULL
);
GO

-- Creating table 'Radnici_Kuvar'
CREATE TABLE [dbo].[Radnici_Kuvar] (
    [BrojNapravljenihJela] int  NOT NULL,
    [Jmbg] nvarchar(13)  NOT NULL
);
GO

-- Creating table 'Proizvodi_Jelo'
CREATE TABLE [dbo].[Proizvodi_Jelo] (
    [Sastojci] nvarchar(100)  NOT NULL,
    [KuvarJmbg] nvarchar(13)  NOT NULL,
    [Naziv] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'Radnici_Konobar'
CREATE TABLE [dbo].[Radnici_Konobar] (
    [BrojNaplacenihKupovina] int  NOT NULL,
    [Jmbg] nvarchar(13)  NOT NULL
);
GO

-- Creating table 'Proizvodi_Pice'
CREATE TABLE [dbo].[Proizvodi_Pice] (
    [Velicina] nvarchar(4)  NOT NULL,
    [Naziv] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'RestoranRadnik'
CREATE TABLE [dbo].[RestoranRadnik] (
    [Restorani_Naziv] nvarchar(100)  NOT NULL,
    [Radnici_Jmbg] nvarchar(13)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Jmbg] in table 'Vlasnici'
ALTER TABLE [dbo].[Vlasnici]
ADD CONSTRAINT [PK_Vlasnici]
    PRIMARY KEY CLUSTERED ([Jmbg] ASC);
GO

-- Creating primary key on [Naziv] in table 'Restorani'
ALTER TABLE [dbo].[Restorani]
ADD CONSTRAINT [PK_Restorani]
    PRIMARY KEY CLUSTERED ([Naziv] ASC);
GO

-- Creating primary key on [Jmbg] in table 'Radnici'
ALTER TABLE [dbo].[Radnici]
ADD CONSTRAINT [PK_Radnici]
    PRIMARY KEY CLUSTERED ([Jmbg] ASC);
GO

-- Creating primary key on [Jmbg] in table 'Kupci'
ALTER TABLE [dbo].[Kupci]
ADD CONSTRAINT [PK_Kupci]
    PRIMARY KEY CLUSTERED ([Jmbg] ASC);
GO

-- Creating primary key on [Naziv] in table 'Proizvodi'
ALTER TABLE [dbo].[Proizvodi]
ADD CONSTRAINT [PK_Proizvodi]
    PRIMARY KEY CLUSTERED ([Naziv] ASC);
GO

-- Creating primary key on [RestoranNaziv], [ProizvodNaziv] in table 'Nudis'
ALTER TABLE [dbo].[Nudis]
ADD CONSTRAINT [PK_Nudis]
    PRIMARY KEY CLUSTERED ([RestoranNaziv], [ProizvodNaziv] ASC);
GO

-- Creating primary key on [NudiRestoranNaziv], [NudiProizvodNaziv], [KupacJmbg] in table 'Kupovine'
ALTER TABLE [dbo].[Kupovine]
ADD CONSTRAINT [PK_Kupovine]
    PRIMARY KEY CLUSTERED ([NudiRestoranNaziv], [NudiProizvodNaziv], [KupacJmbg] ASC);
GO

-- Creating primary key on [Jmbg] in table 'Radnici_Kuvar'
ALTER TABLE [dbo].[Radnici_Kuvar]
ADD CONSTRAINT [PK_Radnici_Kuvar]
    PRIMARY KEY CLUSTERED ([Jmbg] ASC);
GO

-- Creating primary key on [Naziv] in table 'Proizvodi_Jelo'
ALTER TABLE [dbo].[Proizvodi_Jelo]
ADD CONSTRAINT [PK_Proizvodi_Jelo]
    PRIMARY KEY CLUSTERED ([Naziv] ASC);
GO

-- Creating primary key on [Jmbg] in table 'Radnici_Konobar'
ALTER TABLE [dbo].[Radnici_Konobar]
ADD CONSTRAINT [PK_Radnici_Konobar]
    PRIMARY KEY CLUSTERED ([Jmbg] ASC);
GO

-- Creating primary key on [Naziv] in table 'Proizvodi_Pice'
ALTER TABLE [dbo].[Proizvodi_Pice]
ADD CONSTRAINT [PK_Proizvodi_Pice]
    PRIMARY KEY CLUSTERED ([Naziv] ASC);
GO

-- Creating primary key on [Restorani_Naziv], [Radnici_Jmbg] in table 'RestoranRadnik'
ALTER TABLE [dbo].[RestoranRadnik]
ADD CONSTRAINT [PK_RestoranRadnik]
    PRIMARY KEY CLUSTERED ([Restorani_Naziv], [Radnici_Jmbg] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [VlasnikJmbg] in table 'Restorani'
ALTER TABLE [dbo].[Restorani]
ADD CONSTRAINT [FK_VlasnikRestoran]
    FOREIGN KEY ([VlasnikJmbg])
    REFERENCES [dbo].[Vlasnici]
        ([Jmbg])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VlasnikRestoran'
CREATE INDEX [IX_FK_VlasnikRestoran]
ON [dbo].[Restorani]
    ([VlasnikJmbg]);
GO

-- Creating foreign key on [Restorani_Naziv] in table 'RestoranRadnik'
ALTER TABLE [dbo].[RestoranRadnik]
ADD CONSTRAINT [FK_RestoranRadnik_Restoran]
    FOREIGN KEY ([Restorani_Naziv])
    REFERENCES [dbo].[Restorani]
        ([Naziv])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Radnici_Jmbg] in table 'RestoranRadnik'
ALTER TABLE [dbo].[RestoranRadnik]
ADD CONSTRAINT [FK_RestoranRadnik_Radnik]
    FOREIGN KEY ([Radnici_Jmbg])
    REFERENCES [dbo].[Radnici]
        ([Jmbg])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RestoranRadnik_Radnik'
CREATE INDEX [IX_FK_RestoranRadnik_Radnik]
ON [dbo].[RestoranRadnik]
    ([Radnici_Jmbg]);
GO

-- Creating foreign key on [RestoranNaziv] in table 'Nudis'
ALTER TABLE [dbo].[Nudis]
ADD CONSTRAINT [FK_RestoranNudi]
    FOREIGN KEY ([RestoranNaziv])
    REFERENCES [dbo].[Restorani]
        ([Naziv])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProizvodNaziv] in table 'Nudis'
ALTER TABLE [dbo].[Nudis]
ADD CONSTRAINT [FK_NudiProizvod]
    FOREIGN KEY ([ProizvodNaziv])
    REFERENCES [dbo].[Proizvodi]
        ([Naziv])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NudiProizvod'
CREATE INDEX [IX_FK_NudiProizvod]
ON [dbo].[Nudis]
    ([ProizvodNaziv]);
GO

-- Creating foreign key on [KuvarJmbg] in table 'Proizvodi_Jelo'
ALTER TABLE [dbo].[Proizvodi_Jelo]
ADD CONSTRAINT [FK_KuvarJelo]
    FOREIGN KEY ([KuvarJmbg])
    REFERENCES [dbo].[Radnici_Kuvar]
        ([Jmbg])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KuvarJelo'
CREATE INDEX [IX_FK_KuvarJelo]
ON [dbo].[Proizvodi_Jelo]
    ([KuvarJmbg]);
GO

-- Creating foreign key on [NudiRestoranNaziv], [NudiProizvodNaziv] in table 'Kupovine'
ALTER TABLE [dbo].[Kupovine]
ADD CONSTRAINT [FK_NudiKupuje]
    FOREIGN KEY ([NudiRestoranNaziv], [NudiProizvodNaziv])
    REFERENCES [dbo].[Nudis]
        ([RestoranNaziv], [ProizvodNaziv])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [KupacJmbg] in table 'Kupovine'
ALTER TABLE [dbo].[Kupovine]
ADD CONSTRAINT [FK_KupujeKupac]
    FOREIGN KEY ([KupacJmbg])
    REFERENCES [dbo].[Kupci]
        ([Jmbg])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KupujeKupac'
CREATE INDEX [IX_FK_KupujeKupac]
ON [dbo].[Kupovine]
    ([KupacJmbg]);
GO

-- Creating foreign key on [KonobarJmbg] in table 'Kupovine'
ALTER TABLE [dbo].[Kupovine]
ADD CONSTRAINT [FK_KonobarKupuje]
    FOREIGN KEY ([KonobarJmbg])
    REFERENCES [dbo].[Radnici_Konobar]
        ([Jmbg])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KonobarKupuje'
CREATE INDEX [IX_FK_KonobarKupuje]
ON [dbo].[Kupovine]
    ([KonobarJmbg]);
GO

-- Creating foreign key on [Jmbg] in table 'Radnici_Kuvar'
ALTER TABLE [dbo].[Radnici_Kuvar]
ADD CONSTRAINT [FK_Kuvar_inherits_Radnik]
    FOREIGN KEY ([Jmbg])
    REFERENCES [dbo].[Radnici]
        ([Jmbg])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Naziv] in table 'Proizvodi_Jelo'
ALTER TABLE [dbo].[Proizvodi_Jelo]
ADD CONSTRAINT [FK_Jelo_inherits_Proizvod]
    FOREIGN KEY ([Naziv])
    REFERENCES [dbo].[Proizvodi]
        ([Naziv])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Jmbg] in table 'Radnici_Konobar'
ALTER TABLE [dbo].[Radnici_Konobar]
ADD CONSTRAINT [FK_Konobar_inherits_Radnik]
    FOREIGN KEY ([Jmbg])
    REFERENCES [dbo].[Radnici]
        ([Jmbg])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Naziv] in table 'Proizvodi_Pice'
ALTER TABLE [dbo].[Proizvodi_Pice]
ADD CONSTRAINT [FK_Pice_inherits_Proizvod]
    FOREIGN KEY ([Naziv])
    REFERENCES [dbo].[Proizvodi]
        ([Naziv])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------