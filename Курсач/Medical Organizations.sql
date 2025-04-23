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
	('��������� �������� �1', '��. ������, 123'),
	('�������� ��. �������', '��. ��������, 45');
	SELECT * FROM Hospital
	INSERT INTO Corpus (Name, IdHospital) VALUES
	('������ �1', 1),
	('������ �2', 1),
	('������ �3', 1),
	('������ A', 2),
	('������ B', 2),
	('������ C', 2);
	SELECT * FROM Corpus
	INSERT INTO Otdelenie (Name, NumberPalats, NumberBads, IdCorpus) VALUES
	('��������� �1', 10, 20, 1),
	('��������� �2', 15, 25, 2),
	('��������� �3', 12, 18, 3);
	SELECT * FROM Otdelenie
	INSERT INTO Patcient VALUES
	('������ ���� ��������'),
	('������ ���� ��������'),
	('������� ����� ���������'),
	('����������� ��������� �������������'),
	('������ ���� ��������'),
	('����� ��������'),
	('������� ��������'),
	('������� ���������'),
	('����� �������������'),
	('���� ��������'),
	('�������� ������ ����������'),
	('������� ����������'),
	('������� ������ ���������'),
	('����� ���������'),
	('�������� ������� ����������'),
	('����� ����������'),
	('����� ���������'),
	('��������� ����������'),
	('����� �������������'),
	('�������� �����������'),
	('������ ��������'),
	('����� ���������'),
	('��������� �����������'),
	('������ ������������'),
	('������ ����������'),
	('������� ���������'),
	('����� ���������'),
	('���� ������������'),
	('������� ��������'),
	('�������� ������������');
	SELECT * FROM Patcient
	INSERT INTO Bolezn (Name, IdOtdelenie) VALUES
	('������', 1),
	('������', 3),
	('�������', 2),
	('�����������', 3),
	('��������', 1),
	('����������', 2),
	('������ ������', 3),
	('��������', 1),
	('�����', 2),
	('��������', 1),
	('���������', 3),
	('��������', 2),
	('�������', 1),
	('���������', 3),
	('���� �������', 2),
	('�������', 1),
	('������', 3),
	('����������', 2),
	('����������', 1),
	('������', 3),
	('�������', 2),
	('�������� ������������� �����', 1),
	('����������', 3),
	('��������������� �������', 2),
	('�������������', 1),
	('���������', 3),
	('������������������� ���������� �������', 2),
	('��������������', 1),
	('������������ ������', 3),
	('������������', 2),
	('����������� �������', 1),
	('������������', 3),
	('�������� ������', 2),
	('����������', 1),
	('����������� ������� ������', 3),
	('����������', 2),
	('������������� �����', 1);
	SELECT * FROM Bolezn
	INSERT INTO Degree VALUES
	  ('�������� ����������� ����'),
	  ('������ ����������� ����');
	Select * FROM Degree
	INSERT INTO Doctor (Name, Specialization, Degree) VALUES
	('�������', '�������', 1),
	('������', '������', 2),
	('������', '��������', 1),
	('�������', '�������', 1),
	('����������', '������', 2),
	('���������', '��������', 1),
	('����������', '�������', 1),
	('���������', '������', 2);
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
	(1, '����������� �1', 2),
	(2, '����������� �2', NULL);
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
    Doctor.Name AS ���_�����,
    Doctor.Specialization AS �������������,
    Degree.Name AS ������_�������,
    Hospital.Name AS ��������,
    Policlinic.Name AS �����������,
    COUNT(Doctor.id) OVER (PARTITION BY Degree.Name, Hospital.Name) AS ����������_������
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
Doctor.Name AS ������, 
Doctor.Specialization AS �������������, 
Degree.Name AS ������_C������,
(SELECT COUNT(*) FROM Karta Where Doctor.id = Karta.IdDoctor) AS �������������
FROM Doctor 
JOIN Degree ON Doctor.Degree = Degree.id
--5
SELECT 
    Doctor.Name AS ������,
    Karta.Vrema_Postuplenia AS ����,
    SUM(1) AS �������
FROM Karta
JOIN Doctor ON Karta.IdDoctor = Doctor.Id
GROUP BY Karta.Vrema_Postuplenia, Doctor.Name
ORDER BY Karta.Vrema_Postuplenia;


