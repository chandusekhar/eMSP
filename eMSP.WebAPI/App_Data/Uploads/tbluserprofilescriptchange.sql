/*Script to alter data type and */
ALTER TABLE [dbo].[tblUserProfile]
ALTER COLUMN CountryID bigint;
ALTER TABLE [dbo].[tblUserProfile]
ALTER COLUMN StateID bigint;

ALTER TABLE [dbo].[tblUserProfile]  WITH CHECK ADD  CONSTRAINT [FK_tblUserProfile_tblCountries] FOREIGN KEY([CountryID])
REFERENCES [dbo].[tblCountries] ([ID])
GO

ALTER TABLE [dbo].[tblUserProfile] CHECK CONSTRAINT [FK_tblUserProfile_tblCountries]
GO

ALTER TABLE [dbo].[tblUserProfile]  WITH CHECK ADD  CONSTRAINT [FK_tblUserProfile_tblCountryStates] FOREIGN KEY([StateID])
REFERENCES [dbo].[tblCountryStates] ([ID])
GO

ALTER TABLE [dbo].[tblUserProfile] CHECK CONSTRAINT [FK_tblUserProfile_tblCountryStates]
GO


