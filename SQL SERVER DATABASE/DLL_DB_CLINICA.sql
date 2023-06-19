CREATE DATABASE DB_CLINICA;
GO

USE DB_CLINICA;
GO

CREATE TABLE PATIENTS (
	ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	FIRST_NAME NVARCHAR(50) NOT NULL,
	MIDDLE_NAME NVARCHAR(50) NOT NULL,
	LAST_NAME NVARCHAR(50) NOT NULL,
	SECOND_LAST_NAME NVARCHAR(50) NOT NULL,
	IDENTIFICATION_NUMBER INT NOT NULL,
	EMAIL NVARCHAR(100) NOT NULL UNIQUE,
	GENDER CHAR(1) NOT NULL,
	PHONE NVARCHAR(20) NOT NULL,
	DATE_OF_BIRTH DATE NOT NULL,
	NATIONALITY NVARCHAR(50) NOT NULL,
	IS_DELETED BIT NOT NULL
);

CREATE TABLE CONTACT_EMERGENCY (
	ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	PATIENT_ID INT NOT NULL,
	CONTACT_NAME NVARCHAR(50) NOT NULL,
	CONTACT_RELATIONSHIP NVARCHAR(50) NOT NULL,
	CONTACT_PHONE NVARCHAR(20) NOT NULL,
	CONSTRAINT FK_CONTACT_EMERGENCY_PATIENT FOREIGN KEY (PATIENT_ID) REFERENCES PATIENTS(ID)
);

CREATE TABLE EMPLOYEES (
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    FIRST_NAME NVARCHAR(50) NOT NULL,--ready
    MIDDLE_NAME NVARCHAR(50) NOT NULL,--ready
    LAST_NAME NVARCHAR(50) NOT NULL,--ready
    SECOND_LAST_NAME NVARCHAR(50) NOT NULL,--ready
    EMAIL NVARCHAR(100) NOT NULL UNIQUE,--ready
    GENDER CHAR(1) NOT NULL,--ready
    IDENTIFICATION_NUMBER INT NOT NULL,--ready
    PHONE NVARCHAR(20) NOT NULL,--ready
    DATE_OF_BIRTH DATE NOT NULL,--ready
    SALARY DECIMAL(10, 2) NOT NULL,--ready
    POSITION NVARCHAR(50) NOT NULL,--ready
    EMPLOYEE_STATUS NVARCHAR(50) NOT NULL,--Auto generated for a new inserted employee
    HIRE_DATE DATE NOT NULL,--Auto generated for a new inserted employee
    AVAILABLE_VACATION_DAYS INT NOT NULL,--Auto generated for a new inserted employee
    TAKEN_VACATION_DAYS INT NOT NULL,--Auto generated for a new inserted employee
    LAST_VACATION_DATE DATE,--Auto generated for a new inserted employee
    IS_DELETED BIT NOT NULL--Auto generated for a new inserted employee
);

CREATE TABLE CHRONIC_DISEASES (
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    _NAME NVARCHAR(100) NOT NULL,
    _DESCRIPTION NVARCHAR(500),
    TREATMENT NVARCHAR(500),
    DIAGNOSIS_DATE DATE,
    CONTROLLED BIT NOT NULL
);

CREATE TABLE ALLERGIES (
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    _NAME NVARCHAR(100) NOT NULL,
    _DESCRIPTION NVARCHAR(500),
    TYPE NVARCHAR(100),
    SYMPTOMS NVARCHAR(500),
    SEVERITY NVARCHAR(50)
);

CREATE TABLE PATIENT_ALLERGIES (
    PATIENT_ID INT NOT NULL,
    ALLERGY_ID INT NOT NULL,
    CONSTRAINT PK_PATIENT_ALLERGIES PRIMARY KEY (PATIENT_ID, ALLERGY_ID),
    CONSTRAINT FK_PATIENT_ALLERGIES_PATIENT FOREIGN KEY (PATIENT_ID) REFERENCES PATIENTS(ID),
    CONSTRAINT FK_PATIENT_ALLERGIES_ALLERGY FOREIGN KEY (ALLERGY_ID) REFERENCES ALLERGIES(ID)
);

CREATE TABLE PATIENT_CHRONIC_DISEASES (
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    PATIENT_ID INT NOT NULL,
    CHRONIC_DISEASE_ID INT NOT NULL,
    CONSTRAINT FK_PATIENT_CHRONIC_DISEASES_PATIENTS FOREIGN KEY (PATIENT_ID) REFERENCES PATIENTS (ID),
    CONSTRAINT FK_PATIENT_CHRONIC_DISEASES_CHRONIC_DISEASES FOREIGN KEY (CHRONIC_DISEASE_ID) REFERENCES CHRONIC_DISEASES (ID)
);

