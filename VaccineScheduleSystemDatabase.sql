USE master;
DROP DATABASE IF EXISTS VaccineScheduleSystem;
CREATE DATABASE VaccineScheduleSystem;
USE VaccineScheduleSystem;

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
  Email VARCHAR(200),
  ActiveStatus VARCHAR(200)
);

CREATE TABLE VaccineBatches (
  VaccineBatchId INTEGER PRIMARY KEY,
  ManufacturerId INTEGER,
  CenterId INTEGER,
  Quantity INTEGER,
  ActiveStatus VARCHAR(200),
  FOREIGN KEY (ManufacturerId) REFERENCES Manufacturers(ManufacturerId) ON DELETE CASCADE,
  FOREIGN KEY (CenterId) REFERENCES VaccineCenters(CenterId) ON DELETE CASCADE
);

CREATE TABLE VaccineCategories (
  VaccineCategoryId INTEGER PRIMARY KEY,
  ParentCategoryId INTEGER,
  CategoryName VARCHAR(200),
  Description VARCHAR(200),
  Status VARCHAR(200),
  FOREIGN KEY (ParentCategoryId) REFERENCES VaccineCategories(VaccineCategoryId) ON DELETE CASCADE
);

CREATE TABLE Vaccines (
  VaccineId INTEGER PRIMARY KEY,
  CategoryId INTEGER,
  BatchId INTEGER,
  Name VARCHAR(200),
  QuantityAvailable INTEGER,
  UnitOfVolume INTEGER,
  IngredientsDescription VARCHAR(200),
  MinAge INTEGER,
  MaxAge INTEGER,
  BetweenPeriod DATE,
  Price INTEGER,
  ProductionDate DATE,
  ExpirationDate DATE,
  FOREIGN KEY (CategoryId) REFERENCES VaccineCategories(VaccineCategoryId) ON DELETE CASCADE,
  FOREIGN KEY (BatchId) REFERENCES VaccineBatches(VaccineBatchId) ON DELETE CASCADE
);

CREATE TABLE VaccinePackages (
  VaccinePackageId INTEGER PRIMARY KEY,
  PackageName VARCHAR(200),
  PackageDescription VARCHAR(200),
  PackageStatus INTEGER
);

CREATE TABLE VaccinePackageDetails (
  Id INTEGER PRIMARY KEY,
  VaccineId INTEGER,
  VaccinePackageId INTEGER,
  PackagePrice INTEGER,
  FOREIGN KEY (VaccineId) REFERENCES Vaccines(VaccineId) ON DELETE CASCADE,
  FOREIGN KEY (VaccinePackageId) REFERENCES VaccinePackages(VaccinePackageId) ON DELETE CASCADE
);

CREATE TABLE Feedback (
  FeedbackId INTEGER PRIMARY KEY,
  Comment VARCHAR(200),
  Rating INTEGER
);

CREATE TABLE Accounts (
  AccountId INTEGER PRIMARY KEY,
  CenterId INTEGER,
  UserName VARCHAR(200),
  Password VARCHAR(200),
  PhoneNumber INTEGER,
  Email VARCHAR(200), 
  AccountRole VARCHAR(200),
  ProfileImage VARCHAR(200),
  Salary INTEGER,
  Status VARCHAR(200),
  FOREIGN KEY (CenterId) REFERENCES VaccineCenters(CenterId) ON DELETE CASCADE
);

CREATE TABLE ChildrenProfiles (
  ProfileId INTEGER PRIMARY KEY,
  AccountId INTEGER,
  ParentName VARCHAR(200),
  Name VARCHAR(200),
  Gender VARCHAR(1),
  DateOfBirth DATE,
  Allergies VARCHAR(200),
  FOREIGN KEY (AccountId) REFERENCES Accounts(AccountId) ON DELETE CASCADE
);

