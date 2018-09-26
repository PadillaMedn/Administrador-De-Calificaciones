create database estu

use estu
--tabla de alumnos
create table alumnos(
id int identity (1,1) primary key,
Nombre varchar (50),
Apellido varchar (50),
Edad int 
);

--para ver datos de la tabla
select * from alumnos;
--insercion de datos a la tabla alumnos
insert into alumnos(Nombre,Apellido,Edad)
       values ('Juan','Galicia',17);
insert into alumnos(Nombre,Apellido,Edad)
       values ('Marcos','Perez',16);
insert into alumnos(Nombre,Apellido,Edad)
       values ('David','Jimenez',18);
insert into alumnos(Nombre,Apellido,Edad)
       values ('Melvin','Aguilar',19);
insert into alumnos(Nombre,Apellido,Edad)
       values ('Gloria','Vega',16);
insert into alumnos(Nombre,Apellido,Edad)
       values ('Francisco','Gonzales',17);
insert into alumnos(Nombre,Apellido,Edad)
       values ('Fabiola','Zaldaña',18);
insert into alumnos(Nombre,Apellido,Edad)
       values ('Rafael','Ramirez',19);
insert into alumnos(Nombre,Apellido,Edad)
       values ('Erick','Mendoza',17);

--tabla de profesores
create table Profesores(
id int identity (1,1) primary key,
Nombre varchar (50),
Apellido varchar(50)
);

--informacion sobre profesores
select * from Profesores;
--datos de profesores
insert into Profesores(Nombre,Apellido)
       values('Marcos','Quintanilla');
insert into Profesores(Nombre,Apellido)
       values('Mabel','Moran');
insert into Profesores(Nombre,Apellido)
       values('Silvia','Munguia');
insert into Profesores(Nombre,Apellido)
       values('Marcial','Reyes');
insert into Profesores(Nombre,Apellido)
       values('Walter','Figueroa');
insert into Profesores(Nombre,Apellido)
       values('Julio','Perez');
insert into Profesores(Nombre,Apellido)
       values('Sofia','Vazques');
insert into Profesores(Nombre,Apellido)
       values('Jonatha','Hernandez');




--tabla de materias
create table Materias(
id int identity(1,1) primary key,
Nombre varchar (100),

);

--informacion de las materias
 select * from Materias
 --datos de las materias
insert into Materias(Nombre) 
        values('Ciencias');
insert into Materias(Nombre) 
        values('Matematica');
insert into Materias(Nombre) 
        values('Lenguaje');
insert into Materias(Nombre) 
        values('Habilidasdes para la vida');
insert into Materias(Nombre) 
        values('C# imtermedio');
insert into Materias(Nombre) 
        values('Data Layer');
insert into Materias(Nombre) 
        values('HTML');
insert into Materias(Nombre) 
        values('Sociales')

	
       

--tabla de notas
create table notas(
id int identity (1,1) primary key,
nota decimal (4,2),
descripcion varchar (100),
id_materia int foreign key references Materias(id),
id_alum int foreign key  references alumnos(id),
id_prof int foreign key references Profesores(id)
);


-- Presentacion de las materias 
select * from notas;
-- datos de la tabla de notas
insert into notas(nota,descripcion,id_materia,id_alum,id_prof) values(9.5,'Examen final',1,1,1);
insert into notas(nota,descripcion,id_materia,id_alum,id_prof) values(9.5,'Examen final',2,2,2);
insert into notas(nota,descripcion,id_materia,id_alum,id_prof) values(9.5,'Examen final',3,3,3);
insert into notas(nota,descripcion,id_materia,id_alum,id_prof) values(9.5,'Examen final',4,4,4);
insert into notas(nota,descripcion,id_materia,id_alum,id_prof) values(9.5,'Examen final',5,5,5);
insert into notas(nota,descripcion,id_materia,id_alum,id_prof) values(9.5,'Examen final',6,6,6);
insert into notas(nota,descripcion,id_materia,id_alum,id_prof) values(9.5,'Examen final',7,7,7);
insert into notas(nota,descripcion,id_materia,id_alum,id_prof) values(9.5,'Examen final',8,8,1);



select n.id,n.descripcion,n.nota,m.Nombre as Materia,p.Nombre as Profesor,a.Nombre as Alumno,a.Apellido as Apellido,a.Edad as Edad from notas n
inner join Materias m on n.id_materia=m.id
inner join Profesores p on p.id=n.id_prof
inner join alumnos a on a.id=n.id_alum