CREATE TABLE SECRETARIES (
    ID INT NOT NULL PRIMARY KEY,
    IDIOMAS NVARCHAR(100),
    PROGRAMAS_OFIMATICOS NVARCHAR(100),
    FOREIGN KEY (ID) REFERENCES EMPLOYEES (ID)
);

CREATE TABLE DOCTORS (
    ID INT NOT NULL PRIMARY KEY,--Is the equals Id employee
    SPECIALTY NVARCHAR(100),--ready
    LICENSE_NUMBER NVARCHAR(50),--ready
    MEDICAL_CODE NVARCHAR(50),--ready
    FOREIGN KEY (ID) REFERENCES EMPLOYEES (ID)
);

CREATE TABLE CLEANING_MAINTENANCE (
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    EMPLOYEE_ID INT NOT NULL,
    EXPERIENCE NVARCHAR(100),
    EQUIPMENT NVARCHAR(100),
    TOOLS NVARCHAR(100),
    CONSTRAINT FK_CLEANING_MAINTENANCE_EMPLOYEE FOREIGN KEY (EMPLOYEE_ID) REFERENCES EMPLOYEES(ID)
);

CREATE TABLE TASKS (
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    _DESCRIPTION NVARCHAR(100) NOT NULL,
    ASSIGNMENT_DATE DATE NOT NULL,
    COMPLETED BIT NOT NULL,
    RESPONSIBLE_AREA NVARCHAR(50),
    MAINTENANCE_EQUIPMENT NVARCHAR(100),
    CLEANING_MAINTENANCE_ID INT NOT NULL,
    CONSTRAINT FK_TASKS_CLEANING_MAINTENANCE FOREIGN KEY (CLEANING_MAINTENANCE_ID) REFERENCES CLEANING_MAINTENANCE(ID)
);

CREATE TABLE MEDICAL_RECORDS (
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    PATIENT_ID INT NOT NULL,
    DATE_VISIT DATE NOT NULL,
    DOCTOR_NAME NVARCHAR(100) NOT NULL,
    DIAGNOSIS NVARCHAR(100) NOT NULL, -- Nueva columna para el diagn�stico
    FOREIGN KEY (PATIENT_ID) REFERENCES PATIENTS (id)
);

CREATE TABLE MEDICATIONS (
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    _NAME NVARCHAR(100) NOT NULL,
    DOSAGE NVARCHAR(50) NOT NULL,
    FREQUENCY NVARCHAR(50) NOT NULL,
	STARTDATE DATE NOT NULL,
	ENDDATE DATE NOT NULL
);

CREATE TABLE MEDICAL_RECORDS_MEDICATIONS (
    MEDICAL_RECORD_ID INT NOT NULL,
    MEDICATION_ID INT NOT NULL,
    CONSTRAINT PK_MEDICAL_RECORDS_MEDICATIONS PRIMARY KEY (MEDICAL_RECORD_ID, MEDICATION_ID),
    FOREIGN KEY (MEDICAL_RECORD_ID) REFERENCES MEDICAL_RECORDS (ID),
    FOREIGN KEY (MEDICATION_ID) REFERENCES MEDICATIONS (ID)
);

CREATE TABLE APPOINTMENTS (
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    PATIENT_ID INT NOT NULL,
    DOCTOR_ID INT NOT NULL,
	SPECIALTY NVARCHAR(100) NOT NULL,
    APPOINTMENT_DATE DATETIME NOT NULL,
    DURATION_MINUTES INT NOT NULL,
    CONSTRAINT FK_APPOINTMENTS_PATIENTS FOREIGN KEY (PATIENT_ID) REFERENCES PATIENTS (id),
    CONSTRAINT FK_APPOINTMENTS_EMPLOYEES FOREIGN KEY (DOCTOR_ID) REFERENCES DOCTORS (id)
);

