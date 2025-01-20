# CodificoTest
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
Backend .Net
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
- Instalar SDK de .Net en su version 8.0
- Al ejecutar la api esta correrá como servicio por la url https://localhost:7200 para observar de mejor manera añadimos a esta url /swagger/index.html para obtener
  la siguiente url https://localhost:7200/swagger/index.html en donde mediante Swagger podremos visualizar los diferentes métodos creados
- Las pruebas unitarias se realizaron con XUnit se realizan pruebas a metodos reelevates y con assets diferentes
- En el appSettings.json en el apartado del ConnectionStrings voy a reemplazar con el Servidor, Usuario de base de datos, y Password como se disponga en Codifico.
  El nombre de la base de datos se puede dejar de la misma manera que está ya que idealmente el Script se correra tal y cual como esta en la raíz del repositorio
  del Código

"ConnectionStrings": {
  "ServerDb": "Server",
  "NameDb": "StoreSample",
  "UserDb": "userdb",
  "DbPassword": "password&"
},


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
App Angular
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
- Configurar entorno con version Angular 18
- hacer el npm i y posteriormente se ejecutara con ng s -o
- La aplicación se ejecutará por el puerto 4200 ya que esto indicará que el backend conceda el permiso para consumir la Api.


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
Sql Server
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
ejecutar Script esta generado para una version de SqlServer 2019 o inferior


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
Javascript 3D
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
Este proyecto cuenta con 3 archivos Html, Javascript y hoja de estilos Css funciona con click sobre el archivo de extension html
