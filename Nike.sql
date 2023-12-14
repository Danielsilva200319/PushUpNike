CREATE DATABASE Nike;
USE Nike;

CREATE TABLE `County` (
  `id` int PRIMARY KEY,
  `Name` varchar(50)
);

CREATE TABLE `TypeClient` (
  `id` int PRIMARY KEY,
  `TypeClient` varchar(20)
);

CREATE TABLE `Phone` (
  `id` int PRIMARY KEY,
  `Phone` varchar(20),
  `TypePhone` varchar(50)
);

CREATE TABLE `TypeProduct` (
  `id` int PRIMARY KEY,
  `TypeProduct` varchar(50),
  `Description` varchar(255)
);

CREATE TABLE `TypeOrder` (
  `id` int PRIMARY KEY,
  `TypeOrder` varchar(50)
);

CREATE TABLE `Status` (
  `id` int PRIMARY KEY,
  `EntityName` varchar(20),
  `Status` varchar(50),
  `Description` varchar(255)
);

CREATE TABLE `TypePayment` (
  `id` int PRIMARY KEY,
  `TypePayment` varchar(50)
);

CREATE TABLE `TypeShipment` (
  `id` int PRIMARY KEY,
  `TypeShipment` varchar(50)
);

CREATE TABLE `Category` (
  `id` int PRIMARY KEY,
  `Category` varchar(50),
  `Description` varchar(255)
);

CREATE TABLE `Department` (
  `id` int PRIMARY KEY,
  `Name` varchar(50),
  `idCountry` int
);

CREATE TABLE `City` (
  `id` int PRIMARY KEY,
  `Name` varchar(50),
  `idDepartment` int
);

CREATE TABLE `PostalCode` (
  `id` int PRIMARY KEY,
  `PostalCode` varchar(20),
  `idCity` int
);

CREATE TABLE `Address` (
  `id` int PRIMARY KEY,
  `Address` varchar(255),
  `idPostalCode` int,
  `idCity` int
);

CREATE TABLE `Discount` (
  `id` int PRIMARY KEY,
  `Discount` varchar(50),
  `Description` varchar(255),
  `Percentage` double(5,2),
  `StartDate` date,
  `EndDate` date,
  `idStatus` int
);

CREATE TABLE `Shipment` (
  `id` int PRIMARY KEY,
  `ShipmentDate` date,
  `EstimatedArrival` date,
  `ActualArrival` date,
  `idAddress` int,
  `idStatus` int,
  `idTypeShipment` int
);

CREATE TABLE `Client` (
  `id` int PRIMARY KEY,
  `Name` varchar(50),
  `LastName` varchar(50),
  `Email` varchar(100),
  `Gender` varchar(20),
  `Comment` varchar(255),
  `idAddress` int,
  `idPhone` int,
  `idCity` int,
  `idDiscount` int,
  `idTypeClient` int
);

CREATE TABLE `Employee` (
  `id` int PRIMARY KEY,
  `Name` varchar(50),
  `LastName` varchar(50),
  `Email` varchar(100),
  `Position` varchar(80),
  `Department` varchar(50),
  `idAddress` int,
  `idPhone` int,
  `idCity` int
);

CREATE TABLE `Product` (
  `id` int PRIMARY KEY,
  `Name` varchar(255),
  `Description` varchar(255),
  `Price` double,
  `StockQuantity` int,
  `idTypeProduct` int,
  `idCategory` int
);

CREATE TABLE `Order` (
  `id` int PRIMARY KEY,
  `OrderDate` date,
  `TotalAmount` int,
  `idClient` int,
  `idTypeOrder` int,
  `idShipment` int,
  `idPayment` int,
  `idStatus` int,
  `idProduct` int
);

CREATE TABLE `Payment` (
  `id` int PRIMARY KEY,
  `Amount` int,
  `PaymentDate` date,
  `idClient` int,
  `idTypePayment` int,
  `idStatus` int
);

ALTER TABLE `Department` ADD FOREIGN KEY (`idCountry`) REFERENCES `County` (`id`);

ALTER TABLE `City` ADD FOREIGN KEY (`idDepartment`) REFERENCES `Department` (`id`);

ALTER TABLE `Client` ADD FOREIGN KEY (`idCity`) REFERENCES `City` (`id`);

ALTER TABLE `Client` ADD FOREIGN KEY (`idAddress`) REFERENCES `Address` (`id`);

ALTER TABLE `Client` ADD FOREIGN KEY (`idPhone`) REFERENCES `Phone` (`id`);

ALTER TABLE `Client` ADD FOREIGN KEY (`idTypeClient`) REFERENCES `TypeClient` (`id`);

ALTER TABLE `Client` ADD FOREIGN KEY (`idDiscount`) REFERENCES `Discount` (`id`);

ALTER TABLE `Employee` ADD FOREIGN KEY (`idAddress`) REFERENCES `Address` (`id`);

ALTER TABLE `Employee` ADD FOREIGN KEY (`idPhone`) REFERENCES `Phone` (`id`);

ALTER TABLE `Employee` ADD FOREIGN KEY (`idCity`) REFERENCES `City` (`id`);

ALTER TABLE `Address` ADD FOREIGN KEY (`idPostalCode`) REFERENCES `PostalCode` (`id`);

ALTER TABLE `Address` ADD FOREIGN KEY (`idCity`) REFERENCES `City` (`id`);

ALTER TABLE `PostalCode` ADD FOREIGN KEY (`idCity`) REFERENCES `City` (`id`);

ALTER TABLE `Product` ADD FOREIGN KEY (`idTypeProduct`) REFERENCES `TypeProduct` (`id`);

ALTER TABLE `Product` ADD FOREIGN KEY (`idCategory`) REFERENCES `Category` (`id`);

ALTER TABLE `Order` ADD FOREIGN KEY (`idClient`) REFERENCES `Client` (`id`);

ALTER TABLE `Order` ADD FOREIGN KEY (`idTypeOrder`) REFERENCES `TypeOrder` (`id`);

ALTER TABLE `Order` ADD FOREIGN KEY (`idShipment`) REFERENCES `Shipment` (`id`);

ALTER TABLE `Order` ADD FOREIGN KEY (`idPayment`) REFERENCES `Payment` (`id`);

ALTER TABLE `Order` ADD FOREIGN KEY (`idStatus`) REFERENCES `Status` (`id`);

ALTER TABLE `Order` ADD FOREIGN KEY (`idProduct`) REFERENCES `Product` (`id`);

ALTER TABLE `Payment` ADD FOREIGN KEY (`idClient`) REFERENCES `Client` (`id`);

ALTER TABLE `Payment` ADD FOREIGN KEY (`idTypePayment`) REFERENCES `TypePayment` (`id`);

ALTER TABLE `Payment` ADD FOREIGN KEY (`idStatus`) REFERENCES `Status` (`id`);

ALTER TABLE `Shipment` ADD FOREIGN KEY (`idAddress`) REFERENCES `Address` (`id`);

ALTER TABLE `Shipment` ADD FOREIGN KEY (`idStatus`) REFERENCES `Status` (`id`);

ALTER TABLE `Shipment` ADD FOREIGN KEY (`idTypeShipment`) REFERENCES `TypeShipment` (`id`);

ALTER TABLE `Discount` ADD FOREIGN KEY (`idStatus`) REFERENCES `Status` (`id`);
