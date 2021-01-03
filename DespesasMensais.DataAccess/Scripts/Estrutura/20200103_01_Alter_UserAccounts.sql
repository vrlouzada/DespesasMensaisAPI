/*
   domingo, 3 de janeiro de 202120:01:34
   User: 
   Server: LAPTOP-R5QUC1R1
   Database: DespesasMensais
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.UserAccount ADD
	IsActive bit NOT NULL CONSTRAINT DF_UserAccount_IsActive DEFAULT 0
GO
ALTER TABLE dbo.UserAccount SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.UserAccount', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.UserAccount', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.UserAccount', 'Object', 'CONTROL') as Contr_Per 