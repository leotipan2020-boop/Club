
# Grupo 3 – Relación uno a muchos: Club y Jugador

## Descripción del proyecto

Este proyecto consiste en una aplicación web que permite administrar clubes de fútbol y sus jugadores.

La aplicación permite registrar, consultar, editar y eliminar clubes y jugadores mediante operaciones CRUD.

Se implementó una relación uno a muchos (1:N), donde un club puede tener varios jugadores, pero cada jugador pertenece a un solo club.

## Integrantes y aportes

- **Leonardo:** Creación del proyecto, CRUD de Club y Jugador, validaciones, tres migraciones, relación entre entidades y corrección del formulario.
- **Fabricio:** Mostrar los jugadores en el detalle de cada club y corregir la etiqueta Ciudad.
- **Melissa:** Pruebas en otra computadora, capturas de SSMS y elaboración del diagrama de entidades.
- **Nicolas:** Elaboración del README.md con la descripción, integrantes y pasos de ejecución.
- **Josep:** Video de demostración y elaboración del PDF de entrega.

## Tecnologías utilizadas

- ASP.NET Core MVC con .NET 10.
- Entity Framework Core.
- SQL Server Express.
- Visual Studio 2026.
- SQL Server Management Studio (SSMS).
- Git y GitHub.

## Relación entre las entidades

El proyecto utiliza dos entidades:

### Club

- **Id:** Identificador del club.
- **Nombre:** Nombre del club.
- **Ciudad:** Ciudad del club (opcional).

### Jugador

- **Id:** Identificador del jugador.
- **Nombre:** Nombre del jugador.
- **Posicion:** Posición en la que juega.
- **Dorsal:** Número de camiseta.
- **ClubId:** Clave foránea que identifica al club.

La relación es de uno a muchos (1:N). Cada club puede tener varios jugadores y cada jugador pertenece a un único club.

## Pasos para ejecutar el proyecto

1. Clonar el repositorio desde GitHub.
2. Abrir Visual Studio 2026.
3. Abrir la solución `ClubesApp/ClubesApp.slnx`.
4. Verificar que SQL Server Express esté instalado.
5. Revisar la cadena de conexión en `ClubesApp/appsettings.json`.
6. Comprobar que el servidor corresponda a `localhost\SQLEXPRESS`.
7. Abrir la Consola del Administrador de paquetes NuGet.
8. Seleccionar `ClubesApp` como proyecto predeterminado.
9. Ejecutar el siguiente comando:

   `Update-Database`

10. Presionar F5 para ejecutar la aplicación.
11. Comprobar el funcionamiento de los formularios de Clubes y Jugadores.

## Migraciones del proyecto

El proyecto cuenta con tres migraciones:

1. **InitialCreate:** Creación inicial de la base de datos.
2. **ValidacionesJugador:** Aplicación de cambios en las columnas del jugador.
3. **AgregarClub:** Incorporación de la entidad Club y su relación con Jugador.

Estas migraciones permiten actualizar la estructura de la base de datos utilizando Entity Framework Core.

## Funcionalidades principales

- Registrar, consultar, editar y eliminar clubes.
- Registrar, consultar, editar y eliminar jugadores.
- Seleccionar el club desde una lista desplegable.
- Validar los datos ingresados con mensajes en español.
- Mostrar el nombre del club al consultar los jugadores.
- Consultar los jugadores que pertenecen a un club.

## Repositorio del proyecto

https://github.com/leotipan2020-boop/Club


