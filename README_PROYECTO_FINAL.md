# Proyecto final: Sistema de Mantenimiento

## Requisitos implementados

El proyecto final completa el proyecto anterior con un menú propio desarrollado en HTML y CSS, un login con autenticación por cookies de ASP.NET MVC y un CRUD para las seis tablas mediante procedimientos almacenados de SQL Server.

| Requisito | Implementación |
|---|---|
| Menú HTML/CSS | `Views/Shared/_Layout.cshtml` contiene la navegación semántica y `Content/Site.css` contiene el diseño responsive. |
| Login | `CuentaController`, `CuentaLogica`, `LoginViewModel` y `Views/Cuenta/Login.cshtml`. |
| Protección | Los controladores de Usuarios, Equipos, Técnicos, Reparaciones, Detalles y Asignaciones usan `[Authorize]`. |
| Procedimientos almacenados | `Database/SistemaMantenimiento.sql` contiene procedimientos para listar, obtener, guardar, editar y eliminar los registros. |
| CRUD completo | Las seis áreas tienen vistas `Index`, `Crear` y `Editar`, además de eliminación mediante formulario `POST`. |

## Instalación paso a paso

Primero abre SQL Server Management Studio y ejecuta `Database/SistemaMantenimiento.sql`. El script crea la base `SistemaMantenimiento`, las seis tablas, las claves foráneas, 31 procedimientos almacenados y un usuario inicial de prueba.

Después abre `Proyecto N2.slnx` o el proyecto web en Visual Studio. En `Proyecto N2/Web.config`, cambia el valor de `Server` de la cadena `ConexionBD` para que coincida con tu instancia de SQL Server. Por ejemplo, puede ser `localhost`, `localhost\\SQLEXPRESS` o el nombre de tu equipo con `\\SQLEXPRESS`.

Finalmente restaura los paquetes NuGet, inicia el proyecto con IIS Express y entra a `Cuenta/Login`. El acceso de prueba es el siguiente:

| Campo | Valor |
|---|---|
| Correo | `admin@sistema.local` |
| Contraseña | `123456` |

Tras iniciar sesión se puede navegar por Usuarios, Equipos, Técnicos, Reparaciones, Detalles y Asignaciones. Los formularios de relaciones utilizan selectores para escoger el usuario de un equipo, el equipo de una reparación, la reparación de un detalle y la reparación y técnico de una asignación.

## Orden recomendado para probar

Conviene crear primero un usuario, después un equipo asociado a ese usuario, luego una reparación asociada al equipo, un detalle para la reparación y finalmente una asignación seleccionando la reparación y un técnico. También se debe comprobar que cada pantalla permita crear, listar, editar y eliminar, respetando las claves foráneas.

## Nota de compilación

La revisión estática confirmó que los archivos XML son válidos, que el `.csproj` registra los archivos nuevos, que existen las seis áreas CRUD protegidas y que cada capa lógica llama a procedimientos almacenados. La compilación y la conexión real deben verificarse en Visual Studio sobre Windows con SQL Server disponible, porque ASP.NET MVC 5 usa .NET Framework 4.7.2.
