DROP TABLE IF EXISTS "message";
DROP TABLE IF EXISTS "chat";
DROP TABLE IF EXISTS "user";

CREATE TABLE "user"(
	"id" SERIAL PRIMARY KEY,
	"name" VARCHAR(30) NOT NULL UNIQUE
);

CREATE TABLE "chat"(
	"id" SERIAL PRIMARY KEY,
	"name" VARCHAR(30) NOT NULL
);

CREATE TABLE "message"(
	"id" SERIAL PRIMARY KEY,
	"chat_id" INT,
	"from_id" INT,
	"from_name" VARCHAR(30),
	"message" VARCHAR(300),
	"create_date" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	FOREIGN KEY("from_id") REFERENCES "user"("id"),
	FOREIGN KEY("chat_id") REFERENCES "chat"("id")
);

INSERT INTO "user"(name) VALUES ('nacho'),('pablo'),('daiana');
INSERT INTO "chat"(name) VALUES ('prueba');
INSERT INTO "message"(chat_id, from_id, from_name, message) VALUES 
	(1,1,'nacho','hola don pepito'),
	(1,2,'pablo','hola don jose'),
	(1,1,'nacho','paso usted ya por casa?'),
	(1,2,'pablo','por su casa ya pase!'),
	(1,1,'nacho','vio usted a mi abuela?'),
	(1,3,'daiana','a su abuela yo la vi!');