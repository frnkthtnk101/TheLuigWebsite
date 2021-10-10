CREATE TABLE [dbo].[PERSON]
(
	[person_id] INT NOT NULL PRIMARY KEY,
	[person_first_name] VARCHAR(100) not null,
	[person_last_name] VARCHAR(100) not null,
	[person_email_name] VARCHAR(100) not null,
	[person_gender_id] int FOREIGN KEY REFERENCES GENDER(gender_id),

)
