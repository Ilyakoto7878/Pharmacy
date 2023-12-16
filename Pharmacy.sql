BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "razvlekCenter" (
	"id"	INTEGER NOT NULL UNIQUE,
	"name"	TEXT NOT NULL UNIQUE,
	"adress"	INTEGER NOT NULL UNIQUE,
	"ocenka"	INTEGER,
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "dolznostb" (
	"id"	INTEGER NOT NULL UNIQUE,
	"name"	TEXT UNIQUE,
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "uslugi" (
	"id"	INTEGER NOT NULL UNIQUE,
	"name"	TEXT UNIQUE,
	"cost"	INTEGER,
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "sotrudnik" (
	"id"	INTEGER NOT NULL UNIQUE,
	"fio"	TEXT NOT NULL,
	"nomertel"	INTEGER NOT NULL UNIQUE,
	"iddolzotb"	INTEGER NOT NULL UNIQUE,
	PRIMARY KEY("id"),
	FOREIGN KEY("iddolzotb") REFERENCES "dolznostb"("id") ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE IF NOT EXISTS "user" (
	"id"	INTEGER NOT NULL UNIQUE,
	"login"	TEXT NOT NULL UNIQUE,
	"password"	TEXT NOT NULL,
	"idrole"	INTEGER NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT),
	FOREIGN KEY("idrole") REFERENCES "role"("id") ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE IF NOT EXISTS "zakaz" (
	"id"	INTEGER NOT NULL UNIQUE,
	"data"	INTEGER NOT NULL,
	"idclienta"	INTEGER NOT NULL,
	"iduslugi"	INTEGER NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT),
	FOREIGN KEY("iduslugi") REFERENCES "uslugi"("id") ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY("idclienta") REFERENCES "client"("id") ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE IF NOT EXISTS "client" (
	"id"	INTEGER NOT NULL UNIQUE,
	"fio"	TEXT NOT NULL,
	"dataRozd"	INTEGER NOT NULL CHECK(Length("dataRozd") <= 10),
	PRIMARY KEY("id")
);
INSERT INTO "razvlekCenter" ("id","name","adress","ocenka") VALUES (1,'Moon','280589, Астраханская область, город Балашиха, шоссе Славы, 77',9);
INSERT INTO "dolznostb" ("id","name") VALUES (1,'Сотрудник'),
 (2,'Гл.Сотрудник'),
 (3,'Менеджер'),
 (4,'Гл.Менеджер'),
 (5,'Директор');
INSERT INTO "uslugi" ("id","name","cost") VALUES (1,'Аnimator',1500),
 (2,'Music',250),
 (3,'Tamada',2000),
 (4,'Birthday',1500),
 (5,'Conversation sur l''âme',0);
INSERT INTO "role" ("id","name") VALUES (1,'Новичок'),
 (2,'Фаворит'),
 (3,'Воин'),
 (4,'Герой');
INSERT INTO "sotrudnik" ("id","fio","nomertel","iddolzotb") VALUES (1,'Никитин Тимур Максимович','7(910)361-75-32',1),
 (2,'Золотарева Оливия Платоновна','7(910)105-04-14',2),
 (3,'Князева Агата Романовна','7(910)549-56-58',3),
 (4,'Львов Никита Антонович','7(910)713-48-35',4),
 (5,'Попов Дмитрий Савельевич','7(910)069-50-24',5);
INSERT INTO "user" ("id","login","password","idrole") VALUES (1,'Gaz','321',1),
 (2,'Haine','4321',2),
 (3,'Ilina','0000',3);
INSERT INTO "zakaz" ("id","data","idclienta","iduslugi") VALUES (1,'10.05.2021',1,1),
 (2,'25.04.2018',2,2),
 (3,'25.04.2020',3,3);
INSERT INTO "client" ("id","fio","dataRozd") VALUES (1,'Ильина София Ильинична','03.12.2019'),
 (2,'Куликова Таисия Романовна','14.12.2019'),
 (3,'Соколов Кирилл Георгиевич','02.06.2019'),
 (4,'Иванова Ольга Родионовна','03.09.2021'),
 (5,'Игнатьев Савелий Тихонович','18.10.2018');
COMMIT;
