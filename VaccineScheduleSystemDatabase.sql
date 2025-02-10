USE master;
DROP database IF EXISTS VaccineScheduleSystem;

create database VaccineScheduleSystem;
USE VaccineScheduleSystem

CREATE TABLE Manufacturers (
  ManufacturerId INTEGER PRIMARY KEY,
  Name VARCHAR(200),
  Description VARCHAR(200),
  CountryName VARCHAR(100),
  CountryCode VARCHAR(10),
  ActiveStatus VARCHAR(200)
);

CREATE TABLE VaccineCenters (
  CenterId INTEGER PRIMARY KEY,
  Name VARCHAR(200),
  Location VARCHAR(200),
  ContactNumber INTEGER,
  Email VARCHAR(200)
);

CREATE TABLE VaccineBatches (
  VaccineBatchId INTEGER PRIMARY KEY,
  ManufacturerId INTEGER FOREIGN KEY REFERENCES Manufacturers(ManufacturerId),
  CenterId INTEGER FOREIGN KEY REFERENCES VaccineCenters(CenterId),
  Quantity integer,
  ActiveStatus varchar(200)
);

CREATE TABLE VaccineCategories (
  VaccineCategoryId INTEGER PRIMARY KEY,
  ParentCategoryId INTEGER FOREIGN KEY REFERENCES VaccineCategories(VaccineCategoryId),
  CategoryName varchar(200),
  Description varchar(200),
  Status Varchar(200),
);

CREATE TABLE Vaccines (
  VaccineId INTEGER PRIMARY KEY,
  CategoryId INTEGER FOREIGN KEY REFERENCES VaccineCategories(VaccineCategoryId), 
  BatchId INTEGER FOREIGN KEY REFERENCES VaccineBatches(VaccineBatchId), 
  Name VARCHAR(200),
  QuantityAvailable INTEGER,
  UnitOfVolume INTEGER,
  IngredientsDescription VARCHAR(200),
  MinAge Integer,
  MaxAge Integer,
  BetweenPeriod DATE,
  Price INTEGER,
  ProductionDate DATE,
  ExpirationDate DATE
);

CREATE TABLE VaccinePackages (
  VaccinePackageId INTEGER PRIMARY KEY,
  PackageName VARCHAR(200),
  PackageDescription VARCHAR(200),
  PackageStatus INTEGER
);

CREATE TABLE VaccinePackageDetails (
  Id INTEGER PRIMARY KEY,
  VaccineId INTEGER FOREIGN KEY REFERENCES Vaccines(VaccineId),
  VaccinePackageId INTEGER FOREIGN KEY REFERENCES VaccinePackages(VaccinePackageId),
  PackagePrice Integer,
);

CREATE TABLE Feedback (
  FeedbackId INTEGER PRIMARY KEY,
  Comment VARCHAR(200),
  Rating INTEGER
);

CREATE TABLE Accounts (
  AccountId INTEGER PRIMARY KEY,
  CenterId INTEGER FOREIGN KEY REFERENCES VaccineCenters(CenterId),
  UserName VARCHAR(200),
  Password VARCHAR(200),
  PhoneNumber INTEGER,
  Email VARCHAR(200), 
  AccountRole VARCHAR(200),
  ProfileImage VARCHAR(200),
  Salary INTEGER,
  Status VARCHAR(200)
);
CREATE TABLE ChildrenProfiles (
  ProfileId INTEGER PRIMARY KEY,
  AccountId INTEGER FOREIGN KEY REFERENCES Accounts(AccountId),
  ParentName Varchar(200),
  Name VARCHAR(200),
  Gender VARCHAR(1),
  DateOfBirth DATE,
  Allergies VARCHAR(200)
);

CREATE TABLE Orders (
  OrderId INTEGER PRIMARY KEY,
  FeedbackId INTEGER FOREIGN KEY REFERENCES Feedback(FeedbackId),
  ProfileId INTEGER FOREIGN KEY REFERENCES ChildrenProfiles(ProfileId),
  PurchaseDate DATE,
  Status INTEGER
);

CREATE TABLE Payment (
  PaymentId INTEGER PRIMARY KEY,
  OrderId INTEGER FOREIGN KEY REFERENCES Orders(OrderId),
  PaymentName VARCHAR(200),
  PaymentMethod VARCHAR(200),
  PaymentDate INTEGER,
  PaymentStatus INTEGER,
  PayAmount INTEGER
);

CREATE TABLE OrderVaccineDetails (
  OrderVaccineDetailsId INTEGER PRIMARY KEY,
  OrderId INTEGER FOREIGN KEY REFERENCES Orders(OrderId),
  VaccineId INTEGER FOREIGN KEY REFERENCES Vaccines(VaccineId),
  Quantity INTEGER,
  TotalPrice INTEGER
);

CREATE TABLE OrderPackageDetails (
  OrderPackageDetailsId INTEGER PRIMARY KEY,
  OrderId INTEGER FOREIGN KEY REFERENCES Orders(OrderId),
  VaccinePackageId INTEGER FOREIGN KEY REFERENCES VaccinePackages(VaccinePackageId),
  Quantity INTEGER,
  TotalPrice INTEGER
);

CREATE TABLE VaccineHistory (
  HistoryId INTEGER PRIMARY KEY,
  VaccineId INTEGER FOREIGN KEY REFERENCES Vaccines(VaccineId),
  ProfileId INTEGER FOREIGN KEY REFERENCES ChildrenProfiles(ProfileId),
  AccountId INTEGER FOREIGN KEY REFERENCES Accounts(AccountId),
  CenterId INTEGER FOREIGN KEY REFERENCES VaccineCenters(CenterId),
  AdministeredDate DATE,
  AdministeredBy Varchar(200),
  DocumentationProvided VARCHAR(200),
  Notes VARCHAR(100),
  VerifiedStatus INTEGER
);

CREATE TABLE VaccinationSchedule (
  VaccinationScheduleId INTEGER PRIMARY KEY,
  ProfileId INTEGER FOREIGN KEY REFERENCES ChildrenProfiles(ProfileId),
  CenterId INTEGER FOREIGN KEY REFERENCES VaccineCenters(CenterId),
  OrderVaccineDetailsId INTEGER FOREIGN KEY REFERENCES OrderVaccineDetails(OrderVaccineDetailsId),
  OrderPackageDetailsId INTEGER FOREIGN KEY REFERENCES OrderPackageDetails(OrderPackageDetailsId),
  DoseNumber Integer,
  AppointmentDate DATE,
  ActualDate DATE,
  AdministeredBy VARCHAR(200),
  Status INTEGER
);

CREATE TABLE VaccineReactions (
  VaccineReactionId INTEGER PRIMARY KEY,
  VaccineScheduleId INTEGER FOREIGN KEY REFERENCES VaccinationSchedule(VaccinationScheduleId),
  Reaction VARCHAR(200),
  Severity INTEGER,
  ReactionTime INTEGER,
  ResolvedTime INTEGER
);

