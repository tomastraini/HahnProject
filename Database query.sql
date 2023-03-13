USE master
GO
DROP DATABASE HahnWarehouse
GO
Create database HahnWarehouse
GO
USE HahnWarehouse

CREATE TABLE person_type
(
	id int primary key identity,
	type nvarchar(60)
)

CREATE TABLE person
(
	id bigint primary key identity,
	business_name nvarchar(60),
	balance decimal,
	creation_date datetime,
	person_type int foreign key references person_type(id)
)

CREATE TABLE products
(
	id bigint primary key identity,
	description nvarchar(60),
	price decimal,
	stock decimal,
	supplier_id bigint foreign key references person(id)
)

CREATE TABLE transactions
(
	id bigint primary key identity,
	person bigint foreign key references person(id),
	transaction_began datetime,
	total decimal
)

CREATE TABLE sub_transactions
(
	id bigint primary key identity,
	transaction_id bigint foreign key references transactions(id),
	product_id bigint foreign key references products(id),
	amount decimal,
	total decimal
)

insert into person_type values
('Client'),('Suplier')

insert into person values
('Microsoft', 1000000, GETDATE(), 1),
('UBER', 3400000, GETDATE(), 1),
('SupporTech', -50000, GETDATE(), 2)

SELECT * FROM person_type

SELECT * FROM person
