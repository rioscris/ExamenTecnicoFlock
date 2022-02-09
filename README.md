# ExamenTecnicoFlock
API de localizaciones geograficas

Con la presente API se pueden obtener información de una localización geográfica a partir de un identificador. Por ejemplo, y en la versión inicial, obtener las coordenadas de latitud y longitud del centroide de una provincia argentina a partir del nombre de la misma.

Para esto, se utiliza la API pública de https://apis.datos.gob.ar/georef/api/provincias. Mayor información en https://datosgobar.github.io/georef-ar-api/.

La API utiliza una Base de datos en SQL Server para el guardado y lectura de usuarios.
En su primera version, aun no valida autorización del usuario ni encripta la contraseña, estas funcionalidades deben agregarse en versiones posteriores, asi como los tests.

# Instalacion
Para utilizar la API, primero debemos clonar el repositorio a nuestro directorio local.
`git clone https://github.com/rioscris/ExamenTecnicoFlock.git`

Luego, para levantar la Base de datos debemos asegurarnos de tener SQLServer corriendo una instancia de LocalDB. Se puede seguir la guia de instalación del mismo en https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15.

Una vez hecho esto, debemos crear una Base de Datos en nuestra instancia de `(localdb)\mssqllocaldb` de nombre **GeoDB**. Se puede elegir otro nombre, pero lo importante es que sea referenciada en el archivo _appsettings.json_ dentro del proyecto GeoAPI en el parametro _Initial Catalog_ del _ConnectionString_ **GeoAPIConnection**.

Una vez que tenemos la Base de datos creada, podemos levantar el proyecto con IIS Express (tomando como referencia el proyecto GeoAPI como proyecto de inicio). Las migraciones a la Base de datos se aplicaran automaticamente, en caso de haber alguna.

# Uso de la API
Al iniciar la aplicacion, se dirigira automaticamente a la documentacion de Swagger ([localhost]/swagger/index.html) en donde podremos hacer uso y pruebas de la misma.
Cada request puede ejecutarse usando el botón **"Try it out"** de la seccion derecha de la documentacion.
## Usuarios

### Guardado
La API cuenta con guardado y lectura de usuarios en una Base de datos. Para guardar un usuario, debemos enviar una solicitud POST al controlador de Users. El mismo debe contener una estructura similar a la siguiente:

`{
  "username": "admin",
  "password": "admin"
}`

La request devuelve el usuario creado en la BD en caso de éxito (StatusCode 200).

### Lectura
La lectura de los usuarios guardados en la BD la podemos hacer con una request GET al controlador de Users. El mismo no requiere ningun parametro y se encuentra en Swagger con la direccion de _/Users_ y la descripcion de _"Retorna la lista completa de usuarios"_.

Al ejecutarla, veremos que nos devuelve un listado del tipo:

`[
  {
    "username": "admin",
    "password": "admin"
  }
]`

## Localizaciones
La API cuenta en Swagger con un endpoint para obtener las coordenadas de una provincia (centroide) a partir de un nombre, por ejemplo, "Santiago del Estero" o "Neuquen".
Para usarla, debemos buscar el controlador de Locations y enviar una solicitud completando el campo "province" con el nombre de la provincia.

Al hacer la request, la API se comunicará con la API pública de provincias y ubicaciones geográficas y veremos que obtenemos como resultado las coordenadas:

`{
  "lat": -27.7824116550944,
  "lon": -63.2523866568588
}`

# Sobre el proyecto
Este proyecto es un ejercicio práctico de .NET para la empresa AccionaIT y la software factory Flock para la aplicación laboral.

Cualquier contacto se puede hacer al mail mrioscristian@gmail.com

¡Gracias!
