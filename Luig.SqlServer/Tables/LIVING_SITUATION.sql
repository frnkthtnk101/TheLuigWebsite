CREATE TABLE [dbo].[LIVING_SITUATION]
(
	[living_situation_person_id] INT NOT NULL  REFERENCES PERSON(person_id),
	[living_situation_house_address_id] INT NOT NULL  REFERENCES HOUSE_ADDRESS(house_address_id), 
    CONSTRAINT [PK_LIVING_SITUATION] PRIMARY KEY ([living_situation_person_id], [living_situation_house_address_id])
)