CREATE TABLE USERS (
    ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,--Id is equals of id employee
    _NAME NVARCHAR(50) NOT NULL UNIQUE,--ready
    _PASSWORD NVARCHAR(100) NOT NULL,--ready
    _ROLE NVARCHAR(50) NOT NULL,--ready
    CREATION_DATE DATE NOT NULL,--auto generated
    LAST_ACCESS DATE,--auto generated 
    _STATUS NVARCHAR(50) NOT NULL,--auto generated
    DOCTOR_ID INT NULL,--If check is doctor then the id is equals id employee
    SECRETARY_ID INT NULL,
    PATIENT_ID INT NULL,
    IS_ADMIN BIT NOT NULL DEFAULT 0, 
    CONSTRAINT FK_USERS_DOCTORS FOREIGN KEY (DOCTOR_ID) REFERENCES DOCTORS(ID),
    CONSTRAINT FK_USERS_SECRETARIES FOREIGN KEY (SECRETARY_ID) REFERENCES SECRETARIES(ID),
    CONSTRAINT FK_USERS_PATIENTS FOREIGN KEY (PATIENT_ID) REFERENCES PATIENTS(ID),
    CONSTRAINT CK_USERS_ROLE CHECK (
        (_ROLE = 'Doctor' AND DOCTOR_ID IS NOT NULL AND SECRETARY_ID IS NULL AND PATIENT_ID IS NULL)
        OR (_ROLE = 'Secretary' AND DOCTOR_ID IS NULL AND SECRETARY_ID IS NOT NULL AND PATIENT_ID IS NULL)
        OR (_ROLE = 'Patient' AND DOCTOR_ID IS NULL AND SECRETARY_ID IS NULL AND PATIENT_ID IS NOT NULL)
        OR (_ROLE = 'Admin' AND IS_ADMIN = 1 AND DOCTOR_ID IS NOT NULL)
    )
);


CREATE TABLE LOG_USERS (
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    _USER_ID INT NOT NULL,
    _ACTION NVARCHAR(100) NOT NULL,
    _TIMESTAMP DATETIME NOT NULL,
    CONSTRAINT FK_BITACORA_USERS FOREIGN KEY (_USER_ID) REFERENCES USERS (ID)
);




--STORED PROCEDURES

CREATE OR ALTER PROCEDURE dbo.LOGIN_USER
    @username NVARCHAR(50),
    @password NVARCHAR(100),
    @isSuccessful BIT OUTPUT,
    @msj NVARCHAR(50) OUTPUT,
    @rol NVARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    -- Verificar las credenciales del usuario
    IF EXISTS (SELECT 1 FROM USERS WHERE _NAME = @username AND _PASSWORD = @password)
    BEGIN
        SET @isSuccessful = 1; -- Credenciales correctas
        SET @msj = 'Login successful'; -- Mensaje de �xito
        SET @rol = (SELECT _ROLE FROM USERS WHERE _NAME = @username); -- Obtener el rol del usuario
        INSERT INTO LOG_USERS (_USER_ID, _ACTION, _TIMESTAMP)
        VALUES ((SELECT ID FROM USERS WHERE _NAME = @username), 'Login', GETDATE());
		UPDATE USERS SET LAST_ACCESS = GETDATE() WHERE _NAME = @username;
    END
    ELSE
    BEGIN
        SET @isSuccessful = 0; -- Credenciales incorrectas
        SET @msj = 'Login failed'; -- Mensaje de error
        SET @rol = NULL; -- No se establece un rol si el inicio de sesi�n falla
    END
END

CREATE PROCEDURE dbo.GETDOCTOR
    @UserName NVARCHAR(50)
AS
BEGIN
    SELECT	E.ID, 
			E.FIRST_NAME, 
			E.MIDDLE_NAME, 
			E.LAST_NAME, 
			E.SECOND_LAST_NAME, 
			E.EMAIL, 
			E.GENDER, 
			E.IDENTIFICATION_NUMBER, 
			E.PHONE, 
			E.DATE_OF_BIRTH, 
			E.SALARY, 
			E.POSITION, 
			E.EMPLOYEE_STATUS, 
			E.HIRE_DATE, 
			E.AVAILABLE_VACATION_DAYS, 
			E.TAKEN_VACATION_DAYS, 
			E.LAST_VACATION_DATE, 
			E.IS_DELETED, 
			D.SPECIALTY, 
			D.LICENSE_NUMBER, 
			D.MEDICAL_CODE
    FROM USERS U
    INNER JOIN EMPLOYEES E ON U.DOCTOR_ID = E.ID
    INNER JOIN DOCTORS D ON E.ID = D.ID
    WHERE U._NAME = @UserName
END


select * from EMPLOYEES
select * from DOCTORS
select * from USERS
select * from LOG_USERS


EXEC dbo.GETDOCTOR @UserName = 'jsmith';