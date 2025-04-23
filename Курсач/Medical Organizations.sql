create table Hospital(
	id int Identity(1,1) NOT NULL primary key,
	Name nvarchar(40) NOT NULL,
	Adress nvarchar(40) NOT NULL
);
create table Corpus(
	id int Identity(1,1) NOT NULL primary key,
	Name nvarchar(40) NOT NULL,
	IdHospital int references Hospital(id) NOT NULL
);
create table Otdelenie(
	id int Identity(1,1) NOT NULL primary key,	
	Name nvarchar(40) NOT NULL,
	NumberPalats int,
	NumberBads int,
	IdCorpus int references Corpus(id) NOT NULL
);
create table Bolezn(
	id int Identity(1,1) NOT NULL primary key,
	Name nvarchar(40) NOT NULL,
	IdOtdelenie int references Otdelenie(id) NOT NULL
);
create table Degree(
	id int Identity(1,1) NOT NULL primary key,
	Name nvarchar(40) NOT NULL
);
create table  Doctor(
	id int Identity(1,1) NOT NULL primary key,
	Name nvarchar(40) NOT NULL,
	Specialization nvarchar(40) NOT NULL,
	Degree int references Degree(id) NOT NULL
);
create table Patcient(
	id int Identity(1,1) NOT NULL primary key,
	Name nvarchar(40) NOT NULL
);
create table Karta(
	id int Identity(1,1) NOT NULL primary key,
	Vrema_Postuplenia date,
	IdBolezni int NOT NULL,
	IdPatcient int NOT NULL,
	IdDoctor int NOT NULL
);
create table Policlinic(
	id int NOT NULL primary key,
	Name nvarchar(40) NOT NULL,
	idHospital int references Hospital(id)
);
create table DoctorH(
	idDoctor int NOT NULL primary key,
	idHospital int references Hospital(id) NOT NULL
);
create table DoctorP(
	idDoctor int NOT NULL primary key,
	idPoliclinic int references Policlinic(id) NOT NULL
);
CREATE TABLE Users (
	id INT IDENTITY(1,1) PRIMARY KEY,
	userlogin nvarchar(40) NOT NULL,
	password nvarchar(40) NOT NULL,
	AdministratorRights BIT NOT NULL
);
	Select * From Users
	INSERT INTO Users VALUES
	('admin','AdminRulit',1),
	('user','qwerty',0);
	INSERT INTO Hospital (Name, Adress) VALUES
	('Городская больница №1', 'ул. Ленина, 123'),
	('Больница им. Петрова', 'пр. Гагарина, 45');
	SELECT * FROM Hospital
	INSERT INTO Corpus (Name, IdHospital) VALUES
	('Корпус №1', 1),
	('Корпус №2', 1),
	('Корпус №3', 1),
	('Корпус A', 2),
	('Корпус B', 2),
	('Корпус C', 2);
	SELECT * FROM Corpus
	INSERT INTO Otdelenie (Name, NumberPalats, NumberBads, IdCorpus) VALUES
	('Отделение №1', 10, 20, 1),
	('Отделение №2', 15, 25, 2),
	('Отделение №3', 12, 18, 3);
	SELECT * FROM Otdelenie
	INSERT INTO Patcient VALUES
	('Иванов Иван Иванович'),
	('Петров Петр Петрович'),
	('Сидоров Сидор Сидорович'),
	('Александров Александр Александрович'),
	('Егоров Егор Егорович'),
	('Ольга Ивановна'),
	('Наталья Петровна'),
	('Дмитрий Сидорович'),
	('Елена Александровна'),
	('Анна Егоровна'),
	('Михайлов Михаил Михайлович'),
	('Татьяна Михайловна'),
	('Сергеев Сергей Сергеевич'),
	('Мария Сергеевна'),
	('Николаев Николай Николаевич'),
	('Алина Михайловна'),
	('Артем Сергеевич'),
	('Валентина Николаевна'),
	('Ирина Александровна'),
	('Григорий Анатольевич'),
	('Оксана Игоревна'),
	('Антон Антонович'),
	('Екатерина Григорьевна'),
	('Даниил Валентинович'),
	('Виктор Викторович'),
	('Людмила Андреевна'),
	('Роман Романович'),
	('Юлия Владимировна'),
	('Валерия Игоревна'),
	('Владимир Владимирович');
	SELECT * FROM Patcient
	INSERT INTO Bolezn (Name, IdOtdelenie) VALUES
	('Ангина', 1),
	('Диабет', 3),
	('Гепатит', 2),
	('Остеоартрит', 3),
	('Аллергия', 1),
	('Гипертония', 2),
	('Грибок ногтей', 3),
	('Ожирение', 1),
	('Астма', 2),
	('Простуда', 1),
	('Онкология', 3),
	('Глаукома', 2),
	('Бронхит', 1),
	('Эпилепсия', 3),
	('Язва желудка', 2),
	('Мигрень', 1),
	('Артрит', 3),
	('Панкреатит', 2),
	('Туберкулез', 1),
	('Анемия', 3),
	('Псориаз', 2),
	('Инфекция мочевыводящих путей', 1),
	('Шизофрения', 3),
	('Гипертоническая болезнь', 2),
	('Энцефалопатия', 1),
	('Депрессия', 3),
	('Гастроэзофагеальная рефлюксная болезнь', 2),
	('Артериосклероз', 1),
	('Ревматоидный артрит', 3),
	('Тромбофлебит', 2),
	('Хронический бронхит', 1),
	('Паркинсонизм', 3),
	('Сахарный диабет', 2),
	('Остеопороз', 1),
	('Ишемическая болезнь сердца', 3),
	('Гипертония', 2),
	('Аллергический ринит', 1);
	SELECT * FROM Bolezn
	INSERT INTO Degree VALUES
	  ('Кандидат медицинских наук'),
	  ('Доктор медицинских наук');
	Select * FROM Degree
	INSERT INTO Doctor (Name, Specialization, Degree) VALUES
	('Сидоров', 'Окулист', 1),
	('Петров', 'Хирург', 2),
	('Иванов', 'Терапевт', 1),
	('Лопатин', 'Окулист', 1),
	('Коловратин', 'Хирург', 2),
	('Кератинов', 'Терапевт', 1),
	('Карантинов', 'Окулист', 1),
	('Каратинов', 'Хирург', 2);
	SELECT * FROM Doctor
	INSERT INTO Karta (Vrema_Postuplenia, IdBolezni, IdPatcient, IdDoctor)
	VALUES 
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 1, 1, 1),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 1, 2, 1),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 1, 3, 1),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 1, 4, 1),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 1, 5, 1),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 1, 6, 1),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 1, 7, 1),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 1, 10, 1),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 2, 11, 2),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 2, 12, 2),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 2, 13, 2),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 2, 14, 2),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 2, 15, 2),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 2, 16, 2),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 2, 17, 2),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 2, 18, 2),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 2, 19, 2),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 3, 21, 3),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 3, 22, 3),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 3, 23, 3),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 3, 24, 3),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 3, 25, 3),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 3, 26, 3),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 3, 27, 3),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 3, 28, 3),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 3, 29, 3),
		(DATEADD(DAY, -1 * RAND() * 30, GETDATE()), 3, 30, 3);
	SELECT * FROM Karta
	INSERT INTO Policlinic (id, Name, idHospital) VALUES
	(1, 'Поликлиника №1', 2),
	(2, 'Поликлиника №2', NULL);
	SELECT * FROM Policlinic
	INSERT INTO DoctorH (idDoctor, idHospital) VALUES
	(1, 1),
	(2, 1),
	(3, 2),
	(4, 2);
	SELECT * FROM DoctorH
	INSERT INTO DoctorP (idDoctor, idPoliclinic) VALUES
	(5, 1),
	(6, 1),
	(7, 2),
	(8, 2);
	SELECT * FROM DoctorP
