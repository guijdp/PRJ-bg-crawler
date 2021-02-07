CREATE DATABASE bg_main;
GO
USE bg_main;
GO
CREATE TABLE store ( 
	store_id int NOT NULL,
	store_name varchar(255), 
	PRIMARY KEY ( store_id ));
GO
CREATE TABLE boardgame ( 
	boardgame_id int NOT NULL,
	game_name varchar(255), 
	PRIMARY KEY ( boardgame_id ));
GO
CREATE TABLE store_boardgame ( 
	store_id int FOREIGN KEY REFERENCES store(store_id), 
	boardgame_id int FOREIGN KEY REFERENCES boardgame(boardgame_id), 
	price decimal(6, 2) NOT NULL, 
	recorded_date date NOT NULL, 
	PRIMARY KEY ( recorded_date, store_id, boardgame_id ));
GO
CREATE TABLE currency (
	currency_id int NOT NULL, 
	iso_code VARCHAR(3), 
	PRIMARY KEY ( currency_id ));
GO
CREATE TABLE country (
	country_id int NOT NULL, 
	country_name varchar(30), 
	currency_id int FOREIGN KEY REFERENCES currency(currency_id),
	PRIMARY KEY ( country_id ));
GO
CREATE TABLE store_country( 
	store_id int FOREIGN KEY REFERENCES store(store_id), 
	country_id int FOREIGN KEY REFERENCES country(country_id))
GO
CREATE TABLE exchange_rate (
	from_currency int not null references currency(currency_id),
	to_currency int not null references currency(currency_id), 
	exchange_rate decimal(20, 10), 
	PRIMARY KEY (from_currency, to_currency));
GO
INSERT INTO store (store_id, store_name) VALUES (1, "FANTAZY WELT");
GO