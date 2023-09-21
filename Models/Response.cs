using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMedicineApp.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }
    }
}


//----TABLE CODE


//CREATE TABLE Users (ID INT IDENTITY(1,1) PRIMARY KEY, FirstName VARCHAR(100), LastName VARCHAR(100),
//Password VARCHAR(100), Email VARCHAR(100), Fund DECIMAL(18, 2), Type VARCHAR(100), Status INT, CreatedOn Datetime)

//CREATE TABLE Medicines (ID INT IDENTITY(1,1) PRIMARY KEY, Name VARCHAR(100), Manufacturer VARCHAR(100), UnitPrice DECIMAL(18, 2), 
//Discount DECIMAL(18, 2), Quantity INT, ExpDate Datetime, ImageUrl VARCHAR(100), Status INT)

//CREATE TABLE CART( ID INT IDENTITY(1,1) PRIMARY KEY, UserId INT, MedicineId INT, UnitPrice Decimal(18,2),Discount Decimal(18,2),
//Quantity INT, TotalPrice Decimal(18,2))

//CREATE TABLE Orders (ID INT IDENTITY(1,1) PRIMARY KEY, UserID INT, OrderNo VARCHAR(100), OrderTotal DECIMAL(18, 2), OrderStatus VARCHAR(100))

//CREATE TABLE OrderItems (ID INT IDENTITY(1,1) PRIMARY KEY, OrderID INT, MedicineID INT, UnitPrice DECIMAL(18, 2), Discount DECIMAL(18, 2),
//Quantity INT, TotalPrice DECIMAL(18, 2))