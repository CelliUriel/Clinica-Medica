CREATE DATABASE ClinicaMedica
GO

USE ClinicaMedica
GO

CREATE TABLE Provincias(

	ID_Provincia INT IDENTITY(1,1) NOT NULL,
	Descripcion_Provincia VARCHAR(50) NOT NULL,

	CONSTRAINT PK_ID_Provincia PRIMARY KEY (ID_Provincia)
)
GO

CREATE TABLE Localidades(

	ID_Localidad INT IDENTITY(1,1) NOT NULL,
	ID_Provincia_Localidad INT NOT NULL,
	Descripcion_Localidad VARCHAR(50) NOT NULL,

	CONSTRAINT PK_ID_Localidad PRIMARY KEY (ID_Localidad),
	CONSTRAINT FK_ID_Provincia_Localidad FOREIGN KEY (id_Provincia_Localidad)
		REFERENCES Provincias (ID_Provincia)
)
GO

CREATE TABLE Usuarios(
	ID_Usuario INT IDENTITY (1,1) NOT NULL,
	Nombre_Usuario VARCHAR(50) NOT NULL,
	Contraseña VARCHAR(200) NOT NULL,
	Rol BIT NOT NULL,

	CONSTRAINT PK_Usuarios PRIMARY KEY (Id_usuario),
)
GO

CREATE TABLE Especialidades(
	Codigo_Especialidad INT IDENTITY (1,1) NOT NULL,
	Nombre_Especialidad VARCHAR(50) NOT NULL,
	Descripcion_Especialidad VARCHAR(200) NOT NULL,

	CONSTRAINT PK_Especialidades PRIMARY KEY (Codigo_Especialidad)
)
GO

CREATE TABLE Medicos(
	ID_Medico INT IDENTITY(1000,1) NOT NULL,
	Codigo_Especialidad_Medico INT NOT NULL,
	DNI_MEDICO CHAR(8) NOT NULL,
	Nombre_Medico VARCHAR(50) NOT NULL,
	Apellido_Medico VARCHAR(50) NOT NULL,
	Sexo_Medico VARCHAR(20) NOT NULL,
	Nacionalidad_Medico VARCHAR(50) NOT NULL,
	FechaNacimiento_Medico DATE NOT NULL,
	Direccion_Medico VARCHAR(100) NOT NULL,
	ID_Localidad_Medico INT NOT NULL,
	ID_Provincia_Medico INT NOT NULL,
	Correo_Medico VARCHAR(100) NOT NULL,
	Telefono_Medico VARCHAR(20) NOT NULL,
	DiasAtencion_Medico VARCHAR(25) NOT NULL,
	HorariosAtencion_Medico VARCHAR(25) NOT NULL,
	Estado_Medico BIT NOT NULL,

	CONSTRAINT PK_Medicos PRIMARY KEY (ID_Medico),
	CONSTRAINT FK_Localidades_Medicos FOREIGN KEY (ID_Localidad_Medico)
		REFERENCES Localidades (ID_Localidad),
	CONSTRAINT ID_Provincia_Medico FOREIGN KEY (ID_Provincia_Medico)
		REFERENCES Provincias (ID_Provincia),
	CONSTRAINT FK_Codigo_Especialidad_Medico FOREIGN KEY (Codigo_Especialidad_Medico)
		REFERENCES Especialidades(Codigo_Especialidad)
)
GO


