--Agency 
insert into Agency (ShortName, LongName) values ( 'Villar', 'Flashset');
insert into Agency (ShortName, LongName) values ( 'Plum', 'Quamba');
insert into Agency (ShortName, LongName) values ( 'Rishworth', 'Camido');
insert into Agency (ShortName, LongName) values ( 'Tire', 'Pixonyx');
insert into Agency (ShortName, LongName) values ('Poveleye', 'Jayo');
insert into Agency (ShortName, LongName) values ( 'Mockes', 'Photospace');
insert into Agency (ShortName, LongName) values ('Truelock', 'Realcube');
insert into Agency (ShortName, LongName) values ( 'Martensen', 'LiveZ');
insert into Agency (ShortName, LongName) values ( 'Lavery', 'Jaxworks');
insert into Agency (ShortName, LongName) values ( 'Rehn', 'Yodel');
--SELECT * FROM Agency

--Agent
insert into Agent (DateOfBirth, Height, FirstName, LastName) values ('7/21/2021', 0.83, 'Trenton', 'Pattle');
insert into Agent (DateOfBirth, Height, FirstName, LastName) values ( '11/29/2021', 0.51, 'Donia', 'Plante');
insert into Agent (DateOfBirth, Height, FirstName, LastName) values ( '7/27/2021', 0.2, 'Barret', 'Poulsum');
insert into Agent (DateOfBirth, Height, FirstName, LastName) values ( '3/19/2022', 0.7, 'Audrye', 'Gunthorpe');
insert into Agent (DateOfBirth, Height, FirstName, LastName) values ( '6/15/2021', 0.56, 'Romona', 'Chinnock');
insert into Agent (DateOfBirth, Height, FirstName, LastName) values ( '3/20/2022', 0.38, 'Jamill', 'Roach');
insert into Agent (DateOfBirth, Height, FirstName, LastName) values ( '6/1/2021', 0.35, 'Carena', 'Soda');
insert into Agent (DateOfBirth, Height, FirstName, LastName) values ('6/19/2021', 0.67, 'Traver', 'Doore');
insert into Agent (DateOfBirth, Height, FirstName, LastName) values ( '7/7/2021', 0.64, 'Kathe', 'Glendining');
insert into Agent (DateOfBirth, Height, FirstName, LastName) values ( '6/24/2021', 0.03, 'Liane', 'Girdwood');
--SELECT * FROM Agent

--SecurityClearance
insert into SecurityClearance (SecurityClearanceName) values ('Erwin');
insert into SecurityClearance (SecurityClearanceName) values ('Kopf');
insert into SecurityClearance (SecurityClearanceName) values ('Edworthy');
insert into SecurityClearance (SecurityClearanceName) values ('McNeil');
insert into SecurityClearance (SecurityClearanceName) values ('Harmson');
insert into SecurityClearance (SecurityClearanceName) values ('Oakwood');
insert into SecurityClearance (SecurityClearanceName) values ('Ashall');
insert into SecurityClearance (SecurityClearanceName) values ('Drewry');
insert into SecurityClearance (SecurityClearanceName) values ('Wakeham');
insert into SecurityClearance (SecurityClearanceName) values ('Petken');
--SELECT * FROM SecurityClearance

