USE MACARRO
insert into persona values ('6897109','Cedula','Platapus','Moreno','Dela','Colore',SYSDATETIME ( ),16);
insert into USUARIO values ('lapomash@gmail.com','21232f297a57a5a743894a0e4a801fc3','Empleado','Desactivado',SYSDATETIME ( ),null,'Omelette DO FROUMAGE?','NEIN','6897109');
insert into Usuario_rol values ('lapomash@gmail.com',9);

insert into persona values ('6897110','Cedula','Deicker','Incluso','Cazone','Kok',SYSDATETIME ( ),10);
insert into USUARIO values ('isee@gmail.com','21232f297a57a5a743894a0e4a801fc3','Empleado','Desactivado',SYSDATETIME ( ),null,'Nani ?','Athemas','6897110');
insert into Usuario_rol values ('isee@gmail.com',8);

insert into persona values ('6897111','Cedula','Juana','Eone','Santander','Musiq',SYSDATETIME ( ),7);
insert into USUARIO values ('juantwothree@gmail.com','21232f297a57a5a743894a0e4a801fc3','Empleado','Desactivado',SYSDATETIME ( ),null,'Fm?','DO','6897111');
insert into Usuario_rol values ('juantwothree@gmail.com',7);

insert into persona values ('6897112','Cedula','Dancy','Chansy','Perez','Poke',SYSDATETIME ( ),14);
insert into USUARIO values ('doremi@gmail.com','21232f297a57a5a743894a0e4a801fc3','Empleado','Desactivado',SYSDATETIME ( ),null,'Poke #?','113','6897112');
insert into Usuario_rol values ('doremi@gmail.com',5);

update USUARIO set USU_contrasena='21232f297a57a5a743894a0e4a801fc3';