CREATE TABLE Pacientes(
	DNI_Paciente CHAR(8) NOT NULL,
	Nombre_Paciente VARCHAR(50) NOT NULL,
	Apellido_Paciente VARCHAR(50) NOT NULL,
	Sexo_Paciente VARCHAR(20) NOT NULL,
	Nacionalidad_Paciente VARCHAR(50) NOT NULL,
	FechaNacimiento_Paciente DATE NOT NULL,
	Direccion_Paciente VARCHAR(100) NOT NULL,
	ID_Localidad_Paciente INT NOT NULL,
	ID_Provincia_Paciente INT NOT NULL,
	Correo_Paciente VARCHAR(100) NOT NULL,
	Telefono_Paciente VARCHAR(20) NOT NULL,
	Estado_Paciente BIT NOT NULL,

	CONSTRAINT PK_Pacientes PRIMARY KEY (DNI_PACIENTE),
	CONSTRAINT FK_Localidades_Paciente FOREIGN KEY (ID_Localidad_Paciente)
		REFERENCES Localidades (ID_Localidad),
	CONSTRAINT ID_Provincia_Paciente FOREIGN KEY (ID_Provincia_Paciente)
		REFERENCES Provincias (ID_Provincia)
)
GO

CREATE TABLE Turnos(
	ID_Turno INT IDENTITY(1,1) NOT NULL,
	DNI_Paciente_Turno CHAR(8) NOT NULL, 
    Id_Medico_Turno INT NOT NULL,
    Codigo_Especialidad_Turno INT NOT NULL,
    Fecha_Turno DATE NOT NULL,
    Hora_Turno TIME NOT NULL,
    Estado_Turno VARCHAR(50) NOT NULL, 
    Observacion_Turno VARCHAR(255) NULL, 

	CONSTRAINT PK_Turnos PRIMARY KEY (ID_Turno),
    CONSTRAINT FK_Turnos_Pacientes FOREIGN KEY (DNI_Paciente_Turno)
        REFERENCES Pacientes (DNI_Paciente),
    CONSTRAINT FK_Turnos_Medicos FOREIGN KEY (Id_Medico_Turno)
        REFERENCES MEDICOS (ID_Medico),
    CONSTRAINT FK_Turnos_Especialidades FOREIGN KEY (Codigo_Especialidad_Turno)
        REFERENCES ESPECIALIDADES (Codigo_Especialidad)
	
)
GO


INSERT INTO Provincias (Descripcion_Provincia) VALUES ('Buenos Aires');
INSERT INTO Provincias (Descripcion_Provincia) VALUES ('Catamarca');
INSERT INTO Provincias (Descripcion_Provincia) VALUES ('Chaco');
INSERT INTO Provincias (Descripcion_Provincia) VALUES ('Chubut');
INSERT INTO Provincias (Descripcion_Provincia) VALUES ('Córdoba');
INSERT INTO Provincias (Descripcion_Provincia) VALUES ('Corrientes');
INSERT INTO Provincias (Descripcion_Provincia) VALUES ('Entre Ríos');
INSERT INTO Provincias (Descripcion_Provincia) VALUES ('Formosa');
INSERT INTO Provincias (Descripcion_Provincia) VALUES ('Jujuy');
INSERT INTO Provincias (Descripcion_Provincia) VALUES ('La Pampa');
INSERT INTO Provincias (Descripcion_Provincia) VALUES ('La Rioja');
INSERT INTO Provincias (Descripcion_Provincia) VALUES ('Mendoza');
INSERT INTO Provincias (Descripcion_Provincia) VALUES ('Misiones');
INSERT INTO Provincias (Descripcion_Provincia) VALUES ('Neuquén');
INSERT INTO Provincias (Descripcion_Provincia) VALUES ('Río Negro');
INSERT INTO Provincias (Descripcion_Provincia) VALUES ('Salta');
INSERT INTO Provincias (Descripcion_Provincia) VALUES ('San Juan');
INSERT INTO Provincias (Descripcion_Provincia) VALUES ('San Luis');
INSERT INTO Provincias (Descripcion_Provincia) VALUES ('Santa Cruz');
INSERT INTO Provincias (Descripcion_Provincia) VALUES ('Santa Fe');
INSERT INTO Provincias (Descripcion_Provincia) VALUES ('Santiago del Estero');
INSERT INTO Provincias (Descripcion_Provincia) VALUES ('Tierra del Fuego');
INSERT INTO Provincias (Descripcion_Provincia) VALUES ('Tucumán');


INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (1, 'La Plata');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (1, 'Mar del Plata');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (1, 'Tigre');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (2, 'San Fernando del Valle de Catamarca');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (3, 'Resistencia');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (4, 'Rawson');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (5, 'Córdoba');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (5, 'Río Cuarto');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (6, 'Corrientes');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (7, 'Paraná');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (8, 'Formosa');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (9, 'San Salvador de Jujuy');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (10, 'Santa Rosa');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (11, 'La Rioja');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (12, 'Mendoza');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (13, 'Posadas');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (14, 'Neuquén');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (15, 'Viedma');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (16, 'Salta');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (17, 'San Juan');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (18, 'San Luis');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (19, 'Río Gallegos');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (20, 'Rosario');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (21, 'Santiago del Estero');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (22, 'Ushuaia');
INSERT INTO Localidades (ID_Provincia_Localidad, Descripcion_Localidad) VALUES (23, 'San Miguel de Tucumán');

INSERT INTO Especialidades (Nombre_Especialidad, Descripcion_Especialidad) VALUES  
('Cardiología', 'Diagnóstico y tratamiento de enfermedades del corazón y circulación'),  
('Pediatría', 'Atención médica especializada en bebés, niños y adolescentes'),  
('Dermatología', 'Estudio y tratamiento de enfermedades de la piel'),  
('Ginecología', 'Salud femenina y aparato reproductor femenino'),  
('Neurología', 'Enfermedades del sistema nervioso'),  
('Ortopedia', 'Problemas del sistema óseo, músculos y articulaciones'),  
('Oftalmología', 'Salud visual, ojos y sus patologías'),  
('Psiquiatría', 'Trastornos mentales y emocionales'),  
('Otorrinolaringología', 'Enfermedades de oído, nariz y garganta'),  
('Endocrinología', 'Glandulas, hormonas y metabolismo'),  
('Gastroenterología', 'Sistema digestivo y sus enfermedades'),  
('Neumonología', 'Aparato respiratorio y pulmones'),  
('Nefrología', 'Riñones y sistema urinario'),  
('Urología', 'Sistema urinario y sistemas reproductivos masculinos'),  
('Oncología', 'Diagnóstico y tratamiento del cáncer'),  
('Hematología', 'Sangre, médula ósea y sus trastornos'),  
('Reumatología', 'Enfermedades de articulaciones, ligamentos y tendones'),  
('Infectología', 'Infecciones y enfermedades infecciosas'),  
('Medicina Interna', 'Diagnóstico global y tratamiento de enfermedades en adultos'),  
('Cirugía General', 'Intervenciones quirúrgicas de diferentes órganos'),  
('Anestesiología', 'Anestesia y control del dolor en cirugías'),  
('Radiología', 'Diagnóstico por imágenes y estudios radiológicos'),  
('Medicina Familiar', 'Atención médica primaria para pacientes de todas las edades'),  
('Medicina del Trabajo', 'Salud ocupacional y prevención de riesgos laborales'),  
('Geriatría', 'Atención integral para adultos mayores'),  
('Psicología Clínica', 'Tratamiento psicológico de desórdenes mentales y emocionales'),  
('Neurocirugía', 'Cirugía del sistema nervioso central y periférico'),  
('Cardiovascular Intervencionista', 'Intervenciones mínimamente invasivas en el corazón'),  
('Cirugía Plástica', 'Reconstrucción y estética corporal'),  
('Traumatología', 'Lesiones por accidentes o deporte en huesos y músculos');

ALTER TABLE Medicos
ADD ID_Usuario INT NULL;
GO

ALTER TABLE Medicos
ADD CONSTRAINT FK_Usuarios_Medicos 
FOREIGN KEY (ID_Usuario)
REFERENCES Usuarios (ID_Usuario);
GO

SELECT * FROM Localidades;
GO