--1
SELECT
    Doctor.Name AS Имя_врача,
    Doctor.Specialization AS Специализация,
    Degree.Name AS Ученая_степень,
    Hospital.Name AS Больница,
    Policlinic.Name AS Поликлиника,
    COUNT(Doctor.id) OVER (PARTITION BY Degree.Name, Hospital.Name) AS Количество_врачей
FROM Doctor
JOIN Degree ON Doctor.Degree = Degree.id
LEFT JOIN DoctorH ON Doctor.id = DoctorH.idDoctor
LEFT JOIN Hospital ON DoctorH.idHospital = Hospital.id
LEFT JOIN DoctorP ON Doctor.id = DoctorP.idDoctor
LEFT JOIN Policlinic ON DoctorP.idPoliclinic = Policlinic.id;
--3
SELECT 
Patcient.Name AS PName,
Bolezn.Name AS Bolezn,
Doctor.Name AS DName,
Karta.Vrema_Postuplenia
FROM Karta
JOIN Patcient ON Karta.IdPatcient = Patcient.Id
JOIN Bolezn ON Karta.IdBolezni = Bolezn.Id
JOIN Doctor ON Karta.IdDoctor = Doctor.Id;
--4
SELECT
Doctor.Name AS Доктор, 
Doctor.Specialization AS Специализация, 
Degree.Name AS Ученая_Cтепень,
(SELECT COUNT(*) FROM Karta Where Doctor.id = Karta.IdDoctor) AS Загруженность
FROM Doctor 
JOIN Degree ON Doctor.Degree = Degree.id
--5
SELECT 
    Doctor.Name AS Доктор,
    Karta.Vrema_Postuplenia AS Дата,
    SUM(1) AS Пациент
FROM Karta
JOIN Doctor ON Karta.IdDoctor = Doctor.Id
GROUP BY Karta.Vrema_Postuplenia, Doctor.Name
ORDER BY Karta.Vrema_Postuplenia;