--AgencyAgent
insert into AgencyAgent (AgencyId, AgentId, SecurityClearanceId, BadgeId, ActivationDate, DeactivationDate, IsActive) values (1, 1, 1, '9e716ed6-87f8-48b3-8a97-bcd8051eb981', '2/23/2022', '8/24/2021', 1);
insert into AgencyAgent (AgencyId, AgentId, SecurityClearanceId, BadgeId, ActivationDate, DeactivationDate, IsActive) values (4, 7, 9, 'f7293524-21a8-4f37-bbb0-f1a38330ab81', '8/3/2011', '12/1/2020', 1);
insert into AgencyAgent (AgencyId, AgentId, SecurityClearanceId, BadgeId, ActivationDate, DeactivationDate, IsActive) values (8, 5, 7, '6a555139-d24f-4bb3-8fb7-b7c935da6566', '3/16/2014', '8/2/2019', 0);
insert into AgencyAgent (AgencyId, AgentId, SecurityClearanceId, BadgeId, ActivationDate, DeactivationDate, IsActive) values (9, 2, 7, '73ffdfd5-f501-4a97-831b-8e0c74bfcca8', '11/3/2011', '3/5/2021', 1);
insert into AgencyAgent (AgencyId, AgentId, SecurityClearanceId, BadgeId, ActivationDate, DeactivationDate, IsActive) values (10, 2, 8, '20dceb27-a6ee-4207-a8d5-d135cab99468', '11/10/2021', '5/4/2021', 0);
insert into AgencyAgent (AgencyId, AgentId, SecurityClearanceId, BadgeId, ActivationDate, DeactivationDate, IsActive) values (5, 1, 4, 'e21bfa71-aa33-4232-9da9-2c0511b72a1b', '3/24/2013', '10/12/2020', 0);
insert into AgencyAgent (AgencyId, AgentId, SecurityClearanceId, BadgeId, ActivationDate, DeactivationDate, IsActive) values (2, 1, 6, '06e18dcc-8e64-4224-8400-ec69d61cacd6', '10/26/2016', '9/8/2019', 0);
insert into AgencyAgent (AgencyId, AgentId, SecurityClearanceId, BadgeId, ActivationDate, DeactivationDate, IsActive) values (4, 5, 8, '66c23505-35ed-4d7e-97bf-69f62f790c7a', '7/7/2019', '6/7/2020', 1);
insert into AgencyAgent (AgencyId, AgentId, SecurityClearanceId, BadgeId, ActivationDate, DeactivationDate, IsActive) values (1, 4, 9, '3c23cb8e-c77d-4ad4-86bd-dab921ff3baa', '6/4/2015', '4/8/2021', 1);
insert into AgencyAgent (AgencyId, AgentId, SecurityClearanceId, BadgeId, ActivationDate, DeactivationDate, IsActive) values (1, 3, 9, 'da13aa0e-ce9e-4b98-b71d-7306c960b98e', '3/23/2018', '9/1/2019', 1);
insert into AgencyAgent (AgencyId, AgentId, SecurityClearanceId, BadgeId, ActivationDate, DeactivationDate, IsActive) values (8, 6, 10, '27fd7e4a-5949-4d4b-8125-57af856e51fa', '10/13/2020', '1/24/2020', 1);
--SELECT * FROM AgencyAgent

--Alias
insert into Alias (AgentId, AliasName, InterpolId, Persona) values (2, 'Wallace', '8ad8a649-e501-4f47-9f87-9cbb46c3044d', 'Vestibulum sed magna at nunc commodo placerat. Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede.');
insert into Alias (AgentId, AliasName, InterpolId, Persona) values (1, 'Tamiko', 'a9a7ce22-282b-4ef6-bfba-070e227d22e5', 'In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus. Nulla ut erat id mauris vulputate elementum.');
insert into Alias (AgentId, AliasName, InterpolId, Persona) values (3, 'Rinaldo', '15829f16-40f7-4d0b-bb65-5a9e8e92bec3', 'Duis at velit eu est congue elementum. In hac habitasse platea dictumst.');
insert into Alias (AgentId, AliasName, InterpolId, Persona) values (5, 'Kaitlin', '85105c66-c8eb-4cd6-aef6-468549907c43', 'Aliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros. Suspendisse accumsan tortor quis turpis. Sed ante.');
insert into Alias (AgentId, AliasName, InterpolId, Persona) values (4, 'Rowan', 'd178da3b-1403-4ba9-a2b8-9328c8200ec7', 'Cras non velit nec nisi vulputate nonummy.');
insert into Alias (AgentId, AliasName, InterpolId, Persona) values (6, 'Dorotea', 'c02798b0-2c72-44f7-a359-8548226a1ea0', 'Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus. Curabitur at ipsum ac tellus semper interdum. Mauris ullamcorper purus sit amet nulla.');
insert into Alias (AgentId, AliasName, InterpolId, Persona) values (2, 'Barbra', '8a693e39-f4ad-4a9a-843a-d9a22fd004f0', 'Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus. Phasellus in felis.');
insert into Alias (AgentId, AliasName, InterpolId, Persona) values (3, 'Clarabelle', '02c68a08-d858-44c2-bd89-d4e66539f15c', 'Integer ac neque. Duis bibendum. Morbi non quam nec dui luctus rutrum.');
insert into Alias (AgentId, AliasName, InterpolId, Persona) values (9, 'Patti', 'b9058a53-3974-4bb4-a620-fa8ddc4aa0be', 'Phasellus id sapien in sapien iaculis congue. Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl. Aenean lectus.');
insert into Alias (AgentId, AliasName, InterpolId, Persona) values (8, 'Babb', '08c2304d-b794-4e32-bdb1-b668ba45c02b', 'Sed accumsan felis. Ut at dolor quis odio consequat varius.');
--SELECT * FROM Alias

