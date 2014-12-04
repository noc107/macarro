

use MACARRO
go
begin transaction;
go
/* **************CATEGORIA************* */
INSERT INTO CATEGORIA (CAT_id, CAT_nombre) VALUES (1, 'Deporte');
INSERT INTO CATEGORIA (CAT_id, CAT_nombre) VALUES (2, 'Recreativo');
INSERT INTO CATEGORIA (CAT_id, CAT_nombre) VALUES (3, 'Familiar');
INSERT INTO CATEGORIA (CAT_id, CAT_nombre) VALUES (4, 'Infantil');

/* **************SERVICIO************* */
INSERT INTO SERVICIO (SER_id, SER_nombre, SER_descripcion, SER_cantidadDis, SER_capacidad, SER_estado, SER_costo,  SER_retiro, FK_categoria) VALUES (1, 'Tabla de Surf', 'Aférrate y disfruta de las olas del mar', 10, 1, 'Activado', 45, 'Puesto de articulos', 1);
INSERT INTO SERVICIO (SER_id, SER_nombre, SER_descripcion, SER_cantidadDis, SER_capacidad, SER_estado, SER_costo,  SER_retiro, FK_categoria) VALUES (2, 'Caña de Pesca', 'Practica tus habilidades con la pesca', 15, 1, 'Activado', 30, 'Puesto de articulos', 1);
INSERT INTO SERVICIO (SER_id, SER_nombre, SER_descripcion, SER_cantidadDis, SER_capacidad, SER_estado, SER_costo,  SER_retiro, FK_categoria) VALUES (3, 'Pelota de Voleibol', 'Juega con tus amigos sobre la arena bajo el sol de la playa', 5, 4, 'Activado', 10, 'Puesto de articulos', 1);

INSERT INTO SERVICIO (SER_id, SER_nombre, SER_descripcion, SER_cantidadDis, SER_capacidad, SER_estado, SER_costo, SER_retiro, FK_categoria) VALUES (4, 'Moto de Agua', 'Disfruta un paseo por nuestra playa junto a un acompañante y vive la mejor experiencia', 10, 2, 'Activado', 75, 'Muelles', 2);
INSERT INTO SERVICIO (SER_id, SER_nombre, SER_descripcion, SER_cantidadDis, SER_capacidad, SER_estado, SER_costo, SER_retiro, FK_categoria) VALUES (5, 'Snorkel', 'Explora nuestras aguas cristalinas', 15, 1, 'Activado', 30, 'Puesto de equipos', 2);
INSERT INTO SERVICIO (SER_id, SER_nombre, SER_descripcion, SER_cantidadDis, SER_capacidad, SER_estado, SER_costo, SER_retiro, FK_categoria) VALUES (6, 'Kayak', 'Disfruta del un paseo que te generá mucha adrenalina', 10, 2, 'Activado', 75, 'Puesto de equipos', 2);

INSERT INTO SERVICIO (SER_id, SER_nombre, SER_descripcion, SER_cantidadDis, SER_capacidad, SER_estado, SER_costo, SER_retiro, FK_categoria) VALUES (7, 'Paseo en Lancha', 'Diviértete en un atractivo paseo en lancha', 5, 4, 'Activado', 75, 'Muelles', 3);
INSERT INTO SERVICIO (SER_id, SER_nombre, SER_descripcion, SER_cantidadDis, SER_capacidad, SER_estado, SER_costo, SER_retiro, FK_categoria) VALUES (8, 'Paseo en Barco', 'Diviértete con tu familia y explora el mar', 2, 8, 'Activado', 150, 'Muelles', 3);


INSERT INTO SERVICIO (SER_id, SER_nombre, SER_descripcion, SER_cantidadDis, SER_capacidad, SER_estado, SER_costo, SER_retiro, FK_categoria) VALUES (9, 'Kit de arena para niños', 'El mejor Kit para el disfrute de los más pequeños', 25, 3, 'Activado', 20, 'Puesto de articulos', 4);
INSERT INTO SERVICIO (SER_id, SER_nombre, SER_descripcion, SER_cantidadDis, SER_capacidad, SER_estado, SER_costo, SER_retiro, FK_categoria) VALUES (10, 'Flotador infantil', 'Deja que los pequeños se bañen en el mar', 25, 1, 'Activado', 10, 'Puesto de articulos', 4);


/* **************HORARIO************* */
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (1, Convert(VARCHAR(10),'07:00 am',108), Convert(VARCHAR(10),'11:00 am',108), 1);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (2, Convert(VARCHAR(10),'02:00 pm',108), Convert(VARCHAR(10),'04:00 am',108), 1);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (3, Convert(VARCHAR(10),'07:30 am',108), Convert(VARCHAR(10),'10:30 am',108), 2);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (4, Convert(VARCHAR(10),'01:00 pm',108), Convert(VARCHAR(10),'04:00 pm',108), 2);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (5, Convert(VARCHAR(10),'08:00 am',108), Convert(VARCHAR(10),'04:00 pm',108), 3);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (6, Convert(VARCHAR(10),'07:00 am',108), Convert(VARCHAR(10),'12:00 pm',108), 4);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (7, Convert(VARCHAR(10),'02:00 pm',108), Convert(VARCHAR(10),'04:30 pm',108), 4);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (8, Convert(VARCHAR(10),'08:30 am',108), Convert(VARCHAR(10),'01:00 pm',108), 5);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (9, Convert(VARCHAR(10),'07:00 am',108), Convert(VARCHAR(10),'11:30 am',108), 6);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (10, Convert(VARCHAR(10),'02:30 pm',108), Convert(VARCHAR(10),'05:00 pm',108), 6);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (11, Convert(VARCHAR(10),'08:30 am',108), Convert(VARCHAR(10),'12:30 pm',108), 7);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (12, Convert(VARCHAR(10),'07:30 am',108), Convert(VARCHAR(10),'10:30 am',108), 8);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (13, Convert(VARCHAR(10),'07:00 am',108), Convert(VARCHAR(10),'04:00 pm',108), 9);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (14, Convert(VARCHAR(10),'07:00 am',108), Convert(VARCHAR(10),'04:00 pm',108), 10);

/* SECUENCIAS */
CREATE SEQUENCE secuenciaIdServicio
AS 
	int
	START WITH 50
	INCREMENT BY 1;
	
CREATE SEQUENCE secuenciaIdCategoria
AS 
	int
	START WITH 50
	INCREMENT BY 1;


CREATE SEQUENCE secuenciaIdHorario
AS 
	int
	START WITH 50
	INCREMENT BY 1;

	commit transaction;
	go