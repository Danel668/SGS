
-- �������� ������� City
CREATE TABLE City (
  id INT PRIMARY KEY IDENTITY,
  name VARCHAR(255)
);

-- �������� ������� Factory
CREATE TABLE Factory (
  id INT PRIMARY KEY IDENTITY,
  name VARCHAR(255),
  city_id INT,
  FOREIGN KEY (city_id) REFERENCES City(id)
);

-- �������� ������� Employee
CREATE TABLE Employee (
  id INT PRIMARY KEY IDENTITY,
  name VARCHAR(255),
  factory_id INT,
  FOREIGN KEY (factory_id) REFERENCES Factory(id)
);

-- �������� ������� Brigade
CREATE TABLE Brigade (
  id INT PRIMARY KEY IDENTITY,
  name VARCHAR(255)
);

-- �������� ������� Shift
CREATE TABLE Shift (
  id INT PRIMARY KEY IDENTITY,
  name VARCHAR(255),
);

--CREATE TABLE MyTable (
--    City VARCHAR(255),
--    Factory VARCHAR(255),
--    Employee VARCHAR(255),
--    Brigade VARCHAR(255),
--    shift VARCHAR(255),
--    PRIMARY KEY (City, Factory, Employee)
--);