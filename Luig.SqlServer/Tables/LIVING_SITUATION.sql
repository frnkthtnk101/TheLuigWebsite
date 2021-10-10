CREATE TABLE [dbo].[LIVING_SITUATION]
(
	[living_situation_person_id] INT NOT NULL PRIMARY KEY REFERENCES PERSON(person_id),
	[living_situation_house_address_id] INT NOT NULL PRIMARY KEY REFERENCES HOUSE_ADDRESS(house_address_id)
)
