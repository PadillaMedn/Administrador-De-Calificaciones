/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [id]
      ,[nota]
      ,[Nombre_nota]
      ,[descripcion]
      ,[id_materia]
  FROM [Notas_Estudiantes].[dbo].[notas] 