# Dimática test application
API REST con operaciones CRUD sobre entidad Duty en .Net Core 3.1

## Requerimientos
----------------------------------------
MongoDb debe estar instalado. Se usa la versión 4.4

## Instalación
----------------------------------------
Para bbdd mongo, en consola de comandos:

Se crea el path donde se almacenarán los datos, por ejemplo:
	mongod --dbpath D:\proyectos\VS2019\Dimatica\data
Se crea la bbdd:
	mongo
	use DutyDb
	db.createCollection('Duty')
Se ejecuta la API Rest desde Visual Studio. Dimatica.API como proyecto de inicio (en Visual Studio 2019).
	Se muestra el swagger de la API en: https://localhost:44325/swagger/index.html