CREATE TABLE Orders (
  OrderId INTEGER PRIMARY KEY,
  FeedbackId INTEGER,
  ProfileId INTEGER,
  PurchaseDate DATE,
  TotalAmount INTEGER,
  TotalOrderPrice INTEGER,
  Status INTEGER,
  FOREIGN KEY (FeedbackId) REFERENCES Feedback(FeedbackId) ON DELETE CASCADE,
  FOREIGN KEY (ProfileId) REFERENCES ChildrenProfiles(ProfileId) ON DELETE CASCADE
);

CREATE TABLE Payment (
  PaymentId INTEGER PRIMARY KEY,
  OrderId INTEGER,
  PaymentName VARCHAR(200),
  PaymentMethod VARCHAR(200),
  PaymentDate INTEGER,
  PaymentStatus INTEGER,
  PayAmount INTEGER,
  FOREIGN KEY (OrderId) REFERENCES Orders(OrderId) ON DELETE CASCADE
);

CREATE TABLE OrderVaccineDetails (
  OrderVaccineDetailsId INTEGER PRIMARY KEY,
  OrderId INTEGER,
  VaccineId INTEGER,
  Quantity INTEGER,
  TotalPrice INTEGER,
  FOREIGN KEY (OrderId) REFERENCES Orders(OrderId) ON DELETE CASCADE,
  FOREIGN KEY (VaccineId) REFERENCES Vaccines(VaccineId) ON DELETE CASCADE
);

CREATE TABLE OrderPackageDetails (
  OrderPackageDetailsId INTEGER PRIMARY KEY,
  OrderId INTEGER,
  VaccinePackageId INTEGER,
  Quantity INTEGER,
  TotalPrice INTEGER,
  FOREIGN KEY (OrderId) REFERENCES Orders(OrderId) ON DELETE CASCADE,
  FOREIGN KEY (VaccinePackageId) REFERENCES VaccinePackages(VaccinePackageId) ON DELETE CASCADE
);

CREATE TABLE VaccineHistory (
  HistoryId INTEGER PRIMARY KEY,
  VaccineId INTEGER,
  ProfileId INTEGER,
  AccountId INTEGER,
  CenterId INTEGER,
  AdministeredDate DATE,
  AdministeredBy VARCHAR(200),
  DocumentationProvided VARCHAR(200),
  Notes VARCHAR(100),
  VerifiedStatus INTEGER,
  FOREIGN KEY (VaccineId) REFERENCES Vaccines(VaccineId) ON DELETE CASCADE,
  FOREIGN KEY (ProfileId) REFERENCES ChildrenProfiles(ProfileId) ON DELETE CASCADE,
  FOREIGN KEY (AccountId) REFERENCES Accounts(AccountId) ON DELETE CASCADE,
  FOREIGN KEY (CenterId) REFERENCES VaccineCenters(CenterId) ON DELETE CASCADE
);

CREATE TABLE VaccinationSchedule (
  VaccinationScheduleId INTEGER PRIMARY KEY,
  ProfileId INTEGER,
  CenterId INTEGER,
  OrderVaccineDetailsId INTEGER,
  OrderPackageDetailsId INTEGER,
  DoseNumber INTEGER,
  AppointmentDate DATE,
  ActualDate DATE,
  AdministeredBy VARCHAR(200),
  Status INTEGER,
  FOREIGN KEY (ProfileId) REFERENCES ChildrenProfiles(ProfileId) ON DELETE CASCADE,
  FOREIGN KEY (CenterId) REFERENCES VaccineCenters(CenterId) ON DELETE CASCADE,
  FOREIGN KEY (OrderVaccineDetailsId) REFERENCES OrderVaccineDetails(OrderVaccineDetailsId) ON DELETE CASCADE,
  FOREIGN KEY (OrderPackageDetailsId) REFERENCES OrderPackageDetails(OrderPackageDetailsId) ON DELETE CASCADE
);

CREATE TABLE VaccineReactions (
  VaccineReactionId INTEGER PRIMARY KEY,
  VaccineScheduleId INTEGER,
  Reaction VARCHAR(200),
  Severity INTEGER,
  ReactionTime INTEGER,
  ResolvedTime INTEGER,
  FOREIGN KEY (VaccineScheduleId) REFERENCES VaccinationSchedule(VaccinationScheduleId) ON DELETE CASCADE
);