--Location
insert into Location (AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (4, 'Gaoua', '77812 Union Parkway', '0 Oakridge Place', 'Suru', '12345', 'GER');
insert into Location (AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (4, 'Pittsburgh', '8 Maywood Street', '15 Macpherson Court', 'Gambang', '12345', 'PA');
insert into Location (AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (2, 'Osielsko', '16 Shasta Alley', '75 Lakeland Court', 'Senanga', '12345', 'IND');
insert into Location (AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (6, 'Ichnya', '233 Kinsman Street', '6 Blue Bill Park Road', 'Tulsa', '12345', 'JAP');
insert into Location (AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (5, 'Sunzhen', '135 Dovetail Lane', '3 Morrow Way', 'Dekâ€™emhÄre', '12345', 'KOR');
insert into Location (AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (8, 'Xiekou', '79 Barnett Road', '4525 Morning Park', 'Pueblo Viejo', '12345', 'PRC');
insert into Location (AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (1, 'Knoxville', '1 3rd Pass', '2 2nd Drive', 'Xietang', '12345', 'TN');
insert into Location (AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (9, 'Linxi', '0600 Waxwing Lane', '24961 Morningstar Parkway', 'Maguling', '12345', 'VIE');
insert into Location (AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (6, 'Gourcy', '48 Forest Court', '5 Waubesa Center', 'RzozÃ³w', '12345', 'FRA');
insert into Location (AgencyId, LocationName, Street1, Street2, City, PostalCode, CountryCode) values (10, 'Gonzalo Pizarro', '3654 American Court', '61423 Johnson Hill', 'Rosâ€™', '12345', 'SPA');
--SELECT * FROM [Location]

--Mission
insert into Mission (AgencyId, CodeName, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost, Notes) values (6, 'Slender-billed cockatoo', '1/15/2021', '6/22/2019', '4/18/2020', 7149.65, 'Morbi non quam nec dui luctus rutrum. Nulla tellus.');
insert into Mission (AgencyId, CodeName, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost, Notes) values (5, 'Madagascar fruit bat', '2/23/2020', '6/29/2020', '4/12/2022', 6810.09, 'Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem.');
insert into Mission (AgencyId, CodeName, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost, Notes) values (4, 'Blue waxbill', '4/11/2015', '9/4/2020', '9/30/2020', 1887.87, 'Morbi non quam nec dui luctus rutrum.');
insert into Mission (AgencyId, CodeName, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost, Notes) values (7, 'Kaffir cat', '4/24/2015', '3/2/2022', '7/18/2020', 4017.27, 'Nam nulla.');
insert into Mission (AgencyId, CodeName, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost, Notes) values (1, 'Monkey, rhesus', '2/12/2017', '12/20/2020', '5/4/2019', 7571.99, 'Donec semper sapien a libero. Nam dui.');
insert into Mission (AgencyId, CodeName, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost, Notes) values (1, 'Grey mouse lemur', '9/8/2015', '4/8/2022', '2/5/2021', 9539.84, 'Mauris sit amet eros. Suspendisse accumsan tortor quis turpis.');
insert into Mission (AgencyId, CodeName, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost, Notes) values (5, 'Red and blue macaw', '11/23/2015', '6/21/2020', '1/26/2021', 1103.76, 'In hac habitasse platea dictumst.');
insert into Mission (AgencyId, CodeName, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost, Notes) values (10, 'Great egret', '11/1/2021', '1/17/2022', '3/15/2022', 332.47, 'Morbi quis tortor id nulla ultrices aliquet.');
insert into Mission (AgencyId, CodeName, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost, Notes) values (6, 'Bush dog', '5/28/2018', '3/31/2022', '8/23/2021', 8388.57, 'Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus. Suspendisse potenti.');
insert into Mission (AgencyId, CodeName, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost, Notes) values (10, 'Small-toothed palm civet', '10/4/2011', '6/25/2020', '6/17/2020', 1161.99, 'Suspendisse potenti.');
--SELECT * FROM Mission

--MissionAgent
INSERT INTO MissionAgent(MissionId, AgentId) VALUES(1,1)
insert into MissionAgent (AgentId, MissionId) values (1, 5);
insert into MissionAgent (AgentId, MissionId) values (4, 7);
insert into MissionAgent (AgentId, MissionId) values (7, 9);
insert into MissionAgent (AgentId, MissionId) values (2, 4);
insert into MissionAgent (AgentId, MissionId) values (9, 1);
insert into MissionAgent (AgentId, MissionId) values (8, 2);
insert into MissionAgent (AgentId, MissionId) values (8, 6);
insert into MissionAgent (AgentId, MissionId) values (1, 6);
insert into MissionAgent (AgentId, MissionId) values (3, 6);
insert into MissionAgent (AgentId, MissionId) values (10, 10);
--SELECT * FROM MissionAgent