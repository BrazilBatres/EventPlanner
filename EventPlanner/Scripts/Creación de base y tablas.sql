CREATE SCHEMA event_planner DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;
USE event_planner;
CREATE TABLE usuario (
	id INTEGER PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(255) NOT NULL,
    contrasenia VARCHAR(255) NOT NULL,
    comprador BIT(1) NOT NULL
);

SELECT * FROM usuario

