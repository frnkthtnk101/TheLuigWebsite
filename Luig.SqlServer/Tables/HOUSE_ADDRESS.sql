CREATE TABLE [dbo].[HOUSE_ADDRESS]
(
	[house_address_id] INT NOT NULL PRIMARY KEY,
	[house_address_line_one] VARCHAR(29) NOT NULL,
	[house_address_line_two] VARCHAR(1) NOT NULL,
	[house_address_zip_id] INT FOREIGN KEY REFERENCES ZIP(zip_id)
)
