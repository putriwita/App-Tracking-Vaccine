Create Database proyek_try;

CREATE TABLE Users (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Nama_Badan VARCHAR(255),
    username VARCHAR(255),
    roles VARCHAR(255),
    Location VARCHAR(255),
    password VARCHAR(255),
    email VARCHAR(255),
    phone VARCHAR(255)
);

CREATE TABLE Vaksin (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    NameVaksin VARCHAR(255),
    Dosis VARCHAR(255),
    min_age_used INT,
    description_vaksin VARCHAR(MAX)
);

CREATE TABLE ReportUseVaksin1 (
    id UNIQUEIDENTIFIER PRIMARY KEY,
    id_rumah_sakit VARCHAR(255),
    name_patient VARCHAR(255),
    name_vaksin VARCHAR(255),
    id_vaksin VARCHAR(255),
    time_vaksin DATETIME,
    nik_patient VARCHAR(255)
);
CREATE TABLE ReportInnVaksin1 (
    id UNIQUEIDENTIFIER PRIMARY KEY,
    id_vaksin VARCHAR(255),
    nama_vaksin VARCHAR(255),
    name_rumah_sakit VARCHAR(255),
    jumlah_vaksin INT,
    id_rumah_sakit VARCHAR(255),
    Date_In_Vaksin DATETIME
);

CREATE TABLE Penduduk (
    Id INT PRIMARY KEY,
    nik VARCHAR(255),
    Provinsi VARCHAR(255),
    Kabupaten VARCHAR(255),
    Kecamatan VARCHAR(255),
    name_penduduk VARCHAR(255),
    tanggal_lahir DATETIME
);

INSERT INTO Users (Id, Nama_Badan, username, roles, Location, password, email, phone)
VALUES (NEWID(), 'Nama Badan', 'admin', 'user_role_value', 'Location Value', 'password', 'email@example.com', '1234567890');



