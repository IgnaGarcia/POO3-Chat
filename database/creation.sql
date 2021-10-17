DROP TABLE IF EXISTS "message";
DROP TABLE IF EXISTS "chat";
DROP TABLE IF EXISTS "user";

CREATE TABLE "user"(
	"id" SERIAL PRIMARY KEY,
	"name" VARCHAR[30] NOT NULL UNIQUE
);

CREATE TABLE "chat"(
	"id" SERIAL PRIMARY KEY,
	"name" VARCHAR[30] NOT NULL
);

CREATE TABLE "message"(
	"id" SERIAL PRIMARY KEY,
	"chat_id" INT,
	"from_id" INT,
	"message" VARCHAR[300],
	"create_date" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	FOREIGN KEY("from_id") REFERENCES "user"("id"),
	FOREIGN KEY("chat_id") REFERENCES "chat"("id")
);