# Correcciones realizadas en Proyecto N2

## Objetivo

Se completó la aplicación ASP.NET MVC 5 para que el sistema de mantenimiento tenga operaciones de crear, consultar, editar y eliminar para las seis tablas del diseño entregado: `Usuarios`, `Equipos`, `Tecnicos`, `Reparaciones`, `DetallesReparacion` y `Asignaciones`.

## Cambios principales

| Área | Corrección |
|---|---|
| Modelos | Se agregaron `Reparacion`, `DetalleReparacion` y `Asignacion`, y se incorporaron validaciones de datos en los seis modelos. |
| Lógica | Se implementó una clase de acceso a datos para cada tabla, con consultas parametrizadas y conexión compartida. |
| Controladores | Se agregaron seis controladores con acciones `Index`, `Crear`, `Editar` y `Eliminar`. El borrado se cambió a `POST` con token antifalsificación. |
| Vistas | Cada tabla tiene vistas `Index`, `Crear` y `Editar`, con botones de mantenimiento y mensajes de validación. |
| Relaciones | Los formularios permiten seleccionar usuarios, equipos, reparaciones y técnicos mediante listas desplegables. |
| Base de datos | Se agregó `Database/SistemaMantenimiento.sql`, con las seis tablas, claves foráneas y 24 procedimientos almacenados CRUD. |
| Configuración | Se unificaron namespaces en `Proyecto_N2`, se corrigió `Views/Web.config` y se registraron los nuevos archivos en el `.csproj`. |

## Relaciones implementadas

`Equipos.UsuarioID` referencia a `Usuarios.UsuarioID`. `Reparaciones.EquipoID` referencia a `Equipos.EquipoID`. `DetallesReparacion.ReparacionID` referencia a `Reparaciones.ReparacionID`. Finalmente, `Asignaciones` relaciona una reparación con un técnico mediante `ReparacionID` y `TecnicoID`.

## Cómo ejecutar

Primero se debe abrir `Database/SistemaMantenimiento.sql` en SQL Server Management Studio y ejecutarlo sobre una instancia de SQL Server. Después se debe revisar la cadena `ConexionBD` del archivo `Proyecto N2/Web.config` y sustituir el servidor por el nombre de la instancia disponible en el equipo donde se ejecute la aplicación.

Luego se abre `Proyecto N2.slnx` o el proyecto web desde Visual Studio, se restauran los paquetes NuGet y se ejecuta con IIS Express. La navegación principal contiene accesos a los seis mantenimientos.

## Verificación realizada

Se comprobó que el archivo `.csproj` y `Views/Web.config` son XML válidos, que todas las referencias de código agregadas están registradas, que existen las seis carpetas de vistas con sus páginas `Index`, `Crear` y `Editar`, que hay seis controladores con las acciones CRUD y que el script SQL contiene seis tablas y 24 procedimientos almacenados.

La compilación final debe realizarse en Visual Studio sobre Windows, porque el proyecto utiliza ASP.NET MVC 5 sobre .NET Framework 4.7.2 y el entorno de revisión no dispone de MSBuild ni de SQL Server para ejecutar la aplicación contra la base de datos real.
